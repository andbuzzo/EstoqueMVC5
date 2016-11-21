namespace EstoqueMVC5
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<categoria> categoria { get; set; }
        public virtual DbSet<cidade> cidade { get; set; }
        public virtual DbSet<estado> estado { get; set; }
        public virtual DbSet<fornecedor> fornecedor { get; set; }
        public virtual DbSet<produto> produto { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<categoria>()
                .Property(e => e.descricao)
                .IsUnicode(false);

            modelBuilder.Entity<categoria>()
                .HasMany(e => e.produto)
                .WithOptional(e => e.categoria)
                .HasForeignKey(e => e.id_categoria);

            modelBuilder.Entity<cidade>()
                .Property(e => e.descricao)
                .IsUnicode(false);

            modelBuilder.Entity<cidade>()
                .HasMany(e => e.fornecedor)
                .WithOptional(e => e.cidade)
                .HasForeignKey(e => e.id_cidade);

            modelBuilder.Entity<estado>()
                .Property(e => e.descricao)
                .IsUnicode(false);

            modelBuilder.Entity<estado>()
                .HasMany(e => e.cidade)
                .WithOptional(e => e.estado)
                .HasForeignKey(e => e.id_estado);

            modelBuilder.Entity<fornecedor>()
                .Property(e => e.descricao)
                .IsUnicode(false);

            modelBuilder.Entity<fornecedor>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<fornecedor>()
                .HasMany(e => e.produto)
                .WithOptional(e => e.fornecedor)
                .HasForeignKey(e => e.id_fornecedor);

            modelBuilder.Entity<produto>()
                .Property(e => e.descricao)
                .IsUnicode(false);
        }
    }
}
