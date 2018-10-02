using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GeneratorDTO
{
    internal static class ClassInfo<T>
    {
        internal static List<ConstructorInfo> GetClassConstructorsInfo()
        {
            return new List<ConstructorInfo>(typeof(T).GetConstructors());
        }

        internal static List<PropertyInfo> GetClassPropertiesInfo()
        {
            return new List<PropertyInfo>(typeof(T).GetProperties());
        }

        internal static List<FieldInfo> GetClassFieldsInfo()
        {
            return new List<FieldInfo>(typeof(T).GetFields());
        }
    }
}
