using System;
using System.Collections.Generic;
using System.Text;
using SQLExecutor.Common;
using System.Text.RegularExpressions;

namespace SQLExecutor.Business
{
    internal class TextUtilities
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        internal static string ApplyRemplacements(string script, List<ReplaceInfo> replacement, List<ReplaceInfo> patterns)
        {
            #region Realizar los reemplazos via normal
            for (int i = 0; i < replacement.Count; i++)
            {
                script = script.Replace(replacement[i].Word, replacement[i].Replace);
            }
            #endregion

            #region Realizar los reemplazos via expresiones regulares
            Regex rExpression = null;
            for (int i = 0; i < patterns.Count; i++)
            {
                try
                {
                    rExpression = new Regex(patterns[i].Word, RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Compiled);

                    script = rExpression.Replace(script, patterns[i].Replace);
                }
                catch { }
            }
            #endregion

            return script;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="script"></param>
        /// <param name="separator"></param>
        /// <returns></returns>
        internal static List<ExecuteRegionInfo> Divide(string script, string separator)
        {
            Regex rExpression = new Regex(separator, RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Compiled);

            //Se adiciona un caracter de espacio para hacer coincidir las expresiones regulares
            if (script.EndsWith(@"/"))
            {
                script = script + " ";
            }

            //Divide el documento en secciones dadas por el separador
            string[] statement = (string[])rExpression.Split(script);

            List<ExecuteRegionInfo> col = new List<ExecuteRegionInfo>();

            ExecuteRegionInfo region = null;
            for (int i = 0; i < statement.Length; i++)
            {
                region = new ExecuteRegionInfo();
                region.Title = "Sentencia " + (i + 1).ToString();
                region.Index = i;
                region.Text = statement[i];
                col.Add(region);
            }

            return col;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pattern"></param>
        /// <param name="text"></param>
        internal static MatchCollection FindText(string pattern, string text)
        {
            try
            {
                Regex rExpression = new Regex(pattern, RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.Compiled);

                MatchCollection col = rExpression.Matches(text);

                return col;
            }
            catch
            {
                throw;
            }
        }
    }
}
