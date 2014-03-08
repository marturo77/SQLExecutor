using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using SQLExecutor.Common;

namespace SQLExecutorControls
{
    /// <summary>
    /// 
    /// </summary>
    public partial class ErrorDetail : UserControl
    {
        /// <summary>
        /// 
        /// </summary>
        public ErrorDetail()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="err"></param>
        public void SetError(string scriptName,ErrorInfo err)
        {
            this.lblTitle.Text = scriptName;
            this.lblLine.Text = err.Line.ToString();
            this.txtDetail.Text = err.Message;
        }
        /// <summary>
        /// 
        /// </summary>
        public void Clear() 
        {
            this.txtDetail.Text = "";
            this.lblLine.Text = "";
            this.lblTitle.Text = "";
        }
    }
}
