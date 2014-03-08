using System;
using System.Collections.Generic;
using System.Text;

namespace SQLExecutor.DBHelper
{
    /// <summary>
    /// 
    /// </summary>
    internal interface IDBHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="script"></param>
        void ExecuteScript(string script);  
    }
}
