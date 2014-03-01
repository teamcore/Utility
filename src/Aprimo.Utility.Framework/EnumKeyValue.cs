using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aprimo.Utility.Framework
{
    public class EnumKeyValue<TKey>
    {
        public EnumKeyValue(TKey key, string value)
        {
            Key = key;
            Value = value;
        }

        public TKey Key { get; private set; }
        public string Value { get; private set; }
    }
}