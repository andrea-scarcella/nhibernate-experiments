using MappingEnums;
using NHibernate.Cfg;
using NUnit.Framework;

namespace Eg.Tests
{
	[TestFixture]
	public class GenerateMappingEnumsSchemaFixture : TestBase
	{
		[SetUp]
		public void Setup()
		{
			Cfg = new Configuration();
			Cfg.Configure();
			Cfg.AddAssembly(typeof(Account).Assembly);

		}
	}
}
