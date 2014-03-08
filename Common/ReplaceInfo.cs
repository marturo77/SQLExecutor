using System;
using System.Collections.Generic;
using System.Text;

namespace SQLExecutor.Common
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class ReplaceInfo
    {
        /// <summary>
        /// 
        /// </summary>
        string _word;

        public string Word
        {
            get { return _word; }
            set { _word = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        string _replace;

        public string Replace
        {
            get { return _replace; }
            set { _replace = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="word"></param>
        /// <param name="?"></param>
        public ReplaceInfo()
        {
            
        }
        
    }
}
