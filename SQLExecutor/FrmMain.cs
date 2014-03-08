using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using SQLExecutor;
using SQLExecutorControls;
using SQLExecutor.Common;
using System.IO;
using SQLExecutor.DBHelper;

namespace SQLExecutor
{
    /// <summary>
    /// 
    /// </summary>
    public partial class FrmMain : Form
    {   
        /// <summary>
        /// 
        /// </summary>
        private DateTime _timeStart;                
        /// <summary>
        /// 
        /// </summary>
        public FrmMain()
        {
            InitializeComponent();

            #region Inicializa la tabla de archivos y de secciones (Coloca las columnas)
            this.lstFiles.Columns.Add("Archivo",300);
            this.lstFiles.Columns.Add("Resultado", 1000);


            #endregion
       
            
            

            #region Inicializa la tabla de remplazos
            System.Data.DataTable dt = new DataTable();
            dt.Columns.Add("Texto");
            dt.Columns.Add("Reemplazo");
            
            this.dgReplacements.DataSource = dt;
            #endregion  

            #region Inicializa la tabla de patrones
            System.Data.DataTable dtPattern = new DataTable();
            dtPattern.Columns.Add("Patron");
            dtPattern.Columns.Add("Reemplazo");

            this.dgPatterns.DataSource = dtPattern;
            #endregion  
        }        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdExecute_Click(object sender, EventArgs e)
        {
            this.errorDetail.Clear();
            this.lstErrors.Items.Clear();
            this.ClearTextItems();
            this.cmdExecute.Enabled = false;

            //Tiempo de inicio del proceso
            DateTime _timeStart = DateTime.Now;

            SQLExecutor.Business.SQLScript exec = null;

            //Determinar el tipo de motor de base de datos
            BdEngineType engine = (BdEngineType)this.DatabaseSelector.Connection.DbEngine;

            //Construye la cadena de conexion
            string connString = this.DatabaseSelector.Connection.ToString();

            try
            {
                //Obtiene la lista de remplazos
                List<ReplaceInfo> replacements = this.GetRemplacements();

                //Obtiene la lista de patrones                
                List<ReplaceInfo> patterns = this.GetPatterns();

                //Carga el separador dependiendo del motor de base de datos
                string separator = GetSeparator(engine);

                string []bigScript = GetScript();

                if (chkUseReplacements.Checked) 
                {
                    ApplyReplacements(bigScript);
                }

                //Crea un objeto para ejecutar las sentencias en los archivos
                exec = new Business.SQLScript(engine, connString, bigScript,this.chkStopifError.Checked);             
                
                //Guarda la intefaz para poder enviarle notificaciones                
                exec.OnScriptSuccess+=new SQLExecutor.Business.SQLScript.SuccessHandler(exec_OnScriptSuccess);
                exec.OnScriptError += new SQLExecutor.Business.SQLScript.ErrorScriptHandler(exec_OnScriptError);
                
                System.Threading.ThreadStart functionStart = new System.Threading.ThreadStart(exec.ExecuteScript);
                System.Threading.Thread tExecutor = new System.Threading.Thread(functionStart);

                //Inicia el hilo con todo el proceso
                tExecutor.Start();
                
            }
            catch (Exception ex)
            {
                //Muestra el error 
                this.ShowMessage(MessageType.ERROR_RUN_SCRIPTS, ex);
            }
            finally
            {
                //Habilita el formulario
                this.cmdExecute.Enabled = true;
            }       
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bigScript"></param>
        /// <returns></returns>
        private void ApplyReplacements(string[] script)
        {
            List<ReplaceInfo> replacements = GetRemplacements();

            List<ReplaceInfo> patterns = GetPatterns();

            for (int i = 0; i < script.Length; i++)
            {
                script[i] = Business.TextUtilities.ApplyRemplacements(script[i], replacements, patterns);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="ex"></param>
        private void ShowMessage(MessageType type, Exception ex)
        {
            string message = WinTools.GetMessage(type);
            MessageBox.Show(this, message+" "+ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        /// <summary>
        /// 
        /// </summary>
        private void ClearTextItems()
        {
            foreach (ListViewItem item in this.lstFiles.Items)
            {
                item.SubItems[1].Text = "";
                item.ImageIndex = -1;
            }


        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="errors"></param>
        void exec_OnScriptError(int index, List<DBError> errors)
        {
            Business.SQLScript.ErrorScriptHandler d = new SQLExecutor.Business.SQLScript.ErrorScriptHandler(exec_OnScriptError);
            if (this.InvokeRequired)
            {
                this.Invoke(d, new object[] { index, errors });
            }
            else
            {
                ListViewItem item = this.chkRunSelected.Checked ? this.lstFiles.CheckedItems[index] : this.lstFiles.Items[index];                
                item.SubItems[1].Text = errors[0].Message;
                item.ImageIndex = 0;
                
                string fileName;

                ListViewItem errItem = null;

                foreach (DBError e in errors)
                {   
                    fileName = item.Text;
                    string[] data = new string[] { fileName, e.Message };

                    //Adiciona el error en la lista
                    errItem = new ListViewItem(data);
                    errItem.Tag = new ErrorInfo(e.LineNumber, 0, e.Message);
                    errItem.ImageIndex = 0;
                    this.lstErrors.Items.Add(errItem);
                }                                
            }             
        }        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string []GetScript()
        {
            List<string> sb = new List<string>();

            StreamReader sr = null;
            foreach (ListViewItem item in this.lstFiles.Items) 
            {
                FileItemInfo fInfo = (FileItemInfo)item.Tag;

                sr = new StreamReader(fInfo.PathFileName);

                string script = sr.ReadToEnd();

                if (this.chkUseReplacements.Checked)                 
                {
                    script = Business.TextUtilities.ApplyRemplacements(script, GetRemplacements(), GetPatterns());
                }

                sr.Close();
                sr.Dispose();


                if (this.chkRunSelected.Checked)
                {
                    if (item.Checked)
                    {
                        sb.Add(script);
                    }
                }
                else sb.Add(script);
            }

            return sb.ToArray();
        }    
        /// <summary>
        /// 
        /// </summary>
        /// <param name="engine"></param>
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
        /// <returns></returns>
        public List<ReplaceInfo> GetPatterns()
        {
            List<ReplaceInfo> lst = new List<ReplaceInfo>();

            ReplaceInfo l=null;
            foreach (DataGridViewRow row in dgPatterns.Rows)
            {
                if (row.Cells[0].Value != null && row.Cells[1].Value != null)
                {
                    try
                    {
                        l = new ReplaceInfo();
                        l.Word = (string)row.Cells[0].Value;
                        l.Replace = (string)row.Cells[1].Value;
                        lst.Add(l);
                    }
                    catch { }
                }
            }
            
            return lst;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<ReplaceInfo> GetRemplacements()
        {
            List<ReplaceInfo> lst = new List<ReplaceInfo>();

            ReplaceInfo l = null;
            foreach (DataGridViewRow row in dgReplacements.Rows)
            {
                if (row.Cells[0].Value != null && row.Cells[1].Value != null)
                {
                    try
                    {
                        l = new ReplaceInfo();
                        l.Word = (string)row.Cells[0].Value;
                        l.Replace = (string)row.Cells[1].Value;
                        lst.Add(l);
                    }
                    catch { }
                }
            }

            return lst;
        }        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="message"></param>
        private void exec_OnScriptSuccess(int index, string message)
        {
            Business.SQLScript.SuccessHandler d = new SQLExecutor.Business.SQLScript.SuccessHandler(exec_OnScriptSuccess);
            if (this.InvokeRequired) 
            {
                this.Invoke(d, new object[] { index, message });
            }

            else 
            {
                ListViewItem item = this.chkRunSelected.Checked ? this.lstFiles.CheckedItems[index] : this.lstFiles.Items[index];                
                item.SubItems[1].Text = message;

                item.ImageIndex = 1;
            }           
        }        
        /// <summary>
        /// 
        /// </summary>
        private void exec_OnTerminate()
        {
            if (this.InvokeRequired)
            {
                //StateEvent d = new StateEvent(exec_OnTerminate);
                //this.Invoke(d, new object[] {});

            }
            else 
            {
                this.cmdExecute.Enabled = true;                
                TimeSpan ts = DateTime.Now - _timeStart;
                this.lblResults.Text = string.Format("Tiempo Ejecucion {0:0.00} seg", ts.TotalSeconds);
                MessageBox.Show(this, "Operation Terminada", "Finalizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }   
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstFiles_SelectedIndexChanged(object sender, EventArgs e)
        {

            //UserServices.Main.ShowFileDetails(this);
            
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdDel_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)this.dgReplacements.DataSource;

            if (dt != null && dt.Rows.Count>0)
            {
                dt.Rows.RemoveAt(dt.Rows.Count - 1);
                dt.AcceptChanges();               

                this.dgReplacements.DataSource = dt;
            }

        }          
        /// <summary>
        /// 
        /// </summary>
        /// <param name="findText"></param>
        /// <param name="replaceText"></param>
        private void AddReplace(string findText, string replaceText)
        {
            DataTable dt = (DataTable)dgReplacements.DataSource;
            DataRow dr = dt.NewRow();

            dr[0] = findText;
            dr[1] = replaceText;

            dt.Rows.Add(dr);

            dgReplacements.DataSource = dt;

            //Reajusta la columna de remplazos
            this.dgReplacements.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtStatement_MouseUp(object sender, MouseEventArgs e)
        {
            /*
            int selectionLenght = txtStatement.SelectedText.Length;

            if (e.Button == MouseButtons.Left && selectionLenght > 0)
            {
                this.menuActions.Show(this.txtStatement, e.Location);

                this.menuActions.ItemClicked += new ToolStripItemClickedEventHandler(menuActions_ItemClicked);
            }
             */ 
        }     
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgReplacements_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            this.dgReplacements.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgReplacements_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            this.dgReplacements.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }                          
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstFiles_Click(object sender, EventArgs e)
        {

        }        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstFiles_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.lstFiles.SelectedItems.Count > 0)
            {
                FrmSQLFile winSQLFile = new FrmSQLFile();
                FileItemInfo fInfo = (FileItemInfo)this.lstFiles.SelectedItems[0].Tag;
                winSQLFile.LoadFile(fInfo,this.DatabaseSelector.Connection);
                winSQLFile.ShowDialog(this);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdSelectFolder_Click(object sender, EventArgs e)
        {
            DialogResult result = this.folderBrowserDialog.ShowDialog(this);

            if (result == DialogResult.OK)
            {
                this.txtPath.Text = this.folderBrowserDialog.SelectedPath;
                LoadFiles();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        private void LoadFiles()
        {
            if (Directory.Exists(this.txtPath.Text))
            {
                string[] files;
                try
                {
                    files = System.IO.Directory.GetFiles(this.txtPath.Text, this.txtFilter.Text);
                }
                catch
                {
                    return;
                }
                
                string fileName;

                this.lstFiles.Items.Clear();
                for (int i = 0; i < files.Length; i++)
                {
                    fileName = files[i].Substring(files[i].LastIndexOf("\\") + 1);

                    string[] data = new string[] { fileName,"" };

                    ListViewItem item = new ListViewItem(data);                    

                    item.Tag = new FileItemInfo(i, files[i], null);

                    this.lstFiles.Items.Add(item);
                }


                //Coloca el estado del formulario
                this.lblResults.Text = this.lstFiles.Items.Count.ToString() + " Archivo(s)";
            }

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdSelectAll_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < this.lstFiles.Items.Count; i++)
            {
                this.lstFiles.Items[i].StateImageIndex = 1;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdSelectNone_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.lstFiles.Items.Count; i++)
            {
                this.lstFiles.Items[i].StateImageIndex = 0;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtFilter_Leave(object sender, EventArgs e)
        {
            LoadFiles();
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
        private void lstErrors_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lstErrors.SelectedItems.Count > 0)
            {
                ErrorInfo error = (ErrorInfo)this.lstErrors.SelectedItems[0].Tag;

                this.errorDetail.SetError(this.lstErrors.SelectedItems[0].Text, error);
            }

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog.Filter = "*.con|*.con";
                DialogResult response = openFileDialog.ShowDialog();

                if (response == DialogResult.OK)
                {
                    this.DatabaseSelector.Connection = (SQLExecutorControls.DataBaseConnectionInfo)WinTools.DeserializeFromFile(openFileDialog.FileName);
                }
            }
            catch(Exception ex) 
            {
                ShowMessage(MessageType.ERROROPENCONNECTION, ex);
            }

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog.Filter = "*.con|*.con";
                DialogResult response = saveFileDialog.ShowDialog();

                if (response == DialogResult.OK)
                {
                    WinTools.SerializeToFile(saveFileDialog.FileName, this.DatabaseSelector.Connection);
                }
            }
            catch (Exception ex)
            {
                ShowMessage(MessageType.ERRORSAVECONNECTION, ex);
            }
            
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void abrirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog.Filter = "*.rep|*.rep";
                DialogResult response = openFileDialog.ShowDialog();

                if (response == DialogResult.OK)
                {
                    List<ReplaceInfo> replacements = (List<ReplaceInfo>)WinTools.DeserializeFromFile(openFileDialog.FileName);

                    DataTable dt = new DataTable();
                    dt.Columns.Add("Patron");
                    dt.Columns.Add("Reemplazo");

                    DataRow dr = null;
                    foreach (ReplaceInfo rInfo in replacements)
                    {
                        dr = dt.NewRow();
                        dr[0] = rInfo.Word;
                        dr[1] = rInfo.Replace;

                        dt.Rows.Add(dr);
                    }

                    this.dgReplacements.DataSource = dt;
                 
                }
            }
            catch (Exception ex)
            {
                ShowMessage(MessageType.ERROROPENREPLACEMENT, ex);
            }

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void guardarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog.Filter = "*.rep|*.rep";
                DialogResult response = saveFileDialog.ShowDialog();

                if (response == DialogResult.OK)
                {
                    WinTools.SerializeToFile(saveFileDialog.FileName, GetRemplacements());
                }
            }
            catch (Exception ex)
            {
                ShowMessage(MessageType.ERRORSAVEREPLACEMENT, ex);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cargarExpresionesRegularesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog.Filter = "*.exp|*.exp";
                DialogResult response = openFileDialog.ShowDialog();

                if (response == DialogResult.OK)
                {
                    List<ReplaceInfo> replacements = (List<ReplaceInfo>)WinTools.DeserializeFromFile(openFileDialog.FileName);

                    DataTable dt = new DataTable();
                    dt.Columns.Add("Patron");
                    dt.Columns.Add("Reemplazo");

                    DataRow dr = null;
                    foreach (ReplaceInfo rInfo in replacements)
                    {
                        dr = dt.NewRow();
                        dr[0] = rInfo.Word;
                        dr[1] = rInfo.Replace;

                        dt.Rows.Add(dr);
                    }

                    this.dgPatterns.DataSource = dt;

                }
            }
            catch (Exception ex)
            {
                ShowMessage(MessageType.ERROROPENREPLACEMENT, ex);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void guardarExpresionesRegularesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog.Filter = "*.exp|*.exp";
                DialogResult response = saveFileDialog.ShowDialog();

                if (response == DialogResult.OK)
                {
                    WinTools.SerializeToFile(saveFileDialog.FileName, GetPatterns());
                }
            }
            catch (Exception ex)
            {
                ShowMessage(MessageType.ERRORSAVEREPLACEMENT, ex);
            }
        }        
    }
}

