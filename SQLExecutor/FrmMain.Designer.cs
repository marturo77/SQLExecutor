namespace SQLExecutor
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.lstFiles = new System.Windows.Forms.ListView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabConnection = new System.Windows.Forms.TabPage();
            this.DatabaseSelector = new SQLExecutorControls.DatabaseSelector();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cmdSelectNone = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdSelectFolder = new System.Windows.Forms.Button();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.cmdSelectAll = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label9 = new System.Windows.Forms.Label();
            this.dgPatterns = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.dgReplacements = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.errorDetail = new SQLExecutorControls.ErrorDetail();
            this.lstErrors = new System.Windows.Forms.ListView();
            this.colFile = new System.Windows.Forms.ColumnHeader();
            this.colError = new System.Windows.Forms.ColumnHeader();
            this.chkStopifError = new System.Windows.Forms.CheckBox();
            this.chkRunSelected = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.conexionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.remplazosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cargarExpresionesRegularesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarExpresionesRegularesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblResults = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.chkUseReplacements = new System.Windows.Forms.CheckBox();
            this.dataBaseConnectionInfo1 = new SQLExecutorControls.DatabaseSelector();
            this.cmdClose = new System.Windows.Forms.Button();
            this.cmdExecute = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.tabConnection.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPatterns)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgReplacements)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstFiles
            // 
            this.lstFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstFiles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstFiles.CheckBoxes = true;
            this.lstFiles.FullRowSelect = true;
            this.lstFiles.GridLines = true;
            this.lstFiles.Location = new System.Drawing.Point(3, 45);
            this.lstFiles.MultiSelect = false;
            this.lstFiles.Name = "lstFiles";
            this.lstFiles.Size = new System.Drawing.Size(614, 363);
            this.lstFiles.SmallImageList = this.imageList;
            this.lstFiles.TabIndex = 5;
            this.lstFiles.UseCompatibleStateImageBehavior = false;
            this.lstFiles.View = System.Windows.Forms.View.Details;
            this.lstFiles.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstFiles_MouseDoubleClick);
            this.lstFiles.SelectedIndexChanged += new System.EventHandler(this.lstFiles_SelectedIndexChanged);
            this.lstFiles.Click += new System.EventHandler(this.lstFiles_Click);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "cancelar.gif");
            this.imageList.Images.SetKeyName(1, "comprobar.gif");
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabConnection);
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage3);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Location = new System.Drawing.Point(16, 38);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(633, 469);
            this.tabControl.TabIndex = 17;
            // 
            // tabConnection
            // 
            this.tabConnection.Controls.Add(this.DatabaseSelector);
            this.tabConnection.Controls.Add(this.label2);
            this.tabConnection.Location = new System.Drawing.Point(4, 22);
            this.tabConnection.Name = "tabConnection";
            this.tabConnection.Padding = new System.Windows.Forms.Padding(3);
            this.tabConnection.Size = new System.Drawing.Size(625, 443);
            this.tabConnection.TabIndex = 5;
            this.tabConnection.Text = "Conexion";
            this.tabConnection.UseVisualStyleBackColor = true;
            // 
            // DatabaseSelector
            // 
            this.DatabaseSelector.Connection = ((SQLExecutorControls.DataBaseConnectionInfo)(resources.GetObject("DatabaseSelector.Connection")));
            this.DatabaseSelector.Location = new System.Drawing.Point(29, 42);
            this.DatabaseSelector.Name = "DatabaseSelector";
            this.DatabaseSelector.Size = new System.Drawing.Size(289, 220);
            this.DatabaseSelector.TabIndex = 26;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(26, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "Conexion";
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage1.Controls.Add(this.cmdSelectNone);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.cmdSelectFolder);
            this.tabPage1.Controls.Add(this.txtFilter);
            this.tabPage1.Controls.Add(this.cmdSelectAll);
            this.tabPage1.Controls.Add(this.lstFiles);
            this.tabPage1.Controls.Add(this.txtPath);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(625, 443);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Lista de Archivos";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // cmdSelectNone
            // 
            this.cmdSelectNone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdSelectNone.Image = global::SQLExecutor.Properties.Resources.page_delete;
            this.cmdSelectNone.Location = new System.Drawing.Point(50, 414);
            this.cmdSelectNone.Name = "cmdSelectNone";
            this.cmdSelectNone.Size = new System.Drawing.Size(36, 23);
            this.cmdSelectNone.TabIndex = 27;
            this.cmdSelectNone.UseVisualStyleBackColor = true;
            this.cmdSelectNone.Click += new System.EventHandler(this.cmdSelectNone_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "Carpeta";
            // 
            // cmdSelectFolder
            // 
            this.cmdSelectFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSelectFolder.Location = new System.Drawing.Point(521, 11);
            this.cmdSelectFolder.Name = "cmdSelectFolder";
            this.cmdSelectFolder.Size = new System.Drawing.Size(40, 23);
            this.cmdSelectFolder.TabIndex = 29;
            this.cmdSelectFolder.UseVisualStyleBackColor = true;
            this.cmdSelectFolder.Click += new System.EventHandler(this.cmdSelectFolder_Click);
            // 
            // txtFilter
            // 
            this.txtFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilter.Location = new System.Drawing.Point(567, 14);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(50, 20);
            this.txtFilter.TabIndex = 30;
            this.txtFilter.Text = "*.sql";
            this.txtFilter.Leave += new System.EventHandler(this.txtFilter_Leave);
            // 
            // cmdSelectAll
            // 
            this.cmdSelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdSelectAll.Image = global::SQLExecutor.Properties.Resources.page_tick;
            this.cmdSelectAll.Location = new System.Drawing.Point(6, 414);
            this.cmdSelectAll.Name = "cmdSelectAll";
            this.cmdSelectAll.Size = new System.Drawing.Size(36, 23);
            this.cmdSelectAll.TabIndex = 26;
            this.cmdSelectAll.UseVisualStyleBackColor = true;
            this.cmdSelectAll.Click += new System.EventHandler(this.cmdSelectAll_Click);
            // 
            // txtPath
            // 
            this.txtPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPath.Location = new System.Drawing.Point(66, 14);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(449, 20);
            this.txtPath.TabIndex = 28;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Controls.Add(this.dgPatterns);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.dgReplacements);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(625, 443);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Reemplazos";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 339);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(144, 13);
            this.label9.TabIndex = 10;
            this.label9.Text = "Patrones (Expresion Regular)";
            // 
            // dgPatterns
            // 
            this.dgPatterns.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgPatterns.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPatterns.Location = new System.Drawing.Point(12, 355);
            this.dgPatterns.Name = "dgPatterns";
            this.dgPatterns.Size = new System.Drawing.Size(589, 78);
            this.dgPatterns.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Lista de Remplazos";
            // 
            // dgReplacements
            // 
            this.dgReplacements.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgReplacements.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgReplacements.Location = new System.Drawing.Point(12, 26);
            this.dgReplacements.Name = "dgReplacements";
            this.dgReplacements.Size = new System.Drawing.Size(589, 309);
            this.dgReplacements.TabIndex = 7;
            this.dgReplacements.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgReplacements_CellValueChanged);
            this.dgReplacements.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgReplacements_UserAddedRow);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.errorDetail);
            this.tabPage2.Controls.Add(this.lstErrors);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(625, 443);
            this.tabPage2.TabIndex = 6;
            this.tabPage2.Text = "Errores";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // errorDetail
            // 
            this.errorDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.errorDetail.Location = new System.Drawing.Point(15, 183);
            this.errorDetail.Name = "errorDetail";
            this.errorDetail.Size = new System.Drawing.Size(590, 254);
            this.errorDetail.TabIndex = 1;
            // 
            // lstErrors
            // 
            this.lstErrors.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstErrors.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colFile,
            this.colError});
            this.lstErrors.FullRowSelect = true;
            this.lstErrors.GridLines = true;
            this.lstErrors.Location = new System.Drawing.Point(15, 12);
            this.lstErrors.Name = "lstErrors";
            this.lstErrors.Size = new System.Drawing.Size(590, 165);
            this.lstErrors.SmallImageList = this.imageList;
            this.lstErrors.TabIndex = 0;
            this.lstErrors.UseCompatibleStateImageBehavior = false;
            this.lstErrors.View = System.Windows.Forms.View.Details;
            this.lstErrors.SelectedIndexChanged += new System.EventHandler(this.lstErrors_SelectedIndexChanged);
            // 
            // colFile
            // 
            this.colFile.Text = "Archivo";
            this.colFile.Width = 161;
            // 
            // colError
            // 
            this.colError.Text = "Error";
            this.colError.Width = 253;
            // 
            // chkStopifError
            // 
            this.chkStopifError.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkStopifError.AutoSize = true;
            this.chkStopifError.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkStopifError.Location = new System.Drawing.Point(20, 513);
            this.chkStopifError.Name = "chkStopifError";
            this.chkStopifError.Size = new System.Drawing.Size(147, 17);
            this.chkStopifError.TabIndex = 21;
            this.chkStopifError.Text = "Parar al encontrar un error";
            this.chkStopifError.UseVisualStyleBackColor = true;
            // 
            // chkRunSelected
            // 
            this.chkRunSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkRunSelected.AutoSize = true;
            this.chkRunSelected.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkRunSelected.Location = new System.Drawing.Point(20, 534);
            this.chkRunSelected.Name = "chkRunSelected";
            this.chkRunSelected.Size = new System.Drawing.Size(136, 17);
            this.chkRunSelected.TabIndex = 13;
            this.chkRunSelected.Text = "Ejecutar Seleccionados";
            this.chkRunSelected.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 8);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Extensión";
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.conexionesToolStripMenuItem,
            this.remplazosToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(661, 24);
            this.menuStrip.TabIndex = 24;
            this.menuStrip.Text = "menuStrip1";
            // 
            // conexionesToolStripMenuItem
            // 
            this.conexionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirToolStripMenuItem,
            this.guardarToolStripMenuItem});
            this.conexionesToolStripMenuItem.Name = "conexionesToolStripMenuItem";
            this.conexionesToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.conexionesToolStripMenuItem.Text = "Conexion";
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.Image = global::SQLExecutor.Properties.Resources.folder_go;
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.abrirToolStripMenuItem.Text = "Abrir...";
            this.abrirToolStripMenuItem.Click += new System.EventHandler(this.abrirToolStripMenuItem_Click);
            // 
            // guardarToolStripMenuItem
            // 
            this.guardarToolStripMenuItem.Image = global::SQLExecutor.Properties.Resources.disk;
            this.guardarToolStripMenuItem.Name = "guardarToolStripMenuItem";
            this.guardarToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.guardarToolStripMenuItem.Text = "Guardar...";
            this.guardarToolStripMenuItem.Click += new System.EventHandler(this.guardarToolStripMenuItem_Click);
            // 
            // remplazosToolStripMenuItem
            // 
            this.remplazosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirToolStripMenuItem1,
            this.guardarToolStripMenuItem1,
            this.toolStripSeparator1,
            this.cargarExpresionesRegularesToolStripMenuItem,
            this.guardarExpresionesRegularesToolStripMenuItem});
            this.remplazosToolStripMenuItem.Name = "remplazosToolStripMenuItem";
            this.remplazosToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.remplazosToolStripMenuItem.Text = "Remplazos";
            // 
            // abrirToolStripMenuItem1
            // 
            this.abrirToolStripMenuItem1.Image = global::SQLExecutor.Properties.Resources.folder_go;
            this.abrirToolStripMenuItem1.Name = "abrirToolStripMenuItem1";
            this.abrirToolStripMenuItem1.Size = new System.Drawing.Size(248, 22);
            this.abrirToolStripMenuItem1.Text = "Cargar...";
            this.abrirToolStripMenuItem1.Click += new System.EventHandler(this.abrirToolStripMenuItem1_Click);
            // 
            // guardarToolStripMenuItem1
            // 
            this.guardarToolStripMenuItem1.Image = global::SQLExecutor.Properties.Resources.disk;
            this.guardarToolStripMenuItem1.Name = "guardarToolStripMenuItem1";
            this.guardarToolStripMenuItem1.Size = new System.Drawing.Size(248, 22);
            this.guardarToolStripMenuItem1.Text = "Guardar...";
            this.guardarToolStripMenuItem1.Click += new System.EventHandler(this.guardarToolStripMenuItem1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(245, 6);
            // 
            // cargarExpresionesRegularesToolStripMenuItem
            // 
            this.cargarExpresionesRegularesToolStripMenuItem.Image = global::SQLExecutor.Properties.Resources.folder_go;
            this.cargarExpresionesRegularesToolStripMenuItem.Name = "cargarExpresionesRegularesToolStripMenuItem";
            this.cargarExpresionesRegularesToolStripMenuItem.Size = new System.Drawing.Size(248, 22);
            this.cargarExpresionesRegularesToolStripMenuItem.Text = "Cargar Expresiones Regulares...";
            this.cargarExpresionesRegularesToolStripMenuItem.Click += new System.EventHandler(this.cargarExpresionesRegularesToolStripMenuItem_Click);
            // 
            // guardarExpresionesRegularesToolStripMenuItem
            // 
            this.guardarExpresionesRegularesToolStripMenuItem.Image = global::SQLExecutor.Properties.Resources.disk;
            this.guardarExpresionesRegularesToolStripMenuItem.Name = "guardarExpresionesRegularesToolStripMenuItem";
            this.guardarExpresionesRegularesToolStripMenuItem.Size = new System.Drawing.Size(248, 22);
            this.guardarExpresionesRegularesToolStripMenuItem.Text = "Guardar Expresiones Regulares...";
            this.guardarExpresionesRegularesToolStripMenuItem.Click += new System.EventHandler(this.guardarExpresionesRegularesToolStripMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblResults,
            this.toolStripProgressBar});
            this.statusStrip.Location = new System.Drawing.Point(0, 567);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(661, 22);
            this.statusStrip.TabIndex = 25;
            this.statusStrip.Text = "statusStrip1";
            // 
            // lblResults
            // 
            this.lblResults.AutoSize = false;
            this.lblResults.BackColor = System.Drawing.Color.Transparent;
            this.lblResults.Name = "lblResults";
            this.lblResults.Size = new System.Drawing.Size(300, 17);
            // 
            // toolStripProgressBar
            // 
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            this.toolStripProgressBar.Size = new System.Drawing.Size(100, 16);
            // 
            // chkUseReplacements
            // 
            this.chkUseReplacements.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkUseReplacements.AutoSize = true;
            this.chkUseReplacements.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkUseReplacements.Location = new System.Drawing.Point(173, 513);
            this.chkUseReplacements.Name = "chkUseReplacements";
            this.chkUseReplacements.Size = new System.Drawing.Size(101, 17);
            this.chkUseReplacements.TabIndex = 28;
            this.chkUseReplacements.Text = "Usar Remplazos";
            this.chkUseReplacements.UseVisualStyleBackColor = true;
            // 
            // dataBaseConnectionInfo1
            // 
            this.dataBaseConnectionInfo1.Connection = ((SQLExecutorControls.DataBaseConnectionInfo)(resources.GetObject("dataBaseConnectionInfo1.Connection")));
            this.dataBaseConnectionInfo1.Location = new System.Drawing.Point(0, 0);
            this.dataBaseConnectionInfo1.Name = "dataBaseConnectionInfo1";
            this.dataBaseConnectionInfo1.Size = new System.Drawing.Size(320, 222);
            this.dataBaseConnectionInfo1.TabIndex = 0;
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdClose.Image = global::SQLExecutor.Properties.Resources.action_stop;
            this.cmdClose.Location = new System.Drawing.Point(512, 513);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(133, 38);
            this.cmdClose.TabIndex = 27;
            this.cmdClose.Text = "&Cerrar";
            this.cmdClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdExecute
            // 
            this.cmdExecute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdExecute.Image = global::SQLExecutor.Properties.Resources.action_go;
            this.cmdExecute.Location = new System.Drawing.Point(373, 513);
            this.cmdExecute.Name = "cmdExecute";
            this.cmdExecute.Size = new System.Drawing.Size(133, 38);
            this.cmdExecute.TabIndex = 26;
            this.cmdExecute.Text = "Ejecutar";
            this.cmdExecute.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdExecute.UseVisualStyleBackColor = true;
            this.cmdExecute.Click += new System.EventHandler(this.cmdExecute_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.CancelButton = this.cmdClose;
            this.ClientSize = new System.Drawing.Size(661, 589);
            this.Controls.Add(this.chkUseReplacements);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdExecute);
            this.Controls.Add(this.chkStopifError);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.chkRunSelected);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Name = "FrmMain";
            this.Text = "Aranda SQL Script Executor";
            this.tabControl.ResumeLayout(false);
            this.tabConnection.ResumeLayout(false);
            this.tabConnection.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPatterns)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgReplacements)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.ListView lstFiles;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView dgReplacements;
        private System.Windows.Forms.CheckBox chkRunSelected;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dgPatterns;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.CheckBox chkStopifError;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem conexionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem remplazosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem guardarToolStripMenuItem1;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblResults;
        private SQLExecutorControls.DatabaseSelector DatabaseSelector;
        private SQLExecutorControls.DatabaseSelector dataBaseConnectionInfo1;
        private System.Windows.Forms.TabPage tabConnection;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
        private System.Windows.Forms.Button cmdSelectAll;
        private System.Windows.Forms.Button cmdSelectNone;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button cmdSelectFolder;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdExecute;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.CheckBox chkUseReplacements;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListView lstErrors;
        private SQLExecutorControls.ErrorDetail errorDetail;
        private System.Windows.Forms.ColumnHeader colFile;
        private System.Windows.Forms.ColumnHeader colError;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem cargarExpresionesRegularesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarExpresionesRegularesToolStripMenuItem;

    }
}

