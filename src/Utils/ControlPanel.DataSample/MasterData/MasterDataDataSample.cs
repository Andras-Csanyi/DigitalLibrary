namespace DigitalLibrary.Utils.ControlPanel.DataSample.MasterData
{
    using System;
    using System.Collections.Generic;

    using DigitalLibrary.MasterData.Ctx;
    using DigitalLibrary.MasterData.DomainModel;

    public static partial class MasterDataDataSample
    {
        public const int SourceFormatAmount = 10;

        public const int DimensionStructureAmount = 30;

        public static int GetSourceFormatAmount()
        {
            return SourceFormatAmount
                 + AmountOfSourceFormat_BusinessPartner;
        }

        public static int GetDimensionStructureAmount()
        {
            return DimensionStructureAmount;
        }

        public static void Populate(MasterDataContext ctx)
        {
            PopulateBlankSourceFormats(ctx);
            PopulateSourceFormatBusinessPartner(ctx);
            PopulateNutritionIntakeDimensionStructure(ctx);
            PopulateRssContentDimensionStructure(ctx);
            PopulateDimensionsWithoutStructure(ctx);
            PopulateDimensionStructures(ctx);
        }

        private static void PopulateDimensionStructures(MasterDataContext ctx)
        {
            List<DimensionStructure> dimensionStructures = new List<DimensionStructure>();
            for (int i = 0; i < DimensionStructureAmount; i++)
            {
                DimensionStructure dimensionStructure = new DimensionStructure
                {
                    Name = $"Dimension Structure {i}",
                    Desc = $"Dimension Structure Description {i}",
                    IsActive = 1,
                };
                dimensionStructures.Add(dimensionStructure);
            }

            ctx.DimensionStructures.AddRange(dimensionStructures);
            ctx.SaveChanges();
        }

        private static void PopulateBlankSourceFormats(MasterDataContext ctx)
        {
            List<SourceFormat> sourceFormats = new List<SourceFormat>();
            for (int i = 0; i < SourceFormatAmount; i++)
            {
                SourceFormat sourceFormat = new SourceFormat
                {
                    Name = $"Source Format Name - {i}",
                    Desc = $"Source Format Description - {i}",
                    IsActive = 1,
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