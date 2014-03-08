using System;
using System.Collections.Generic;
using System.Text;

namespace SQLExecutor.Business
{
    /// <summary>
    /// 
    /// </summary>
    internal class EMail
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        internal static bool Send(Common.EmailInfo m) 
        {
            bool retValue = false;
            try
            {
                ArandaSmtp.ArandaSmtp.SendMail(m.From, string.Empty, m.To, string.Empty, m.Subject, m.Body, m.Server, false, string.Empty, string.Empty);
                retValue = true;
            }            
            catch
            {
                retValue = false;
                throw;
            }

            return retValue;
        }
    }
}
