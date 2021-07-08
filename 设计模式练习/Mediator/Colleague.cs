using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator
{
    public class Colleague
    {
        public Colleague(string name) 
        {
            this.name = name;
        }

        public Chatroom chatroom { get; set; }

        public string name { get; }

        public void Send(string to, string message) 
        {
            chatroom.Send(name, to, message);
        }

        public virtual void Receive(string from, string message) 
        {
            Console.WriteLine("{0} to {1}:'{2}'", from, name, message);
        }
    }

    public class Beatle : Colleague
    {
        public Beatle(string name) : base(name) { }

        public override void Receive(string from, string message)
        {
            Console.Write("To a Beatle: ");
            base.Receive(from, message);
        }
    }

        public class Joen : Colleague
        {
            public Joen(string name) : base(name) { }

            public override void Receive(string from, string message)
            {
                Console.Write("To a Joen: ");
                base.Receive(from, message);
            }


        }

    public class Jack : Colleague
    {
        public Jack(string name) : base(name) { }

        public override void Receive(string from, string message)
        {
            Console.Write("To a Jack: ");
            base.Receive(from, message);
        }


    }
}
