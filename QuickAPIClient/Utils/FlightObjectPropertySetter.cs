using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Flight.Trade.TradeQuickAPI.Client.Utils
{
    public class FlightObjectPropertySetter : DefaultObjectPropertySetter
    {
        protected override void SetStringValue(System.Reflection.PropertyInfo propertyInfo, object owner)
        {
            if (Regex.IsMatch(propertyInfo.Name, "(A(rr((i)?v(e)?)?)?port)|(D(epart)?port)", RegexOptions.IgnoreCase))
            {
                string[] ports = new string[] { "PEK", "SHA", "XIY", "SZX", "HGH", "CTU", "XNN", "TSN", "TXN", "TAO", "KWL", "DLC" };
                int pos = new Random(randomIndex++).Next(1, ports.Length);
                propertyInfo.SetValue(owner, ports[pos], null);

                return;
            }
            
            if (Regex.IsMatch(propertyInfo.Name, "(A(rr((i)?v(e)?)?)?city)|(D(epart)?city)", RegexOptions.IgnoreCase))
            {
                string[] cities = new string[] { "BJS", "SHA", "CAN", "SZX", "HGH", "TAO", "TSN", "TXN", "NGB", "KWL", "DLC" };
                int pos = new Random(randomIndex++).Next(1, cities.Length);
                propertyInfo.SetValue(owner, cities[pos], null);

                return;
            }
            
            if (Regex.IsMatch(propertyInfo.Name, "Airline", RegexOptions.IgnoreCase))
            {
                string[] airlines = new string[] { "CA", "MU", "CZ", "3U", "HU", "FM", "HO" };
                int pos = new Random(randomIndex++).Next(1, airlines.Length);
                propertyInfo.SetValue(owner, airlines[pos], null);

                return;
            }
            
            if (Regex.IsMatch(propertyInfo.Name, "(Sub|Booking)Class", RegexOptions.IgnoreCase))
            {
                string character = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                int pos = new Random(randomIndex++).Next(1, character.Length);
                propertyInfo.SetValue(owner, string.Format("{0}", character[pos]), null);

                return;
            }
            
            if (propertyInfo.Name.Equals("Days", StringComparison.OrdinalIgnoreCase))
            {                
                propertyInfo.SetValue(owner, "1234567", null);
                return;
            }

            base.SetStringValue(propertyInfo, owner);
        }

        protected override void SetIntValue(System.Reflection.PropertyInfo propertyInfo, object owner)
        {
            if (propertyInfo.Name.Equals("ClientID", StringComparison.OrdinalIgnoreCase))
            {
                int value = new Random(randomIndex++).Next(1, 7);
                propertyInfo.SetValue(owner, (byte)value, null);
                return;
            }

            if (propertyInfo.Name.Equals("Advreserve", StringComparison.OrdinalIgnoreCase) || propertyInfo.Name.Equals("MinAdvanceDay", StringComparison.OrdinalIgnoreCase))
            {
                propertyInfo.SetValue(owner, (byte)0, null);
                return;
            }

            if (propertyInfo.Name.Equals("MaxAdvanceDay", StringComparison.OrdinalIgnoreCase))
            {
                propertyInfo.SetValue(owner, (short)365, null);
                return;
            }

            base.SetIntValue(propertyInfo, owner);
        }

        protected override void SetDateTimeValue(System.Reflection.PropertyInfo propertyInfo, object owner)
        {
            if (Regex.IsMatch(propertyInfo.Name, "EffectDate", RegexOptions.IgnoreCase))
            {
                propertyInfo.SetValue(owner, DateTime.Now, null);
                return;
            }
            
            if (Regex.IsMatch(propertyInfo.Name, "ExpiryDate", RegexOptions.IgnoreCase))
            {
                propertyInfo.SetValue(owner, DateTime.Now.AddDays(1.0), null);
                return;
            }

            base.SetDateTimeValue(propertyInfo, owner);
        }

        protected override void SetNullableIntValue(string p, Type nullableType, out object nullableObject)
        {
            if (p.Equals("ClientID", StringComparison.OrdinalIgnoreCase))
            {
                int value = new Random(randomIndex++).Next(1, 7);
                nullableObject = Convert.ChangeType(value, nullableType);
                return;
            }

            if (p.Equals("Advreserve", StringComparison.OrdinalIgnoreCase) || p.Equals("MinAdvanceDay", StringComparison.OrdinalIgnoreCase))
            {
                nullableObject = Convert.ChangeType(0, nullableType);
                return;
            }

            if (p.Equals("MaxAdvanceDay", StringComparison.OrdinalIgnoreCase))
            {
                nullableObject = Convert.ChangeType(365, nullableType);
                return;
            }

            base.SetNullableIntValue(p, nullableType, out nullableObject);
        }

        protected override void  SetNullableDateTimeValue(string p, Type nullableType, out object nullableObject)
        {
            if (Regex.IsMatch(p, "EffectDate", RegexOptions.IgnoreCase))
            {
                nullableObject = DateTime.Now;
                return;
            }
            
            if (Regex.IsMatch(p, "ExpiryDate", RegexOptions.IgnoreCase))
            {
                nullableObject = DateTime.Now.AddDays(1.0);
                return;
            }

 	        base.SetNullableDateTimeValue(p, nullableType, out nullableObject);
        }        
    }
}
