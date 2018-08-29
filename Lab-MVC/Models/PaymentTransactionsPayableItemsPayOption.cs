namespace Lab_MVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PaymentTransactionsPayableItemsPayOption
    {
        public long Id { get; set; }

        public long PaymentTransactionsPayableItemsId { get; set; }

        [Required]
        [StringLength(50)]
        public string FeeType { get; set; }

        public decimal TotalAmount { get; set; }

        public decimal AmountPaid { get; set; }

        public DateTime EntryDateTime { get; set; }

        public virtual PaymentTransactionsPayableItem PaymentTransactionsPayableItem { get; set; }
    }
}
