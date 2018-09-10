namespace Lab_MVC.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class WebPayment : DbContext
    {
        public WebPayment()
            : base("name=WebPayment")
        {
        }

        public virtual DbSet<Log> Logs { get; set; }
        public virtual DbSet<PayflowResultCode> PayflowResultCodes { get; set; }
        public virtual DbSet<PaymentTransaction> PaymentTransactions { get; set; }
        public virtual DbSet<PaymentTransactionsPayableItem> PaymentTransactionsPayableItems { get; set; }
        public virtual DbSet<PaymentTransactionsPayableItemsPayOption> PaymentTransactionsPayableItemsPayOptions { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Train> Train { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PaymentTransaction>()
                .Property(e => e.Amount)
                .HasPrecision(18, 4);

            modelBuilder.Entity<PaymentTransaction>()
                .HasMany(e => e.PaymentTransactionsPayableItems)
                .WithRequired(e => e.PaymentTransaction)
                .HasForeignKey(e => e.PaymentTransactionsId);

            modelBuilder.Entity<PaymentTransactionsPayableItem>()
                .HasMany(e => e.PaymentTransactionsPayableItemsPayOptions)
                .WithRequired(e => e.PaymentTransactionsPayableItem)
                .HasForeignKey(e => e.PaymentTransactionsPayableItemsId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PaymentTransactionsPayableItemsPayOption>()
                .Property(e => e.TotalAmount)
                .HasPrecision(18, 4);

            modelBuilder.Entity<PaymentTransactionsPayableItemsPayOption>()
                .Property(e => e.AmountPaid)
                .HasPrecision(18, 4);
        }
    }
}
