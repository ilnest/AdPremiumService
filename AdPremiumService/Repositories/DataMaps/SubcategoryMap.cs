using FluentNHibernate.Mapping;
using Model.Entities;

namespace Repositories.DataMaps
{
	public class SubcategoryMap : ClassMap<Subcategory>
	{
		public SubcategoryMap()
		{
			Table("Subcategories");
			Id(x => x.Id);
			Map(x => x.Name);
		}
	}
}
