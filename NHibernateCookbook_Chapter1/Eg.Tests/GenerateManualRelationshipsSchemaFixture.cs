using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManualRelationships;
using NHibernate.Cfg;
using NUnit.Framework;
namespace Eg.Tests
{
	public class GenerateManualRelationshipsSchemaFixture : TestBase
	{
		[SetUp]
		public void Setup()
		{
			Cfg = new Configuration();
			Cfg.Configure();
			Cfg.AddAssembly(typeof(Order).Assembly);
		}
	}
}
