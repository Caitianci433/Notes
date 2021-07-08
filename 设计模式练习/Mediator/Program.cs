using System;

namespace Mediator
{
    class Program
    {
        static void Main(string[] args)
        {
            Chatroom chatroom = new Chatroom();

            Colleague colleague1 = new Beatle("colleague1");
            chatroom.Register(colleague1);
            Colleague colleague2 = new Beatle("colleague2");
            chatroom.Register(colleague2);
            Colleague colleague3 = new Beatle("colleague3");
            chatroom.Register(colleague3);


            colleague1.Send("colleague2", "ni hao");
            colleague2.Send("colleague3", "zai ma");
            colleague3.Send("colleague1", "zai");

        }
    }
}
