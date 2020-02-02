namespace DigitalLibrary.Utils.ControlPanel.DataSample.MasterData
{
    using System;
    using System.Collections.Generic;

    using DigitalLibrary.MasterData.Ctx;
    using DigitalLibrary.MasterData.DomainModel;

    public static partial class MasterDataDataSample
    {
        public static void Populate(MasterDataContext ctx)
        {
            PopulateBlankSourceFormats(ctx);
            PopulateSourceFormatBusinessPartner(ctx);
            PopulateNutritionIntakeDimensionStructure(ctx);
            PopulateRssContentDimensionStructure(ctx);
            PopulateDimensionsWithoutStructure(ctx);
        }

        private static void PopulateBlankSourceFormats(MasterDataContext ctx)
        {
            int amout = 10;
            List<SourceFormat> sourceFormats = new List<SourceFormat>();
            for (int i = 0; i < amout; i++)
            {
                SourceFormat sourceFormat = new SourceFormat
                {
                    Name = $"Source Format Name - {i}",
                    Desc = $"Source Format Description - {i}",
                    IsActive = 1
                };
                sourceFormats.Add(sourceFormat);
            }

            ctx.SourceFormats.AddRange(sourceFormats);
            ctx.SaveChanges();
        }

        private static void PopulateDimensionsWithoutStructure(MasterDataContext ctx)
        {
            for (int i = 0; i < 10; i++)
            {
                Dimension dimension1 = new Dimension
                {
                    Name = $"Dimension Name - {i}",
                    Description = $"Dimension Name Description - {i}",
                    IsActive = 1,
                };
                ctx.Dimensions.Add(dimension1);
                ctx.SaveChanges();
            }
        }

        private static void PopulateRssContentDimensionStructure(MasterDataContext ctx)
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

        private static void PopulateNutritionIntakeDimensionStructure(MasterDataContext ctx)
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
    }
}