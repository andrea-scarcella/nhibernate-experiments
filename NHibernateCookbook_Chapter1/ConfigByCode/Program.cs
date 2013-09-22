using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.ByteCode.Castle;
using NHibernate.Cfg;
using NHibernate.Dialect;

namespace ConfigByCode
{
	class Program
	{
		private static void Main(string[] args)
		{
			var nhConfig = new Configuration().Proxy(proxy =>
				proxy.ProxyFactoryFactory<ProxyFactoryFactory>())
				.DataBaseIntegration(db =>
				{
					db.Dialect<MsSql2008Dialect>();
					db.ConnectionStringName = "db";
					db.BatchSize = 100;
				}
				).AddAssembly("Eg.Core");
			var sessionFactory = nhConfig.BuildSessionFactory();
			Console.WriteLine("NHibernate Configured!");
			Console.ReadKey();

		}
	}
}
