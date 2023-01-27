using AdPremiumService.Mapper;
using AutoMapper;
using Contracts.DTO;
using Contracts.Requests;
using Contracts.Responses;
using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.Entities;
using NHibernate;
using Repositories.Interface;
using Service.Implementation;
using System;

namespace UnitTest
{
	[TestClass]
	public class AdPremiumManagerTest
	{
		private IMapper _mapper;
		private ISessionFactory _sessionFactoryMock;
		private ISession _sessionMock;
		private IAdPremiumRepository _adPremiumRepositoryMock;

		private AdPremiumManager _sut;
		[TestInitialize]
		public void AdPremiumManagerTestInitialize()
		{
			var mapperConfig = new MapperConfiguration(mc => mc.AddProfile(new MappingProfile()));
			_mapper = mapperConfig.CreateMapper();
			_sessionMock = A.Fake<ISession>();
			_sessionFactoryMock = A.Fake<ISessionFactory>();
			A.CallTo(() => _sessionFactoryMock.OpenSession()).Returns(_sessionMock);
			_adPremiumRepositoryMock = A.Fake<IAdPremiumRepository>();
			_sut = new AdPremiumManager(_sessionFactoryMock, _adPremiumRepositoryMock, _mapper);
		}

		// Example of unit test
		// This one fails because of the lack of Equals and GetHashCode methods in models
		[TestMethod]
		public void AddNewAdPremium_Success()
		{
			// Arrange
			var request = new AdPremiumRequest()
			{
				LocationId = 35,
				SubcategoryId = 126,
				PremiumStart = new DateTime(2022, 5, 8),
				PremiumEnd = new DateTime(2022, 5, 8),
			};
			var okEntityToSave = getOKEntityToSave();
			var okSavedEntity = getOKSavedEntity();
			A.CallTo(() => _adPremiumRepositoryMock.Save(_sessionMock, okEntityToSave)).Returns(1);
			A.CallTo(() => _adPremiumRepositoryMock.GetById(_sessionMock, 1)).Returns(okSavedEntity);
			var expectedEntity = new AdPremiumResponse()
			{
				AdId = 1,
				Location = new LocationDto() { Id = 35, Name = "Fresno" },
				Subcategory = new SubcategoryDTO { Id = 126, Name = "Fabrics" },
				PremiumEnd = new DateTime(2022, 5, 8),
				PremiumStart = new DateTime(2022, 5, 8),
			};

			//Act
			var response = _sut.AddNewAdPremium(request);

			//Assert
			Assert.AreEqual(expectedEntity, response);
		}

		private AdPremium getOKEntityToSave()
		{
			return new AdPremium()
			{
				Location = new Location() { Id = 35 },
				Subcategory = new Subcategory { Id = 126 },
				PremiumEnd = new DateTime(2022, 5, 8),
				PremiumStart = new DateTime(2022, 5, 8)
			};
		}

		private AdPremium getOKSavedEntity()
		{
			return new AdPremium()
			{
				AdId = 1,
				Location = new Location() { Id = 35, Name = "Fresno" },
				Subcategory = new Subcategory { Id = 126, Name = "Fabrics" },
				PremiumEnd = new DateTime(2022, 5, 8),
				PremiumStart = new DateTime(2022, 5, 8),
			};
		}
	}
}
