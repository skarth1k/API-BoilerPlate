using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.ExceptionHandling;

namespace APIBootstrap
{
    public class MyExceptionLogger : ExceptionLogger
    {
        public override Task LogAsync(ExceptionLoggerContext context, CancellationToken cancellationToken)
        {
            MyLogger.Log(context.ExceptionContext.Exception.ToString());
            return Task.FromResult(0);
        }
    }
}