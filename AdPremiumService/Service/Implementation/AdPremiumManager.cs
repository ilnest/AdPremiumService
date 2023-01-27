using AutoMapper;
using Model.Entities;
using NHibernate;
using Repositories.Interface;
using Contracts.Requests;
using Contracts.Responses;
using System;
using System.Collections.Generic;
using Service.Interface;

namespace Service.Implementation
{
	public class AdPremiumManager : IAdPremiumManager
	{
		private readonly IAdPremiumRepository _adPremiumRepository;
		private readonly IMapper _mapper;
		private readonly ISessionFactory _sessionFactory;

		public AdPremiumManager(ISessionFactory sessionFactory, IAdPremiumRepository adPremiumRepository, IMapper mapper)
		{
			_adPremiumRepository = adPremiumRepository ?? throw new ArgumentNullException(nameof(adPremiumRepository));
			_sessionFactory = sessionFactory ?? throw new ArgumentNullException(nameof(sessionFactory));
			_mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
		}

		public AdPremiumResponse AddNewAdPremium(AdPremiumRequest adPremiumRequest)
		{
			try
			{
				int adPremiumId;
				using (var session = _sessionFactory.OpenSession())
				{
					adPremiumId = _adPremiumRepository.Save(session, _mapper.Map<AdPremiumRequest, AdPremium>(adPremiumRequest));
					session.Flush();
					session.Close();
				}
				return GetAdPremiumById(adPremiumId);
			}
			catch (Exception exc)
			{
				throw exc;
			}
		}

		public AdPremiumResponse GetAdPremiumById(int adId)
		{
			try
			{
				using (var session = _sessionFactory.OpenSession())
				{
					var adPremium = _adPremiumRepository.GetById(session, adId);
					return _mapper.Map<AdPremium, AdPremiumResponse>(adPremium);
				}
			}
			catch (Exception exc)
			{
				throw exc;
			}
		}

		public List<AdPremiumResponse> GetAllAdPremium()
		{
			try
			{
				using (var session = _sessionFactory.OpenSession())
				{
					var adPremiumList = _adPremiumRepository.GetAllAdPremium(session);
					return _mapper.Map<List<AdPremium>, List<AdPremiumResponse>>(adPremiumList);
				}
			}
			catch (Exception exc)
			{
				throw exc;
			}
		}
	}
}
