using System;
using System.Text;
using SQLExecutorControls;

namespace SQLExecutor.Data
{
    /// <summary>
    /// 
    /// </summary>
    public class Connection
    {
        /// <summary>
        /// 
        /// </summary>
        public static string _connectionString;
        /// <summary>
        /// 
        /// </summary>
        public static BdEngineType _engine; 
        /// <summary>
        /// 
        /// </summary>
        /// <param name="engine"></param>
        /// <param name="connectionString"></param>
        public static void SetHelper(BdEngineType engine, string connectionString) 
        {
            _engine = engine;

            _connectionString = connectionString;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static CreateHelper() 
        {
            DBEngine hengine = DBEngine.NONE;

            switch (_engine)
            {
                case BdEngineType.MSSQL:
                    hengine = DBEngine.MSSQLSERVER_2005;
                    break;
                case BdEngineType.ORACLE:
                    hengine = DBEngine.ORACLE;
                    break;                
                default:
                    hengine = DBEngine.NONE;

                    break;
            }
            return DBFactory.CreateHelper(hengine, _connectionString);
        }

    }
}
