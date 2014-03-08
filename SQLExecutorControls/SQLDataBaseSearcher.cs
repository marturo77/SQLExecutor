using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Text.RegularExpressions;
using System.IO;
using Microsoft.Win32;

namespace SQLExecutorControls
{
    /// <summary>
    /// 
    /// </summary>
    internal class SQLDataBaseSearcher
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="databases"></param>
        internal delegate void OnTerminateHandler(List<string> databases);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        internal delegate void OnErrorHandler(string message);
        /// <summary>
        /// 
        /// </summary>
        internal event OnTerminateHandler OnTerminate;
        /// <summary>
        /// 
        /// </summary>
        internal event OnErrorHandler OnError;        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="databases"></param>
        void SQLServerDataBaseSearcher_OnTerminate(List<string> databases)
        {
            
        }
        /// <summary>
        /// 
        /// </summary>
        private string _conString;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="conString"></param>
        public SQLDataBaseSearcher(string conString)
        {
            _conString = conString;
            OnTerminate += new OnTerminateHandler(SQLServerDataBaseSearcher_OnTerminate);
            OnError += new OnErrorHandler(SQLServerDataBaseSearcher_OnError);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        void SQLServerDataBaseSearcher_OnError(string message)
        {
            
        }
        /// <summary>
        /// 
        /// </summary>
        internal void StartSQL()
        {
            List<string> databases = new List<string>();
            try
            {
                using (SqlConnection sqlConx = new SqlConnection(_conString))
                {
                    sqlConx.Open();
                    DataTable tblDatabases = sqlConx.GetSchema("Databases");
                    sqlConx.Close();

                    foreach (DataRow row in tblDatabases.Rows)
                    {
                        // System.Diagnostics.Trace.WriteLine(row["database_name"]);
                        databases.Add(row["database_name"].ToString());

                    }
                }
            }
            catch(SqlException ex) 
            {
                OnError(ex.Message);
            }
            finally 
            {
                OnTerminate(databases);
            }
        }
    }
}
