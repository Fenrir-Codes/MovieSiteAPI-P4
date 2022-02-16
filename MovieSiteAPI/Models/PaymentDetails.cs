namespace MovieSiteAPI.Models
{
    public class PaymentDetails
    {
        public int PaymentDetailsId { get; set; }  //--> PK
        public int ProfileId { get; set; }  //--> FK Profile

        public string PaymentType { get; set; } // card , mobilepay, etc...

        public string CardholderName { get; set; }
        public string CardType { get; set; } //--> Mastercard, Visa
        public string CardNumber { get; set; }
        public string ExpMonth { get; set; }
        public string SecurityCode { get; set; } //--> CVV

        public string TransactionId { get; set; }


    }
}
