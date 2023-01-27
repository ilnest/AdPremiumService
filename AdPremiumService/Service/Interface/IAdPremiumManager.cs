using Contracts.Requests;
using Contracts.Responses;
using System.Collections.Generic;

namespace Service.Interface
{
	public interface IAdPremiumManager
	{
		AdPremiumResponse AddNewAdPremium(AdPremiumRequest adPremiumRequest);
		AdPremiumResponse GetAdPremiumById(int adId);
		List<AdPremiumResponse> GetAllAdPremium();
	}
}
