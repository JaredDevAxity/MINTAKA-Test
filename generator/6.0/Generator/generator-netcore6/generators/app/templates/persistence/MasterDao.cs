// <summary>
// <copyright file="[%= controllerName %]Dao.cs" company="Axity">
// This source code is Copyright Axity and MAY NOT be copied, reproduced,
// published, distributed or transmitted to or stored in any manner without prior
// written consent from Axity (www.axity.com).
// </copyright>
// </summary>

namespace [%= company %].[%= name %].Persistence.DAO.[%= controllerName %].Impl
{
    /// <summary>
    /// Class [%= controllerName %]Dao.
    /// </summary>
    public class [%= controllerName %]Dao : I[%= controllerName %]Dao
    {
        private readonly DatabaseContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="[%= controllerName %]Dao"/> class.
        /// </summary>
        /// <param name="context">DataBase Context.</param>
        public [%= controllerName %]Dao(DatabaseContext context)
        {
            ArgumentNullException.ThrowIfNull(context);
            this.context = context;
        }
[% if (controllerGet) { %]
        /// <inheritdoc/>
        public async Task<IEnumerable<[%= singularControllerName %]Model>> GetAllAsync()
            => await this.context.[%= controllerName %].ToListAsync();

        /// <inheritdoc/>
        public async Task<[%= singularControllerName %]Model> GetByIdAsync(int id)
            => await this.context.[%= controllerName %].FindAsync(id);
[% } %][% if (controllerPost) { %]
        /// <inheritdoc/>
        public async Task InsertAsync([%= singularControllerName %]Model model)
            => await this.context.AddAsync(model);
[% } %][% if (controllerPut) { %]
        /// <inheritdoc/>
        public [%= singularControllerName %]Model Update([%= singularControllerName %]Model model)
            => this.context.Update(model).Entity;
[% } %][% if (controllerDelete) { %]
        /// <inheritdoc/>
        public void Delete([%= singularControllerName %]Model model)
            => this.context.Remove(model);
[% } %]
        /// <inheritdoc/>
        public async Task<int> SaveChangesAsync() => await this.context.SaveChangesAsync();
    }
}
