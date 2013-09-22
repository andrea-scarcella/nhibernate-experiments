using Eg.FluentMappings;
using NHibernate.Cfg;
using NUnit.Framework;

namespace Eg.Tests
{
	public class GenerateFluentNhSchemaFixture : TestBase
	{
		[SetUp]
		public void Setup()
		{
			Cfg = new Configuration();
			Cfg.Configure();
			Cfg.AddAssembly(typeof(Product).Assembly);
		}
	}
}
