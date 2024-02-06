// <summary>
// <copyright file="[%= singularControllerName %]Model.cs" company="Axity">
// This source code is Copyright Axity and MAY NOT be copied, reproduced,
// published, distributed or transmitted to or stored in any manner without prior
// written consent from Axity (www.axity.com).
// </copyright>
// </summary>
namespace [%= company %].[%= name %].Model.Entities
{
    /// <summary>
    /// [%= singularControllerName %]Model class.
    /// </summary>
    public class [%= singularControllerName %]Model : SignedModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="[%= singularControllerName %]Model"/> class.
        /// </summary>
        public [%= singularControllerName %]Model()
        {
        }
[% properties.forEach(function(property){ %]
        /// <summary>
        /// Gets or sets [%- property.name %].
        /// </summary>
        /// <value>
        /// [%- property.type %] [%- property.name %].
        /// </value>
        public [%- property.type %] [%- property.name %] { get; set; }
[% }); %]    }
}
