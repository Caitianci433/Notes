using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator
{
    //Mediator
    public abstract class AbstractChatroom 
    {
        public abstract void Register(Colleague colleague);

        public abstract void Send(string from, string to, string message);

    }


    public class Chatroom : AbstractChatroom
    {

        private Dictionary<string, Colleague> _mediator = new Dictionary<string, Colleague>();

        public override void Register(Colleague colleague)
        {
            _mediator.Add(colleague.name, colleague);
            colleague.chatroom = this;
        }

        public override void Send(string from, string to, string message)
        {
            _mediator[to].Receive(from, message);
        }
    }


}
