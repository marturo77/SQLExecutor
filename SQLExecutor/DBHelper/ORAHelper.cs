using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OracleClient;

namespace SQLExecutor.DBHelper
{
    internal class ORAHelper : IDBHelper
    {
        private OracleCommand _command;
        /// <summary>
        /// 
        /// </summary>
        private  OracleConnection _conn;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="conString"></param>
        public ORAHelper(string conString)
        {
            _conn = new OracleConnection(conString);
        }

        #region Miembros de IDBHelper

        public void ExecuteScript(string script)
        {
            _command = new OracleCommand(script, _conn);

            try
            {
                if (_conn.State != System.Data.ConnectionState.Open)
                {
                    _conn.Open();
                }
                _command.ExecuteNonQuery();
                _conn.Close();
            }
            catch(OracleException ex)
            {
                if (_conn.State != System.Data.ConnectionState.Closed)
                {
                    _conn.Close();
                }

                throw new DBError(ex.ErrorCode,0,ex.Message);
            }
        }

     

        #endregion
    }
}
