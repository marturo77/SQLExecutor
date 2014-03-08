using System;
using System.Collections.Generic;
using System.Text;

namespace SQLExecutor.DBHelper
{
    public class DBError:Exception 
    {
        /// <summary>
        /// 
        /// </summary>
        private int _errorCode;
        /// <summary>
        /// 
        /// </summary>
        public int ErrorCode
        {
            get { return _errorCode; }
            set { _errorCode = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        private int _lineNumber;
        /// <summary>
        /// 
        /// </summary>
        public int LineNumber
        {
            get { return _lineNumber; }
            set { _lineNumber = value; }
        }
        private string _message;
        public override string  Message
{
	get 
	{ 
		 return _message;
	}
}
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lineNumber"></param>
        /// <param name="message"></param>
        public DBError(int errorCode,int lineNumber,string message)
        {
            _errorCode = errorCode;
            _lineNumber = lineNumber;
            _message = message;
        }

    }
}
