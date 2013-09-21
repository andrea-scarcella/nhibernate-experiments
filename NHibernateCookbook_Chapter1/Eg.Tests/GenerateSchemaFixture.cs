using Eg.Core;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;

namespace Eg.Tests
{
	[TestFixture]
	public class GenerateSchemaFixture
	{
		private Configuration _cfg;

		[SetUp]
		public void Setup()
		{
			_cfg = new Configuration();
			_cfg.Configure();
			_cfg.AddAssembly(typeof(Product).Assembly);
			//_cfg.AddAssembly(typeof(Book).Assembly);
			//_cfg.AddAssembly(typeof(Movie).Assembly);
		}
		[Test]
		public void Can_generate_schema()
		{
			//goede instellingen om problemen met System.Data.SqlServerCe te voorkomen:
			//copy local=true!
			//http://sarkies.blogspot.it/2010/07/could-not-create-driver-from.html
			//je moet de stand 'Build action' voor elke mappingbestand op 'Embedded resource'  zetten!
			new SchemaExport(_cfg).Execute(true, true, false);
			//(false, true, false, false);
		}
	}
}
