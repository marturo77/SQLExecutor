using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Specialized;
using System.Text.RegularExpressions;

namespace SQLExecutorControls
{
    /// <summary>
    /// 
    /// </summary>
    public enum MessageType
    {  
        /// <summary>
        /// 
        /// </summary>
        WRONGSERVERNAME,
        /// <summary>
        /// 
        /// </summary>
        WRONGUSERNAME,
        /// <summary>
        /// 
        /// </summary>
        CONEXIONSUCCES,      
        /// <summary>
        /// 
        /// </summary>
        CONEXIONECTIONBAD,
        /// <summary>
        /// 
        /// </summary>
        SEARCHINGSERVERS,
        /// <summary>
        /// 
        /// </summary>
        SEARCHINGDATABASES,
        /// <summary>
        /// 
        /// </summary>
        SQLDATABASETEXT,
        /// <summary>
        /// 
        /// </summary>
        ORACLEDATABASETEXT

    }
    /// <summary>
    /// 
    /// </summary>
    public class WinTools
    {
        /// <summary>
        /// Devuelve un mensaje de la aplicacion registrado en un archivo de recursos para la cultura actual de la aplicacion
        /// </summary>
        /// <param name="mType"></param>
        /// <returns></returns>
        public static string GetMessage(MessageType mType)
        {
            try
            {                
                System.Reflection.Assembly asm = System.Reflection.Assembly.GetCallingAssembly();
                System.Resources.ResourceManager rm = new System.Resources.ResourceManager("SQLExecutorControls.Properties.Resources", asm);

                return rm.GetString(mType.ToString());
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex.Message);
                return mType.ToString();
            }
        }
    }
}