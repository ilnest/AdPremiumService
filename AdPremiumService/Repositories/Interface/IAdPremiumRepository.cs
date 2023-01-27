using Model.Entities;
using NHibernate;
using System.Collections.Generic;

namespace Repositories.Interface
{
	public interface IAdPremiumRepository
	{
		int Save(ISession session, AdPremium adPremium);
		AdPremium GetById(ISession session, int adPremiumId);
		List<AdPremium> GetAllAdPremium(ISession session);
	}
}
