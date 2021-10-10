using System;

namespace Bridge
{
    public abstract class RemoteControlAbstract
    {
        private TV _tv;

        public TV TV
        {
            get { return _tv; }
            set { _tv = value; }
        }

        public virtual void On()
        {
            _tv.On();
        }

        public virtual void Off()
        {
            _tv.Off();
        }

        public virtual void SetChannel()
        {
            _tv.TuneChannel();
        }
    }

    public class ConcreteRemote : RemoteControlAbstract
    {
        public override void SetChannel()
        {
            Console.WriteLine("---------------------");
            base.SetChannel();
            Console.WriteLine("---------------------");
        }
    }
}
