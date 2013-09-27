using FluentNHibernate.Mapping;

namespace HierarchyManagement.Mappings
{
	public class NodeMapping : ClassMap<Node>
	{
		public NodeMapping()
		{
			Id(n => n.Id).GeneratedBy.GuidComb();
			Map(n => n.Name).Length(50).Not.Nullable();
			Map(n => n.Parent);//????
			References(n => n.Parent).Not.Nullable();//many2one
			HasManyToMany(n => n.Ancestors).Inverse().Cascade.All().Table("NodeHierarchy").AsSet();
			HasMany(n => n.Children).Inverse().Cascade.All().KeyColumn("ParentId").AsSet();//one2many
			HasManyToMany(n => n.Descendants).Inverse().Cascade.All().Table("NodeHierarchy").AsSet();
		}
	}
}
