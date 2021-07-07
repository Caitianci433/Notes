using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    

    public abstract class BuilderAbstract
    {
        public abstract void BuildPartA();

        public abstract void BuildPartB();

        public abstract void BuildPartC();

        public abstract Product GetProduct();

    }


    public class Builder1 : BuilderAbstract
    {
        Product product = new Product();

        public override void BuildPartA()
        {
            product.Add("PartA");
        }

        public override void BuildPartB()
        {
            product.Add("PartB");
        }

        public override void BuildPartC()
        {
            product.Add("PartC");
        }

        public override Product GetProduct()
        {
            return product;
        }
    }


    public class Director1
    {
        public void Construct(BuilderAbstract builder)
        {
            builder.BuildPartA();
            builder.BuildPartB();
        }
    }
    public class Director2
    {
        public void Construct(BuilderAbstract builder)
        {
            builder.BuildPartA();
            builder.BuildPartB();
            builder.BuildPartC();
        }
    }





    public class Product
    {
        private IList<string> parts = new List<string>();

        public void Add(string part) 
        {
            parts.Add(part);
        }

        public string Run() 
        {
            return string.Join(',', parts);
        
        }
    }
}
