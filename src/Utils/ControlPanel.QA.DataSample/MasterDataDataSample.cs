namespace ControlPanel.QA.DataSample
{
    using System;

    using DigitalLibrary.IaC.MasterData.Ctx.Ctx;
    using DigitalLibrary.IaC.MasterData.DomainModel.DomainModel;

    public static class MasterDataDataSample
    {
        public static void Populate(MasterDataContext ctx)
        {
            populateBusinessPartnerDimensionStructure(ctx);
            populateNutritionIntakeDimensionStructure(ctx);
            populateRssContentDimensionStructure(ctx);
            populateDimensionsWithoutStructure(ctx);
        }

        private static void populateDimensionsWithoutStructure(MasterDataContext ctx)
        {
            Dimension dimension1 = new Dimension
            {
                Name = "dimension 1",
                Description = "dimension 1 desc",
                IsActive = 1
            };
            ctx.Dimensions.Add(dimension1);
            ctx.SaveChanges();
            Console.WriteLine($"{dimension1.Name} is created...");

            Dimension dimension2 = new Dimension
            {
                Name = "dimension 2",
                Description = "dimension 2 desc",
                IsActive = 1
            };
            ctx.Dimensions.Add(dimension2);
            ctx.SaveChanges();
            Console.WriteLine($"{dimension2.Name} is created...");

            Dimension dimension3 = new Dimension
            {
                Name = "dimension 3",
                Description = "dimension 3 desc",
                IsActive = 1
            };
            ctx.Dimensions.Add(dimension3);
            ctx.SaveChanges();
            Console.WriteLine($"{dimension3.Name} is created...");
        }

        private static void populateRssContentDimensionStructure(MasterDataContext ctx)
        {
            DimensionStructure rssTopDimensionStructure = new DimensionStructure
            {
                Name = "RSS Dimension Structure",
                Desc = "RSS Dimension structure",
                IsActive = 1
            };
            ctx.DimensionStructures.Add(rssTopDimensionStructure);
            ctx.SaveChanges();
        }

        private static void populateNutritionIntakeDimensionStructure(MasterDataContext ctx)
        {
            DimensionStructure nutritionIntakeTopDimensionStructure = new DimensionStructure
            {
                Name = "Nutrition intake",
                Desc = "Nutrition intake dimension structure",
                IsActive = 1
            };
            ctx.DimensionStructures.Add(nutritionIntakeTopDimensionStructure);
            ctx.SaveChanges();
        }

        private static void populateBusinessPartnerDimensionStructure(MasterDataContext ctx)
        {
            DimensionStructure businessEntityTopDimensionStructure = new DimensionStructure
            {
                Name = "Business partner",
                Desc = "Business partner in which between business transaction might happen",
                IsActive = 1,
            };
            ctx.DimensionStructures.Add(businessEntityTopDimensionStructure);
            ctx.SaveChanges();

            Dimension businessEntityNameDimension = new Dimension
            {
                Name = "Hungarian Business Entity Name",
                Description = "Name of the business entity, which is regulated by Hungarian law",
                IsActive = 1
            };
            ctx.Dimensions.Add(businessEntityNameDimension);
            ctx.SaveChanges();

            DimensionStructure businessEntityNameDimensionStructure = new DimensionStructure
            {
                Name = businessEntityNameDimension.Name,
                Desc = businessEntityNameDimension.Description,
                IsActive = 1,
                DimensionId = businessEntityNameDimension.Id,
                ParentDimensionStructureId = businessEntityTopDimensionStructure.Id
            };
            ctx.DimensionStructures.Add(businessEntityNameDimensionStructure);
            ctx.SaveChanges();

            Dimension businessEntityType = new Dimension
            {
                Name = "hungarian legal entity type",
                Description = "Hungarian entity types regulated by some laws",
                IsActive = 1
            };
            ctx.Dimensions.Add(businessEntityType);
            ctx.SaveChanges();

            DimensionStructure businessEntityTypeDimensionStructure = new DimensionStructure
            {
                Name = businessEntityType.Name,
                Desc = businessEntityType.Description,
                DimensionId = businessEntityType.Id,
                IsActive = 1,
                ParentDimensionStructureId = businessEntityTopDimensionStructure.Id
            };
            ctx.DimensionStructures.Add(businessEntityTypeDimensionStructure);
            ctx.SaveChanges();

            DimensionStructure businessEntityPostalAddressDimensionStructure = new DimensionStructure
            {
                Name = "Hungarian Postal Address",
                Desc = "Hungarian Postal Address",
                IsActive = 1,
                ParentDimensionStructureId = businessEntityTopDimensionStructure.Id
            };
            ctx.DimensionStructures.Add(businessEntityPostalAddressDimensionStructure);
            ctx.SaveChanges();

            Dimension hungarianTownDimension = new Dimension
            {
                Name = "Hungarian town",
                Description = "Hungarian town",
                IsActive = 1
            };
            ctx.Dimensions.Add(hungarianTownDimension);
            ctx.SaveChanges();
            DimensionStructure businessEntityPostalAddressTownDimensionStructure = new DimensionStructure
            {
                Name = "Hungarian Town",
                Desc = "Hungarian town",
                IsActive = 1,
                ParentDimensionStructureId = businessEntityPostalAddressDimensionStructure.Id,
                DimensionId = hungarianTownDimension.Id
            };
            ctx.DimensionStructures.Add(businessEntityPostalAddressTownDimensionStructure);
            ctx.SaveChanges();

            Dimension hungarianPublicPlaceDimension = new Dimension
            {
                Name = "Hungarian street name",
                Description = "Hungarian street name",
                IsActive = 1
            };
            ctx.Dimensions.Add(hungarianPublicPlaceDimension);
            ctx.SaveChanges();
            DimensionStructure hungarianPublicPlaceDimensionStructure = new DimensionStructure
            {
                Name = hungarianPublicPlaceDimension.Name,
                Desc = hungarianPublicPlaceDimension.Description,
                IsActive = 1,
                DimensionId = hungarianPublicPlaceDimension.Id,
                ParentDimensionStructureId = businessEntityPostalAddressDimensionStructure.Id
            };
            ctx.DimensionStructures.Add(hungarianPublicPlaceDimensionStructure);
            ctx.SaveChanges();

            Dimension hungarianPublicPlaceTypeDimension = new Dimension
            {
                Name = "Hungarian public place type",
                Description = "Hungarian public place type",
                IsActive = 1
            };
            ctx.Dimensions.Add(hungarianPublicPlaceTypeDimension);
            ctx.SaveChanges();
            DimensionStructure hungarianPublicPlaceTypeDimensionStructure = new DimensionStructure
            {
                Name = hungarianPublicPlaceTypeDimension.Name,
                Desc = hungarianPublicPlaceTypeDimension.Description,
                IsActive = 1,
                DimensionId = hungarianPublicPlaceTypeDimension.Id,
                ParentDimensionStructureId = businessEntityPostalAddressDimensionStructure.Id
            };
            ctx.DimensionStructures.Add(hungarianPublicPlaceTypeDimensionStructure);
            ctx.SaveChanges();

            Dimension hungarianPublicPlaceNumberDimension = new Dimension
            {
                Name = "Hungarian public place number",
                Description = "Hungarian public place number",
                IsActive = 1
            };
            ctx.Dimensions.Add(hungarianPublicPlaceNumberDimension);
            ctx.SaveChanges();
            DimensionStructure hungarianPublicPlaceNumberDimensionStructure = new DimensionStructure
            {
                Name = hungarianPublicPlaceNumberDimension.Name,
                Desc = hungarianPublicPlaceNumberDimension.Description,
                IsActive = 1,
                DimensionId = hungarianPublicPlaceNumberDimension.Id,
                ParentDimensionStructureId = businessEntityPostalAddressDimensionStructure.Id
            };
            ctx.DimensionStructures.Add(hungarianPublicPlaceNumberDimensionStructure);
            ctx.SaveChanges();
        }
    }
}