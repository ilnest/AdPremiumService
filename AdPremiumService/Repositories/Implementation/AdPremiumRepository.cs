using Model.Entities;
using NHibernate;
using Repositories.Interface;
using System.Collections.Generic;
using System.Linq;

namespace Repositories.Implementation
{
	public class AdPremiumRepository : IAdPremiumRepository
	{

		public List<AdPremium> GetAllAdPremium(ISession session)
		{
			var list = session.CreateCriteria<AdPremium>().List<AdPremium>();
			return list.ToList();
		}

		public AdPremium GetById(ISession session, int adPremiumId)
		{
				var adPremium = session.Get<AdPremium>(adPremiumId);
				return adPremium;
		}

		public int Save(ISession session, AdPremium adPremium)
		{
				var id = (int)session.Save(adPremium);
				return id;
		}
	}
}
