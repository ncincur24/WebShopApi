using ASPNedjelja3Vjezbe.Application.Logging;
using ASPNedjelja3Vjezbe.Application.UseCases;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace ASPNedjelja3Vjezbe.Implementation
{
    public class UseCaseHandler
    {
		private IExceptionLogger logger;

        public UseCaseHandler(IExceptionLogger logger)
        {
            this.logger = logger;
        }

        public void HandleCommand<TRequest>(ICommand<TRequest> command, TRequest data)
        {
			try
			{
                var stopwatch = new Stopwatch();
                stopwatch.Start();
				command.Execute(data);
                stopwatch.Stop();
                Console.WriteLine(command.Name + " " + stopwatch.ElapsedMilliseconds);
            }
			catch (Exception ex)
			{
                logger.Log(ex);
				throw;
			}
        }

        public TResponse HandleQuery<TRequest, TResponse>(IQuery<TRequest, TResponse> command, TRequest data)
        {
			try
			{
                var stopwatch = new Stopwatch();
                stopwatch.Start();
				var response = command.Execute(data);
                stopwatch.Stop();
                Console.WriteLine(command.Name + " " + stopwatch.ElapsedMilliseconds);

                return response;
            }
			catch (Exception ex)
			{
                logger.Log(ex);
				throw;
			}
        }
    }
}
