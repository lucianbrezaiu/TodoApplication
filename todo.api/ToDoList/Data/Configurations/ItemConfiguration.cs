using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoList.Data.Entities;

namespace ToDoList.Data.Configurations
{
    public class ItemConfiguration : IEntityTypeConfiguration<Note>
    {

        public void Configure(EntityTypeBuilder<Note> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Title)
                .IsRequired()
                .HasMaxLength(100);
            
            builder.Property(a => a.Description)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(a => a.CreatedAt)
                .IsRequired();

            builder.Property(a => a.UpdatedAt)
                   .IsRequired();
        }
    }
}
