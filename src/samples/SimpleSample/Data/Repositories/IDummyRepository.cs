using FluiTec.AppFx.Data.Repositories;
using SimpleSample.Data.Entities;

namespace SimpleSample.Data.Repositories
{
    public interface IDummyRepository : IWritableKeyTableDataRepository<DummyEntity, int>
    {
    }
}