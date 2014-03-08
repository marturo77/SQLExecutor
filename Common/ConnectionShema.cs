using System;
using System.Collections.Generic;
using System.Text;

namespace SQLExecutor.Common
{
    [Serializable]
    public class ConnectionShema
    {
        /// <summary>
        /// 
        /// </summary>
        private string _server;
        /// <summary>
        /// 
        /// </summary>
        private string _database;
        /// <summary>
        /// 
        /// </summary>
        private string _userName;
        /// <summary>
        /// 
        /// </summary>
        private string _password;
        /// <summary>
        /// 
        /// </summary>
        private byte _engine;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="server"></param>
        /// <param name="database"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="engine"></param>
        public ConnectionShema(string server,string database,string username, string password,byte engineId) 
        {
            this._server = server;
            this._database = database;
            this._userName = username;
            this._password = password;
            this._engine = engineId;
        }

        /// <summary>
        /// 
        /// </summary>
        public string Server { get { return this._server; } }
        /// <summary>
        /// 
        /// </summary>
        public string DataBase { get { return this._database; } }
        /// <summary>
        /// 
        /// </summary>
        public string UserName { get { return this._userName; } }
        /// <summary>
        /// 
        /// </summary>
        public string Password { get { return this._password; } }
        /// <summary>
        /// 
        /// </summary>
        public byte EngineID{ get { return this._engine; } }

    }
}
