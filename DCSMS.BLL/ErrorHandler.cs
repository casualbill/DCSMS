using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace DCSMS.BLL
{
    public class ErrorHandler : System.Web.UI.Page
    {
        public static String logFile;

        public void WriteLog(string logStr)
        {
            StreamWriter streamWriter = null;
            logFile = Server.MapPath("/") + "\\errorlog\\log" + System.DateTime.Now.Date.ToString("yyMMdd") + ".txt";

            try
            {
                FileInfo finfo = new FileInfo(logFile);
                if (finfo.Exists && finfo.Length > 10485760)
                {
                    finfo.Delete();
                }
                streamWriter = new StreamWriter(@logFile, true, System.Text.UnicodeEncoding.Unicode);
                streamWriter.WriteLine(System.DateTime.Now.ToString() + "   " + logStr);
            }
            catch (UnauthorizedAccessException uae)
            {
                throw (new Exception(uae.Message + logFile));
            }
            catch (DirectoryNotFoundException de)
            {
                throw (de);
            }
            catch (System.Security.SecurityException se)
            {
                throw (se);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                streamWriter.Flush();
                streamWriter.Close();
            }

        }
    }
}
