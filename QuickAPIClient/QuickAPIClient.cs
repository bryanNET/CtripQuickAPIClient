using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Web;
using System.Net;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using System.Web.Security;
using System.Diagnostics;
using System.Security.Cryptography;
using System.IO.Compression;
using System.Reflection;
using Flight.Trade.TradeQuickAPI.Client.Core;
using System.Text.RegularExpressions;
using Ctrip.Flight.TradeCommon.Utility;

namespace Flight.Trade.TradeQuickAPI.Client
{
    public partial class QuickAPIClient : Form
    {
        private RequestHelper helper = new RequestHelper();

        private string _largeRequest = null;
        private string _largeReponse = null;
        private bool _manualInput = false;
        private readonly string _largeMessageTip = "报文太大, 不显示!(点击【保存】，可将其保存至文件)";
        private readonly int _maxMessageLength = 1024 * 1024 * 2;

        public QuickAPIClient()
        {
            Console.WriteLine("");


            InitializeComponent();

            helper.GetEnvList(chkAccessProxy.Checked).ForEach(p => cmbServer.Items.Add(p));
            cmbServer.SelectedIndex = 0;

            helper.GetRequestTypeList().ForEach(p => cmbRequestType.Items.Add(p));

            if (cmbRequestType.Items.Count > 0)
            {
                cmbRequestType.SelectedIndex = 0;
            }
        }

        private string GetMessageType()
        {
            if (rbXML.Checked) return "xml";

            if (rbJSON.Checked) return "json";

            if (rbSOAP.Checked) return "soap";

            return string.Empty;
        }

