using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace SQLExecutor.Common
{
    public class FileErrorInfo
    {
        /// <summary>
        /// 
        /// </summary>
        private ErrorInfoCollection _fileErrors;
        /// <summary>
        /// 
        /// </summary>
        private string _pathFileName;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="errors"></param>
        public FileErrorInfo(string fileName,ErrorInfoCollection errors)
        {
            this._pathFileName = fileName;
            this._fileErrors = errors;
        }
        /// <summary>
        /// Nombre del documento
        /// </summary>
        public string PathFileName
        {
            get 
            { 
                return this._pathFileName; 
            } 
        }
        /// <summary>
        /// 
        /// </summary>
        public string FileName
        {
            get
            {
                return _pathFileName.Substring(_pathFileName.LastIndexOf(@"\") + 1);
            }
        }
        /// <summary>
        /// Errores del archivo
        /// </summary>
        public ErrorInfoCollection Errors 
        {
            get 
            {
                return this._fileErrors;
            }
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public class FileErrorInfoCollection : CollectionBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="f"></param>
        public void Add(FileErrorInfo f)
        {
            List.Add(f);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public FileErrorInfo this[int index]
        {
            get
            {
                return (FileErrorInfo)List[index];
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        public void Remove(int index)
        {
            List.RemoveAt(index);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            System.Text.StringBuilder sb = new StringBuilder();
            for (int i = 0; i < this.List.Count; i++) 
            {
                FileErrorInfo eInfo = (FileErrorInfo)List[i];

                sb.Append(string.Format(@"File: {0}{1}{1}{2}",eInfo.FileName.ToUpper(),(char)10,eInfo.Errors.ToString()));
            }

            return sb.ToString();
        }
    }
}
