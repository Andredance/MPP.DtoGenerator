using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratorDTO.Generators
{
    public class UIntGenerator : IGenerator
    {
        Random random;

        public UIntGenerator()
        {
            random = new Random();
        }

        public object Generate()
        {
            uint res = (uint)random.Next(int.MaxValue) + (uint)random.Next(int.MaxValue);
            return res;
        }
    }
}
