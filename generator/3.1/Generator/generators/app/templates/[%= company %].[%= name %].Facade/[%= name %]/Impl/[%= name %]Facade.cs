// <summary>
// <copyright file="[%= name %]Facade.cs" company="Axity">
// This source code is Copyright Axity and MAY NOT be copied, reproduced,
// published, distributed or transmitted to or stored in any manner without prior
// written consent from Axity (www.axity.com).
// </copyright>
// </summary>

namespace [%= company %].[%= name %].Facade.[%= name %].Impl
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using [%= company %].[%= name %].Dtos.[%= name %];
    using [%= company %].[%= name %].Services.[%= name %];

    /// <summary>
    /// Class [%= name %] Facade.
    /// </summary>
    public class [%= name %]Facade : I[%= name %]Facade
    {
        private readonly I[%= name %]Service modelService;

        /// <summary>
        /// Initializes a new instance of the <see cref="[%= name %]Facade"/> class.
        /// </summary>
        /// <param name="modelService">Interface [%= name %] Service.</param>
        public [%= name %]Facade(I[%= name %]Service modelService)
        {
            this.modelService = modelService ?? throw new ArgumentNullException(nameof(modelService));
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<[%= name %]Dto>> GetList[%= name %]Active()
        {
            return await this.modelService.GetAll[%= name %]Async();
        }

        /// <inheritdoc/>
        public async Task<[%= name %]Dto> GetList[%= name %]Active(int id)
        {
            return await this.modelService.Get[%= name %]Async(id);
        }

        /// <inheritdoc/>
        public async Task<bool> Insert[%= name %]([%= name %]Dto model)
        {
            return await this.modelService.Insert[%= name %](model);
        }
    }
}
