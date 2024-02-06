// <summary>
// <copyright file="[%= controllerName %]Service.cs" company="Axity">
// This source code is Copyright Axity and MAY NOT be copied, reproduced,
// published, distributed or transmitted to or stored in any manner without prior
// written consent from Axity (www.axity.com).
// </copyright>
// </summary>

namespace [%= company %].[%= name %].Services.[%= controllerName %].Impl
{
    /// <summary>
    /// [%= controllerName %]Service class.
    /// </summary>
    public class [%= controllerName %]Service : I[%= controllerName %]Service
    {
        private readonly I[%= controllerName %]Dao [%= controllerNameLower %]Dao;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="[%= controllerName %]Service"/> class.
        /// </summary>
        /// <param name="mapper">Mapper.</param>
        /// <param name="[%= controllerNameLower %]Dao">[%= controllerName %] dao.</param>
        public [%= controllerName %]Service(IMapper mapper, I[%= controllerName %]Dao [%= controllerNameLower %]Dao)
            => (this.mapper, this.[%= controllerNameLower %]Dao) = (mapper, [%= controllerNameLower %]Dao);
[% if (controllerGet) { %]
        /// <inheritdoc/>
        public async Task<IEnumerable<[%= singularControllerName %]Dto>> GetAllAsync()
            => this.mapper.Map<IEnumerable<[%= singularControllerName %]Dto>>(
                await this.[%= controllerNameLower %]Dao.GetAllAsync());

        /// <inheritdoc/>
        public async Task<[%= singularControllerName %]Dto> GetByIdAsync(int id)
        {
            var model = await this.[%= controllerNameLower %]Dao.GetByIdAsync(id);
            model.ThrowExceptionIfNull<NotFoundException>(
                string.Format(ErrorMessages.NotFoundIdFormat, id));
            return this.mapper.Map<[%= singularControllerName %]Dto>(model);
        }
[% } %][% if (controllerPost) { %]
        /// <inheritdoc/>
        public async Task<[%= singularControllerName %]Dto> InsertAsync(string user, Create[%= singularControllerName %]Dto [%= singularControllerNameLower %]Request)
        {
            var model = this.mapper.Map<[%= singularControllerName %]Model>([%= singularControllerNameLower %]Request);
            model.UserCreated = user;
            model.Active = true;
            model.Created = DateTime.UtcNow;
            await this.[%= controllerNameLower %]Dao.InsertAsync(model);
            return this.mapper.Map<[%= singularControllerName %]Dto>(model);
        }
[% } %][% if (controllerPut) { %]
        /// <inheritdoc/>
        public async Task<[%= singularControllerName %]Dto> UpdateAsync(
            int id, string user, Update[%= singularControllerName %]Dto [%= controllerNameLower %]Request)
        {
            var model = await this.[%= controllerNameLower %]Dao.GetByIdAsync(id);
            model.ThrowExceptionIfNull<NotFoundException>(
                string.Format(ErrorMessages.NotFoundIdFormat, id));
[% properties.filter(property => property.allowUpdate).forEach(function(property){ %]
            model.[%- property.name %] = [%= controllerNameLower %]Request.[%- property.name %];[% }); %]
            model.UserModified = user;
            model.Modified = DateTime.Now;
            this.[%= controllerNameLower %]Dao.Update(model);
            return this.mapper.Map<[%= singularControllerName %]Dto>(model);
        }
[% } %][% if (controllerDelete) { %]
        /// <inheritdoc/>
        public async Task DeleteAsync(int id)
        {
            var model = await this.[%= controllerNameLower %]Dao.GetByIdAsync(id);
            model.ThrowExceptionIfNull<NotFoundException>(
                string.Format(ErrorMessages.NotFoundIdFormat, id));
            this.[%= controllerNameLower %]Dao.Delete(model);
        }[% } %]
    }
}
