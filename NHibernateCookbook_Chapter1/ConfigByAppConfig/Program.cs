using System;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace ConfigByAppConfig
{
	class Program
	{
		static void Main(string[] args)
		{
			log4net.Config.XmlConfigurator.Configure();
			var nhConfig = new Configuration().Configure();
			var sessionFactory = nhConfig.BuildSessionFactory();
			Console.WriteLine("NHibernate Configured!");

			var schemaExport = new SchemaExport(nhConfig);
			schemaExport.SetOutputFile(@"db.sql").Execute(false, false, false);
			Console.WriteLine("NHibernate database created!");
			Console.ReadKey();
		}
	}
}
