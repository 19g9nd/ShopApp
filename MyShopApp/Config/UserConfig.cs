using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyShopApp.Classes;

namespace MyShopApp.Config
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            //// - Id
            builder
                .Property(user => user.Id)
                .HasColumnName("UID")
                .HasDefaultValueSql("NEWID()");
            //NAME
            builder.Property<string>(user => user.Login)
                  .IsRequired()
                  .HasMaxLength(50);
            builder.HasIndex(user => user.Login)
      .IsUnique(true);
            //EMAIL
            builder.Property<string>(user => user.Email)
                .HasMaxLength(30)
                .IsRequired();
            builder.HasIndex(user => user.Email)
           .IsUnique(true); 

            //PASWORD
            builder.Property<string>(user => user.Password)
                .HasMaxLength(20)
                .IsRequired();
            //CONSTRAINTS
            builder
             .ToTable(b => b.HasCheckConstraint("CK_Users_Email", "Email like '%@%'"));
            builder
           .ToTable(b => b.HasCheckConstraint("CK_Users_Password", "LEN(Password)>=5"));
        }
    }
}
