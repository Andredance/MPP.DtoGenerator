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
        private static Dictionary<string, ICollectionGenerator> collectionGenerator;
        private static List<Type> recursionControl;
        private static Faker faker;

        public static Faker Faker
        {
            get
            {
                return faker;
            }
            set
            {
                faker = value;
            }
        }

        static ParameterGenerator()
        {
            Assembly asm = Assembly.LoadFrom("C:\\Users\\andre\\Documents\\labs\\mpp.labs\\MPP.DtoGenerator\\PluginGenerators\\bin\\Debug\\PluginGenerators.dll");

            collectionGenerator = new Dictionary<string, ICollectionGenerator>();
            generatorMethods = new Dictionary<Type, IGenerator>();
            generatorMethods.Add(typeof(double), new DoubleGenerator());
            generatorMethods.Add(typeof(uint), new UIntGenerator());
            generatorMethods.Add(typeof(float), new FloatGenerator());
            generatorMethods.Add(typeof(char), new CharGenerator());
            generatorMethods.Add(typeof(string), new StringGenerator());
            generatorMethods.Add(typeof(long), new LongGenerator());
            generatorMethods.Add(typeof(DateTime), new DateGenerator());

            var types = asm.GetTypes().Where(t => t.GetInterfaces().Where(i => i.Equals(typeof(IGenerator))).Any());

            foreach (var type in types)
            {
                var plugin = asm.CreateInstance(type.FullName) as IPluginGenerator;
                Type t = plugin.GetGeneratorType();
                if (!generatorMethods.ContainsKey(t))
                    generatorMethods.Add(plugin.GetGeneratorType(), plugin as IGenerator);
            }

            collectionGenerator.Add(typeof(List<>).Name, new ListGenerator());

            recursionControl = new List<Type>();
        }

        public static void AddToRecursionControlList(Type t)
        {
            recursionControl.Add(t);
        }

        public static void RemoveFromRecursionControlList(Type t)
        {
            recursionControl.Remove(t);
        }

        public static void ClearRecursionControlList()
        {
            recursionControl.Clear();
        }

        internal static object Generate(Type parameterType)
        {
            if (generatorMethods.ContainsKey(parameterType))
            {
                return generatorMethods[parameterType].Generate();
            }
            if (collectionGenerator.ContainsKey(parameterType.Name))
            {
                return collectionGenerator[parameterType.Name].Generate(parameterType.GenericTypeArguments[0]);
            }
            if (recursionControl.Contains(parameterType))
            {
                throw new InvalidOperationException("Cyclic objects! First DTO contains second DTO as field, second DTO contains first as field.");
            }
            if (DtoChecker.IsDto(parameterType))
            {
                object tmp = faker.Create(parameterType);
                RemoveFromRecursionControlList(parameterType);
                return tmp;
            }
            return parameterType.IsValueType ? Activator.CreateInstance(parameterType) : null;
        }
    }
}
