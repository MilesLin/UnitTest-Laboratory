namespace Lab_MVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PaymentTransactionsPayableItem
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PaymentTransactionsPayableItem()
        {
            PaymentTransactionsPayableItemsPayOptions = new HashSet<PaymentTransactionsPayableItemsPayOption>();
        }

        public long Id { get; set; }

        public long PaymentTransactionsId { get; set; }

        [StringLength(50)]
        public string BillOfLading { get; set; }

        [Required]
        [StringLength(50)]
        public string ContainerNumber { get; set; }

        public DateTime PickupDate { get; set; }

        [Required]
        [StringLength(50)]
        public string Terminal { get; set; }

        [Required]
        [StringLength(50)]
        public string Line { get; set; }

        public DateTime EntryDateTime { get; set; }

        public virtual PaymentTransaction PaymentTransaction { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PaymentTransactionsPayableItemsPayOption> PaymentTransactionsPayableItemsPayOptions { get; set; }
    }
}
