using System;
using System.Collections.Generic;

namespace OpenClosedPrincipleViolation
{
    public class Program
    {
        public static void Main()
        {
            Factory factory = new Factory();

            IEnumerable<ICraftable> craftables = new List<ICraftable>
            {
                new Wood(),
                new Metal()
            };

            Production production = factory.Craft(craftables);

            Console.WriteLine(production);
        }
    }

    public sealed class Factory
    {
        public Production Craft(IEnumerable<ICraftable> manyTypeBlocks)
        {
            Production newProduction = new Production(manyTypeBlocks);
            return newProduction;
        }
    }

    public class Production
    {
        public IEnumerable<ICraftable> Materials { get; set; }

        public Production(IEnumerable<ICraftable> manyMaterials)
        {
            Materials = manyMaterials;
        }

        public override string ToString()
        {
            string description = "Object is composed of\n:";
            foreach (ICraftable craftable in Materials)
            {
                description += "\t" + craftable.Type;
            }
            return description;
        }
    }

    public abstract class ICraftable
    {
        public virtual string Type { get; }
    }

    public class Wood : ICraftable
    {
        public override string Type
        {
            get
            {
                return "Wood";
            }
        }
    }

    public class Metal : ICraftable
    {
        public override string Type
        {
            get
            {
                return "Metal";
            }
        }
    }
}