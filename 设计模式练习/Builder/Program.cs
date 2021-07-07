using System;

namespace Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            Director1 director1 = new Director1();
            Director2 director2 = new Director2();

            Builder1 b1 = new Builder1();
            Builder1 b2 = new Builder1();

            director1.Construct(b1);
            director2.Construct(b2);

            Product p1 = b1.GetProduct();
            Product p2 = b2.GetProduct();

            Console.WriteLine(p1.Run());
            Console.WriteLine(p2.Run());

        }
    }

    

}