        private string RequestText
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_largeRequest))
                {
                    return Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(txtRequest.Text));
                }
                else
                {
                    return Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(_largeRequest));
                }
            }

            set
            {
                this.txtRequest.TextChanged -= new System.EventHandler(this.txtRequest_TextChanged);
                if (!string.IsNullOrWhiteSpace(value) && value.Length > _maxMessageLength)
                {
                    _largeRequest = value;
                    txtRequest.Text = _largeMessageTip;
                }
                else
                {
                    _largeRequest = null;
                    txtRequest.Text = value;
                }
                this.txtRequest.TextChanged += new System.EventHandler(this.txtRequest_TextChanged);
            }
        }

        private string ResponseText
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_largeReponse))
                {
                    return Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(txtResponse.Text));
                }
                else
                {
                    return Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(_largeReponse));
                }
            }

            set
            {
                if (!string.IsNullOrWhiteSpace(value) && value.Length > _maxMessageLength)
                {
                    _largeReponse = value;
                    txtResponse.Text = _largeMessageTip;
                }
                else
                {
                    _largeReponse = null;
                    txtResponse.Text = value;
                }
            }
        }

        private void UpdateUrl(string env, bool useAccessProxy, string messageType, string requestType)
        {
            txtRequestURL.Text = string.Format("{0}{1}/{2}", useAccessProxy ? helper.GetRequestProxyUrl(env) : helper.GetRequestUrl(env), messageType, requestType); 
        }

        private void cmbServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateUrl(cmbServer.Text, chkAccessProxy.Checked, GetMessageType(), cmbRequestType.Text);
        }

        private void cmbServer_TextChanged(object sender, EventArgs e)
        {
            UpdateUrl(cmbServer.Text, chkAccessProxy.Checked, GetMessageType(), cmbRequestType.Text);
        }

        private void chkAccessProxy_CheckedChanged(object sender, EventArgs e)
        {
            UpdateUrl(cmbServer.Text, chkAccessProxy.Checked, GetMessageType(), cmbRequestType.Text);
        }

        private void rbXML_CheckedChanged(object sender, EventArgs e)
        {
            if (!(sender as RadioButton).Checked || specifyURL.Checked)
                return;

            UpdateUrl(cmbServer.Text, chkAccessProxy.Checked, GetMessageType(), cmbRequestType.Text);

            //todo: 格式化请求文本
            if (!string.IsNullOrWhiteSpace(RequestText))
            {
                string error = null;
                object o = helper.DeserializeRequest(out error, cmbRequestType.Text, RequestText, Utils.MessageFormatType.JSON);

                if (o != null)
                {
                    RequestText = helper.SerializeRequest(cmbRequestType.Text, o, Utils.MessageFormatType.XML);
                }
                else
                {
                    ResponseText = error;
                }
            }
        }

        private void rbJSON_CheckedChanged(object sender, EventArgs e)
        {
            if (!(sender as RadioButton).Checked || specifyURL.Checked)
                return;

            UpdateUrl(cmbServer.Text, chkAccessProxy.Checked, GetMessageType(), cmbRequestType.Text);

            //todo: 格式化请求文本
            if (!string.IsNullOrWhiteSpace(RequestText))
            {
                string error = null;
                object o = helper.DeserializeRequest(out error, cmbRequestType.Text, RequestText, Utils.MessageFormatType.XML);

                if (o != null)
                {
                    RequestText = helper.SerializeRequest(cmbRequestType.Text, o, Utils.MessageFormatType.JSON);
                }
                else
                {
                    ResponseText = error;
                }
            }
        }

        private string LoadContenFormFile(string file)
        {
            string result = string.Empty;

            if (!string.IsNullOrWhiteSpace(file))
            {
                try
                {
                    FileStream fs = new FileStream(file, FileMode.Open);
                    using (MemoryStream ms = new MemoryStream((int)fs.Length))
                    {
                        fs.CopyTo(ms);
                        fs.Close();

                        int position = 0;
                        byte[] buffer = ms.ToArray();
                        if (buffer.Length >= 3 && buffer[0] == 239 && buffer[1] == 187 && buffer[2] == 191)
                        {   // UTF8文件
                            position = 3;
                        }

                        result = Encoding.UTF8.GetString(ms.ToArray(), position, (int)ms.Length - position);
                    }
                }
                catch (Exception ex)
                {
                    result = ex.Message;
                }
            }

            return result;
        }

        private void StoreContentToFile(string content, string file)
        {
            if (string.IsNullOrWhiteSpace(content) || string.IsNullOrWhiteSpace(file))
                return;

            FileStream fs = new FileStream(file, FileMode.Create);
            using (MemoryStream ms = new MemoryStream())
            {
                byte[] buffer = Encoding.UTF8.GetBytes(content);
                ms.Write(buffer, 0, buffer.Length);

                ms.Position = 0;
                ms.CopyTo(fs);
                fs.Close();
            }
        }

        private void cmbRequestType_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtResponse.Clear();
            UpdateUrl(cmbServer.Text, chkAccessProxy.Checked, GetMessageType(), cmbRequestType.Text);

            //todo: 如果加载示例请求勾选，查找Request目录，加载对应的示例
            if (chkLoadRequestSample.Checked)
            {
                RequestText = string.Empty;
                //txtRequest.Clear();
                
                if (Directory.Exists("Request"))
                {
                    string[] files = Directory.GetFiles("Request", string.Format("{0}*.*", cmbRequestType.Text));
                    string file = string.Empty;
                    if (files != null)
                    {
                        file = files.FirstOrDefault(p => Regex.IsMatch(p, string.Format("{0}(Request(Type)?)?_{1}", cmbRequestType.Text, GetMessageType()), RegexOptions.IgnoreCase));
                    }

                    RequestText = LoadContenFormFile(file);
                }
            }
        }

        private void btnGenerateRequest_Click(object sender, EventArgs e)
        {
            RequestText = helper.GenerateRequest(cmbRequestType.Text, rbJSON.Checked ? Utils.MessageFormatType.JSON : Utils.MessageFormatType.XML);
        }

        private string ReplaceUser(Match m)
        {
            string oldString = m.ToString();
            return string.Format("<UserName>{0}</UserName>", txtUserName.Text);
        }

        private string ReplacePassword(Match m)
        {
            string oldString = m.ToString();
            string password = FormsAuthentication.HashPasswordForStoringInConfigFile(string.Format("{0}#{1}", txtUserName.Text, txtPassword.Text), "MD5");
            //string password = MD5Helper.GetMD5(Encoding.UTF8.GetBytes(string.Format("{0}#{1}", txtUserName.Text, txtPassword.Text)));
            return string.Format("<Password>{0}</Password>", password);
        }

        private string ReplaceGUID(Match m)
        {
            return string.Format("<RequestGUID xmlns=\"urn:ctrip:api:flight:trade:common:baseType:v1\">{0}</RequestGUID>", Guid.NewGuid().ToString());
        }

        private void btnSendRequest_Click(object sender, EventArgs e)
        {
            //todo: 简单的有效性校验
            if (string.IsNullOrWhiteSpace(cmbServer.Text)
                || string.IsNullOrWhiteSpace(txtUserName.Text)
                || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                return;
            }

            if (_manualInput)
            {
                _manualInput = false;
                RequestText = txtRequest.Text;
            }

            //todo: 如果校验请求，反序列化并重新序列化请求到合法请求
            if (chkValidateRequest.Checked && !specifyURL.Checked)
            {
                string error = null;
                object o = helper.DeserializeRequest(out error, cmbRequestType.Text, RequestText, rbJSON.Checked ? Utils.MessageFormatType.JSON : Utils.MessageFormatType.XML);

                if (o != null)
                {
                    RequestText = helper.SerializeRequest(cmbRequestType.Text, o, rbJSON.Checked ? Utils.MessageFormatType.JSON : Utils.MessageFormatType.XML);
                }
                else
                {
                    ResponseText = error;
                    return;
                }
            }

            if (rbXML.Checked)
            {
                if (checkMD5.Checked)
                {
                    RequestText = Regex.Replace(RequestText, @"(\<UserName\>[^\<]+\<\/UserName\>)|(\<UserName[ ]+/\>)", new MatchEvaluator(ReplaceUser));

                    RequestText = Regex.Replace(RequestText, "(\\<Password\\>[^\\<]+\\<\\/Password\\>)|(\\<Password[ ]+/\\>)", new MatchEvaluator(ReplacePassword));
                }

                if (checkGUID.Checked)
                {
                    RequestText = Regex.Replace(RequestText, "(\\<RequestGUID xmlns=\"urn:ctrip:api:flight:trade:common:baseType:v1\"\\>[^\\<]+\\<\\/RequestGUID\\>)|(\\<RequestGUID xmlns=\"urn:ctrip:api:flight:trade:common:baseType:v1\"[ ]+/\\>)", new MatchEvaluator(ReplaceGUID));
                }
            }

            ResponseText = RequestPost(txtRequestURL.Text, RequestText);
        }

        /// <summary>
        /// 返回经过格式化处理的xml文档
        /// </summary>
        /// <param name="result">请求文本</param>
        /// <returns></returns>
        private string GetFormatXml(string result)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(result);
            if (doc != null)
            {
                MemoryStream mstream = null;
                XmlTextWriter writer = null;
                try
                {
                    mstream = new MemoryStream(1024 * 1024 * 10);
                    writer = new XmlTextWriter(mstream, null);
                    writer.Formatting = System.Xml.Formatting.Indented;
                    doc.WriteTo(writer);
                    writer.Flush();
                    writer.Close();

                    Encoding encoding = Encoding.GetEncoding("utf-8");
                    result = encoding.GetString(mstream.ToArray());
                    mstream.Close();
                }
                catch
                {
                    // 只能实现换行
                    result = doc.OuterXml.Replace(">\r\n", ">").Replace(">", ">\r\n");
                }
                finally
                {
                    if (writer != null)
                    {
                        writer.Close();
                    }
                    if (mstream != null)
                    {
                        mstream.Close();
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 提交请求报文，获得响应报文
        /// </summary>
        /// <param name="Url">url地址</param>
        /// <param name="Context">请求报文</param>
        /// <returns></returns>
        private string RequestPost(string Url, string Context)
        {
            Stopwatch watcher = new Stopwatch();

            string PageStr = string.Empty;
            Uri url = new Uri(Url);

            byte[] reqbytes = Encoding.UTF8.GetBytes(Context);

            Stream requestStream = null;
            Stream responseStream = null;
            StreamReader srd = null;
            HttpWebResponse resp = null;
            try
            {
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                req.Timeout = 300000;   // 5分钟超时
                req.Method = "POST";

                #region gzip
                if (checkGZip.Checked)
                {
                    using (MemoryStream gzipStream = Gzip.Compress(reqbytes))
                    {
                        reqbytes = gzipStream.ToArray();
                    }

                    req.Headers.Add("Content-Encoding", "gzip");
                }
                #endregion


                // 分别以xml、json、soap格式提交请求
                if (rbXML.Checked)
                {
                    req.Accept = "application/xml, */*";
                    req.ContentType = "application/xml";
                }
                else if (rbJSON.Checked)
                {
                    req.Accept = "application/json, */*";
                    req.ContentType = "application/json";
                }
                else if (rbSOAP.Checked)
                {
                    req.Accept = "application/xml, */*";
                    req.ContentType = "text/xml";
                }

                req.ContentLength = reqbytes.Length;
                requestStream = req.GetRequestStream();

                watcher.Start();

                requestStream.Write(reqbytes, 0, reqbytes.Length);
                requestStream.Close();

                resp = (HttpWebResponse)req.GetResponse();

                watcher.Stop();

                this.lblTimeConsuming.Text = "耗时：" + watcher.ElapsedMilliseconds.ToString() + "ms";

                responseStream = resp.GetResponseStream();

                if (resp.ContentEncoding.ToLower().Contains("gzip"))
                {
                    responseStream = new GZipStream(responseStream, CompressionMode.Decompress);
                }

                srd = new StreamReader(responseStream, Encoding.UTF8);
                PageStr += srd.ReadToEnd();

                // xml格式响应显示成良好的xml格式
                if (rbXML.Checked)
                {
                    PageStr = GetFormatXml(PageStr);
                }
                // soap格式响应结果换行显示
                if (rbSOAP.Checked)
                {
                    PageStr = PageStr.Replace(">\r\n", ">").Replace(">", ">\r\n");
                }
                //req.KeepAlive = false;
                responseStream.Close();
                srd.Close();
                resp.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (requestStream != null)
                {
                    requestStream.Close();
                }
                if (responseStream != null)
                {
                    responseStream.Close();
                }
                if (resp != null)
                {
                    resp.Close();
                }
                if (srd != null)
                {
                    srd.Close();
                }
            }
            return PageStr;
        }

        private void btnOpenRequest_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = string.Format("{0}/history", Directory.GetCurrentDirectory());
            dialog.Title = "打开历史请求报文";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                RequestText = LoadContenFormFile(dialog.FileName);
            }
        }

        private void btnSaveRequest_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.InitialDirectory = string.Format("{0}/history", Directory.GetCurrentDirectory());
            dialog.Title = "保存历史请求报文";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                StoreContentToFile(RequestText, dialog.FileName);
            }
        }

        private void btnSaveResponse_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.InitialDirectory = string.Format("{0}/history", Directory.GetCurrentDirectory());
            dialog.Title = "保存历史响应报文";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                StoreContentToFile(ResponseText, dialog.FileName);
            }
        }

        private void txtRequest_TextChanged(object sender, EventArgs e)
        {
            _manualInput = true;
        }

        private void specifyURL_CheckedChanged(object sender, EventArgs e)
        {
            if (specifyURL.Checked)
            {
                txtRequestURL.ReadOnly = false;

                cmbServer.Enabled = false;
                chkAccessProxy.Enabled = false;
                cmbRequestType.Enabled = false;
                chkLoadRequestSample.Enabled = false;
                chkValidateRequest.Enabled = false;
            }
            else
            {
                txtRequestURL.ReadOnly = true;

                cmbServer.Enabled = true;
                chkAccessProxy.Enabled = true;
                cmbRequestType.Enabled = true;
                chkLoadRequestSample.Enabled = true;
                chkValidateRequest.Enabled = true;
            }
        }
    }
}
