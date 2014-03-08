using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using SQLExecutorControls;
using SQLExecutor.Common;
using SQLExecutor.DBHelper;

namespace SQLExecutor.Business
{

    /// <summary>
    /// 
    /// </summary>
    public class SQLScript
    {   
        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg"></param>
        public delegate void SuccessHandler(int index,string msg);
        /// <summary>
        /// 
        /// </summary>
        public event SuccessHandler OnScriptSuccess;
        /// <summary>
        /// 
        /// </summary>
        public event SuccessHandler OnBlockSuccess;

        public delegate void ErrorScriptHandler(int index, List<DBError> error);
        /// <summary>
        /// 
        /// </summary>
        public event ErrorScriptHandler OnScriptError;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="error"></param>
        public delegate void ErrorBlockHandler(DBError error);
        /// <summary>
        /// 
        /// </summary>
        public event ErrorBlockHandler OnBlockError;

        /// <summary>
        /// 
        /// </summary>
        private DBHelper.DBType _type;

        /// <summary>
        /// 
        /// </summary>
        private string _connString;
        /// <summary>
        /// 
        /// </summary>
        private string []_scripts;
        /// <summary>
        /// 
        /// </summary>
        private string _separator;
        /// <summary>
        /// 
        /// </summary>
        private bool _stopIfError;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="engine"></param>
        /// <param name="connectionstring"></param>
        public SQLScript(BdEngineType engine, string connectionstring, string []scripts,bool stopIfError)
        {
            OnScriptSuccess += new SuccessHandler(SQLScript_OnMessage);
            OnBlockError += new ErrorBlockHandler(SQLScript_OnError);
            OnBlockSuccess += new SuccessHandler(SQLScript_OnSuccessBlock);
            OnScriptError += new ErrorScriptHandler(SQLScript_OnErrorScript);

            switch (engine)
            {
                case BdEngineType.MSSQL:
                    _type = SQLExecutor.DBHelper.DBType.SQLSERVER; 
                    _separator = "^GO";
                    break;
                case BdEngineType.ORACLE:
                    _type = SQLExecutor.DBHelper.DBType.ORACLE;
                    _separator= "[\t\n\x0B\f\r]+/[ \t\n\x0B\f\r]+";                
                    break;
            }
            _connString = connectionstring;
            _scripts = scripts;
            _stopIfError = stopIfError;
            
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="error"></param>
        void SQLScript_OnErrorScript(int index, List<DBError> error)
        {
            
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="msg"></param>
        void SQLScript_OnSuccessBlock(int index, string msg)
        {
            
        }        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="script"></param>
        /// <param name="separator"></param>
        /// <param name="replacement"></param>
        /// <param name="patterns"></param>
        /// <returns></returns>
        public void ExecuteScript()
        {
            DBHelper.DBHelper _helper = new DBHelper.DBHelper(_connString, _type);

            int fileIndex = 0;

            List<DBError> errors = new List<DBError>();

            foreach (string s in _scripts)            
            {
                //Divide el script en las regiones especificadas por el separador usando una expresion regular
                List<ExecuteRegionInfo> region = Business.TextUtilities.Divide(s, _separator);
                
                errors.Clear();

                for (int i = 0; i < region.Count; i++)
                {
                    string block = region[i].Text;

                    #region Ejecuta un bloque del codigo
                    try
                    {
                        if (block.Length > 0)
                        {
                            System.Diagnostics.Trace.WriteLine("");
                            System.Diagnostics.Trace.WriteLine(block);
                            System.Diagnostics.Trace.WriteLine("");

                            //Ejecuta el script
                            _helper.Execute(block);

                            OnBlockSuccess(i, "Bloque ejecutado Correctamente " + i.ToString());
                        }
                    }
                    catch (DBError ex)
                    {                        
                        errors.Add(ex);
                        OnBlockError(ex);

                        if (_stopIfError && errors.Count > 0)
                        {
                            OnScriptError(fileIndex, errors);
                            return;
                        }
                    }
                    #endregion                    
                }

                if (errors.Count == 0)
                {
                    //lanza el evento despues de la ejecucion del la sentencia
                    OnScriptSuccess(fileIndex, "Script correcto " + fileIndex.ToString());
                }
                else
                {
                    OnScriptError(fileIndex, errors);
                }

 
                fileIndex++;
            }            
        }        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg"></param>
        void SQLScript_OnMessage(int index,string msg)
        {   
            
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="error"></param>
        void SQLScript_OnError(SQLExecutor.DBHelper.DBError error)
        {

        }          
    }

}
