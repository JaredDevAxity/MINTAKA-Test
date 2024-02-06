// <summary>
// <copyright file="[%= controllerName %]Facade.cs" company="Axity">
// This source code is Copyright Axity and MAY NOT be copied, reproduced,
// published, distributed or transmitted to or stored in any manner without prior
// written consent from Axity (www.axity.com).
// </copyright>
// </summary>

namespace [%= company %].[%= name %].Facade.[%= controllerName %].Impl
{
    /// <summary>
    /// Class [%= controllerName %]Facade.
    /// </summary>
    public class [%= controllerName %]Facade : I[%= controllerName %]Facade
    {
        private readonly I[%= controllerName %]Service [%= controllerNameLower %]Service;

        /// <summary>
        /// Initializes a new instance of the <see cref="[%= controllerName %]Facade"/> class.
        /// </summary>
        /// <param name="[%= controllerNameLower %]Service">Interface [%= controllerName %]Service.</param>
        public [%= controllerName %]Facade(I[%= controllerName %]Service [%= controllerNameLower %]Service) =>
            this.[%= controllerNameLower %]Service = [%= controllerNameLower %]Service ?? throw new ArgumentNullException(nameof([%= controllerNameLower %]Service));
[% if (controllerGet) { %]
        /// <inheritdoc/>
        public async Task<IEnumerable<[%= singularControllerName %]Dto>> GetAllAsync()
            => await this.[%= controllerNameLower %]Service.GetAllAsync();

        /// <inheritdoc/>
        public async Task<[%= singularControllerName %]Dto> GetByIdAsync(int id)
            => await this.[%= controllerNameLower %]Service.GetByIdAsync(id);
[% } %][% if (controllerPost) { %]
        /// <inheritdoc/>
        public async Task<[%= singularControllerName %]Dto> InsertAsync(string user, Create[%= singularControllerName %]Dto [%= singularControllerNameLower %]Request)
            => await this.[%= controllerNameLower %]Service.InsertAsync(user, [%= singularControllerNameLower %]Request);
[% } %][% if (controllerPut) { %]
        /// <inheritdoc/>
        public async Task<[%= singularControllerName %]Dto> UpdateAsync(
            int id, string user, Update[%= singularControllerName %]Dto [%= singularControllerNameLower %]Request)
            => await this.[%= controllerNameLower %]Service.UpdateAsync(id, user, [%= singularControllerNameLower %]Request);
[% } %][% if (controllerDelete) { %]
        /// <inheritdoc/>
        public async Task DeleteAsync(int id)
            => await this.[%= controllerNameLower %]Service.DeleteAsync(id);[% } %]
    }
}