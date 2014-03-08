namespace SQLExecutor
{
    partial class FrmSQLFile
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSQLFile));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabFile = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.txtStatement = new SyntaxHighlighter.SyntaxRichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmdExecute = new System.Windows.Forms.Button();
            this.tabSegments = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lstSections = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.txtSection = new SyntaxHighlighter.SyntaxRichTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmdExecuteSegment = new System.Windows.Forms.Button();
            this.cmdClose = new System.Windows.Forms.Button();
            this.cmdApplyReplacements = new System.Windows.Forms.Button();
            this.cmdSaveFile = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabFile.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabSegments.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabFile);
            this.tabControl1.Controls.Add(this.tabSegments);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(776, 627);
            this.tabControl1.TabIndex = 0;
            // 
            // tabFile
            // 
            this.tabFile.Controls.Add(this.tableLayoutPanel2);
            this.tabFile.Location = new System.Drawing.Point(4, 22);
            this.tabFile.Name = "tabFile";
            this.tabFile.Padding = new System.Windows.Forms.Padding(3);
            this.tabFile.Size = new System.Drawing.Size(768, 601);
            this.tabFile.TabIndex = 0;
            this.tabFile.Text = "Archivo";
            this.tabFile.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.txtStatement, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 89.7479F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.2521F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(762, 595);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // txtStatement
            // 
            this.txtStatement.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtStatement.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtStatement.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStatement.Location = new System.Drawing.Point(3, 3);
            this.txtStatement.Name = "txtStatement";
            this.txtStatement.Size = new System.Drawing.Size(756, 528);
            this.txtStatement.TabIndex = 3;
            this.txtStatement.Text = "";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmdSaveFile);
            this.panel1.Controls.Add(this.cmdExecute);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 537);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(756, 55);
            this.panel1.TabIndex = 4;
            // 
            // cmdExecute
            // 
            this.cmdExecute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdExecute.Location = new System.Drawing.Point(624, 7);
            this.cmdExecute.Name = "cmdExecute";
            this.cmdExecute.Size = new System.Drawing.Size(122, 40);
            this.cmdExecute.TabIndex = 3;
            this.cmdExecute.Text = "&Ejecutar";
            this.cmdExecute.UseVisualStyleBackColor = true;
            this.cmdExecute.Click += new System.EventHandler(this.cmdExecute_Click);
            // 
            // tabSegments
            // 
            this.tabSegments.Controls.Add(this.tableLayoutPanel1);
            this.tabSegments.Location = new System.Drawing.Point(4, 22);
            this.tabSegments.Name = "tabSegments";
            this.tabSegments.Padding = new System.Windows.Forms.Padding(3);
            this.tabSegments.Size = new System.Drawing.Size(768, 601);
            this.tabSegments.TabIndex = 1;
            this.tabSegments.Text = "Segmentos";
            this.tabSegments.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.lstSections, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtSection, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 378F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 61F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(762, 595);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lstSections
            // 
            this.lstSections.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstSections.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lstSections.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstSections.FullRowSelect = true;
            this.lstSections.GridLines = true;
            this.lstSections.Location = new System.Drawing.Point(3, 3);
            this.lstSections.Name = "lstSections";
            this.lstSections.Size = new System.Drawing.Size(756, 150);
            this.lstSections.TabIndex = 1;
            this.lstSections.UseCompatibleStateImageBehavior = false;
            this.lstSections.View = System.Windows.Forms.View.Details;
            this.lstSections.SelectedIndexChanged += new System.EventHandler(this.lstSections_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Sentencia";
            this.columnHeader1.Width = 517;
            // 
            // txtSection
            // 
            this.txtSection.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSection.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSection.Location = new System.Drawing.Point(3, 159);
            this.txtSection.Name = "txtSection";
            this.txtSection.Size = new System.Drawing.Size(756, 372);
            this.txtSection.TabIndex = 2;
            this.txtSection.Text = "";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cmdExecuteSegment);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 537);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(756, 55);
            this.panel2.TabIndex = 3;
            // 
            // cmdExecuteSegment
            // 
            this.cmdExecuteSegment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdExecuteSegment.Location = new System.Drawing.Point(624, 8);
            this.cmdExecuteSegment.Name = "cmdExecuteSegment";
            this.cmdExecuteSegment.Size = new System.Drawing.Size(122, 40);
            this.cmdExecuteSegment.TabIndex = 4;
            this.cmdExecuteSegment.Text = "&Ejecutar  Segmento";
            this.cmdExecuteSegment.UseVisualStyleBackColor = true;
            this.cmdExecuteSegment.Click += new System.EventHandler(this.cmdExecuteSegment_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdClose.Location = new System.Drawing.Point(646, 645);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(122, 40);
            this.cmdClose.TabIndex = 2;
            this.cmdClose.Text = "&Cerrar";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdApplyReplacements
            // 
            this.cmdApplyReplacements.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdApplyReplacements.Location = new System.Drawing.Point(12, 645);
            this.cmdApplyReplacements.Name = "cmdApplyReplacements";
            this.cmdApplyReplacements.Size = new System.Drawing.Size(120, 40);
            this.cmdApplyReplacements.TabIndex = 4;
            this.cmdApplyReplacements.Text = "&Aplicar Reemplazos";
            this.cmdApplyReplacements.UseVisualStyleBackColor = true;
            this.cmdApplyReplacements.Click += new System.EventHandler(this.cmdApplyReplacements_Click);
            // 
            // cmdSaveFile
            // 
            this.cmdSaveFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSaveFile.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdSaveFile.Location = new System.Drawing.Point(496, 7);
            this.cmdSaveFile.Name = "cmdSaveFile";
            this.cmdSaveFile.Size = new System.Drawing.Size(122, 40);
            this.cmdSaveFile.TabIndex = 5;
            this.cmdSaveFile.Text = "&Guardar";
            this.cmdSaveFile.UseVisualStyleBackColor = true;
            this.cmdSaveFile.Click += new System.EventHandler(this.cmdSaveFile_Click);
            // 
            // FrmSQLFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdClose;
            this.ClientSize = new System.Drawing.Size(800, 697);
            this.Controls.Add(this.cmdApplyReplacements);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmSQLFile";
            this.Text = "FrmSQLFile";
            this.tabControl1.ResumeLayout(false);
            this.tabFile.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tabSegments.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabFile;
        private System.Windows.Forms.TabPage tabSegments;
        private SyntaxHighlighter.SyntaxRichTextBox txtStatement;
        private System.Windows.Forms.ListView lstSections;
        private SyntaxHighlighter.SyntaxRichTextBox txtSection;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.Button cmdExecute;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button cmdExecuteSegment;
        private System.Windows.Forms.Button cmdApplyReplacements;
        private System.Windows.Forms.Button cmdSaveFile;
    }
}