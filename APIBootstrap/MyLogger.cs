using log4net;

namespace APIBootstrap
{
    public class MyLogger
    {
        private static readonly ILog log = LogManager.GetLogger("apiLogger");
        public static void Log(object message)
        {
            log.Error(message);
        }
    }
}