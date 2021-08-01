using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility
{
    public class Request 
    { 
        public int Level { get; set; }
    
    }
    public class Response
    {
        public bool IsError { get; set; }

        public string Errormessage { get; set; }
    }

    public abstract class IHttpHandler 
    {
        protected IHttpHandler next;

        public void SetNEXT(IHttpHandler httpHandler) 
        {
            this.next = httpHandler;
        }

        public abstract Response Handler(Request request);

    }

    public class Filter1 : IHttpHandler
    {

        public override Response Handler(Request request)
        {
            if (request.Level > 1)
            {
                Console.WriteLine("Filer1 acess");
                if (next!=null)
                {
                    return next.Handler(request);
                }
                else
                {
                    return new Response();
                }     
            }
            else
            {
                return new Response();
            }
        }
    }

    public class Filter2 : IHttpHandler
    {

        public override Response Handler(Request request)
        {
            if (request.Level > 2)
            {
                Console.WriteLine("Filer2 acess");
                if (next != null)
                {
                    return next.Handler(request);
                }
                else
                {
                    return new Response();
                }
            }
            else
            {
                return new Response();
            }
        }
    }

    public class Filter3 : IHttpHandler
    {

        public override Response Handler(Request request)
        {
            if (request.Level > 3)
            {
                Console.WriteLine("Filer3 acess");
                if (next != null)
                {
                    return next.Handler(request);
                }
                else
                {
                    return new Response();
                }
            }
            else
            {
                return new Response();
            }
        }
    }
}
