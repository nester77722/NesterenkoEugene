namespace PublisherSubscriberProject
{
    public class LoggerSubscriber : ISubscriber
    {
        private Logger.Logger _logger = Logger.Logger.Instance;

        public LoggerSubscriber(Publisher pub)
        {
            Publisher = pub;
            pub.PublisherEvent += HandleEvent;
        }

        public IPublisher Publisher { get; init; }

        public void HandleEvent(object sender, MyEventArgs e)
        {
            _logger.AddLog(e.Message);
        }
    }
}
