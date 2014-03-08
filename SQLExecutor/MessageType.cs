using System;
using System.Collections.Generic;
using System.Text;

namespace SQLExecutor
{
    /// <summary>
    /// 
    /// </summary>
    internal enum MessageType:int
    {
        /// <summary>
        /// 
        /// </summary>
        ERROR_RUN_SCRIPTS,
        /// <summary>
        /// 
        /// </summary>
        ERROROPENCONNECTION,
        /// <summary>
        /// 
        /// </summary>
        ERRORSAVECONNECTION,
        /// <summary>
        /// 
        /// </summary>
        ERROROPENREPLACEMENT,
        /// <summary>
        /// 
        /// </summary>
        ERRORSAVEREPLACEMENT
    }
}
