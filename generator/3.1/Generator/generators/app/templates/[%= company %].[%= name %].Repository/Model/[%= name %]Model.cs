// <summary>
// <copyright file="[%= name %]Model.cs" company="Axity">
// This source code is Copyright Axity and MAY NOT be copied, reproduced,
// published, distributed or transmitted to or stored in any manner without prior
// written consent from Axity (www.axity.com).
// </copyright>
// </summary>

namespace [%= company %].[%= name %].Entities.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Class [%= name %] Model.
    /// </summary>
    [Table("[%= name %]")]
    public class [%= name %]Model
    {
        /// <summary>
        /// Gets or sets Id.
        /// </summary>
        /// <value>
        /// Int Id.
        /// </value>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets FirstName.
        /// </summary>
        /// <value>
        /// String FirstName.
        /// </value>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets LastName.
        /// </summary>
        /// <value>
        /// String LastName.
        /// </value>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets Email.
        /// </summary>
        /// <value>
        /// String Email.
        /// </value>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets Birthdate.
        /// </summary>
        /// <value>
        /// String Birthdate.
        /// </value>
        public DateTime Birthdate { get; set; }
    }
}
