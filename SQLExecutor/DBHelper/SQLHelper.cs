using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace SQLExecutor.DBHelper
{
    internal class SQLHelper : IDBHelper
    {        
        /// <summary>
        /// 
        /// </summary>
        private SqlCommand _command;
        /// <summary>
        /// 
        /// </summary>
        private SqlConnection _conn;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="conString"></param>
        public SQLHelper(string conString)
        {   
            _conn = new SqlConnection(conString);
        }

        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="script"></param>
        public void ExecuteScript(string script)
        {
            try
            {
                _command = new SqlCommand(script, _conn);

                _conn.Open();
                _command.ExecuteNonQuery();                
            }
            catch (SqlException ex)
            {
                throw new DBError(ex.ErrorCode, ex.LineNumber, ex.Message);
            }

            finally 
            {
                if (_conn.State != System.Data.ConnectionState.Closed)
                {
                    _conn.Close();
                }
            }

        }        
    }
}
