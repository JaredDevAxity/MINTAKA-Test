// <summary>
// <copyright file="ITestsDao.cs" company="Axity">
// This source code is Copyright Axity and MAY NOT be copied, reproduced,
// published, distributed or transmitted to or stored in any manner without prior
// written consent from Axity (www.axity.com).
// </copyright>
// </summary>

namespace Axity.ArquetipoUnitTesting.Persistence.DAO.Tests
{
    /// <summary>
    /// Interface ITestsDao.
    /// </summary>
    public interface ITestsDao
    {
        /// <summary>
        /// Method for GetAllAsync.
        /// </summary>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<IEnumerable<TestModel>> GetAllAsync();

        /// <summary>
        /// Method for GetByIdAsync.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<TestModel> GetByIdAsync(int id);

        /// <summary>
        /// Method for InsertAsync.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        Task InsertAsync(TestModel model);

        /// <summary>
        /// Method for UpdateAsync.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>A <see cref="TestModel"/> representing the result of the operation.</returns>
        TestModel Update(TestModel model);

        /// <summary>
        /// Method for DeleteAsync.
        /// </summary>
        /// <param name="model">The model.</param>
        void Delete(TestModel model);
    }
}
