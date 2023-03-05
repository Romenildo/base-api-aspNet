using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using base_api_aspNet.Models;

namespace base_api_aspNet.Data.Map
{
    public class BaseMap : IEntityTypeConfiguration<Base>
    {
        public void Configure(EntityTypeBuilder<Base> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Idade).IsRequired();
            builder.Property(x => x.Data).IsRequired();
            builder.Property(x => x.Altura).IsRequired().HasMaxLength(150);
            //relacionamento
            //builder.HasMany(x => x.Array).WithOne(x => x.Livro).OnDelete(DeleteBehavior.Cascade);

        }
    }
}
