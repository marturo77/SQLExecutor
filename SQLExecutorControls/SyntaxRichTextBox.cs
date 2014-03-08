using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Drawing;

namespace SyntaxHighlighter
{
    /// <summary>
    /// 
    /// </summary>
	public class SyntaxRichTextBox : System.Windows.Forms.RichTextBox
    {
        #region Private Variables
        /// <summary>
        /// 
        /// </summary>
		private SyntaxSettings _settings = new SyntaxSettings();
        /// <summary>
        /// 
        /// </summary>
		private static bool _bPaint = true;
        /// <summary>
        /// 
        /// </summary>
		private string _strLine = "";        
        /// <summary>
        /// 
        /// </summary>
		private int _nLineLength = 0;
        /// <summary>
        /// 
        /// </summary>
		private int _nLineStart = 0;
        /// <summary>
        /// 
        /// </summary>
		private string _strKeywords = "";
        /// <summary>
        /// 
        /// </summary>
		private int m_nCurSelection = 0;
		/// <summary>
		/// The settings.
		/// </summary>
		public SyntaxSettings Settings
		{
			get { return _settings; }
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="start"></param>
        /// <param name="lenght"></param>
        /// <param name="col"></param>
        public delegate void PutColorHandle(int start, int lenght, Color col);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="start"></param>
        /// <param name="lenght"></param>
        /// <param name="col"></param>
        public void PutColor(int start, int lenght, Color col)
        {   
            SelectionStart = start;
            SelectionLength = lenght;
            SelectionColor = col;            
        }

        #region Private Methods
        /// <summary>
		/// WndProc
		/// </summary>
		/// <param name="m"></param>
		protected override void WndProc(ref System.Windows.Forms.Message m)
		{
			if (m.Msg == 0x00f)
			{
				if (_bPaint)
					base.WndProc(ref m);
				else
					m.Result = IntPtr.Zero;
			}
			else
				base.WndProc(ref m);
		}
		/// <summary>
		/// OnTextChanged
		/// </summary>
		/// <param name="e"></param>
		protected override void OnTextChanged(EventArgs e)
		{
            //// Calculate shit here.
            //_nContentLength = this.TextLength;

            //int nCurrentSelectionStart = SelectionStart;
            //int nCurrentSelectionLength = SelectionLength;

            //_bPaint = false;

            //// Find the start of the current line.
            //_nLineStart = nCurrentSelectionStart;
            //while ((_nLineStart > 0) && (Text[_nLineStart - 1] != '\n'))
            //    _nLineStart--;
            //// Find the end of the current line.
            //_nLineEnd = nCurrentSelectionStart;
            //while ((_nLineEnd < Text.Length) && (Text[_nLineEnd] != '\n'))
            //    _nLineEnd++;
            //// Calculate the length of the line.
            //_nLineLength = _nLineEnd - _nLineStart;
            //// Get the current line.
            //_strLine = Text.Substring(_nLineStart, _nLineLength);

            //// Process this line.
            //ProcessLine();

            //_bPaint = true;
		}
		/// <summary>
		/// Process a line.
		/// </summary>
		private void ProcessLine()
		{
			// Save the position and make the whole line black
			int nPosition   = SelectionStart;
			SelectionStart  = _nLineStart;
			SelectionLength = _nLineLength;
			SelectionColor  = Color.Black;

			// Process the keywords
			ProcessRegex(_strKeywords, Settings.KeywordColor);

            // Process numbers
            if (Settings.EnableIntegers)
                ProcessRegex("\\b(?:[0-9]*\\.)?[0-9]+\\b", Settings.IntegerColor);
            // Process strings
            if (Settings.EnableStrings)
                ProcessRegex("\"[^\"\\\\\\r\\n]*(?:\\\\.[^\"\\\\\\r\\n]*)*\"", Settings.StringColor);
            // Process comments
            if (Settings.EnableComments && !string.IsNullOrEmpty(Settings.Comment))
                ProcessRegex(Settings.Comment + ".*$", Settings.CommentColor);

			SelectionStart = nPosition;
			SelectionLength = 0;
			SelectionColor = Color.Black;

			m_nCurSelection = nPosition;
		}
		/// <summary>
		/// Process a regular expression.
		/// </summary>
		/// <param name="strRegex">The regular expression.</param>
		/// <param name="color">The color.</param>
		private void ProcessRegex(string strRegex, Color color)
		{
            Regex regKeywords = new Regex(strRegex, RegexOptions.IgnoreCase | RegexOptions.Compiled);
            Match regMatch;

            for (regMatch = regKeywords.Match(_strLine); regMatch.Success; regMatch = regMatch.NextMatch())
            {
                // Process the words
                int nStart = _nLineStart + regMatch.Index;
                int nLenght = regMatch.Length;
                SelectionStart = nStart;
                SelectionLength = nLenght;
                SelectionColor = color;
            }      
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strRegex"></param>
        /// <param name="color"></param>
        /// <param name="text"></param>
        private void ProcessRegex(string text,string strRegex, Color color)
        {   
            Regex regKeywords = new Regex(strRegex, RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.Compiled );

            MatchCollection col = regKeywords.Matches(text);
            
            for (int i = 0; i < col.Count; i++)
            {
                //WordPaint p = new WordPaint(col[i].Index, col[i].Length, color, this);
                //System.Threading.ThreadStart start = new System.Threading.ThreadStart(p.Run);
                //System.Threading.Thread t = new System.Threading.Thread(start);
                //t.Start();
                this.PutColor(col[i].Index, col[i].Length, color);
            }
            
        }
        #endregion      

        #region Public Methods
        /// <summary>
		/// Compiles the keywords as a regular expression.
		/// </summary>
		public void CompileKeywords()
		{
            System.Text.StringBuilder sb = new StringBuilder();            

			for (int i = 0; i < Settings.Keywords.Count-1; i++)
			{   
                sb.Append(string.Format("\\b{0}\\b|",Settings.Keywords[i]));
			}

            //Adiciona el ultimo token            
            sb.Append(string.Format("\\b{0}\\b", Settings.Keywords[Settings.Keywords.Count-1]));

            this._strKeywords = sb.ToString();
		}
        /// <summary>
        /// 
        /// </summary>
		public void ProcessAllLines2()
        {
            #region OldCode
            //_bPaint = false;

            //int nStartPos = 0;
            //int i = 0;
            //int nOriginalPos = SelectionStart;
            //while (i < Lines.Length)
            //{
            //    _strLine = Lines[i];
            //    _nLineStart = nStartPos;
            //    _nLineEnd = _nLineStart + _strLine.Length;

            //    ProcessLine();
            //    i++;

            //    nStartPos += _strLine.Length + 1;
            //}

            //_bPaint = true;
            #endregion

            _bPaint = false;

            ProcessRegex(this.Text, _strKeywords, Settings.KeywordColor);

            ProcessRegex(this.Text, "\\b(?:[0-9]*\\.)?[0-9]+\\b", Settings.IntegerColor);

            ProcessRegex(this.Text, "\"[^\"\\\\\\r\\n]*(?:\\\\.[^\"\\\\\\r\\n]*)*\"", Settings.StringColor);

            _bPaint = true;
        }
        #endregion
    }
	/// <summary>
	/// Class to store syntax objects in.
	/// </summary>
	public class SyntaxList
	{
        /// <summary>
        /// 
        /// </summary>
		public List<string> m_rgList = new List<string>();
        /// <summary>
        /// 
        /// </summary>
		public Color m_color = new Color();
	}
	/// <summary>
	/// Settings for the keywords and colors.
	/// </summary>
	public class SyntaxSettings
    {
        #region Private Variables
        /// <summary>
        /// 
        /// </summary>
		SyntaxList _rgKeywords = new SyntaxList();
        /// <summary>
        /// 
        /// </summary>
		string _strComment = "";
        /// <summary>
        /// 
        /// </summary>
		Color _colorComment = Color.Green;
        /// <summary>
        /// 
        /// </summary>
		Color _colorString = Color.Gray;
        /// <summary>
        /// 
        /// </summary>
		Color _colorInteger = Color.Red;
        /// <summary>
        /// 
        /// </summary>
		bool _bEnableComments = true;
        /// <summary>
        /// 
        /// </summary>
		bool _bEnableIntegers = true;
        /// <summary>
        /// 
        /// </summary>
		bool _bEnableStrings = true;
        #endregion

        #region Properties
        /// <summary>
		/// A list containing all keywords.
		/// </summary>
		public List<string> Keywords
		{
			get { return _rgKeywords.m_rgList; }
		}
		/// <summary>
		/// The color of keywords.
		/// </summary>
		public Color KeywordColor
		{
			get { return _rgKeywords.m_color; }
			set { _rgKeywords.m_color = value; }
		}
		/// <summary>
		/// A string containing the comment identifier.
		/// </summary>
		public string Comment
		{
			get { return _strComment; }
			set { _strComment = value; }
		}
		/// <summary>
		/// The color of comments.
		/// </summary>
		public Color CommentColor
		{
			get { return _colorComment; }
			set { _colorComment = value; }
		}
		/// <summary>
		/// Enables processing of comments if set to true.
		/// </summary>
		public bool EnableComments
		{
			get { return _bEnableComments; }
			set { _bEnableComments = value; }
		}
		/// <summary>
		/// Enables processing of integers if set to true.
		/// </summary>
		public bool EnableIntegers
		{
			get { return _bEnableIntegers; }
			set { _bEnableIntegers = value; }
		}
		/// <summary>
		/// Enables processing of strings if set to true.
		/// </summary>
		public bool EnableStrings
		{
			get { return _bEnableStrings; }
			set { _bEnableStrings = value; }
		}
		/// <summary>
		/// The color of strings.
		/// </summary>
		public Color StringColor
		{
			get { return _colorString; }
			set { _colorString = value; }
		}
		/// <summary>
		/// The color of integers.
		/// </summary>
		public Color IntegerColor
		{
			get { return _colorInteger; }
			set { _colorInteger = value; }
		}
		#endregion
	}
    /// <summary>
    /// 
    /// </summary>
    public class WordPaint 
    {
        /// <summary>
        /// 
        /// </summary>
        SyntaxRichTextBox _control;
        /// <summary>
        /// 
        /// </summary>
        int _start;
        /// <summary>
        /// 
        /// </summary>
        int _lenght;
        /// <summary>
        /// 
        /// </summary>
        Color _col;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="start"></param>
        /// <param name="lenght"></param>
        /// <param name="col"></param>
        /// <param name="control"></param>
        public WordPaint(int start, int lenght, Color col, SyntaxRichTextBox control) 
        {
            _start   = start;
            _lenght  = lenght;
            _col     = col;
            _control = control;
        }
        /// <summary>
        /// 
        /// </summary>
        public void Run() 
        {
            _control.PutColor(_start, _lenght, _col);            
        }
    }
}
