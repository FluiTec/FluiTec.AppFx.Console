using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;
using System.Threading;
using System;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace FluiTec.AppFx.Console.Hosting
{
    /// <summary>
    ///     A hosted program.
    /// </summary>
    public abstract class BaseHostedProgram : IHostedService
    {
        private readonly IHostApplicationLifetime _liftetime;
        private readonly ILogger<BaseHostedProgram> _logger;

        /// <summary>
        ///     Specialized constructor for use only by derived class.
        /// </summary>
        /// <param name="logger">   The logger. </param>
        /// <param name="lifetime"> The lifetime. </param>
        protected BaseHostedProgram(ILogger<BaseHostedProgram> logger, IHostApplicationLifetime lifetime)
        {
            _logger = logger;
            _liftetime = lifetime;
        }

        /// <summary>
        ///     Triggered when the application host is ready to start the service.
        /// </summary>
        /// <param name="cancellationToken">    Indicates that the start process has been aborted. </param>
        /// <returns>
        ///     A Task.
        /// </returns>
        public Task StartAsync(CancellationToken cancellationToken)
        {
            var args = Environment.GetCommandLineArgs().Skip(1).ToArray();
            _logger.LogDebug($"Start HostedProgram, Arguments:\r\n {string.Join(",", args)}");

            _liftetime.ApplicationStarted.Register(() =>
            {
                Task.Run(async () =>
                {
                    try
                    {
                        await Task.Delay(100, cancellationToken);
                        Run(args);
                    }
                    catch (Exception e)
                    {
                        _logger.LogError(e, "Unhandled exception!");
                    }
                    finally
                    {
                        _liftetime.StopApplication();
                    }

                    return Task.CompletedTask;
                }, cancellationToken);
            });

            return Task.CompletedTask;
        }

        /// <summary>
        ///     Triggered when the application host is performing a graceful shutdown.
        /// </summary>
        /// <param name="cancellationToken">
        ///     Indicates that the shutdown process should no longer be
        ///     graceful.
        /// </param>
        /// <returns>
        ///     A Task.
        /// </returns>
        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        /// <summary>
        ///     Runs the given arguments.
        /// </summary>
        /// <param name="args">                 The arguments. </param>
        public abstract void Run(string[] args);
    }
}