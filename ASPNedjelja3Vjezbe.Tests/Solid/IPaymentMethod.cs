using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNedjelja3Vjezbe.Tests.Solid
{
    public interface IPaymentMethod
    {
        bool Pay(decimal amount);
    }

    public interface ILogger
    {
        void Log(string message);
    }

    public class CreditCardPaymentMethod : IPaymentMethod, ILogger
    {
        private string cardNumber;
        private int ccv;
        private string exp;

        public CreditCardPaymentMethod(string cardNumber, int ccv, string exp)
        {
            this.cardNumber = cardNumber;
            this.ccv = ccv;
            this.exp = exp;
        }

        public void Log(string message)
        {
            throw new NotImplementedException();
        }

        public bool Pay(decimal amount)
        {
            Console.WriteLine("Paying with card...");
            return true;
        }
    }

    public class PeypalPaymentMethod : IPaymentMethod
    {
        public bool Pay(decimal amount)
        {
            Console.WriteLine("Paying with Paypal account...");
            return true;
        }
    }

    public class BankPaymentMethod : IPaymentMethod
    {
        public bool Pay(decimal amount)
        {
            Console.WriteLine("Paying with bank transfer...");
            return true;
        }
    }
}
