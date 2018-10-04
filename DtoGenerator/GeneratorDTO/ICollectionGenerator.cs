using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratorDTO
{
    public interface ICollectionGenerator
    {
        object Generate(Type t);
    }
}
