using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

using ACE.Database;
using ACE.Entity;
using ACE.Common;
using log4net;

namespace ACE.Managers
{
    /// <summary>
    /// Servermanager handles unloading the server application properly.
    /// </summary>
    /// <remarks>
    ///  Still need to verify that the system unloads properly.
    ///   Possibly useful for:
    ///     1. Monitor for errors and performance issues in LandblockManager, GuidManager, WorldManager,
    ///         DatabaseManager, or AssetManager
    ///   Known issue:
    ///     1. No method to verify that everything unloaded properly.
    /// </remarks>
    public static class ServerManager
    {
        /// <summary>
        /// Provides a true or false value that indicates advanced warning if the applcation will unload.
        /// </summary>
        public static bool shutdownInitiated { get; private set; }

        /// <summary>
        /// The ammount of seconds that the server will wait before unloading the application.
        /// </summary>
        public static uint shutdownInterval { get; private set; }

        public static void setShutdownInterval(uint interval)
        {
            log.Warn($"Server shutdown interval reset: {interval}");
            shutdownInterval = interval;
        }

        public static void Initialise()
        {
            shutdownInterval = ConfigManager.Config.Server.ShutdownInterval;
        }

        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Starts the shutdown wait thread.
        /// </summary>
        public static void BeginShutdown()
        {
            shutdownInitiated = true;
            var shutdownThread = new Thread(ShutdownServer);
            shutdownThread.Start();
        }

        /// <summary>
        /// Calling this function will always cancel an in-progress shutdown (application unload). This will also
        /// stop the shutdown wait thread and alert users that the server will stay in operation.
        /// </summary>
        public static void CancelShutdown()
        {
            shutdownInitiated = false;
        }

        /// <summary>
        /// Threaded task created when performing a server shutdown
        /// </summary>
        private static void ShutdownServer()
        {
            DateTime shutdownTime = DateTime.UtcNow.AddSeconds(shutdownInterval);

            // wait for shutdown interval to expire
            while (shutdownTime != DateTime.MinValue && shutdownTime >= DateTime.UtcNow)
            {
                // this allows the server shutdown to be canceled
                if (!shutdownInitiated)
                {
                    // reset shutdown details
                    string shutdownText = $"The server has canceled the shutdown procedure @ {DateTime.UtcNow} UTC";
                    log.Warn(shutdownText);
                    // special text
                    foreach (var player in WorldManager.GetAll())
                    {
                        player.WorldBroadcast(shutdownText);
                    }
                    // break function
                    return;
                }
            }

            // logout each player
            foreach (var player in WorldManager.GetAll())
            {
                player.LogOffPlayer();
            }

            // wait 6 seconds for log-off
            Thread.Sleep(6000);

            // TODO: Make sure that the landblocks unloads properly.

            // TODO: Make sure that the databasemanager unloads properly.

            // disabled thread update loop and halt application
            WorldManager.StopWorld();
            // wait for world to end
            while (WorldManager.WorldActive)
            {
                // no nothing
            }

            // write exit to console/log
            log.Warn($"Exiting at {DateTime.UtcNow}");
            // system exit
            System.Environment.Exit(System.Environment.ExitCode);
        }
    }
}
