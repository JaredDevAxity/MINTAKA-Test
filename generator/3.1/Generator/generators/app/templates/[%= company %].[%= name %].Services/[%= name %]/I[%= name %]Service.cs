// <summary>
// <copyright file="I[%= name %]Service.cs" company="Axity">
// This source code is Copyright Axity and MAY NOT be copied, reproduced,
// published, distributed or transmitted to or stored in any manner without prior
// written consent from Axity (www.axity.com).
// </copyright>
// </summary>

namespace [%= company %].[%= name %].Services.[%= name %]
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using [%= company %].[%= name %].Dtos.[%= name %];

    /// <summary>
    /// Interface [%= name %] Service.
    /// </summary>
    public interface I[%= name %]Service
    {
        /// <summary>
        /// Method for get all users from db.
        /// </summary>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<IEnumerable<[%= name %]Dto>> GetAll[%= name %]Async();

        /// <summary>
        /// Method for get [%= name %] by id from db.
        /// </summary>
        /// <param name="id">User Id.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<[%= name %]Dto> Get[%= name %]Async(int id);

        /// <summary>
        /// Method for add [%= name %] to DB.
        /// </summary>
        /// <param name="model">[%= name %] Dto.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<bool> Insert[%= name %]([%= name %]Dto model);
    }
}
