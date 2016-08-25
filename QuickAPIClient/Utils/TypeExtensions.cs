using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Flight.Trade.TradeQuickAPI.Client.Utils
{
    public static class TypeExtensions
    {
        public static bool CanSerializer(this Type t)
        {
            return Attribute.IsDefined(t, typeof(SerializableAttribute))
                || Attribute.IsDefined(t, typeof(XmlRootAttribute))
                || t == typeof(IXmlSerializable);
        }

        public static bool IsXmlSerializer(this Type t)
        {
            return Attribute.IsDefined(t, typeof(XmlRootAttribute));
        }

        public static bool IsBuiltIn(this Type t)
        {
            return (t.IsPrimitive && t != typeof(IntPtr) && t != typeof(UIntPtr))
                  || t.IsEnum
                  || t == typeof(string)
                  || t == typeof(DateTime)
                  || t == typeof(Decimal)
                  || t == typeof(object);
        }

        public static object CreateObject(this Type t)
        {
            if (t == null)
                return null;

            object result = null;
            if (t == typeof(string))
                result = "";
            else
                result = Activator.CreateInstance(t);

            return result;
        }
    }
}
