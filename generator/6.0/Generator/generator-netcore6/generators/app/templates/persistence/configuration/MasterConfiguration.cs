// <summary>
// <copyright file="[%= controller.singularName %]Configuration.cs" company="Axity">
// This source code is Copyright Axity and MAY NOT be copied, reproduced,
// published, distributed or transmitted to or stored in any manner without prior
// written consent from Axity (www.axity.com).
// </copyright>
// </summary>

namespace [%= company %].[%= name %].Persistence.Configuration
{
    /// <summary>
    /// [%= controller.singularName %]Configuration class.
    /// </summary>
    public class [%= controller.singularName %]Configuration : IEntityTypeConfiguration<[%= controller.singularName %]Model>
    {
        /// <inheritdoc/>
        public void Configure(EntityTypeBuilder<[%= controller.singularName %]Model> builder)
        {
            [%- tableSetting %]
[% propertySettings.forEach(function(propertySetting){ %]
            [%- propertySetting %]
[% }); %]
            builder.Property(s => s.UserCreated)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(s => s.Created)
                .IsRequired();

            builder.Property(s => s.UserModified)
                .HasMaxLength(100);

            builder.Property(s => s.Active)
                .IsRequired();
        }
    }
}
