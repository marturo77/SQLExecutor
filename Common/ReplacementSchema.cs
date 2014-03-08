using System;
using System.Collections.Generic;
using System.Text;

namespace SQLExecutor.Common
{
    [Serializable]
    public class ReplacementSchema
    {
        /// <summary>
        /// 
        /// </summary>
        private List<ReplaceInfo> _replacements;
        /// <summary>
        /// 
        /// </summary>
        private List<ReplaceInfo> _patterns;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="replacements"></param>
        /// <param name="patterns"></param>
        public ReplacementSchema(List<ReplaceInfo> replacements, List<ReplaceInfo> patterns)
        {
            this._replacements = replacements;
            this._patterns = patterns;
        }
        /// <summary>
        /// 
        /// </summary>
        public List<ReplaceInfo> Replacements { get { return this._replacements; } }
        /// <summary>
        /// 
        /// </summary>
        public List<ReplaceInfo> Patterns { get { return this._patterns; } }
    }
}
