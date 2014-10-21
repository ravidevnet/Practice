using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Extensions
{
    public static class EnumExtensions
    {
        public static string GetName(this Enum value)
        {
            return Enum.GetName(value.GetType(),value);
        }
    }
}
