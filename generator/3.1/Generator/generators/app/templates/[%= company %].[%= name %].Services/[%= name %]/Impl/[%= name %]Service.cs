// <summary>
// <copyright file="[%= name %]Service.cs" company="Axity">
// This source code is Copyright Axity and MAY NOT be copied, reproduced,
// published, distributed or transmitted to or stored in any manner without prior
// written consent from Axity (www.axity.com).
// </copyright>
// </summary>

namespace [%= company %].[%= name %].Services.[%= name %].Impl
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AutoMapper;
    using [%= company %].[%= name %].DataAccess.DAO.[%= name %];
    using [%= company %].[%= name %].Dtos.[%= name %];
    using [%= company %].[%= name %].Entities.Model;

    /// <summary>
    /// Class [%= name %] Service.
    /// </summary>
    public class [%= name %]Service : I[%= name %]Service
    {
        private readonly IMapper mapper;

        private readonly I[%= name %]Dao modelDao;

        /// <summary>
        /// Initializes a new instance of the <see cref="[%= name %]Service"/> class.
        /// </summary>
        /// <param name="mapper">Object to mapper.</param>
        /// <param name="modelDao">Object to modelDao.</param>
        public [%= name %]Service(IMapper mapper, I[%= name %]Dao modelDao)
        {
            this.mapper = mapper;
            this.modelDao = modelDao ?? throw new ArgumentNullException(nameof(modelDao));
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<[%= name %]Dto>> GetAll[%= name %]Async()
        {
            return this.mapper.Map<List<[%= name %]Dto>>(await this.modelDao.GetAll[%= name %]Async());
        }

        /// <inheritdoc/>
        public async Task<[%= name %]Dto> Get[%= name %]Async(int id)
        {
            return this.mapper.Map<[%= name %]Dto>(await this.modelDao.Get[%= name %]Async(id));
        }

        /// <inheritdoc/>
        public async Task<bool> Insert[%= name %]([%= name %]Dto model)
        {
            return await this.modelDao.Insert[%= name %](this.mapper.Map<[%= name %]Model>(model));
        }
    }
}
