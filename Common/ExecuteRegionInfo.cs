using System;
using System.Collections;
using System.Text;

namespace SQLExecutor.Common
{
    /// <summary>
    /// 
    /// </summary>
    public class ExecuteRegionInfo
    {
        /// <summary>
        /// 
        /// </summary>
        private string _text;
        /// <summary>
        /// 
        /// </summary>
        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }
        
        /// <summary>
        /// 
        /// </summary>
        private string _title;
        /// <summary>
        /// 
        /// </summary>
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        
        /// <summary>
        /// 
        /// </summary>        
        private int _index;
        /// <summary>
        /// 
        /// </summary>
        public int Index
        {
            get { return _index; }
            set { _index = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="title"></param>
        /// <param name="text"></param>
        public ExecuteRegionInfo() 
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return _title;
        }
        
    }    
}
