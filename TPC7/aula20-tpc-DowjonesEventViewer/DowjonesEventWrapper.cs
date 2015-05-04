using System;

public delegate void DowjonesEventHandler(String title, String desc, DateTime when);

public class DowjonesEventWrapper
{
    private DowjonesNews news = new DowjonesNews();

    public void Pull() 
    {
        news.Pull();
    }

    public void AddHandler(DowjonesEventHandler handler)
    {
		news.AddSubscriber(new handlerAdapter(handler));
    }

    public void RemoveHandler(DowjonesEventHandler handler)
    {
       news.RemoveSubscriber(new handlerAdapter(handler));
		
    }
}

class handlerAdapter : Subscriber
    {
		private DowjonesEventHandler handler;
		public Test(DowjonesEventHandler handler){
		this.handler = handler;
		
		}
		
        public void Occurrence(string title, string uri, DateTime when)
        {
		handler(title,uri,when);
        }
    }
