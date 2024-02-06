// <summary>
// <copyright file="I[%= name %]Dao.cs" company="Axity">
// This source code is Copyright Axity and MAY NOT be copied, reproduced,
// published, distributed or transmitted to or stored in any manner without prior
// written consent from Axity (www.axity.com).
// </copyright>
// </summary>

namespace [%= company %].[%= name %].DataAccess.DAO.[%= name %]
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using [%= company %].[%= name %].Entities.Model;

    /// <summary>
    /// Interface IUserDao.
    /// </summary>
    public interface I[%= name %]Dao
    {
        /// <summary>
        /// Method for get all users from db.
        /// </summary>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<IEnumerable<[%= name %]Model>> GetAll[%= name %]Async();

        /// <summary>
        /// Method for get user by id from db.
        /// </summary>
        /// <param name="id">[%= name %] Id.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<[%= name %]Model> Get[%= name %]Async(int id);

        /// <summary>
        /// Method for add [%= name %] to DB.
        /// </summary>
        /// <param name="model">[%= name %] Dto.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<bool> Insert[%= name %]([%= name %]Model model);
    }
}
