using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace SQLExecutor
{
    /// <summary>
    /// 
    /// </summary>
    public class WinTools
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mType"></param>
        /// <returns></returns>
        internal static string GetMessage(MessageType mType)
        {
            System.Reflection.Assembly asm = typeof(FrmMain).Assembly;
            try
            {
                System.Resources.ResourceManager rm = new System.Resources.ResourceManager("SQLExecutor.Messages", asm);

                return rm.GetString(mType.ToString(), System.Windows.Forms.Application.CurrentCulture);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex.Message);

                //Devuelve la representacion string de la enumeracion
                return mType.ToString();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        internal static object DeserializeFromString(string data)
        {
            BinaryFormatter b = new BinaryFormatter();

            MemoryStream ms = new MemoryStream();
            StreamWriter r = new StreamWriter(ms);

            r.Write(data);
            r.Flush();

            ms.Seek(0,0);

            object o = b.Deserialize(ms);

            r.Close();
            r.Dispose();
            return o;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        internal static string SerializeToString(object o)
        {
            BinaryFormatter b = new BinaryFormatter();
            MemoryStream  ms=new MemoryStream();                        

            b.Serialize(ms, o);
            ms.Position = 0;
            StreamReader r = new StreamReader(ms);
            string data = r.ReadToEnd();

            r.Close();
            r.Dispose();

            return data;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pathFile"></param>
        /// <param name="o"></param>
        internal static void SerializeToFile(string path, object o)
        {
            FileStream fs = new FileStream(path, FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();

            bf.Serialize(fs, o);
            
            fs.Close();
            fs.Dispose();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        internal static object DeserializeFromFile(string path)
        {
            FileStream fs = new FileStream(path, FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();

            object o = bf.Deserialize(fs);
            
            fs.Close();
            fs.Dispose();

            return o;
        }
    }
}
