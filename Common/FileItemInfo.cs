using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace SQLExecutor.Common
{
    /// <summary>
    /// 
    /// </summary>
    public class FileItemInfo
    {
        /// <summary>
        /// 
        /// </summary>
        private string _fileName;
        /// <summary>
        /// 
        /// </summary>
        private int _controlPosition;
        /// <summary>
        /// 
        /// </summary>
        private Common.ErrorInfoCollection _errors;
        /// <summary>
        /// 
        /// </summary>
        public Common.ErrorInfoCollection Errors 
        {
            get { return this._errors; }
            set { this._errors = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="controlPosition"></param>
        /// <param name="fileName"></param>
        public FileItemInfo(int controlPosition, string fileName,Common.ErrorInfoCollection errors) 
        {
            this._controlPosition = controlPosition;
            this._fileName = fileName;
            this._errors = errors;
        }
        /// <summary>
        /// 
        /// </summary>
        public string PathFileName { get { return this._fileName; } }
        /// <summary>
        /// 
        /// </summary>
        public string FileName
        {
            get 
            {
                return _fileName.Substring(_fileName.LastIndexOf(@"\") + 1);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Index { get { return this._controlPosition; } }
    } 
}
