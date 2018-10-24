/* 
*   Project: MyExpenses
*   Author: Luiz Felipe Machado da Silva
*   Github: http://github.com/lfmachadodasilva/MyExpenses
*/

namespace MyExpenses.Infrastructure.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using MyExpenses.Domain.Domains;

    internal class LabelConfiguration : ConfigurationBase<LabelDomain>
    {
        public override void Configure(EntityTypeBuilder<LabelDomain> builder)
        {
            base.Configure(builder);

            // Columns
            builder.Property(x => x.Name).HasColumnName("Name");
            builder.HasOne(x => x.Group).WithMany(x => x.Labels).HasForeignKey("GroupId");

            builder.ToTable("Label");
        }
    }
}
