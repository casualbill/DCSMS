﻿using System;
using System.IO;
using System.Web;
using DCSMS.BLL;

namespace DCSMS.Web
{
    public class uploadHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Charset = "utf-8";

            HttpPostedFile file = context.Request.Files["Filedata"];
            String orderId = @context.Request["orderId"];
            String uploadPath = HttpContext.Current.Server.MapPath("uploads\\" + orderId) + "\\";

            if (file != null && file.ContentLength <= 2097152)
            {
                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }
                file.SaveAs(uploadPath + file.FileName);
                OrderLogic orderLogic = new OrderLogic();
                orderLogic.imageAdd("/uploads/" + orderId + "/" + file.FileName, orderId);

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