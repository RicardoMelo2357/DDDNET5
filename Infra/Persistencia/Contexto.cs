using Dominio.Entidades.Endereco;
using Dominio.Entidades.Usuario;
using Infra.Persistencia.Map.Endereco;
using Infra.Persistencia.Map.Usuario;
using Microsoft.EntityFrameworkCore;
using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Persistencia
{
    public class Contexto : DbContext
    {
        public Contexto() : base() { }
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }

        public DbSet<Usuario> Usuario;
        public DbSet<Endereco> Endereco;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Notification>();
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Contexto).Assembly);

            foreach (var entityType in modelBuilder.Model.GetEntityTypes()) entityType.SetTableName(entityType.DisplayName());
            var cascadeFKs = modelBuilder.Model.GetEntityTypes().SelectMany(t => t.GetForeignKeys()).Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Restrict);
            foreach (var fk in cascadeFKs) fk.DeleteBehavior = DeleteBehavior.Restrict;
            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetProperties().Where(p => p.ClrType == typeof(string)))) property.SetColumnType("varchar(" + (property.GetMaxLength() > 0 ? property.GetMaxLength().ToString() : "100") + ")");

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            AddDate();
            return base.SaveChanges();
        }

        private void AddDate()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.State == EntityState.Added) entry.Property("DataInclusao").CurrentValue = DateTime.Now;
                if (entry.State == EntityState.Modified) entry.Property("DataAlteracao").CurrentValue = DateTime.Now;
            }
        }
    }
}
