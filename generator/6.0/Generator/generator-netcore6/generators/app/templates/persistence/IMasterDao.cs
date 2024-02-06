// <summary>
// <copyright file="I[%= controllerName %]Dao.cs" company="Axity">
// This source code is Copyright Axity and MAY NOT be copied, reproduced,
// published, distributed or transmitted to or stored in any manner without prior
// written consent from Axity (www.axity.com).
// </copyright>
// </summary>

namespace [%= company %].[%= name %].Persistence.DAO.[%= controllerName %]
{
    /// <summary>
    /// Interface I[%= controllerName %]Dao.
    /// </summary>
    public interface I[%= controllerName %]Dao
    {[% if (controllerGet) { %]
        /// <summary>
        /// Method for GetAllAsync.
        /// </summary>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<IEnumerable<[%= singularControllerName %]Model>> GetAllAsync();

        /// <summary>
        /// Method for GetByIdAsync.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<[%= singularControllerName %]Model> GetByIdAsync(int id);
[% } %][% if (controllerPost) { %]
        /// <summary>
        /// Method for InsertAsync.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        Task InsertAsync([%= singularControllerName %]Model model);
[% } %][% if (controllerPut) { %]
        /// <summary>
        /// Method for UpdateAsync.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>A <see cref="[%= singularControllerName %]Model"/> representing the result of the operation.</returns>
        [%= singularControllerName %]Model Update([%= singularControllerName %]Model model);
[% } %][% if (controllerDelete) { %]
        /// <summary>
        /// Method for DeleteAsync.
        /// </summary>
        /// <param name="model">The model.</param>
        void Delete([%= singularControllerName %]Model model);[% } %]
    }
}
