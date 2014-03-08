using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SQLExecutor
{
    /// <summary>
    /// 
    /// </summary>
    public partial class FrmInputBox : Form
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="title"></param>
        public FrmInputBox(string title)
        {
            InitializeComponent();

            this.lblTitle.Text = title;
        }
        /// <summary>
        /// 
        /// </summary>
        public string InputText 
        {
            get 
            {
                return this.textBox.Text;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        protected string Title
        {
            set
            {
                this.lblTitle.Text = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdAccept_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmInputBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }  
    }
}