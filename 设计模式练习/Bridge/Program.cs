using System;

namespace Bridge
{
    class Program
    {
        static void Main(string[] args)
        {
            // 创建一个遥控器
            var remoteControl = new ConcreteRemote();
            // 长虹电视机
            remoteControl.TV = new ChangHong();
            remoteControl.On();
            remoteControl.SetChannel();
            remoteControl.Off();
            Console.WriteLine();

            // 三星牌电视机
            remoteControl.TV = new Samsung();
            remoteControl.On();
            remoteControl.SetChannel();
            remoteControl.Off();
            Console.Read();
        }
    }
}
