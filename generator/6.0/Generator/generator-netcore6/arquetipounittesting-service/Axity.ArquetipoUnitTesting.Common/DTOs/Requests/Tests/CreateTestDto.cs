// <summary>
// <copyright file="CreateTestDto.cs" company="Axity">
// This source code is Copyright Axity and MAY NOT be copied, reproduced,
// published, distributed or transmitted to or stored in any manner without prior
// written consent from Axity (www.axity.com).
// </copyright>
// </summary>

namespace Axity.ArquetipoUnitTesting.Common.DTOs.Requests.Tests
{
    /// <summary>
    /// CreateTestDto class.
    /// </summary>
    public class CreateTestDto
    {
        /// <summary>
        /// Gets or sets Name.
        /// </summary>
        /// <value>
        /// string Name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Active.
        /// </summary>
        /// <value>
        /// bool Active.
        /// </value>
        public bool Active { get; set; }

        /// <summary>
        /// Gets or sets Create.
        /// </summary>
        /// <value>
        /// DateTime Create.
        /// </value>
        public DateTime Create { get; set; }

        /// <summary>
        /// Gets or sets User.
        /// </summary>
        /// <value>
        /// string User.
        /// </value>
        public string User { get; set; }
   }
}