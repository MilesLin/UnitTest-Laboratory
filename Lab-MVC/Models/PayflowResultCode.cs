namespace Lab_MVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PayflowResultCode")]
    public partial class PayflowResultCode
    {
        [Key]
        [StringLength(10)]
        public string ResultCode { get; set; }

        [Required]
        public string Definition { get; set; }

        public bool EnableDefinition { get; set; }

        public string Description { get; set; }

        public bool EnableDescription { get; set; }
    }
}
