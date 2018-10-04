using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratorDTO.Generators
{
    public class ListGenerator : ICollectionGenerator
    {
        public object Generate(Type t)
        {
            object res = Activator.CreateInstance(typeof(List<>).MakeGenericType(t));

            ((IList)res).Add(ParameterGenerator.Generate(t));

            return res;
        }
    }
}
