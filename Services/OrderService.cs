using ProvaPub.Models;
using ProvaPub.Models.Enums;

namespace ProvaPub.Services
{
    public class OrderService
    {
        private Dictionary<PaymentOption, Delegate> _payments;

        public OrderService()
        {
            _payments = new Dictionary<PaymentOption, Delegate>();
            _payments.Add(PaymentOption.Paypal, PayPalPay);
            _payments.Add(PaymentOption.Pix, PixPay);
            _payments.Add(PaymentOption.Creditcard, CreditCardPay);
        }
        public async Task<Order> PayOrder(PaymentOption paymentOption, decimal paymentValue, int customerId)
        {
            _payments[paymentOption].DynamicInvoke(paymentValue);    

            return await Task.FromResult(new Order()
            {
                Value = paymentValue
            });
        }
        // Também seria possível fazendo com diversas classes, tento como base uma interface de PaymentMethod, como um método Pay(), sendo implementado nas concretas conforme necessidade(PaypalMethod,PixMethod)
        // Bastaria chamar pelo PixMethod.Pay()
        // Acredito que o padrão de abstract factory serveria muito bem, porém acabei ficando sem tempo para implementá-lo.
        public void PixPay(decimal paymentValue)
        {
            //Faz pagamento...
        }
        public void PayPalPay(decimal paymentValue)
        {
            //Faz pagamento...
        }
        public void CreditCardPay(decimal paymentValue)
        {
            //Faz pagamento...
        }
    }
}
