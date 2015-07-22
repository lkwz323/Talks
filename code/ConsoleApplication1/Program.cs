using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBatisNet.DataMapper;
using IBatisNet.Common;
using IBatisNet.Common.Logging;
using IBatisNet.Common.Logging.Impl;
using log4net;
using log4net.Config;
using System.IO;

namespace ConsoleApplication1
{
    public class Program
    {
        public static ISqlMapper EntityMapper
        {
            get
            {
                try
                {
                    ISqlMapper mapper = Mapper.Instance();
                    mapper.DataSource.ConnectionString = "Data Source=(local)\\sqlExpress;Initial Catalog=TalksDB;uid=sa;pwd=sd;";
                    return mapper;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public static Guid executeFunction()
        {
            
            ISqlMapper mapper = EntityMapper;
            
            Guid str = mapper.QueryForObject<Guid>("FindPageId", "Footer");

            return str;

        }
   
        static void Main(string[] args)
        {
            XmlConfigurator.ConfigureAndWatch(new FileInfo(AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "log4net.config"));

            Console.Write(executeFunction());
            Console.Read();
        }
    }
}
