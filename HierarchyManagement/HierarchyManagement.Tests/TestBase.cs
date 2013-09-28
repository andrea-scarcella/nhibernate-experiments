using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;

namespace HierarchyManagement.Tests
{

	public class TestBase
	{
		//replace with fluent configuration :)
		protected Configuration Cfg;
		protected ISessionFactory SessionFactory;
		protected ISession Session;
		//[Test]
		//public void CanGenerateSchema()
		//{
		//	new SchemaExport(Cfg).Execute(true, true, false);
		//}
	}
}
