using System;
using Microsoft.Extensions.Logging;

namespace SimpleSample.Data.LiteDb
{
    public class LiteDbTestDataService : LiteDbDataService<LiteDbTestUnitOfWork>, ITestDataService
    {
        public LiteDbTestDataService(bool? useSingletonConnection, string dbFilePath, ILoggerFactory loggerFactory,
            string applicationFolder = null) : base(useSingletonConnection, dbFilePath, loggerFactory,
            applicationFolder)
        {
        }

        public LiteDbTestDataService(bool? useSingletonConnection, string dbFilePath, ILoggerFactory loggerFactory,
            IEntityNameService nameService, string applicationFolder = null) : base(useSingletonConnection, dbFilePath,
            loggerFactory, nameService, applicationFolder)
        {
        }

        public LiteDbTestDataService(LiteDbServiceOptions options, ILoggerFactory loggerFactory) : base(options,
            loggerFactory)
        {
        }

        public LiteDbTestDataService(LiteDbServiceOptions options, ILoggerFactory loggerFactory,
            IEntityNameService nameService) : base(options, loggerFactory, nameService)
        {
        }

        public override string Name => "LiteDbTestDataService";

        ITestUnitOfWork IDataService<ITestUnitOfWork>.BeginUnitOfWork(IUnitOfWork other)
        {
            return BeginUnitOfWork(other);
        }

        ITestUnitOfWork IDataService<ITestUnitOfWork>.BeginUnitOfWork()
        {
            return BeginUnitOfWork();
        }

        public override LiteDbTestUnitOfWork BeginUnitOfWork()
        {
            return new LiteDbTestUnitOfWork(this, LoggerFactory?.CreateLogger<IUnitOfWork>());
        }

        public override LiteDbTestUnitOfWork BeginUnitOfWork(IUnitOfWork other)
        {
            if (other == null) throw new ArgumentNullException(nameof(other));
            if (!(other is LiteDbUnitOfWork))
                throw new ArgumentException(
                    $"Incompatible implementation of UnitOfWork. Must be of type {nameof(LiteDbUnitOfWork)}!");
            return new LiteDbTestUnitOfWork(this, (LiteDbUnitOfWork) other, LoggerFactory?.CreateLogger<IUnitOfWork>());
        }
    }
}