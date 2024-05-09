using System.ComponentModel.DataAnnotations;

namespace JuiceTip_API.Model
{
    public class TransactionDetail
    {
        [Key]
        public Guid TransactionId { get; set; }
        public Guid JustiperId { get; set; }
        public float ApplicationFee { get; set; }
        public Guid ProductId { get; set; }
        public string TransactionStatus { get; set; }
        public int Qty { get; set; }
        public float SubtotalProduct { get; set; }
        public float SubtotalPrice { get; set; }
    }
}
