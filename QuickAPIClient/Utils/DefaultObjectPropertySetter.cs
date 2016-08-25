using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flight.Trade.TradeQuickAPI.Client.Utils
{
    public class DefaultObjectPropertySetter : IObjectPropertySetter
    {
        protected int randomIndex = new Random().Next(1, short.MaxValue);
        protected virtual void SetIntValue(System.Reflection.PropertyInfo propertyInfo, object owner)
        {
            propertyInfo.SetValue(owner, (byte)0, null);
        }

        protected virtual void SetStringValue(System.Reflection.PropertyInfo propertyInfo, object owner)
        {
            propertyInfo.SetValue(owner, "", null);
        }

        protected virtual void SetDoubleValue(System.Reflection.PropertyInfo propertyInfo, object owner)
        {
            int value1 = new Random(randomIndex++).Next(0, 9999);
            double value2 = new Random(randomIndex++).NextDouble();
            propertyInfo.SetValue(owner, (float)value1 * value2, null);
        }

        protected virtual void SetDecimalValue(System.Reflection.PropertyInfo propertyInfo, object owner)
        {
            int value = new Random(randomIndex++).Next(0, 9999);
            propertyInfo.SetValue(owner, (decimal)value, null);
        }

        protected virtual void SetDateTimeValue(System.Reflection.PropertyInfo propertyInfo, object owner)
        {
            propertyInfo.SetValue(owner, DateTime.Now, null);
        }

        protected virtual void SetBoolValue(System.Reflection.PropertyInfo propertyInfo, object owner)
        {
            bool[] values = new bool[2] { true, false };
            int pos = new Random(randomIndex++).Next(0, 2);
            propertyInfo.SetValue(owner, values[pos], null);
        }

        protected virtual void SetNullableIntValue(string p, Type nullableType, out object nullableObject)
        {
            int value = new Random(randomIndex++).Next(0, 127);
            nullableObject = Convert.ChangeType(value, nullableType);//nullableType == typeof(Byte) || nullableType == typeof(SByte) ? (sbyte)value : (int)value;
        }

        protected virtual void SetNullableDoubleValue(string p, Type nullableType, out object nullableObject)
        {
            int value1 = new Random(randomIndex++).Next(0, 9999);
            double value2 = new Random(randomIndex++).NextDouble();
            nullableObject = (float)value1 * value2;
        }

        protected virtual void SetNullableDecimalValue(string p, Type nullableType, out object nullableObject)
        {
            int value = new Random(randomIndex++).Next(0, 9999);
            nullableObject = (decimal)value;
        }

        protected virtual void SetNullableBoolValue(string p, Type nullableType, out object nullableObject)
        {
            bool[] values = new bool[2] { true, false };
            int pos = new Random(randomIndex++).Next(0, 2);
            nullableObject = values[pos];
        }

        protected virtual void SetNullableDateTimeValue(string p, Type nullableType, out object nullableObject)
        {
            nullableObject = DateTime.Now;
        }

        public void SetValue(System.Reflection.PropertyInfo propertyInfo, object owner)
        {
            try
            {
                if (propertyInfo.PropertyType == typeof(string))
                {
                    SetStringValue(propertyInfo, owner);
                }
                else if (propertyInfo.PropertyType == typeof(byte)
                    || propertyInfo.PropertyType == typeof(sbyte)
                    || propertyInfo.PropertyType == typeof(short)
                    || propertyInfo.PropertyType == typeof(ushort)
                    || propertyInfo.PropertyType == typeof(int)
                    || propertyInfo.PropertyType == typeof(uint)
                    || propertyInfo.PropertyType == typeof(long)
                    || propertyInfo.PropertyType == typeof(ulong))
                {
                    SetIntValue(propertyInfo, owner);
                }
                else if (propertyInfo.PropertyType == typeof(float) || propertyInfo.PropertyType == typeof(double))
                {
                    SetDoubleValue(propertyInfo, owner);
                }
                else if (propertyInfo.PropertyType == typeof(bool))
                {
                    SetBoolValue(propertyInfo, owner);
                }
                else if (propertyInfo.PropertyType.IsEnum)
                {
                    object o = propertyInfo.PropertyType.CreateObject();
                    propertyInfo.SetValue(owner, o, null);
                }
                else if (propertyInfo.PropertyType == typeof(DateTime))
                {
                    SetDateTimeValue(propertyInfo, owner);
                }
            }
            catch (Exception ex)
            {
                //ignore it
            }
        }

        public void SetNullableValue(string p, Type nullableType, out object nullableObject)
        {
            nullableObject = null;            

            try
            {
                bool[] values = new bool[2] { true, false };
                int pos = new Random(randomIndex++).Next(0, 2);
                if (values[pos])
                {
                    if (nullableType == typeof(byte)
                        || nullableType == typeof(sbyte)
                        || nullableType == typeof(short)
                        || nullableType == typeof(ushort)
                        || nullableType == typeof(int)
                        || nullableType == typeof(uint)
                        || nullableType == typeof(long)
                        || nullableType == typeof(ulong))
                    {
                        SetNullableIntValue(p, nullableType, out nullableObject);
                    }
                    else if (nullableType == typeof(float) || nullableType == typeof(double))
                    {
                        SetNullableDoubleValue(p, nullableType, out nullableObject);
                    }
                    else if (nullableType == typeof(bool))
                    {
                        SetNullableBoolValue(p, nullableType, out nullableObject);
                    }
                    else if (nullableType.IsEnum)
                    {
                        nullableObject = nullableType.CreateObject();
                    }
                    else if (nullableType == typeof(DateTime))
                    {
                        SetNullableDateTimeValue(p, nullableType, out nullableObject);
                    }
                }
            }
            catch (Exception ex)
            {
                //ignore it
            }
        }

        public bool AllowCreateCollectionItem(System.Reflection.PropertyInfo propertyInfo, object owner)
        {
            bool[] values = new bool[2] { true, false };
            int pos = new Random(randomIndex++).Next(0, 2);
            return values[pos];
        }

        public uint GetCreateCollectionItemCount(System.Reflection.PropertyInfo propertyInfo, object owner)
        {
            return (uint)new Random(randomIndex++).Next(0, 5);
        }
    }
}
