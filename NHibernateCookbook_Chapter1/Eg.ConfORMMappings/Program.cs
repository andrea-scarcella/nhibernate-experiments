using System;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using ConfOrm;
using ConfOrm.NH;
using ConfOrm.Patterns;
using ConfOrm.Shop.CoolNaming;
using Eg.Core;
using NHibernate;
using NHibernate.Cfg.MappingSchema;


namespace Eg.ConfORMMappings
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			WriteXmlMapping(GetMapping());
		}

		private static HbmMapping GetMapping()
		{
			var orm = new ObjectRelationalMapper();
			var mapper = new Mapper(orm, patternsAppliers: new CoolPatternsAppliersHolder(orm));
			orm.TablePerClassHierarchy<Product>();
			orm.TablePerClass<ActorRole>();
			orm.Patterns.PoidStrategies.Add(new GuidOptimizedPoidPattern());
			orm.VersionProperty<Entity>(p => p.Version);
			orm.NaturalId<Product>(p => p.Name);
			orm.Cascade<Movie, ActorRole>(
			  CascadeOn.All | CascadeOn.DeleteOrphans);

			mapper.AddPropertyPattern(mi =>
			  mi.GetPropertyOrFieldType() == typeof(Decimal) &&
			  mi.Name.Contains("Price"),
			  pm => pm.Type(NHibernateUtil.Currency));

			mapper.AddPropertyPattern(mi =>
			  orm.IsRootEntity(mi.DeclaringType) &&
			  !"Description".Equals(mi.Name),
			  pm => pm.NotNullable(true));

			mapper.Subclass<Movie>(cm =>
			  cm.List(movie => movie.Actors,
			  colm => colm.Index(
				lim => lim.Column("ActorIndex")), m => { }));


			var domainClasses = typeof(Entity).Assembly.GetTypes()
			  .Where(t => typeof(Entity).IsAssignableFrom(t));

			return mapper.CompileMappingFor(domainClasses);
		}
		private static void WriteXmlMapping(HbmMapping hbmMapping)
		{
			var document = Serialize(hbmMapping);
			File.WriteAllText("WholeDomain.hbm.xml", document);
		}
		private static string Serialize(HbmMapping hbmElement)
		{
			string outp = null;
			var setting = new XmlWriterSettings { Indent = true };
			var serializer = new XmlSerializer(typeof(HbmMapping));
			using (var memStream = new MemoryStream(2048))
			{
				using (var xmlWriter = XmlWriter.Create(memStream, setting))
				{
					serializer.Serialize(xmlWriter, hbmElement);

				}
				//StreamReader sluit zijn stroom voordat het (StreamReader) wordt weggeworpen 
				//Dus wordt er een Exception veroorzakt zodra XmlWriter wordt weggeworpen
				//want het probeert om dezelfde stroom te wijzigen
				memStream.Flush();
				memStream.Position = 0;
				using (var sr = new StreamReader(memStream))
				{
					outp = sr.ReadToEnd();
				}
			}
			return outp;
		}
	}
}
