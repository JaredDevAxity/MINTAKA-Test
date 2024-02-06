// <summary>
// <copyright file="BaseTest.cs" company="Axity">
// This source code is Copyright Axity and MAY NOT be copied, reproduced,
// published, distributed or transmitted to or stored in any manner without prior
// written consent from Axity (www.axity.com).
// </copyright>
// </summary>

namespace [%= company %].[%= name %].Test
{
    /// <summary>
    /// Class Base Test.
    /// </summary>
    public abstract class BaseTest
    {
[% controllers.forEach(function(controller){ %]
        /// <summary>
        /// List of ProjectModel.
        /// </summary>
        /// <returns>A <see cref="TResult"/> representing the result of the operation.</returns>
        public IEnumerable<UserModel> Get[%- controller.name %]Model()
        {
            return new List<UserModel>()
            {
                [% controller.data.forEach(function(data){ %][%- data %],[% }); %]
            };
        }[% }); %]
    }
}
