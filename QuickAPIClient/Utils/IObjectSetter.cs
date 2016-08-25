using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Flight.Trade.TradeQuickAPI.Client.Utils
{
    public interface IObjectPropertySetter
    {
        void SetValue(PropertyInfo propertyInfo, object owner);
        void SetNullableValue(string p, Type nullableType, out object nullableObject);
        bool AllowCreateCollectionItem(PropertyInfo propertyInfo, object owner);
        uint GetCreateCollectionItemCount(PropertyInfo propertyInfo, object owner);        
    }
}
