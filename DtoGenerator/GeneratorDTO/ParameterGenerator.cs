using GeneratorDTO.Generators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GeneratorDTO
{
    internal static class ParameterGenerator
    {
        private static Dictionary<Type, IGenerator> generatorMethods;
        private static List<Type> recursionControl;

        static ParameterGenerator()
        {
            generatorMethods = new Dictionary<Type, IGenerator>();
            generatorMethods.Add(typeof(int), new IntGenerator());
            generatorMethods.Add(typeof(double), new DoubleGenerator());
            generatorMethods.Add(typeof(uint), new UIntGenerator());
            generatorMethods.Add(typeof(float), new FloatGenerator());
            generatorMethods.Add(typeof(char), new CharGenerator());
            generatorMethods.Add(typeof(string), new StringGenerator());
            generatorMethods.Add(typeof(bool), new BoolGenerator());
            generatorMethods.Add(typeof(long), new LongGenerator());

            recursionControl = new List<Type>();       
        }

        public static void AddToRecursionControlList(Type t)
        {
            recursionControl.Add(t);
        }

        public static void ClearRecursionControlList()
        {
            recursionControl.Clear();
        }

        internal static object Generate(Type parameterType, Faker faker)
        {
            if (generatorMethods.ContainsKey(parameterType))
            {
                return generatorMethods[parameterType].Generate();
            }
            else
            {
                if (recursionControl.Contains(parameterType))
                {
                    throw new InvalidOperationException("Cyclic objects! First DTO contains second DTO as field, second DTO contains first as field.");
                }
                else
                {
                    if (DtoChecker.IsDto(parameterType))
                    {
                        return faker.Create(parameterType);
                    }
                    else
                    {
                        return parameterType.IsValueType ? Activator.CreateInstance(parameterType) : null;
                    }
                }
            }
        }
    }
}
