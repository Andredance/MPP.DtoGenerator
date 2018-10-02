using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GeneratorDTO
{
    internal static class ParametersInfoProcessor
    {
        internal static bool isParameterSimple(ParameterInfo parameter)
        {
            Type type = parameter.GetType();
            return type.IsPrimitive || type.Equals(typeof(string));
        }
    }
}
