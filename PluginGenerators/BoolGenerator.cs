using GeneratorDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginGenerators
{
    public class BoolGenerator: IGenerator, IPluginGenerator
    {
        Random random;

        public BoolGenerator()
        {
            random = new Random();
        }

        public object Generate()
        {
            return random.Next(1) == 1 ? true : false;
        }

        public Type GetGeneratorType()
        {
            return typeof(bool);
        }
    }
}
