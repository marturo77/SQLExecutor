using System;
using System.Collections;
using System.Text;

namespace SQLExecutor.Common
{
    /// <summary>
    /// 
    /// </summary>
    public class ErrorInfo
    {
        /// <summary>
        /// 
        /// </summary>
        string _errorMessage;
        /// <summary>
        /// 
        /// </summary>
        int _lineNumber;
        /// <summary>
        /// 
        /// </summary>
        int _segment;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="errorMessage"></param>
        /// <param name="innerTrace"></param>
        public ErrorInfo(int linenumber,int segment,string errorMessage) 
        {
            _errorMessage = errorMessage;
            _lineNumber = linenumber;
            _segment = segment;
        }
        /// <summary>
        /// 
        /// </summary>
        public string Message 
        {
            get { return this._errorMessage; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Line
        {
            get { return this._lineNumber; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Segment
        {
            get { return this._segment; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("Linea: {0} Segmento: {1}{3}{2}",this._lineNumber,this._segment,this._errorMessage,(char)10);
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public class ErrorInfoCollection :CollectionBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < List.Count; i++)
            {
                ErrorInfo eInfo=(ErrorInfo)List[i];
                sb.Append(string.Format("{0}{1}", eInfo.ToString(), (char)10));
            }

            return sb.ToString();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        public void Add(ErrorInfo e)
        {
            List.Add(e);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public ErrorInfo this[int index] 
        {
            get { return (ErrorInfo)List[index];}
        }        
    }
}
