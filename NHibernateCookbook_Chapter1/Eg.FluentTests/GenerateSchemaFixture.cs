using Eg.FluentMappings;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;

namespace Eg.FluentTests
{
	[TestFixture]
	public class GenerateSchemaFixture
	{
		private Configuration _cfg;
		[TestFixtureSetUp]
		private void OneTimeSetup()
		{
		}
		[SetUp]
		private void Setup()
		{
			_cfg = new Configuration();
			_cfg.Configure();
			_cfg.AddAssembly(typeof(Product).Assembly);
		}
		[Test]
		public void Can_generate_schema()
		{
			new SchemaExport(_cfg).Execute(true,true,false);
		}
	}
}
