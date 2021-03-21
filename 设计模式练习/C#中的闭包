```
class Program
    {
        // 定义闭包委托
        delegate void ClosureDelegate();

        static void Main(string[] args)
        {
            ClosureDelegate test = CreateDelegateInstance();
            test();
   
            Console.Read();
        }

        // 闭包延长变量的生命周期
        private static ClosureDelegate CreateDelegateInstance()
        {
            int count = 1;
  
            ClosureDelegate closuredelegate = delegate
            {
                Console.WriteLine(count);
                count++;
            };

            // 调用委托
            closuredelegate();
            return closuredelegate;
        }
}
```
