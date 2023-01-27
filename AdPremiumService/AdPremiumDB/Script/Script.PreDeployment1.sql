/*
 Pre-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be executed before the build script.	
 Use SQLCMD syntax to include a file in the pre-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the pre-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/



SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Locations](
	[id] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Locations] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


insert into Locations values (35, 'Fresno');
insert into Locations values (42, 'Riverside');
insert into Locations values (43, 'Sacramento');

go

CREATE TABLE [dbo].[Subcategories](
	[id] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_subcategories] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


insert into subcategories values (126, 'Alfombras y Pisos: Venta e Instalaciуn');
insert into subcategories values (128, 'Construcciуn y Remodelaciones');
insert into subcategories values (144, 'Fotos y Video');
insert into subcategories values (150, 'Bodegas y Warehouse');
insert into subcategories values (152, 'Choferes y Troqueros');
insert into subcategories values (153, 'Meseros y Cocineros');
insert into subcategories values (154, 'Limpieza');
insert into subcategories values (155, 'Independientes');
insert into subcategories values (158, 'Otros empleos');
insert into subcategories values (208, 'Barberos y Cosmetуlogas');
insert into subcategories values (231, 'Entretenimiento');
insert into subcategories values (290, 'Aire Acondicionado');
insert into subcategories values (293, 'Pintura');
insert into subcategories values (407, 'Bartenders');
insert into subcategories values (409, 'Carpinteros y Construcciуn');
insert into subcategories values (412, 'Electricistas');
insert into subcategories values (416, 'Mecбnica de Autos');
insert into subcategories values (425, 'Fбbricas');
insert into subcategories values (601, 'Cajeros');
insert into subcategories values (628, 'Toros Mecбnicos');
insert into subcategories values (648, 'Tapicero');


Go



CREATE TABLE [dbo].[AdPremium](
	[AdId] [int] IDENTITY(300,1) NOT NULL,
	[LocationsID] [int] NOT NULL,
	[subcategoriesID] [int] NOT NULL,
	[PremiumStart] [datetime] NULL,
	[PremiumEnd] [datetime] NULL,
 CONSTRAINT [PK_AdPremium] PRIMARY KEY CLUSTERED 
(
	[AdId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO



ALTER TABLE AdPremium
ADD CONSTRAINT FK_AdPremium_Locations
FOREIGN KEY (LocationsID) REFERENCES Locations(ID);

ALTER TABLE [dbo].[AdPremium] CHECK CONSTRAINT [FK_AdPremium_Locations]
GO

ALTER TABLE [dbo].[AdPremium]  WITH CHECK ADD  CONSTRAINT [FK_AdPremium_Subcategories] FOREIGN KEY([subcategoriesID])
REFERENCES [dbo].[Subcategories] ([id])
GO

ALTER TABLE [dbo].[AdPremium] CHECK CONSTRAINT [FK_AdPremium_Subcategories]
GO

insert into adpremium values (35, 144, '01/16/2022', '01/21/2022');
insert into adpremium values (42, 425, '02/22/2022', '02/27/2022');
insert into adpremium values (42, 290, '01/30/2022', '02/04/2022');
insert into adpremium values (42, 290, '02/14/2022', '02/19/2022');
insert into adpremium values (42, 290, '01/21/2022', '01/26/2022');
insert into adpremium values (42, 290, '01/25/2022', '01/30/2022');
insert into adpremium values (42, 290, '02/07/2022', '02/12/2022');
insert into adpremium values (42, 290, '12/28/2021', '01/02/2022');
insert into adpremium values (42, 290, '01/19/2022', '01/24/2022');
insert into adpremium values (42, 648, '02/15/2022', '02/20/2022');
insert into adpremium values (42, 628, '01/27/2022', '02/01/2022');
insert into adpremium values (42, 231, '12/27/2021', '01/01/2022');
insert into adpremium values (42, 152, '02/01/2022', '02/06/2022');
insert into adpremium values (42, 152, '01/25/2022', '01/30/2022');
insert into adpremium values (42, 153, '01/26/2022', '01/31/2022');
insert into adpremium values (42, 409, '01/28/2022', '02/02/2022');
insert into adpremium values (42, 153, '01/31/2022', '02/05/2022');
insert into adpremium values (42, 152, '02/03/2022', '02/08/2022');
insert into adpremium values (42, 154, '02/03/2022', '02/08/2022');
insert into adpremium values (42, 152, '02/06/2022', '02/11/2022');
insert into adpremium values (42, 152, '02/07/2022', '02/12/2022');
insert into adpremium values (42, 409, '02/08/2022', '02/13/2022');
insert into adpremium values (42, 150, '02/08/2022', '02/13/2022');
insert into adpremium values (42, 154, '02/08/2022', '02/13/2022');
insert into adpremium values (42, 409, '02/09/2022', '02/14/2022');
insert into adpremium values (42, 152, '02/11/2022', '02/16/2022');
insert into adpremium values (42, 416, '02/15/2022', '02/20/2022');
insert into adpremium values (42, 154, '02/15/2022', '02/20/2022');
insert into adpremium values (42, 154, '02/16/2022', '02/21/2022');
insert into adpremium values (42, 153, '02/18/2022', '02/23/2022');
insert into adpremium values (42, 152, '02/20/2022', '02/25/2022');
insert into adpremium values (42, 150, '02/21/2022', '02/26/2022');
insert into adpremium values (42, 126, '01/19/2022', '01/24/2022');
insert into adpremium values (42, 128, '01/10/2022', '01/15/2022');
insert into adpremium values (42, 128, '02/02/2022', '02/07/2022');
insert into adpremium values (42, 128, '01/12/2022', '01/17/2022');
insert into adpremium values (42, 412, '01/24/2022', '01/29/2022');
insert into adpremium values (42, 158, '01/20/2022', '01/25/2022');
insert into adpremium values (42, 208, '12/22/2021', '12/27/2021');
insert into adpremium values (42, 407, '12/22/2021', '12/27/2021');
insert into adpremium values (42, 409, '12/22/2021', '12/27/2021');
insert into adpremium values (42, 152, '12/22/2021', '12/27/2021');
insert into adpremium values (42, 155, '12/22/2021', '12/27/2021');
insert into adpremium values (42, 293, '12/28/2021', '01/02/2022');
insert into adpremium values (42, 154, '12/29/2021', '01/03/2022');
insert into adpremium values (42, 152, '01/10/2022', '01/15/2022');
insert into adpremium values (42, 150, '01/12/2022', '01/17/2022');
insert into adpremium values (42, 152, '01/14/2022', '01/19/2022');
insert into adpremium values (42, 152, '01/25/2022', '01/30/2022');
insert into adpremium values (42, 150, '01/20/2022', '01/25/2022');
insert into adpremium values (42, 152, '01/20/2022', '01/25/2022');
insert into adpremium values (42, 425, '01/20/2022', '01/25/2022');
insert into adpremium values (42, 155, '01/20/2022', '01/25/2022');
insert into adpremium values (42, 409, '01/18/2022', '01/23/2022');
insert into adpremium values (42, 208, '01/20/2022', '01/25/2022');
insert into adpremium values (42, 407, '01/20/2022', '01/25/2022');
insert into adpremium values (42, 601, '01/20/2022', '01/25/2022');
insert into adpremium values (42, 409, '01/20/2022', '01/25/2022');
insert into adpremium values (42, 153, '01/20/2022', '01/25/2022');
insert into adpremium values (42, 153, '01/22/2022', '01/27/2022');
insert into adpremium values (43, 154, '12/31/2021', '01/05/2022');
insert into adpremium values (43, 153, '01/06/2022', '01/11/2022');

go

