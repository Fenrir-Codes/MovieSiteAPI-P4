namespace MovieSiteAPI.Models
{
    public class PaymentDetails
    {
        public int PaymentDetailsId { get; set; }  //--> PK
        public int OrderId { get; set; }  //--> FK Order

        public string PaymentType { get; set; } // card , mobilepay, etc...

        public string CardholderName { get; set; }
        public string CardType { get; set; } //--> Mastercard, Visa
        public int CardNumber { get; set; }
        public string ExpMonth { get; set; }
        public int SecurityCode { get; set; } //--> CVV

        public int TransactionId { get; set; }


    }
}
