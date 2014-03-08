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
    public partial class PolarProgress : UserControl
    {
        /// <summary>
        /// 
        /// </summary>
        public override Color ForeColor
        {
            set
            {
                this.StopThreads();
                this.Terminate();
                base.ForeColor = value;
                this.ReadTokens();
                this.StartThreads();
            }
            get
            {
                return base.ForeColor;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="status"></param>
        private void Terminate()
        {
            for (int i = 0; i < this._tokens.Count; i++)
            {   
                RenderToken t = (RenderToken)_tokens[i];
                t.Terminate = true;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        private List<RenderToken> _tokens;
        /// <summary>
        /// 
        /// </summary>
        private List<Thread> _threads;
        /// <summary>
        /// Constante para hacer la transformacion en radianes
        /// </summary>
        private double TORAD = Math.PI / 180;
        /// <summary>
        /// 
        /// </summary>
        private int _dx = 30; 
        /// <summary>
        /// 
        /// </summary>
        private Graphics _gr;
        /// <summary>
        /// 
        /// </summary>
        public PolarProgress()
        {
            InitializeComponent();

             _gr= this.CreateGraphics();

             //Lista de tokens
             _tokens = new List<RenderToken>();

             _threads = new List<Thread>(); 
           
        }
        /// <summary>
        /// 
        /// </summary>
        public void Start() 
        {
            this.ReadTokens();

            this.StartThreads();
        }
        /// <summary>
        /// 
        /// </summary>
        public void Stop()
        {
            this.StopThreads();
            this.Terminate();            

            this.Refresh();
        }
        /// <summary>
        /// 
        /// </summary>
        private void ReadTokens()
        {            
            //Borra los tokens actuales
            _tokens.Clear();

            //Tiempo de inicio de la degradacion           
            int degradationTime = 0;

            //Periodo de actualizacion del color de degradado
            int period = 1;                        

            //Ancho de la barra
            int barWidth = 2;

            //Radio inicial
            int initialRadius = (int)(this.Width * 0.1);

            //Radio final
            int finishRadium =this.Width / 3;            

            int totalTokens =(int) (360 / _dx);

            //Tasa de degradacion
            int dg = 140;

            //Calcular el periodo para el cual el hilo tiene que volver a hacer degradacion            
            int turnPeriod = totalTokens * period*dg;

            for (int angle = 0; angle <360; angle += _dx)
            {   
                degradationTime += dg;

                RadialToken config = new RadialToken(angle * TORAD, initialRadius, finishRadium,barWidth, this.ForeColor, this.BackColor, degradationTime, period);

                RenderToken token = new RenderToken(turnPeriod, config, _gr, this.Width / 2, this.Height / 2);                                
                
                _tokens.Add(token);                
            }
        }
        /// <summary>
        /// 
        /// </summary>
        private void StartThreads()
        {
            _threads.Clear();
            
            for (int i = 0; i < this._tokens.Count; i++)
            {
                ThreadStart tStart = new ThreadStart(this._tokens[i].Start);
                Thread t = new Thread(tStart);
                _threads.Add(t);
                t.Start();
            }            
        }
        /// <summary>
        /// 
        /// </summary>
        private void StopThreads()
        {   
            for (int i = 0; i < this._threads.Count; i++)
            {
                try
                {
                    Thread t = (Thread)_threads[i];                   
                    
                    t.Abort();                    
                }
                catch(Exception ex) 
                {
                    System.Diagnostics.Trace.WriteLine(ex.Message);
                }
            }
        }           
    }
    /// <summary>
    /// 
    /// </summary>
    internal class RenderToken
    {   
        /// <summary>
        /// 
        /// </summary>
        public bool Enabled
        {
            set { this._enabled = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool Terminate
        {
            set { this._terminate = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        private bool _terminate = false;
        /// <summary>
        /// 
        /// </summary>
        private int _period;
        /// <summary>
        /// 
        /// </summary>
        private bool _enabled = true;        
        /// <summary>
        /// 
        /// </summary>
        private const int DR = 3;
        /// <summary>
        /// 
        /// </summary>        
        private const int DG = 3;
        /// <summary>
        /// 
        /// </summary>
        private const int DB = 3;
        /// <summary>
        /// 
        /// </summary>
        private System.Threading.Timer _renderTimer;
        /// <summary>
        /// 
        /// </summary>
        private System.Threading.Timer _restartTimer;
        /// <summary>
        /// 
        /// </summary>
        private RadialToken _t;        
        /// <summary>
        /// 
        /// </summary>
        private Graphics _g;
        /// <summary>
        /// 
        /// </summary>
        private List<Point> _poly;
        /// <summary>
        /// 
        /// </summary>
        private Font _font;
        /// <summary>
        /// 
        /// </summary>
        private PointF _zero;
        /// <summary>
        /// 
        /// </summary>
        private Brush _drawBrush = Brushes.Black;
        /// <summary>
        /// 
        /// </summary>
        private Color _actualColor;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="token"></param>
        internal RenderToken(int restartPeriod,RadialToken t,Graphics g,int deltaX,int deltaY)
        {
            this._actualColor = t.Color;

            this._period = restartPeriod;

            _font = new Font("Courier New", 9f);            
            
            this._t = t;

            this._g = g;

            //Calcula las coordenadas en base a las coordenadas polares

            double alfa = Math.Atan(t.q / t.r1);
            double beta = Math.Atan(t.q / t.r2);

            double x1 = t.r1 * Math.Cos(t.Angle - alfa)+deltaX;
            double y1 = t.r1 * Math.Sin(t.Angle - alfa)+deltaY;
            Point p1 = new Point((int)x1, (int)y1);

            double x2 = t.r2 * Math.Cos(t.Angle - beta) + deltaX;
            double y2 = t.r2 * Math.Sin(t.Angle - beta) + deltaY;
            Point p2 = new Point((int)x2, (int)y2);

            double x3 = t.r2 * Math.Cos(t.Angle + beta) + deltaX;
            double y3 = t.r2 * Math.Sin(t.Angle + beta) + deltaY;
            Point p3 = new Point((int)x3, (int)y3);

            double x4 = t.r1 * Math.Cos(t.Angle + alfa) + deltaX;
            double y4 = t.r1 * Math.Sin(t.Angle + alfa) + deltaY;
            Point p4 = new Point((int)x4, (int)y4);
        
            //Guardar los puntos
            _poly = new List<Point>();
            _poly.Add(p1);
            _poly.Add(p2);
            _poly.Add(p3);
            _poly.Add(p4);

            _zero = new PointF(deltaX, deltaY);
        } 
        /// <summary>
        /// 
        /// </summary>
        public void Start()
        {
            #region ajuste del reloj para hacer degradacion del color
            TimerCallback callBack = new TimerCallback(OnDegradeeTimer);
            AutoResetEvent auto = new AutoResetEvent(true);

            _renderTimer = new System.Threading.Timer(callBack, auto, _t.OffSet, _t.Period);
            #endregion

            #region Reloj que determina cuando hay que volver a empezar hacer degradee
            TimerCallback callBackrestart = new TimerCallback(OnRestart);
            AutoResetEvent autoRestart = new AutoResetEvent(true);
            _restartTimer = new System.Threading.Timer(callBackrestart, autoRestart, _t.OffSet, _period);
            #endregion

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        private void OnRestart(object state) 
        {
            _enabled = true;
            _actualColor = _t.Color;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        private void OnDegradeeTimer(object state)
        {
            if (_terminate)
            {
                _enabled = false;
                this._renderTimer.Dispose();
                this._restartTimer.Dispose();
                lock (_g)
                {
                    _g.Clear(_t.BackColor);
                }
            }

            if (_enabled)
            {
                lock (_g)
                {
                    if (_actualColor.R + DR >= 255 || _actualColor.G + DG >= 255 || _actualColor.B + DB >= 255)
                    {
                        //Pinta el color transparente
                        _drawBrush = new SolidBrush(_t.BackColor);                                                

                        //No pinta mas
                        _enabled = false;                        
                    }
                    else
                    {
                        //Calcula el nuevo color
                        _actualColor = Color.FromArgb(_actualColor.R + DR, _actualColor.G + DG, _actualColor.B + DB);
                                      
                        //Actualiza el color
                        _drawBrush= new SolidBrush(_actualColor);                        
                    }
                    
                    //Dibuja un poligono suavisado en los bordes y relleno de color
                    _g.FillClosedCurve(_drawBrush,this._poly.ToArray(),System.Drawing.Drawing2D.FillMode.Alternate,0.5f);                    
                }
            }
        }        
    }
    /// <summary>
    /// 
    /// </summary>
    internal class RadialToken
    {
        /// <summary>
        /// Angulo de rotacion
        /// </summary>
        public double Angle;
        /// <summary>
        /// Diametro inicial
        /// </summary>
        public double r1;
        /// <summary>
        /// Diametro final
        /// </summary>
        public double r2;
        /// <summary>
        /// 
        /// </summary>
        public double q;
        /// <summary>
        /// Color del rectangulo
        /// </summary>
        public Color Color;
        /// <summary>
        /// Color de fondo
        /// </summary>
        public Color BackColor;
        /// <summary>
        /// Periodo de degradacion
        /// </summary>
        public int Period;
        /// <summary>
        /// Tiempo de inicio del degradado
        /// </summary>
        public int OffSet;
        /// <summary>
        /// 
        /// </summary>
        public RadialToken(double angle, double d1, double d2, double q, Color c, Color back, int offset, int period)
        {
            this.Angle = angle;
            this.r1 = d1;
            this.q = q;
            this.r2 = d2;
            this.Color = c;
            this.BackColor = back;
            this.OffSet = offset;
            this.Period = period;
        }
    }

}
