using MultiMarket.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace MultiMarket.Libraries.Json
{
    public class UndoJsonIgnore<T> : DefaultContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var property = base.CreateProperty(member, memberSerialization);
            property.Ignored = false;
            property.ShouldSerialize = propInstance => property.DeclaringType != typeof(T);
            return property;
        }
    }
}

