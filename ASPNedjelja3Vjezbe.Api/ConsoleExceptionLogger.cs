namespace ASPNedjelja3Vjezbe.Api
{
    public interface IExceptionLogger
    {
        void LogException(Exception ex, Guid correlationId);
    }
    public class ConsoleExceptionLogger : IExceptionLogger
    {
        public void LogException(Exception e, Guid correlationId) =>
            Console.WriteLine($"Message: {e.Message}\nStack trace: {e.StackTrace}\n Inner ex message{e.InnerException?.Message}, Error ID: {correlationId}");
    }

    public class DbExceptionLogger : IExceptionLogger
    {
        public void LogException(Exception e, Guid correlationId)
        {

        }
    }
}
