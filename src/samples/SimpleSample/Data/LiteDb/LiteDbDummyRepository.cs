using FluiTec.AppFx.Data.LiteDb.Repositories;
using FluiTec.AppFx.Data.LiteDb.UnitsOfWork;
using FluiTec.AppFx.Data.Repositories;
using Microsoft.Extensions.Logging;
using SimpleSample.Data.Entities;
using SimpleSample.Data.Repositories;

namespace SimpleSample.Data.LiteDb
{
    public class LiteDbDummyRepository : LiteDbWritableIntegerKeyTableDataRepository<DummyEntity>, IDummyRepository
    {
        public LiteDbDummyRepository(LiteDbUnitOfWork unitOfWork, ILogger<IRepository> logger) : base(unitOfWork,
            logger)
        {
        }
    }
}