using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace SQLExecutorControls
{
    public partial class ConnectionBuilder : UserControl
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="engineID"></param>
        public delegate void ChangeEngineHandler(byte engineID);
        /// <summary>
        /// 
        /// </summary>
        public event ChangeEngineHandler OnChangeEngine;
        /// <summary>
        /// 
        /// </summary>
        public ConnectionBuilder()
        {
            InitializeComponent();

            this.OnChangeEngine += new ChangeEngineHandler(ConnectionBuilder_OnChangeEngine);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="engineID"></param>
        void ConnectionBuilder_OnChangeEngine(byte engineID)
        {
            
        }      
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public SQLExecutorControls.DataBaseConnectionInfo Connection
        {
            get
            {
                byte engineID = this.cmbEngine.SelectedIndex == -1 ? (byte)0 : (byte)this.cmbEngine.SelectedIndex;

                return new SQLExecutor.Common.ConnectionShema(this.cmbServer.Text, this.txtDataBase.Text, this.txtUser.Text, this.txtPassword.Text, (byte)engineID);
            }
            set {
                this.cmbEngine.SelectedIndex = value.EngineID;
                this.cmbServer.Text = value.Server;
                this.txtDataBase.Text = value.DataBase;
                this.txtUser.Text = value.UserName;
                this.txtPassword.Text = value.Password;
            }
        }   
        /// <summary>
        /// 
        /// </summary>
        /// <param name="server"></param>
        public void AddServer(string server)
        {
            this.cmbServer.Items.Add(server);
        }
        /// <summary>
        /// 
        /// </summary>
        public void ClearServers() 
        {
            this.cmbServer.Items.Clear();            
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbEngine_SelectedIndexChanged(object sender, EventArgs e)
        {
            byte engineID = this.cmbEngine.SelectedIndex == -1 ? (byte)0 : (byte)this.cmbEngine.SelectedIndex;

            this.OnChangeEngine(engineID);
        }
    }
}
