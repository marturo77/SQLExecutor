using System;
using System.Text;

namespace SQLExecutor.Data
{
    /// <summary>
    /// 
    /// </summary>
    public class DBExecutor
    {
        private DBHelper.DBHelper _helper;
        
        /// <summary>
        /// 
        /// </summary>
        public DBExecutor(string connectionString,DBHelper.DBType type) 
        {
            _helper = new DBHelper.DBHelper(connectionString, type);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="statement"></param>
        public void ExecuteStatement(string statement)
        {
            _helper.Execute(statement);
        }
    }
}
