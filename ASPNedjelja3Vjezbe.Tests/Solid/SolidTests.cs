using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ASPNedjelja3Vjezbe.Tests.Solid
{
    public class SolidTests
    {
        //[Fact]
        //public void PaymentProcessorThrowsException_WhenPaymentFails()
        //{            
        //    var processor = new OrderProcessor(new TestPaymentMethod());
        //    Action a = () => processor.ProcessOrder(Order);
        //    a.Should().ThrowExactly<Exception>().WithMessage("Placanje neuspjesno");
        //    processor.emailSent.Should().BeFalse();
        //}

        //[Fact]
        //public void EmailSent_WhenPaymentDoesntFail()
        //{
        //    var mock = new Mock<IPaymentMethod>();

        //    mock.Setup(x => x.Pay(360)).Returns(true);
        //    var paymentMethod = mock.Object;

        //    var processor = new OrderProcessor(paymentMethod);
        //    Action a = () => processor.ProcessOrder(Order);
        //    a.Should().NotThrow();
        //    processor.emailSent.Should().BeTrue();
        //    mock.Verify(x => x.Pay(360), Times.Once());
        //}
        public Order Order => new Order
        {
            Lines = new List<OrderLine>
            {
                new OrderLine
                {
                    Name="OL 1",
                    Price=100,
                    Quantity=3
                },
                new OrderLine
                {
                    Name="OL 2",
                    Price=30,
                    Quantity=2
                }
            }
        };
    }

    public class TestPaymentMethod : IPaymentMethod
    {
        public bool Pay(decimal amount) => false;
    }
}