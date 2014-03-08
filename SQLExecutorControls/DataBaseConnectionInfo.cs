using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace SQLExecutorControls
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public enum BdEngineType 
    { 
        /// <summary>
        /// 
        /// </summary>
        MSSQL, 
        /// <summary>
        /// 
        /// </summary>
        ORACLE, 
        /// <summary>
        /// 
        /// </summary>
        NONE 
    };

    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class DataBaseConnectionInfo
    {
        /// <summary>
        /// 
        /// </summary>
        protected string _server;
        /// <summary>
        /// 
        /// </summary>
        protected string _database;
        /// <summary>
        /// 
        /// </summary>
        protected string _userName;
        /// <summary>
        /// 
        /// </summary>
        protected string _password;
        /// <summary>
        /// 
        /// </summary>
        private BdEngineType _dbEngine;
        /// <summary>
        /// Initializes a new instance of the <see cref="DataBaseConnectionInfo"/> class.
        /// </summary>
        public DataBaseConnectionInfo()
        {

        }
        /// <summary>
        /// Initializes a new instance of the <see cref="DataBaseConnectionInfo"/> class.
        /// </summary>
        /// <param name="server">The server.</param>
        /// <param name="database">The database.</param>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <param name="dbEngine">The db engine.</param>
        public DataBaseConnectionInfo(string server, string database, string userName, string password, BdEngineType dbEngine)
        {
            this._server = server;
            this._database = database;
            this._userName = userName;
            this._password = password;
            this._dbEngine = dbEngine;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="DataBaseConnectionInfo"/> class.
        /// </summary>
        /// <param name="connStr">The conn STR.</param>
        /// <param name="engineStr">The engine STR.</param>
        public DataBaseConnectionInfo(string connStr, string engineStr)
        {
            string[] conValues = connStr.Split(';');
            string provider = engineStr.Substring(engineStr.LastIndexOf('.') + 1);

            BdEngineType engine = provider.ToUpper() == "SQLCLIENT" ? BdEngineType.MSSQL : BdEngineType.ORACLE;

            DbEngine = engine;

            switch (engine)
            {
                case BdEngineType.MSSQL:

                    Server = conValues[0].Substring(conValues[0].LastIndexOf('=') + 1);
                    Database = conValues[1].Substring(conValues[1].LastIndexOf('=') + 1);
                    UserName = conValues[2].Substring(conValues[2].LastIndexOf('=') + 1);
                    Password = conValues[3].Substring(conValues[3].LastIndexOf('=') + 1);

                    break;

                case BdEngineType.ORACLE:
                    string ser = conValues[1].Substring(conValues[1].LastIndexOf('=') + 1);
                    Server = ser;
                    UserName = conValues[0].Substring(conValues[0].LastIndexOf('=') + 1);
                    Password = conValues[2].Substring(conValues[2].LastIndexOf('=') + 1);

                    break;

                default:

                    break;
            }
        }
        /// <summary>
        /// Gets or sets the server.
        /// </summary>
        /// <value>The server.</value>
        public string Server
        {
            get { return _server; }

            set { _server = value; }
        }
        /// <summary>
        /// Gets or sets the database.
        /// </summary>
        /// <value>The database.</value>
        public string Database
        {
            get { return _database; }

            set { _database = value; }
        }
        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>The name of the user.</value>
        public string UserName
        {

            get { return _userName; }

            set { _userName = value; }

        }
        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>The password.</value>
        public string Password
        {

            get { return _password; }

            set { _password = value; }
        }
        /// <summary>
        /// Gets or sets the db engine.
        /// </summary>
        /// <value>The db engine.</value>
        public BdEngineType DbEngine
        {
            get { return _dbEngine; }

            set { _dbEngine = value; }
        }
        /// <summary>
        /// Returns a <see cref="T:System.String"></see> that represents the current <see cref="T:System.Object"></see>.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"></see> that represents the current <see cref="T:System.Object"></see>.
        /// </returns>
        override public string ToString()
        {
            if (_dbEngine == BdEngineType.MSSQL)
            {
                return "server=" + _server + ";database=" + _database + "; user id=" + _userName + "; password=" + _password;
            }
            else
            {
                if (_server == "")
                {
                    return "user id=" + _userName + ";data source=" + _database + ";password=" + _password;
                }
                else
                {
                    
                    return "user id=" + _userName + ";data source=" + _server + ";password=" + _password;
                }
            }
        }
    }
}