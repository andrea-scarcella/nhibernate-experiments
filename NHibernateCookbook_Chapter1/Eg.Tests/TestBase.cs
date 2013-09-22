using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;

namespace Eg.Tests
{

	public class TestBase
	{
		protected Configuration Cfg;
		[Test]
		public void Can_generate_schema()
		{
			//goede instellingen om problemen met System.Data.SqlServerCe te voorkomen:
			//copy local=true!
			//http://sarkies.blogspot.it/2010/07/could-not-create-driver-from.html
			//je moet de stand 'Build action' voor elke mappingbestand op 'Embedded resource'  zetten!
			new SchemaExport(Cfg).Execute(true, true, false);
			//(false, true, false, false);
		}
	}
}
