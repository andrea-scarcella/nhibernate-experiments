using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Cfg;

namespace ConfigByXML
{
	class Program
	{
		static void Main(string[] args)
		{
			var nhConfig = new Configuration().Configure();
			var sessionFactory = nhConfig.BuildSessionFactory();
			Console.WriteLine("NHibernate Configured!");
			ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
		}
	}
}
