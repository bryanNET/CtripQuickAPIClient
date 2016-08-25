using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Collections;

namespace Flight.Trade.TradeQuickAPI.Client.Utils
{
    public static class ObjectExtension
    {
        public static void SetValue(this object o, string value)
        {
            if (!o.GetType().IsEnum)
            {
                o = Convert.ChangeType(value, o.GetType());
            }
            else
            {
                foreach (FieldInfo fi in o.GetType().GetFields())
                {
                    if (fi.Name.Equals(value))
                    {
                        o = fi.GetValue(null);
                        break;
                    }
                }
            }
        }

        public static void InitSelf(this object o, IObjectPropertySetter setter = null)
        {
            Type t = o.GetType();

            if (t != typeof(object))
            {
                foreach (PropertyInfo info in t.GetProperties(BindingFlags.Public | BindingFlags.Instance))
                {
                    if (info.CanWrite && info.GetIndexParameters().Length == 0)
                    {
                        if (setter != null)
                        {
                            if (info.PropertyType.IsBuiltIn())
                            {
                                setter.SetValue(info, o);
                            }
                            else if (info.PropertyType.IsGenericType && info.PropertyType.Name == "Nullable`1")
                            {
                                Type nullableType = info.PropertyType.GetGenericArguments()[0];
                                object nullableObject = null;
                                setter.SetNullableValue(info.Name, nullableType, out nullableObject);

                                info.SetValue(o, nullableObject, null);
                            }
                            else
                            {
                                object propertyObj = info.PropertyType.CreateObject();
                                if (propertyObj != null)
                                {
                                    if (typeof(ICollection).IsAssignableFrom(info.PropertyType))
                                    {
                                        if (setter.AllowCreateCollectionItem(info, o))
                                        {
                                            uint collectionItemCount = setter.GetCreateCollectionItemCount(info, o);
                                            MethodInfo addMethod = null;
                                            Type itemType = null;
                                            foreach (MethodInfo methodInfo in info.PropertyType.GetMethods())
                                            {
                                                ParameterInfo[] parameters = methodInfo.GetParameters();
                                                if (methodInfo.Name == "Add" && parameters.Length == 1)
                                                {
                                                    addMethod = methodInfo;
                                                    itemType = parameters[0].ParameterType;

                                                    break;
                                                }
                                            }

                                            for (int i = 0; i < collectionItemCount; ++i)
                                            {
                                                object parameterObj = itemType.CreateObject();
                                                if (parameterObj != null)
                                                    parameterObj.InitSelf(setter);

                                                addMethod.Invoke(propertyObj, new object[] { parameterObj });

                                                info.SetValue(o, propertyObj, null);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        propertyObj.InitSelf(setter);
                                        info.SetValue(o, propertyObj, null);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
