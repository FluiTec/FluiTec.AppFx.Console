using FluiTec.AppFx.Data.LiteDb.Repositories;
using FluiTec.AppFx.Data.LiteDb.UnitsOfWork;
using FluiTec.AppFx.Data.Repositories;
using Microsoft.Extensions.Logging;
using SimpleSample.Data.Entities;
using SimpleSample.Data.Repositories;

namespace SimpleSample.Data.LiteDb
{
    public class LiteDbDummy2Repository : LiteDbWritableIntegerKeyTableDataRepository<DummyEntity2>, IDummy2Repository
    {
        public LiteDbDummy2Repository(LiteDbUnitOfWork unitOfWork, ILogger<IRepository> logger) : base(unitOfWork,
            logger)
        {
        }
    }
}