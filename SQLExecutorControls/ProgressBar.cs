using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace SQLExecutorControls
{
    /// <summary>
    /// 
    /// </summary>
    public partial class ProgressBar : UserControl
    {
        /// <summary>
        /// 
        /// </summary>
        private Font _font;
        /// <summary>
        /// 
        /// </summary>
        private float _percent;        
        /// <summary>
        /// 
        /// </summary>
        public ProgressBar()
        {
            InitializeComponent();            
            
            this._font = new Font(FontFamily.GenericSerif,30f,FontStyle.Bold);
            
        }
        /// <summary>
        /// 
        /// </summary>        
        public float Percent 
        {
            set 
            {
                this._percent = value;
                this.Refresh();
            }
            get { return this._percent; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Font CenterFont 
        {
            get { return this._font; }
            set { this._font = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomProgressBar_Paint(object sender, PaintEventArgs e)
        {
            //Calculo del angulo            
            float endAngle = this._percent * 360 / 100;

            //Le quita 10 grados
            float startAngle = endAngle - 10;

            float w=(float)(this.Width*0.9f);

            float h=(float)(this.Height*0.9f);

            //Dibuja el pastel completo
            e.Graphics.DrawPie(Pens.DarkBlue, 0, 0, w+1, h+1, 0, 360);            

            e.Graphics.FillPie(Brushes.Gainsboro, 0, 0, w, h, 0, endAngle);
            
            //Dibuja el porcentaje que lleva
            e.Graphics.DrawString(_percent.ToString()+" %",this._font, Brushes.DarkBlue, this.Width / 2, this.Height / 2);
            
        }
    }
}
