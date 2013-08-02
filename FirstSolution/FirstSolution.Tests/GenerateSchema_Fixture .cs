using FirstSolution.Domain;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;

namespace FirstSolution.Tests
{
    [TestFixture]
    public class GenerateSchema_Fixture
    {
        private Configuration cfg;

        [SetUp]
        public void Setup()
        {
            cfg = new Configuration();
            cfg.Configure();
            cfg.AddAssembly(typeof(Product).Assembly);
        }


        [Test]
        public void Can_generate_schema()
        {

            //http://sarkies.blogspot.it/2010/07/could-not-create-driver-from.html
            //je moet de stand 'Build action' voor elke mappingbestand op 'Embedded resource'  zetten!
            new SchemaExport(cfg).Execute(true, true, false);
            //(false, true, false, false);
        }
    }
}
