using System;
using System.Collections.Generic;
using System.Text;

namespace SQLExecutor.Common
{
    public class EmailInfo
    {
        /// <summary>
        /// 
        /// </summary>
        string _to;
        /// <summary>
        /// 
        /// </summary>
        string _from;
        /// <summary>
        /// 
        /// </summary>
        string _password;
        /// <summary>
        /// 
        /// </summary>
        string _subject;
        /// <summary>
        /// 
        /// </summary>
        string _server;        
        /// <summary>
        /// 
        /// </summary>
        string _body;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="to"></param>
        /// <param name="from"></param>
        /// <param name="password"></param>
        /// <param name="subject"></param>
        /// <param name="server"></param>
        /// <param name="body"></param>
        public EmailInfo(string to,string from,string password,string subject,string server,string body)
        {
            this._to = to;
            this._from = from;
            this._password = password;
            this._subject = subject;
            this._server = server;
            this._body = body;
        }
        /// <summary>
        /// 
        /// </summary>
        public string To { get { return this._to; } }
        /// <summary>
        /// 
        /// </summary>
        public string From { get { return this._from; } }
        /// <summary>
        /// 
        /// </summary>
        public string Password { get { return this._password; } }
        /// <summary>
        /// 
        /// </summary>
        public string Subject { get { return this._subject ; } }
        /// <summary>
        /// 
        /// </summary>
        public string Server { get { return this._server; } }
        /// <summary>
        /// 
        /// </summary>
        public string Body { get { return this._body; } }
    }
}
