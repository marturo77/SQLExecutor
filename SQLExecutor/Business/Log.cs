using System;
using System.Collections.Generic;
using System.Text;

namespace SQLExecutor.Business
{
    /// <summary>
    /// 
    /// </summary>
    public class Log
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="col"></param>
        public static void Write(Common.ErrorInfoCollection col) 
        {
            Data.Log l = new SQLExecutor.Data.Log();

            for (int i = 0; i < col.Count; i++)
            {
                l.Write(col[i].Message);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public static void Reset()
        {
            new Data.Log().Clear();
        }
    }
}
