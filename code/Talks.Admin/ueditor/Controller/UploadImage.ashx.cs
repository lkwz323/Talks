﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Talks.UEditor;


namespace Talks.Admin.ueditor.Controller
{
    /// <summary>
    /// Summary description for UploadImage
    /// </summary>
    public class UploadImage : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            Handler action = null;
            var act = (context.Request["action"] ?? "").ToString().ToLower();

            switch (act)
            {
                case "config":
                    action = new ConfigHandler(context);
                    break;
                case "uploadimage":
                    action = new UploadHandler(context, new UploadConfig()
                    {
                        AllowExtensions = Config.GetStringList("imageAllowFiles"),
                        PathFormat = Config.GetString("imagePathFormat"),
                        SizeLimit = Config.GetInt("imageMaxSize"),
                        UploadFieldName = Config.GetString("imageFieldName")
                    });
                    break;
                case "uploadscrawl":
                    action = new UploadHandler(context, new UploadConfig()
                    {
                        AllowExtensions = new string[] { ".png" },
                        PathFormat = Config.GetString("scrawlPathFormat"),
                        SizeLimit = Config.GetInt("scrawlMaxSize"),
                        UploadFieldName = Config.GetString("scrawlFieldName"),
                        Base64 = true,
                        Base64Filename = "scrawl.png"
                    });
                    break;
                case "uploadvideo":
                    action = new UploadHandler(context, new UploadConfig()
                    {
                        AllowExtensions = Config.GetStringList("videoAllowFiles"),
                        PathFormat = Config.GetString("videoPathFormat"),
                        SizeLimit = Config.GetInt("videoMaxSize"),
                        UploadFieldName = Config.GetString("videoFieldName")
                    });
                    break;
                case "uploadfile":
                    action = new UploadHandler(context, new UploadConfig()
                    {
                        AllowExtensions = Config.GetStringList("fileAllowFiles"),
                        PathFormat = Config.GetString("filePathFormat"),
                        SizeLimit = Config.GetInt("fileMaxSize"),
                        UploadFieldName = Config.GetString("fileFieldName")
                    });
                    break;
                //case "listimage":
                //    action = new ListFileManager(context, Config.GetString("imageManagerListPath"), Config.GetStringList("imageManagerAllowFiles"));
                //    break;
                //case "listfile":
                //    action = new ListFileManager(context, Config.GetString("fileManagerListPath"), Config.GetStringList("fileManagerAllowFiles"));
                //    break;
                //case "catchimage":
                //    action = new CrawlerHandler(context);
                //    break;
                default:
                    action = new NotSupportedHandler(context);
                    break;
            }
            action.Process();
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