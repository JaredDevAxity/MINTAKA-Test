// <summary>
// <copyright file="[%= singularControllerName %]Dto.cs" company="Axity">
// This source code is Copyright Axity and MAY NOT be copied, reproduced,
// published, distributed or transmitted to or stored in any manner without prior
// written consent from Axity (www.axity.com).
// </copyright>
// </summary>

namespace [%= company %].[%= name %].Common.DTOs.Responses.[%= controllerName %]
{
    /// <summary>
    /// [%= singularControllerName %]Dto class.
    /// </summary>
    public class [%= singularControllerName %]Dto
    {[% properties.forEach(function(property){ %]
        /// <summary>
        /// Gets or sets [%- property.name %].
        /// </summary>
        /// <value>
        /// [%- property.type %] [%- property.name %].
        /// </value>
        public [%- property.type %] [%- property.name %] { get; set; }
[% }); %]
    }
}