using System;
using System.Text;
using System.IO;

namespace SQLExecutor.Data
{
    /// <summary>
    /// 
    /// </summary>
    public class Log
    {
        /// <summary>
        /// 
        /// </summary>
        private string _path;
        /// <summary>
        /// 
        /// </summary>
        public Log() 
        {
            _path = System.Reflection.Assembly.GetEntryAssembly().CodeBase.Substring(8) + ".log";
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public void Write(string data)
        {
            StreamWriter sw = new StreamWriter(_path, true);
            sw.WriteLine(data);
            sw.Close();
            sw.Dispose();
        }
        /// <summary>
        /// 
        /// </summary>
        public void Clear()
        {
            try 
            {
                System.IO.File.Delete(_path);
            }
            catch{}
        }
    }
}
