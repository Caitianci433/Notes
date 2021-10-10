using System;

namespace Bridge
{
    public abstract class TV
    {
        public abstract void On();
        public abstract void Off();
        public abstract void TuneChannel();
    }

    public class ChangHong : TV
    {
        public override void On()
        {
            Console.WriteLine("长虹牌电视机已经打开了");
        }

        public override void Off()
        {
            Console.WriteLine("长虹牌电视机已经关掉了");
        }

        public override void TuneChannel()
        {
            Console.WriteLine("长虹牌电视机换频道");
        }
    }

    public class Samsung : TV
    {
        public override void On()
        {
            Console.WriteLine("三星牌电视机已经打开了");
        }

        public override void Off()
        {
            Console.WriteLine("三星牌电视机已经关掉了");
        }

        public override void TuneChannel()
        {
            Console.WriteLine("三星牌电视机换频道");
        }
    }
}
