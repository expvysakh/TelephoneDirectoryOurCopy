using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace TelephoneDirectoryApplication.Data_Layer
{
    public class ContactRecordContext: DbContext
    {
        public ContactRecordContext() : base("name = ConnectionString")
        {
        }

        //Creating the tables
        public DbSet<Directory> Directories { get; set; }
        public DbSet<PhoneNumber> PhoneNumbers { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Entity Type Configuration for Directories
            modelBuilder.Entity<Directory>().HasKey(c => c.Id);
            modelBuilder.Entity<Directory>()
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(50);

            //Entity Type Configuration for PhoneNumbers
            modelBuilder.Entity<PhoneNumber>().HasKey(c => c.RecordId);
            modelBuilder.Entity<PhoneNumber>()
                .Property(c => c.FirstName)
                .IsRequired()
                .HasMaxLength(50);
            modelBuilder.Entity<PhoneNumber>()
               .Property(c => c.LastName)
               .IsRequired()
               .HasMaxLength(50);
            modelBuilder.Entity<PhoneNumber>()
               .Property(c => c.TelephoneNumber)
               .IsRequired()
               .HasMaxLength(11);
            modelBuilder.Entity<PhoneNumber>()
               .Property(c => c.Address)
               .IsRequired()
               .HasMaxLength(100);
            // Relationship PhoneNumbers with Directories
            modelBuilder.Entity<PhoneNumber>()
                .HasRequired(c => c.DirectoryList)
                .WithMany(s => s.DirectoryRecord)
                .HasForeignKey(s => s.DirectoryId);

            //Entity Type Configuration for Contacts
            modelBuilder.Entity<User>().HasKey(c => c.Id);
            modelBuilder.Entity<User>()
                .Property(c => c.UserName)
                .IsRequired()
                .HasMaxLength(50);
            modelBuilder.Entity<User>()
               .Property(c => c.Password)
               .IsRequired()
               .HasMaxLength(50);
        }
    }
}