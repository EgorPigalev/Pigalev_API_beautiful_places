//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Pigalev_API_beautiful_places.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BaseData : DbContext
    {
        public BaseData()
            : base("name=BaseData")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<BeautifulPlace> BeautifulPlace { get; set; }
        public virtual DbSet<Favorites> Favorites { get; set; }
        public virtual DbSet<Grades> Grades { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<TypeLocalitys> TypeLocalitys { get; set; }
        public virtual DbSet<Users> Users { get; set; }
    }
}
