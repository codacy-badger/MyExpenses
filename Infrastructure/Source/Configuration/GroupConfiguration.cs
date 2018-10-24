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

    internal class GroupConfiguration : ConfigurationBase<GroupDomain>
    {
        public override void Configure(EntityTypeBuilder<GroupDomain> builder)
        {
            base.Configure(builder);

            // Columns
            builder.Property(x => x.Name).HasColumnName("Name");
            builder.HasMany(x => x.Labels);

            builder.ToTable("Group");
        }
    }
}
