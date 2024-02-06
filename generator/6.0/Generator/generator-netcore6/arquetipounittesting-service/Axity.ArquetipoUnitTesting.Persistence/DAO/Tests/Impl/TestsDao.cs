// <summary>
// <copyright file="TestsDao.cs" company="Axity">
// This source code is Copyright Axity and MAY NOT be copied, reproduced,
// published, distributed or transmitted to or stored in any manner without prior
// written consent from Axity (www.axity.com).
// </copyright>
// </summary>

namespace Axity.ArquetipoUnitTesting.Persistence.DAO.Tests.Impl
{
    /// <summary>
    /// Class TestsDao.
    /// </summary>
    public class TestsDao : ITestsDao
    {
        private readonly DatabaseContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="TestsDao"/> class.
        /// </summary>
        /// <param name="context">DataBase Context.</param>
        public TestsDao(DatabaseContext context)
        {
            ArgumentNullException.ThrowIfNull(context);
            this.context = context;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<TestModel>> GetAllAsync()
            => await this.context.Tests.ToListAsync();

        /// <inheritdoc/>
        public async Task<TestModel> GetByIdAsync(int id)
            => await this.context.Tests.FindAsync(id);

        /// <inheritdoc/>
        public async Task InsertAsync(TestModel model)
            => await this.context.AddAsync(model);

        /// <inheritdoc/>
        public TestModel Update(TestModel model)
            => this.context.Update(model).Entity;

        /// <inheritdoc/>
        public void Delete(TestModel model)
            => this.context.Remove(model);

        /// <inheritdoc/>
        public async Task<int> SaveChangesAsync() => await this.context.SaveChangesAsync();
    }
}
