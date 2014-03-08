using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Microsoft.Win32;
using System.IO;
using System.Text.RegularExpressions;
using System.Data.Sql;

namespace SQLExecutorControls
{
    internal class ServerSearcher
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="servers"></param>
        internal delegate void OnTerminateHandler(List<string> servers);
        /// <summary>
        /// 
        /// </summary>
        internal event OnTerminateHandler OnTerminate;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="?"></param>
        internal delegate void OnErrorHandler(string message);
        /// <summary>
        /// 
        /// </summary>
        internal event OnErrorHandler OnError;
        /// <summary>
        /// 
        /// </summary>
        public ServerSearcher()
        {
            OnTerminate += new OnTerminateHandler(ServerSearcher_OnTerminate);
            OnError += new OnErrorHandler(ServerSearcher_OnError);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        void ServerSearcher_OnError(string message)
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="servers"></param>
        void ServerSearcher_OnTerminate(List<string> servers)
        {

        }
        /// <summary>
        /// 
        /// </summary>
        public void StartSQL()
        {
            List<string> list = new List<string>();
            try
            {
                DataTable servers = SqlDataSourceEnumerator.Instance.GetDataSources();

                for (int i = 0; i < servers.Rows.Count; i++)
                {
                    if ((servers.Rows[i]["InstanceName"] as string) != null)

                        list.Add(servers.Rows[i]["ServerName"] + "\\" + servers.Rows[i]["InstanceName"]);
                    else
                        list.Add(servers.Rows[i]["ServerName"].ToString());

                }

            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex.Message);
                OnError(ex.Message);
            }
            finally
            {
                OnTerminate(list);
            }

        }
        /// <summary>
        /// 
        /// </summary>
        public void StartORACLE()
        {
            List<string> list = new List<string>();

            try
            {
                RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\ORACLE\HOME0", false);

                if (key != null)
                {
                    key.GetValue("ORACLE_HOME");
                    string ruta = Convert.ToString(key.GetValue("ORACLE_HOME"));
                    ruta = ruta + "\\network\\admin\\tnsnames.ora";

                    FileInfo fileInfo = new FileInfo(ruta);
                    string cad;
                    if (fileInfo.Exists)
                    {
                        // Read content all file 
                        FileStream stream = new FileStream(ruta, FileMode.Open, FileAccess.Read);
                        StreamReader reader = new StreamReader(stream);
                        // Read file, line for line
                        while (reader.Peek() > 0)
                        {
                            cad = reader.ReadLine().ToString();
                            if (cad.Trim() != "")
                            {
                                //Verified that is not comment line 
                                if (cad.Contains("#") == true)
                                {
                                    cad = cad;
                                }
                                else
                                {
                                    string InputText = cad.Trim();
                                    // Variable than evaluate regurar expression
                                    Regex exp = new Regex(@"([^=\s*]*)", RegexOptions.IgnoreCase);
                                    //The MatchCollection class stores a list of successful matches found by applying the regular expression pattern to an input string. 
                                    MatchCollection MatchList = exp.Matches(InputText);
                                    Match FirstMatch = MatchList[0];
                                    string cadena = FirstMatch.Value;
                                    if ((cadena.Trim().Contains("(") == true) || (cadena.Trim().Contains(")") == true))
                                    {
                                        cadena = cadena;
                                    }
                                    else
                                    {
                                        if (cadena != "")
                                        {
                                            list.Add(FirstMatch.Value);
                                        }
                                    }
                                }
                            }
                        }

                        reader.Close();
                        reader.Dispose();
                        stream.Close();
                        stream.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                OnError(ex.Message);
                System.Diagnostics.Trace.WriteLine(ex.Message);
            }
            finally
            {
                OnTerminate(list);
            }
        }
    }
}
