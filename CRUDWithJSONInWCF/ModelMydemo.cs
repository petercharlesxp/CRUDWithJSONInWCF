namespace CRUDWithJSONInWCF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModelMydemo : DbContext
    {
        public ModelMydemo()
            : base("name=ModelMydemo")
        {
        }

        public virtual DbSet<mydemoproduct> mydemoproducts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<mydemoproduct>()
                .Property(e => e.Name)
                .IsUnicode(false);
        }
    }
}
