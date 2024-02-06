// <summary>
// <copyright file="[%= name %]Dao.cs" company="Axity">
// This source code is Copyright Axity and MAY NOT be copied, reproduced,
// published, distributed or transmitted to or stored in any manner without prior
// written consent from Axity (www.axity.com).
// </copyright>
// </summary>

namespace [%= company %].[%= name %].DataAccess.DAO.[%= name %]
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using [%= company %].[%= name %].Entities.Context;
    using [%= company %].[%= name %].Entities.Model;

    /// <summary>
    /// Class [%= name %] Dao.
    /// </summary>
    public class [%= name %]Dao : I[%= name %]Dao
    {
        private readonly IDatabaseContext databaseContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="[%= name %]Dao"/> class.
        /// </summary>
        /// <param name="databaseContext">DataBase Context.</param>
        public [%= name %]Dao(IDatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext ?? throw new ArgumentNullException(nameof(databaseContext));
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<[%= name %]Model>> GetAll[%= name %]Async()
        {
            return await this.databaseContext.Cat[%= name %].ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<[%= name %]Model> Get[%= name %]Async(int id)
        {
            return await this.databaseContext.Cat[%= name %].FirstOrDefaultAsync(p => p.Id.Equals(id));
        }

        /// <inheritdoc/>
        public async Task<bool> Insert[%= name %]([%= name %]Model model)
        {
            var response = await this.databaseContext.Cat[%= name %].AddAsync(model);
            bool result = response.State.Equals(EntityState.Added);
            await ((DatabaseContext)this.databaseContext).SaveChangesAsync();
            return result;
        }
    }
}
