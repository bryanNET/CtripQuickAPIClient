using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;
using Flight.Trade.TradeQuickAPI.Client.Utils;
using Newtonsoft.Json;
using System.Xml.Serialization;
using System.Windows.Forms;

namespace Flight.Trade.TradeQuickAPI.Client.Core
{
    /// <summary>
    /// 请求助手类
    /// </summary>
    public class RequestHelper
    {
        private Dictionary<string, string> proxyEnvList = new Dictionary<string, string>();
        private Dictionary<string, string> envList = new Dictionary<string, string>();
        private Dictionary<string, string> requestTypeList = new Dictionary<string, string>();
        private Dictionary<string, Assembly> requestAssemblyList = new Dictionary<string, Assembly>();   

        public RequestHelper()
        {
            InitEnvList();

            InitRequestList();
        }

        /// <summary>
        /// 初始化环境列表
        /// </summary>
        private void InitEnvList()
        {
            envList.Add("prod", "http://tradeapi.flight.sh2.ctripcorp.com");
            envList.Add("local", "http://localhost");
            envList.Add("fws", "http://tradeapi.flight.fws.qa.nt.ctripcorp.com");
            envList.Add("uat", "http://tradeapi.flight.uat.qa.nt.ctripcorp.com");

            proxyEnvList["prod"] = "http://exchdata.ctrip.com";
            proxyEnvList["local"] = "http://localhost";
            proxyEnvList["fws"] = "http://exchdata.fws.qa.nt.ctripcorp.com";
            proxyEnvList["uat"] = "http://exchdata.uat.qa.nt.ctripcorp.com";

            //fat
            for (int i = 1; i < 99; ++i)
            {
                string env = string.Format("fat{0}", i);
                envList.Add(env, string.Format("http://tradeapi.flight.{0}.qa.nt.ctripcorp.com", env));
                proxyEnvList.Add(env, string.Format("http://exchdata.{0}.qa.nt.ctripcorp.com", env));
            }

            //lpt
            for (int i = 1; i < 10; ++i)
            {
                string env = string.Format("lpt{0}", i);
                envList.Add(env, string.Format("http://tradeapi.flight.{0}.qa.nt.ctripcorp.com", env));
                proxyEnvList.Add(env, string.Format("http://exchdata.{0}.qa.nt.ctripcorp.com", env));
            }
        }

        /// <summary>
        /// 获取环境列表
        /// </summary>
        /// <returns></returns>
        public List<string> GetEnvList(bool proxy)
        {
            if (!proxy)
            {
                return envList.Keys.ToList();
            }
            else
            {
                return proxyEnvList.Keys.ToList();
            }
        }

        /// <summary>
        /// 获取环境对应的网址
        /// </summary>
        /// <param name="env"></param>
        /// <returns></returns>
        public string GetRequestUrl(string env)
        {
            return string.Format("{0}/Flight-Product-TradeQuickAPI/api/", envList.ContainsKey(env.ToLower()) ? envList[env.ToLower()] : string.Format("http://{0}", env));
        }

        /// <summary>
        /// 获取环境对应的代理网址
        /// </summary>
        /// <param name="env"></param>
        /// <returns></returns>
        public string GetRequestProxyUrl(string env)
        {
            return string.Format("{0}/Flight-Proxy-TradeQuickAPI/api/", proxyEnvList.ContainsKey(env.ToLower()) ? proxyEnvList[env.ToLower()] : string.Format("http://{0}", env));
        }

        /// <summary>
        /// 初始化请求类型列表
        /// </summary>
        private void InitRequestList()
        {
            if (Directory.Exists("plugin"))
            {
                foreach (string f in Directory.GetFiles("plugin", "*.dll"))
                {
                    string fileName = string.Format("{0}/{1}", Directory.GetCurrentDirectory(), f);
                    Assembly ass = Assembly.LoadFile(fileName);
                    foreach (Type t in ass.GetLoadableTypes().OrderBy(p => p.Name))
                    {
                        PropertyInfo pHead = t.GetProperty("MessageHead");
                        PropertyInfo pBody = t.GetProperty("MessageBody");

                        if (pHead != null)
                        {
                            string typeName = t.Name.Remove(t.Name.Length - 11); //移除尾部RequestType    
                            if (!requestTypeList.ContainsKey(typeName))
                            {
                                requestTypeList[typeName] = t.FullName;
                                requestAssemblyList[typeName] = ass;
                            }
                        }

                    }
                }
            }
        }

        /// <summary>
        /// 获取请求类型列表
        /// </summary>
        /// <returns></returns>
        public List<string> GetRequestTypeList()
        {
            List<string> l = requestTypeList.Keys.ToList();
            l.Sort();

            return l;
        }

        /// <summary>
        /// 生成示例请求
        /// </summary>
        /// <param name="requestType"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public string GenerateRequest(string requestType, MessageFormatType format)
        {
            string result = string.Empty;

            object request = null;
            Assembly ass = requestAssemblyList[requestType];
            if (ass != null)
            {
                request = ass.CreateInstance(requestTypeList[requestType]);
                request.InitSelf(new FlightObjectPropertySetter());
            }

            if (request != null)
            {
                result = SerializeRequest(requestType, request, format);
            }

            return result;
        }

        /// <summary>
        /// 反序列化请求
        /// </summary>
        /// <param name="requestType"></param>
        /// <param name="message"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public object DeserializeRequest(out string error, string requestType, string message, MessageFormatType format)
        {
            error = null;
            object o = null;
            try
            {
                if (requestTypeList.ContainsKey(requestType))
                {
                    Type t = requestAssemblyList[requestType].GetType(requestTypeList[requestType]);
                    if (format == MessageFormatType.JSON)
                    {
                        o = JsonConvert.DeserializeObject(message, t);
                    }
                    else
                    {
                        XmlSerializer serilizer = new XmlSerializer(t);
                        using (MemoryStream ms = new MemoryStream())
                        {
                            byte[] messageBytes = Encoding.UTF8.GetBytes(message);
                            ms.Write(messageBytes, 0, messageBytes.Length);
                            ms.Position = 0;
                            o = serilizer.Deserialize(ms);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                error = string.Format("报文格式错误\n\r{0}", ex.ToString());
            }

            return o;
        }

        /// <summary>
        /// 序列化请求
        /// </summary>
        /// <param name="requestType"></param>
        /// <param name="o"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public string SerializeRequest(string requestType, object o, MessageFormatType format)
        {
            string s = string.Empty;
            if (requestTypeList.ContainsKey(requestType))
            {
                Type t = requestAssemblyList[requestType].GetType(requestTypeList[requestType]);
                if (format == MessageFormatType.JSON)
                {
                    JsonSerializerSettings settings = new JsonSerializerSettings();
                    settings.Formatting = Formatting.Indented;
                    s = JsonConvert.SerializeObject(o, t, settings);
                }
                else
                {
                    XmlSerializer serilizer = new XmlSerializer(t);                    
                    using (MemoryStream ms = new MemoryStream())
                    {
                        serilizer.Serialize(ms, o);
                        s = Encoding.UTF8.GetString(ms.ToArray());
                    }
                }
            }

            return s;
        }
    }
}
