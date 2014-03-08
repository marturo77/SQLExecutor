using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SQLExecutor.Common;
using System.IO;
using SQLExecutorControls;

using System.Threading;
using SQLExecutor.DBHelper;

namespace SQLExecutor
{
    public partial class FrmSQLFile : Form
    {
        /// <summary>
        /// 
        /// </summary>
        delegate void StateEvent();

        /// <summary>
        /// 
        /// </summary>
        private DataBaseConnectionInfo _connection;
        /// <summary>
        /// 
        /// </summary>
        private FileItemInfo _fInfo;

        /// <summary>
        /// 
        /// </summary>
        public FrmSQLFile()
        {
            InitializeComponent();

            this.lstSections.Columns.Add("Archivo", 300);
            this.lstSections.Columns.Add("Resultado", 1000);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fInfo"></param>
        internal void LoadFile(FileItemInfo f,DataBaseConnectionInfo connection)
        {
            this._fInfo = f;

            this.Text = _fInfo.FileName;
            _connection = connection;            

            StreamReader sr = new StreamReader(_fInfo.PathFileName);

            string script = sr.ReadToEnd();
            sr.Close();
            sr.Dispose();    

            List<ExecuteRegionInfo> list = Business.TextUtilities.Divide(script, GetSeparator(_connection.DbEngine));

            this.tabSegments.Text = string.Format("Segmentos ({0})", list.Count);

            this.lstSections.Items.Clear();
            ListViewItem item;
            foreach (ExecuteRegionInfo r in list)
            {
                string[] data = new string[] {r.Title };
                item = new ListViewItem(data);
                item.Tag = r;
                this.lstSections.Items.Add(item);
            }

            this.txtStatement.Text = script;
            
                   
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bdEngineType"></param>
        /// <returns></returns>
        private string GetSeparator(BdEngineType engine)
        {
            switch (engine)
            {
                case BdEngineType.MSSQL:
                    return "^GO";                    
                case BdEngineType.ORACLE:
                    return "[\t\n\x0B\f\r]+/[ \t\n\x0B\f\r]+";                    
            }

            return "";
        }   
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstSections_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lstSections.SelectedItems.Count > 0)
            {
                ExecuteRegionInfo region = (ExecuteRegionInfo)this.lstSections.SelectedItems[0].Tag;

                this.txtSection.Text = region.Text;                                
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private List<ReplaceInfo> GetPatterns()
        {
            FrmMain winMain = (FrmMain)this.Owner;
            return winMain.GetPatterns();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private List<ReplaceInfo> GetRemplacements()
        {
            FrmMain winMain = (FrmMain)this.Owner;
            return winMain.GetRemplacements();
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="script"></param>
        /// <param name="separator"></param>
        void DivideScript(string script, string separator)
        {
            //Divide el script en los tokens segun del separador dado por la expresion regular
            List<ExecuteRegionInfo> col = Business.TextUtilities.Divide(script, separator);

            //Coloca las secciones del script
            this.lstSections.Items.Clear();
            this.txtSection.Text = "";
            for (int i = 0; i < col.Count; i++)
            {
                ListViewItem item = new ListViewItem(new string[] { col[i].Title, "" }, -1);
                item.Tag = col[i];
                this.lstSections.Items.Add(item);
            }
        }
     
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private List<ExecuteRegionInfo> GetScriptColl()
        {
            List<ExecuteRegionInfo> col = new List<ExecuteRegionInfo>();

            for (int i = 0; i < this.lstSections.Items.Count; i++)
            {
                ExecuteRegionInfo region = (ExecuteRegionInfo)this.lstSections.Items[i].Tag;

                col.Add(region);
            }

            return col;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdExecute_Click(object sender, EventArgs e)
        {   
            DialogResult result = MessageBox.Show(this, "Esta seguro de ejecutar el script?", "Advertencia", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                this.cmdExecute.Enabled = false;
                
                BdEngineType engine = (BdEngineType)_connection.DbEngine;

                //Construye la cadena de conexion
                string connString = _connection.ToString();

                Business.SQLScript bScript = new SQLExecutor.Business.SQLScript(_connection.DbEngine, connString, new string[] { this.txtStatement.Text },true);
                bScript.OnScriptSuccess += new SQLExecutor.Business.SQLScript.SuccessHandler(bScript_OnMessage);
                bScript.OnScriptError += new SQLExecutor.Business.SQLScript.ErrorScriptHandler(bScript_OnError);

                ThreadStart tStart = new ThreadStart(bScript.ExecuteScript);
                Thread t = new Thread(tStart);
                t.Start();
                
            }          
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="error"></param>
        void bScript_OnError(int index, List<DBError> errors)
        {
            if (this.InvokeRequired)
            {
                SQLExecutor.Business.SQLScript.ErrorScriptHandler d = new SQLExecutor.Business.SQLScript.ErrorScriptHandler(bScript_OnError);

                this.Invoke(d, new object[] {index, errors });
            }
            else
            {
                MessageBox.Show(this, "Error: " + errors[0].Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.cmdExecute.Enabled = true;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="msg"></param>
        void bScript_OnMessage(int index,string msg)
        {
            if (this.InvokeRequired) 
            {
                SQLExecutor.Business.SQLScript.SuccessHandler d = new SQLExecutor.Business.SQLScript.SuccessHandler(bScript_OnMessage);
                this.Invoke(d, new object[] { index, msg });
            }
            else 
            {
                this.cmdExecute.Enabled = true;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdApplyReplacements_Click(object sender, EventArgs e)
        {
            this.txtStatement.Text = Business.TextUtilities.ApplyRemplacements(this.txtStatement.Text, GetRemplacements(), GetPatterns());
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdSaveFile_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter(_fInfo.PathFileName);

            sw.Write(this.txtStatement.Text);
            sw.Close();
            sw.Dispose();

            this.Close();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdExecuteSegment_Click(object sender, EventArgs e)
        {
            SQLExecutor.Business.SQLScript bScript = new SQLExecutor.Business.SQLScript(_connection.DbEngine, _connection.ToString(), new string[] { this.txtSection.Text },true);

            bScript.OnScriptSuccess += new SQLExecutor.Business.SQLScript.SuccessHandler(bScript_OnScriptSuccess);
            bScript.OnScriptError += new SQLExecutor.Business.SQLScript.ErrorScriptHandler(bScript_OnScriptError);

            ThreadStart tStart = new ThreadStart(bScript.ExecuteScript);
            Thread t = new Thread(tStart);
            t.Start();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="error"></param>
        void bScript_OnScriptError(int index, List<DBError> error)
        {
            if (this.InvokeRequired) 
            {
                SQLExecutor.Business.SQLScript.ErrorScriptHandler d = new SQLExecutor.Business.SQLScript.ErrorScriptHandler(bScript_OnScriptError);

                this.Invoke(d, new object[] { index, error });
            }
            else
            {
                MessageBox.Show(this, "Error " + error[0].Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="msg"></param>
        void bScript_OnScriptSuccess(int index, string msg)
        {
            if (this.InvokeRequired)
            {
                SQLExecutor.Business.SQLScript.SuccessHandler d = new SQLExecutor.Business.SQLScript.SuccessHandler(bScript_OnScriptSuccess);

                this.Invoke(d, new object[] { index, msg });
            }
            else
            {
                MessageBox.Show(this, "Script ejecutado Correctamente", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}