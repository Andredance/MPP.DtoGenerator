using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GeneratorDTO
{
    public class Faker
    {
        public Faker() { }

        public object Create(Type t)
        {
            List<ConstructorInfo> constructors = ClassInfo.GetClassConstructorsInfo(t);
            if (constructors.Count != 0)
            {
                ConstructorInfo bestConstructor = ConstructorInfoProcessor.GetMaxParameterizedConstructor(constructors);
                List<ParameterInfo> parameters = ParametersInfoProcessor.GetParametersInfo(bestConstructor);

            }
            else
            {

            }
            Object obj = new Object();
            return obj;
        }

        public T Create<T>()
        {
            return (T)Create(typeof(T));         
        }
    }
}
