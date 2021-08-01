using System;

namespace ChainOfResponsibility
{
    class Program
    {
        static void Main(string[] args)
        {
            var Filter1 = new Filter1();
            var Filter2 = new Filter2();
            var Filter3 = new Filter3();
            Filter1.SetNEXT(Filter2);
            Filter2.SetNEXT(Filter3);

            var req1 = new Request() { Level = 1 };
            var req2 = new Request() { Level = 2 };
            var req3 = new Request() { Level = 3 };
            var req4 = new Request() { Level = 4 };

            Filter1.Handler(req1);
            Filter1.Handler(req2);
            Filter1.Handler(req3);
            Filter1.Handler(req4);
        }
    }
}
