﻿using System;
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

        public object CreateByConstructor(ConstructorInfo constructor)
        {
            List<ParameterInfo> parameters = ParametersInfoProcessor.GetParametersInfo(constructor);
            object[] tmpParams = new object[parameters.Count];
            int i = 0;

            foreach (ParameterInfo parameterInfo in parameters)
            {
                tmpParams[i] = ParameterGenerator.Generate(parameterInfo.GetType(), this);
            }
            return constructor.Invoke(tmpParams);
        }

        public object CreateByFieldsAndProperties(Type t)
        {
            object res = Activator.CreateInstance(t);
            List<FieldInfo> fields = ClassInfo.GetClassFieldsInfo(t);
            List<PropertyInfo> settableProperties = PropertiesInfoProcessor.GetSettableProperties(ClassInfo.GetClassPropertiesInfo(t));
            foreach (FieldInfo field in fields)
            {
                field.SetValue(res, ParameterGenerator.Generate(field.FieldType, this));
            }

            foreach (PropertyInfo property in settableProperties)
            {
                property.SetValue(res, ParameterGenerator.Generate(property.PropertyType, this));
            }

            return res;
        }

        public object Create(Type t)
        {
            ParameterGenerator.AddToRecursionControlList(t);
            Object result;
            List<ConstructorInfo> constructors = ClassInfo.GetClassConstructorsInfo(t);
            if (constructors.Count > 1)
            {
                ConstructorInfo bestConstructor = ConstructorInfoProcessor.GetMaxParameterizedConstructor(constructors);
                result = CreateByConstructor(bestConstructor);
            }
            else
            {
                result = CreateByFieldsAndProperties(t);
            }
            return result;
        }

        public T Create<T>()
        {
            ParameterGenerator.ClearRecursionControlList();
            return (T)Create(typeof(T));         
        }
    }
}
