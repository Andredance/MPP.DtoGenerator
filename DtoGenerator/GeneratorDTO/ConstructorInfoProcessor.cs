using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GeneratorDTO
{
    internal static class ConstructorInfoProcessor
    {
        internal static ConstructorInfo GetMaxParameterizedConstructor(List<ConstructorInfo> allConstructors)
        {
            if (allConstructors.Count == 0)
            {
                throw new InvalidOperationException("Empty list");
            }
    
            allConstructors = allConstructors.OrderBy(item => item.GetParameters().Length).ToList();
            return allConstructors[0];
        } 
    }
}
