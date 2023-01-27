using FluentNHibernate.Mapping;
using Model.Entities;

namespace Repositories.DataMaps
{
	public class LocationMap : ClassMap<Location>
	{
		public LocationMap()
		{
			Table("Locations");
			Id(x => x.Id);
			Map(x => x.Name);
		}
	}
}
