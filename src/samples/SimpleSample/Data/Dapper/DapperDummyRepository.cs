using Microsoft.Extensions.Logging;
using SimpleSample.Data.Entities;
using SimpleSample.Data.Repositories;

namespace SimpleSample.Data.Dapper
{
    public class DapperDummyRepository : DapperWritableKeyTableDataRepository<DummyEntity, int>, IDummyRepository
    {
        public DapperDummyRepository(DapperUnitOfWork unitOfWork, ILogger<IRepository> logger) : base(unitOfWork,
            logger)
        {
        }
    }
}