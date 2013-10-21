using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace DCSMS.Web
{
    public class uploadHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Charset = "utf-8";

            HttpPostedFile file = context.Request.Files["Filedata"];
            String uploadPath = HttpContext.Current.Server.MapPath("uploads\\" + @context.Request["orderId"]) + "\\";

            if (file != null && file.ContentLength <= 2097152)
            {
                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }
                file.SaveAs(uploadPath + file.FileName);

                context.Response.Write("1");

            }
            else
            {
                context.Response.Write("0");
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}