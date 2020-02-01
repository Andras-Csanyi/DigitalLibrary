namespace DigitalLibrary.Utils.ControlPanel.DataSample.MasterData
{
    using System.Collections.Generic;

    using DigitalLibrary.MasterData.Ctx;
    using DigitalLibrary.MasterData.DomainModel;

    public static partial class MasterDataDataSample
    {
        private static void PopulateSourceFormatBusinessPartner(MasterDataContext ctx)
        {
            DimensionStructure businessPartnerAddress = new DimensionStructure
            {
                Name = "Hungarian Address Dimension Structure",
                Desc = "Hungarian Address Dimension Structure",
                IsActive = 1
            };
            ctx.DimensionStructures.Add(businessPartnerAddress);
            ctx.SaveChanges();

            DimensionStructure hungarianLegalEntityFormat = new DimensionStructure
            {
                Name = "Hungarian Legal Entity Format",
                Desc = "Hungarian Legal Entity Format, mainly Kft., Bt., or etc.",
                IsActive = 1
            };
            ctx.DimensionStructures.Add(hungarianLegalEntityFormat);
            ctx.SaveChanges();

            DimensionStructure hungarianLegalEntityName = new DimensionStructure
            {
                Name = "Hungarian Legal Entity Name",
                Desc = "Hungarian Legal Entity Name, mainly company name",
                IsActive = 1
            };
            ctx.DimensionStructures.Add(hungarianLegalEntityName);
            ctx.SaveChanges();

            DimensionStructure businessPartnerNameDimensionStructure = new DimensionStructure
            {
                Name = "Business Partner Name",
                Desc = "Name of the business partner, a.k.a. legal entity",
                IsActive = 1,
            };
            ctx.DimensionStructures.Add(businessPartnerNameDimensionStructure);
            ctx.SaveChanges();

            DimensionStructureDimensionStructure hungarianLegalEntityNameBusinessPartnerNameConnected =
                new DimensionStructureDimensionStructure
                {
                    ChildDimensionStructureId = hungarianLegalEntityName.Id,
                    ParentDimensionStructureId = businessPartnerNameDimensionStructure.Id,
                };
            ctx.DimensionStructureDimensionStructures.Add(hungarianLegalEntityNameBusinessPartnerNameConnected);
            ctx.SaveChanges();

            DimensionStructureDimensionStructure hungarianLegalEntityFormatBusinessPartnerNameConnected =
                new DimensionStructureDimensionStructure
                {
                    ChildDimensionStructureId = hungarianLegalEntityFormat.Id,
                    ParentDimensionStructureId = businessPartnerNameDimensionStructure.Id,
                };
            ctx.DimensionStructureDimensionStructures.Add(hungarianLegalEntityFormatBusinessPartnerNameConnected);
            ctx.SaveChanges();

            DimensionStructure businessPartnerRootDimensionStructure = new DimensionStructure
            {
                Name = "Hungarian Business Partner",
                Desc = "Root Dimension Structure for Hungarian Business Partner Dimension Structure",
                IsActive = 1,
            };
            ctx.DimensionStructures.Add(businessPartnerRootDimensionStructure);
            ctx.SaveChanges();

            DimensionStructureDimensionStructure businessPartnerNameBusinessPartnerConnected =
                new DimensionStructureDimensionStructure
                {
                    ParentDimensionStructureId = businessPartnerRootDimensionStructure.Id,
                    ChildDimensionStructureId = businessPartnerNameDimensionStructure.Id,
                };
            ctx.DimensionStructureDimensionStructures.Add(businessPartnerNameBusinessPartnerConnected);
            ctx.SaveChanges();

            DimensionStructureDimensionStructure businessPartnerAddressBusinessPartnerConnected =
                new DimensionStructureDimensionStructure
                {
                    ParentDimensionStructureId = businessPartnerRootDimensionStructure.Id,
                    ChildDimensionStructureId = businessPartnerAddress.Id,
                };

            SourceFormat businessPartner = new SourceFormat
            {
                Name = "Hungarian Business Partner Source Format",
                Desc = "Source format for being able to record Business Partners from Hungary",
                IsActive = 1,
                RootDimensionStructureId = businessPartnerRootDimensionStructure.Id,
            };
            ctx.SourceFormats.Add(businessPartner);
            ctx.SaveChanges();
        }
    }
}