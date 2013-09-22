using System;
using NHibernate.Cfg;

namespace ConfigByXML
{
	class Program
	{
		static void Main(string[] args)
		{
			//hibernate zoekt een bestand dat 'hibernate.cfg.xml' is genoemd
			//op deze manier kan er een bestand met een andere naam worden gebruikt
			var cfgFile = "hibernate.cfg.xml";
			var nhConfig = new Configuration().Configure(cfgFile);
			var sessionFactory = nhConfig.BuildSessionFactory();
			Console.WriteLine("NHibernate Configured!");
			ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
		}
	}
}
