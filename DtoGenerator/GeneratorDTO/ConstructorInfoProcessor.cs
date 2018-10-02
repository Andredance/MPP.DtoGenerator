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
        internal static ConstructorInfo GetMaxParameterizedByBasicTypesConstructor(List<ConstructorInfo> allConstructors)
        {
            if (allConstructors.Count == 0)
            {
                throw new InvalidOperationException("Empty list");
            }
    
            allConstructors = allConstructors.OrderBy(item => item.GetParameters().Length).ToList();
            foreach (ConstructorInfo constructor in allConstructors)
            {
                if (constructor.GetParameters().Any(parameter => ParametersInfoProcessor.isParameterSimple(parameter)))
                {
                    return constructor;
                }
            }

            throw new InvalidOperationException("Can't find constructor that satisfying conditions");
        } 
    }
}
