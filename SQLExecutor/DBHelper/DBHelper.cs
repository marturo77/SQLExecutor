using System;
using System.Collections.Generic;
using System.Text;

namespace SQLExecutor.DBHelper
{
    /// <summary>
    /// 
    /// </summary>
    public enum DBType
    {
        /// <summary>
        /// 
        /// </summary>
        SQLSERVER,
        /// <summary>
        /// 
        /// </summary>
        ORACLE
    }
    /// <summary>
    /// 
    /// </summary>
    internal class DBHelper
    {
        /// <summary>
        /// 
        /// </summary>
        private DBType _type;
        /// <summary>
        /// 
        /// </summary>
        private IDBHelper _helper;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connString"></param>
        /// <param name="type"></param>
        public DBHelper(string connString,DBType type)
        {
            switch (type)
            {
                case DBType.SQLSERVER:
                    _helper = new SQLHelper(connString);
                    break;
                case DBType.ORACLE:
                    _helper = new ORAHelper(connString);
                    break;                
            }            
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="script"></param>
        public void Execute(string script)
        {
            _helper.ExecuteScript(script);
        }
    }
}
