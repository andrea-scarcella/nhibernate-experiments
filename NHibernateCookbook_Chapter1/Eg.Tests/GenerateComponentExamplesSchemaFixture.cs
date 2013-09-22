using ComponentExamples;
using NHibernate.Cfg;
using NUnit.Framework;

namespace Eg.Tests
{
	[TestFixture]
	public class GenerateComponentExamplesSchemaFixture : TestBase
	{
		[SetUp]
		public void Setup()
		{
			Cfg = new Configuration();
			Cfg.Configure();
			Cfg.AddAssembly(assembly: typeof(Customer).Assembly);
		}
	}
}
