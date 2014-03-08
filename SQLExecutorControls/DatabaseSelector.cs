using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace SQLExecutorControls
{
    /// <summary>
    /// 
    /// </summary>
    public partial class DatabaseSelector : UserControl
    {
        /// <summary>
        /// 
        /// </summary>
        private bool _locked = false;

        /// <summary>
        /// 
        /// </summary>
        public DatabaseSelector()
        {
            InitializeComponent();
        }

        #region DataBase Connection
        /// <summary>
        /// 
        /// </summary>
        public DataBaseConnectionInfo Connection
        {
            get
            {
                DataBaseConnectionInfo conn = new DataBaseConnectionInfo();

                conn.Database = this.cmbDataBaseName.Text;
                conn.DbEngine = this.cmbServerType.SelectedIndex == 0 ? BdEngineType.MSSQL : BdEngineType.ORACLE;
                conn.Server = this.cmbServerName.Text;
                conn.UserName = this.txtUserName.Text;
                conn.Password = this.txtPassword.Text;

                return conn;
            }
            set
            {
                if (value != null)
                {
                    this._locked = true;
                    this.cmbServerType.SelectedIndex = value.DbEngine == BdEngineType.MSSQL ? 0 : 1;

                    this.cmbDataBaseName.Text = value.Database;
                    this.cmbServerName.Text = value.Server;
                    this.txtUserName.Text = value.UserName;
                    this.txtPassword.Text = value.Password;
                    this.cmbDataBaseName.Visible = value.DbEngine == BdEngineType.MSSQL ? true : false;
                    this.lblDatabaseName.Visible = value.DbEngine == BdEngineType.MSSQL ? true : false;
                    this._locked = false;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdTest_Click(object sender, EventArgs e)
        {
            string msg = "";

            //Prueba la cadena de conexion
            if (this.TestConnString(this.Connection, out msg))
            {
                msg = WinTools.GetMessage(MessageType.CONEXIONSUCCES);

                MessageBox.Show(this, msg, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(this, msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Prueba una cadena de conexion
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="errMessage"></param>
        /// <returns></returns>
        private bool TestConnString(DataBaseConnectionInfo conn, out string errMessage)
        {
            errMessage = "";

            //Algoritmo pesimista solo permite las cadenas de conexion que esten correctas
            bool isOK = false;

            switch (conn.DbEngine)
            {
                case BdEngineType.MSSQL:
                    #region Probar la cadena sql server
                    Microsoft.Practices.EnterpriseLibrary.Data.Sql.SqlDatabase sqlDB;
                    try
                    {
                        sqlDB = new Microsoft.Practices.EnterpriseLibrary.Data.Sql.SqlDatabase(conn.ToString());

                        //sentencia de prueba, debe funcionar en todas las versiones de sql server
                        sqlDB.ExecuteNonQuery(CommandType.Text, "SELECT GETDATE()");
                        isOK = true;
                    }
                    catch (Exception ex)
                    {
                        errMessage = ex.Message;
                    }
                    #endregion
                    break;
                case BdEngineType.ORACLE:
                    #region Prueba de conexion con Oracle
                    Microsoft.Practices.EnterpriseLibrary.Data.Oracle.OracleDatabase oraDB;
                    try
                    {
                        oraDB = new Microsoft.Practices.EnterpriseLibrary.Data.Oracle.OracleDatabase(conn.ToString());

                        //Sentencia de prueba para oracle, debe funcionar en todas las versiones de oracle
                        oraDB.ExecuteNonQuery(CommandType.Text, "SELECT SYSDATE FROM DUAL");

                        isOK = true;
                    }
                    catch (Exception ex)
                    {
                        errMessage = ex.Message;
                    }
                    #endregion
                    break;
            }

            return isOK;
        }
        #endregion

        #region Render Servers o TSN
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbServerType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this._locked)
            {
                this.ClearData();
                this.ListServers();
            }
        }       
        /// <summary>
        /// 
        /// </summary>
        private void ListServers()
        {   
            this.lblMessage.Visible = true;

            ServerSearcher sFinder = new ServerSearcher();
            sFinder.OnTerminate += new ServerSearcher.OnTerminateHandler(sFinder_OnTerminate);
            sFinder.OnError += new ServerSearcher.OnErrorHandler(sFinder_OnError);

            ThreadStart tStart = null;

            switch (this.cmbServerType.SelectedIndex)
            {
                case 0:
                    this.lblMessage.Text = WinTools.GetMessage(MessageType.SEARCHINGSERVERS);
                    this.lblServer.Text = WinTools.GetMessage(MessageType.SQLDATABASETEXT);
                    this.cmbDataBaseName.Visible = true;
                    this.lblDatabaseName.Visible = true;
                    tStart = new ThreadStart(sFinder.StartSQL);
                    break;
                case 1:
                    this.lblMessage.Text = "TSN";                    
                    this.lblServer.Text = WinTools.GetMessage(MessageType.ORACLEDATABASETEXT);
                    this.cmbDataBaseName.Visible = false;
                    this.lblDatabaseName.Visible = false;
                    tStart = new ThreadStart(sFinder.StartORACLE);
                    break;
            }

            this.cmbServerType.Enabled = false;
            Thread p = new Thread(tStart);

            p.Start();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        void sFinder_OnError(string message)
        {
            MessageBox.Show(message);        
        }       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="servers"></param>
        void sFinder_OnTerminate(List<string> servers)
        {
            this.RenderServers(servers);            
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="servers"></param>
        private void RenderServers(List<string> servers)
        {
            //Revisar aca esta el error
            if (this.InvokeRequired)
            {
                ServerSearcher.OnTerminateHandler d = new ServerSearcher.OnTerminateHandler(RenderServers);

                this.Invoke(d, new object[] { servers });
            }
            else
            {
                try
                {
                    this.cmbServerType.Enabled = true;
                    
                    this.lblMessage.Visible = false;

                    this.cmbServerName.Items.Clear();
                    this.cmbServerName.Items.AddRange(servers.ToArray());
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine(ex.Message);
                }

            }
        }
        #endregion

        #region Render Databases (Unicamente en SQLServer)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbServerName_Leave(object sender, EventArgs e)
        {
            //Unicamente en SQL Server
            if (this.cmbServerName.Text.Length > 0 && this.cmbServerType.SelectedIndex == 0)
            {
                this.ListDataBases();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        private void ListDataBases()
        {
            if (!_locked)
            {
                _locked = true;

                this.cmbDataBaseName.Items.Clear();
                this.cmbDataBaseName.Text = "";

                

                SQLDataBaseSearcher databaseFinder = new SQLDataBaseSearcher(this.Connection.ToString());
                databaseFinder.OnTerminate += new SQLDataBaseSearcher.OnTerminateHandler(databaseFinder_OnTerminate);
                databaseFinder.OnError += new SQLDataBaseSearcher.OnErrorHandler(databaseFinder_OnError);

                //Lista base de datos si hay nombre de servidor, si no hay un proceso corriendo
                //y si hay nombre de servidor escrito
                this.lblMessage.Visible = true;
                this.lblMessage.Text = WinTools.GetMessage(MessageType.SEARCHINGDATABASES);

                ThreadStart tStart = new ThreadStart(databaseFinder.StartSQL);

                Thread p = new Thread(tStart);
                p.Start();

            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        void databaseFinder_OnError(string message)
        {
            MessageBox.Show(message);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="databases"></param>
        void databaseFinder_OnTerminate(List<string> databases)
        {
            this.RenderDataBases(databases);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="databases"></param>
        private void RenderDataBases(List<string> databases)
        {
            if (this.InvokeRequired)
            {
                SQLDataBaseSearcher.OnTerminateHandler d = new SQLDataBaseSearcher.OnTerminateHandler(RenderDataBases);

                this.Invoke(d, new object[] { databases });
            }
            else
            {   
                
                this.lblMessage.Visible = false;

                this.cmbDataBaseName.Items.Clear();
                this.cmbDataBaseName.Items.AddRange(databases.ToArray());

                _locked = false;

            }
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        private void ClearData()
        {
            this.txtPassword.Text = "";
            this.txtUserName.Text = "";

            this.cmbDataBaseName.Items.Clear();
            this.cmbServerName.Items.Clear();

            this.cmbDataBaseName.Text = "";
            this.cmbServerName.Text = "";
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DatabaseSelector_Load(object sender, EventArgs e)
        {
            if (!this._locked)
            {
                this.ClearData();
                this.ListServers();
            }
        }

    }
}
