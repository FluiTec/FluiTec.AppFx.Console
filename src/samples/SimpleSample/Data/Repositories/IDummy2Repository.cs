using FluiTec.AppFx.Data.Repositories;
using SimpleSample.Data.Entities;

namespace SimpleSample.Data.Repositories
{
    public interface IDummy2Repository : IWritableKeyTableDataRepository<DummyEntity2, int>
    {
    }
}