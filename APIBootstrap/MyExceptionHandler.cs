using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;

namespace APIBootstrap
{
    public class MyExceptionHandler : ExceptionHandler
    {
        public override Task HandleAsync(ExceptionHandlerContext context, CancellationToken cancellationToken)
        {
            context.Result = new TextPlainErrorResult
            {
                Request = context.ExceptionContext.Request,
                Content = "Oops! Sorry! Something went wrong." +
                      "Please contact support@exception.com"
            };

            return Task.FromResult(0);
        }


        private class TextPlainErrorResult : IHttpActionResult
        {
            public HttpRequestMessage Request { get; set; }

            public string Content { get; set; }

            public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
            {
                var response =
                                 new HttpResponseMessage(HttpStatusCode.InternalServerError)
                                 {
                                     Content = new StringContent(Content),
                                     RequestMessage = Request
                                 };
                return Task.FromResult(response);
            }
        }
    }
}