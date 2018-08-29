namespace Lab_MVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PaymentTransaction
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PaymentTransaction()
        {
            PaymentTransactionsPayableItems = new HashSet<PaymentTransactionsPayableItem>();
        }

        public long Id { get; set; }

        [Required]
        [StringLength(30)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(30)]
        public string LastName { get; set; }

        [Required]
        [StringLength(50)]
        public string Company { get; set; }

        [Required]
        [StringLength(30)]
        public string Street1 { get; set; }

        [StringLength(30)]
        public string Street2 { get; set; }

        [Required]
        [StringLength(20)]
        public string City { get; set; }

        [Required]
        [StringLength(2)]
        public string State { get; set; }

        [Required]
        [StringLength(9)]
        public string Zipcode { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        public string Phone { get; set; }

        [Required]
        [StringLength(4)]
        public string LastFourNumberOfCard { get; set; }

        [Required]
        [StringLength(200)]
        public string MerchantResult { get; set; }

        [Required]
        [StringLength(50)]
        public string MerchantAuthCode { get; set; }

        [Required]
        [StringLength(50)]
        public string MerchantPNRef { get; set; }

        public decimal Amount { get; set; }

        public DateTime EntryDateTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PaymentTransactionsPayableItem> PaymentTransactionsPayableItems { get; set; }
    }
}
