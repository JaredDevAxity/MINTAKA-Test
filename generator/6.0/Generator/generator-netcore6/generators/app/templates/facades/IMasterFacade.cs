// <summary>
// <copyright file="I[%= controllerName %]Facade.cs" company="Axity">
// This source code is Copyright Axity and MAY NOT be copied, reproduced,
// published, distributed or transmitted to or stored in any manner without prior
// written consent from Axity (www.axity.com).
// </copyright>
// </summary>

namespace [%= company %].[%= name %].Facade.[%= controllerName %]
{
    /// <summary>
    /// Interface I[%= controllerName %]Facade.
    /// </summary>
    public interface I[%= controllerName %]Facade
    {[% if (controllerGet) { %]
        /// <summary>
        /// Method for get all [%= controllerNameLower %].
        /// </summary>
        /// <returns>A <see cref="Task{IEnumerable{[%= singularControllerName %]Dto}}"/> representing the result of the asynchronous operation.</returns>
        Task<IEnumerable<[%= singularControllerName %]Dto>> GetAllAsync();

        /// <summary>
        /// Method for get a [%= singularControllerNameLower %] by id.
        /// </summary>
        /// <param name="id">[%= singularControllerName %] Id.</param>
        /// <returns>A <see cref="Task{[%= singularControllerName %]Dto}"/> representing the result of the asynchronous operation.</returns>
        Task<[%= singularControllerName %]Dto> GetByIdAsync(int id);
[% } %][% if (controllerPost) { %]
        /// <summary>
        /// Method for insert a [%= singularControllerNameLower %].
        /// </summary>
        /// <param name="user">User.</param>
        /// <param name="[%= singularControllerNameLower %]Request">Object to insert.</param>
        /// <returns>A <see cref="Task{[%= singularControllerName %]Dto}"/> representing the result of the asynchronous operation.</returns>
        Task<[%= singularControllerName %]Dto> InsertAsync(string user, Create[%= singularControllerName %]Dto [%= singularControllerNameLower %]Request);
[% } %][% if (controllerPut) { %]
        /// <summary>
        /// Method for update a [%= singularControllerNameLower %].
        /// </summary>
        /// <param name="id">[%= singularControllerName %] Id.</param>
        /// <param name="user">User name.</param>
        /// <param name="[%= singularControllerNameLower %]Request">Object to update.</param>
        /// <returns>A <see cref="Task{[%= singularControllerName %]Dto}"/> representing the result of the asynchronous operation.</returns>
        Task<[%= singularControllerName %]Dto> UpdateAsync(int id, string user, Update[%= singularControllerName %]Dto [%= singularControllerNameLower %]Request);[% } %]
[% if (controllerDelete) { %]
        /// <summary>
        /// Method for delete a [%= singularControllerNameLower %].
        /// </summary>
        /// <param name="id">[%= singularControllerName %]  Id.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        Task DeleteAsync(int id);[% } %]
    }
}