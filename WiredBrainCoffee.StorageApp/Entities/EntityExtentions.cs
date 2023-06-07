using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WiredBrainCoffee.StorageApp.Entities
{
    public static class EntityExtentions
    {
        // hàm Copy chung áp dụng cho tất cả các lớp kế thừa lớp IEntity
        public static T? Copy<T>(this T itemToCopy)
            where T : IEntity
        {
            var json= JsonSerializer.Serialize<T>(itemToCopy);
            return JsonSerializer.Deserialize<T>(json);
        }
    }
}
