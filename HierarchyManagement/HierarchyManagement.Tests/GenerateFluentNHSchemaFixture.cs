using System.Linq;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using HierarchyManagement.Mappings;
using NHibernate.Linq;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;

namespace HierarchyManagement.Tests
{
	[TestFixture]
	public class GenerateFluentNhSchemaFixture : TestBase
	{
		[TestFixtureSetUp]
		public void Setup()
		{
			Cfg = Fluently.Configure()
			.Database(MsSqlCeConfiguration.Standard.ShowSql().ConnectionString(connstr =>
			 connstr.FromConnectionStringWithKey("db")))
								.Mappings(m => m.FluentMappings.AddFromAssemblyOf<NodeMapping>())
								.BuildConfiguration();

			new SchemaExport(Cfg).Execute(true, true, false);

			SessionFactory = Cfg.BuildSessionFactory();
			Session = SessionFactory.OpenSession();
		}
		[Test]
		public void CanInsertTree()
		{
			var n = 5;
			object id;
			using (var tx = Session.BeginTransaction())
			{

				var r = GetSingleLevelTree(n);
				id = Session.Save(r);
				tx.Commit();
			}
			Session.Clear();
			using (var tx = Session.BeginTransaction())
			{
				var root = Session.Get<Node>(id);
				Assert.IsNotNull(root);
				Assert.AreEqual(n, root.Children.Count);
				tx.Commit();
			}
		}

		private static Node GetSingleLevelTree(int n)
		{
			var r = new Node
			{
				Name = "Root"
			};

			var l1 = Enumerable.Repeat(element: new Node { Name = "Child " }, count: n);
			var numbers = Enumerable.Range(0, n);
			var l2 = l1.Zip(numbers, (el, num) =>
				new Node
				{
					Name = "Child " + num
				});

			l2.ForEach(el => r.AddChild(el));
			return r;
		}
	}
}
