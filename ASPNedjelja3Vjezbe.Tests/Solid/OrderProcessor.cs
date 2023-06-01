using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNedjelja3Vjezbe.Tests.Solid
{
    public class OrderProcessor
    {
        private IPaymentMethod paymentMethod;
        public bool emailSent = false;

        public OrderProcessor(IPaymentMethod paymentMethod)
        {
            this.paymentMethod = paymentMethod;
        }

        public void ProcessOrder(IEnumerable<OrderLine> lines)
        {
            emailSent = false;
            foreach (var ol in lines)
            {
                Console.WriteLine(ol.Name + ": " + ol.Price);
            }
            Console.WriteLine("Total: " + lines.Sum(x => x.Price * x.Quantity));
            var result = paymentMethod.Pay(lines.Sum(x => x.Price * x.Quantity));
            if (!result)
            {
                throw new Exception("Placanje neuspjesno");
            }
            SendEmail();
        }
        private void SendEmail() => this.emailSent = true;
    }

    public class Order
    {
        public IEnumerable<OrderLine> Lines { get; set; }   
    }

    public class OrderLine
    {
        public decimal Price { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }   
    }
}
