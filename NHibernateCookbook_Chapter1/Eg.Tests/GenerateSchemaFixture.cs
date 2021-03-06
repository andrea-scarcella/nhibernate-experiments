﻿using Eg.Core;
using NHibernate.Cfg;
using NUnit.Framework;

namespace Eg.Tests
{
	[TestFixture]
	public class GenerateSchemaFixture : TestBase
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
