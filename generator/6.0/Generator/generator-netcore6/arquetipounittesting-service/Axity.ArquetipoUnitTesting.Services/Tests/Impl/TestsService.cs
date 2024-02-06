// <summary>
// <copyright file="TestsService.cs" company="Axity">
// This source code is Copyright Axity and MAY NOT be copied, reproduced,
// published, distributed or transmitted to or stored in any manner without prior
// written consent from Axity (www.axity.com).
// </copyright>
// </summary>

namespace Axity.ArquetipoUnitTesting.Services.Tests.Impl
{
    /// <summary>
    /// TestsService class.
    /// </summary>
    public class TestsService : ITestsService
    {
        private readonly ITestsDao testsDao;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="TestsService"/> class.
        /// </summary>
        /// <param name="mapper">Mapper.</param>
        /// <param name="testsDao">Tests dao.</param>
        public TestsService(IMapper mapper, ITestsDao testsDao)
            => (this.mapper, this.testsDao) = (mapper, testsDao);

        /// <inheritdoc/>
        public async Task<IEnumerable<TestDto>> GetAllAsync()
            => this.mapper.Map<IEnumerable<TestDto>>(
                await this.testsDao.GetAllAsync());

        /// <inheritdoc/>
        public async Task<TestDto> GetByIdAsync(int id)
        {
            var model = await this.testsDao.GetByIdAsync(id);
            model.ThrowExceptionIfNull<NotFoundException>(
                string.Format(ErrorMessages.NotFoundIdFormat, id));
            return this.mapper.Map<TestDto>(model);
        }

        /// <inheritdoc/>
        public async Task<TestDto> InsertAsync(string user, CreateTestDto testRequest)
        {
            var model = this.mapper.Map<TestModel>(testRequest);
            model.UserCreated = user;
            model.Active = true;
            model.Created = DateTime.UtcNow;
            await this.testsDao.InsertAsync(model);
            return this.mapper.Map<TestDto>(model);
        }

        /// <inheritdoc/>
        public async Task<TestDto> UpdateAsync(
            int id, string user, UpdateTestDto testsRequest)
        {
            var model = await this.testsDao.GetByIdAsync(id);
            model.ThrowExceptionIfNull<NotFoundException>(
                string.Format(ErrorMessages.NotFoundIdFormat, id));

            model.Name = testsRequest.Name;
            model.Active = testsRequest.Active;
            model.Create = testsRequest.Create;
            model.User = testsRequest.User;
            model.UserModified = user;
            model.Modified = DateTime.Now;
            this.testsDao.Update(model);
            return this.mapper.Map<TestDto>(model);
        }

        /// <inheritdoc/>
        public async Task DeleteAsync(int id)
        {
            var model = await this.testsDao.GetByIdAsync(id);
            model.ThrowExceptionIfNull<NotFoundException>(
                string.Format(ErrorMessages.NotFoundIdFormat, id));
            this.testsDao.Delete(model);
        }
    }
}
