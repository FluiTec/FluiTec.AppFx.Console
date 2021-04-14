using Microsoft.Extensions.Logging;
using SimpleSample.Data.Repositories;

namespace SimpleSample.Data.Dapper
{
    public class DapperTestUnitOfWork : DapperUnitOfWork, ITestUnitOfWork
    {
        public DapperTestUnitOfWork(IDapperDataService dataService, ILogger<IUnitOfWork> logger) : base(dataService,
            logger)
        {
            RegisterRepositories();
        }

        public DapperTestUnitOfWork(DapperUnitOfWork parentUnitOfWork, IDataService dataService,
            ILogger<IUnitOfWork> logger) : base(parentUnitOfWork, dataService, logger)
        {
            RegisterRepositories();
        }

        public IDummyRepository DummyRepository => GetRepository<IDummyRepository>();
        public IDummy2Repository Dummy2Repository => GetRepository<IDummy2Repository>();

        private void RegisterRepositories()
        {
            RepositoryProviders.Add(typeof(IDummyRepository),
                (uow, log) => new DapperDummyRepository((DapperTestUnitOfWork) uow, log));
            RepositoryProviders.Add(typeof(IDummy2Repository),
                (uow, log) => new DapperDummy2Repository((DapperTestUnitOfWork) uow, log));
        }
    }
}