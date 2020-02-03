namespace DigitalLibrary.Utils.ControlPanel.DataSample.MasterData
{
    using System.Collections.Generic;

    using DigitalLibrary.MasterData.Ctx;
    using DigitalLibrary.MasterData.DomainModel;

    public static partial class MasterDataDataSample
    {
        private static void PopulateSourceFormatBusinessPartner(MasterDataContext ctx)
        {
            Dimension hungarianPublicSpaceRegistrationNumberDimension = new Dimension
            {
                Name = "Hungarian Public Space Registration Number",
                Description = "Hungarian Public Space Registration Number",
                IsActive = 1,
            };
            ctx.Dimensions.Add(hungarianPublicSpaceRegistrationNumberDimension);
            ctx.SaveChanges();
            DimensionStructure hungarianPublicSpaceRegistrationNumber = new DimensionStructure
            {
                Name = "Hungarian Public Space Registration Number",
                Desc = "Hungarian Public Space Registration number",
                DimensionId = hungarianPublicSpaceRegistrationNumberDimension.Id,
                IsActive = 1,
            };
            ctx.DimensionStructures.Add(hungarianPublicSpaceRegistrationNumber);
            ctx.SaveChanges();

            Dimension hungarianPublicSpaceNumberDimension = new Dimension
            {
                Name = "Hungarian Public Space Number",
                Description = "Hungarian Public Space Number",
                IsActive = 1,
            };
            ctx.Dimensions.Add(hungarianPublicSpaceNumberDimension);
            ctx.SaveChanges();
            DimensionStructure hungarianPublicSpaceNumber = new DimensionStructure
            {
                Name = "Hungarian Public Space Number",
                Desc = "Hungarian Public Space Number",
                DimensionId = hungarianPublicSpaceNumberDimension.Id,
                IsActive = 1,
            };
            ctx.DimensionStructures.Add(hungarianPublicSpaceNumber);
            ctx.SaveChanges();

            Dimension hungarianPublicSpaceNameDimension = new Dimension
            {
                Name = "Hungarian Public Space Name",
                Description = "Hungarian Public Space Name",
                IsActive = 1,
            };
            ctx.Dimensions.Add(hungarianPublicSpaceNameDimension);
            ctx.SaveChanges();
            DimensionStructure hungarianPublicSpaceName = new DimensionStructure
            {
                Name = "hungarian Public Space Name",
                Desc = "Hungarian Public Space Name, which can be street name or registration number",
                DimensionId = hungarianPublicSpaceNameDimension.Id,
                IsActive = 1,
            };
            ctx.DimensionStructures.Add(hungarianPublicSpaceName);
            ctx.SaveChanges();

            DimensionStructure hungarianPublicSpace = new DimensionStructure
            {
                Name = "Hungarian Public Place",
                Desc = "Hungarian Public Place, which consists of place name, place type and place number," +
                       "or registration number",
                IsActive = 1,
            };
            ctx.DimensionStructures.Add(hungarianPublicSpace);
            ctx.SaveChanges();

            DimensionStructureDimensionStructure hungarianPublicSpaceNameAndHungarianPublicSpaceConnected =
                new DimensionStructureDimensionStructure
                {
                    ParentDimensionStructureId = hungarianPublicSpace.Id,
                    ChildDimensionStructureId = hungarianPublicSpaceName.Id,
                };
            ctx.DimensionStructureDimensionStructures.Add(hungarianPublicSpaceNameAndHungarianPublicSpaceConnected);
            ctx.SaveChanges();

            DimensionStructureDimensionStructure hungarianPublicSpaceNumberAndHungarianPublicSpaceConnected =
                new DimensionStructureDimensionStructure
                {
                    ParentDimensionStructureId = hungarianPublicSpace.Id,
                    ChildDimensionStructureId = hungarianPublicSpaceNumber.Id,
                };
            ctx.DimensionStructureDimensionStructures.Add(hungarianPublicSpaceNumberAndHungarianPublicSpaceConnected);
            ctx.SaveChanges();

            DimensionStructureDimensionStructure hungarianPublicSpaceRegistrationNumberAndHungarianPublicspaceConnected
                =
                new DimensionStructureDimensionStructure
                {
                    ParentDimensionStructureId = hungarianPublicSpace.Id,
                    ChildDimensionStructureId = hungarianPublicSpaceRegistrationNumber.Id,
                };
            ctx.DimensionStructureDimensionStructures.Add(
                hungarianPublicSpaceRegistrationNumberAndHungarianPublicspaceConnected);
            ctx.SaveChanges();

            Dimension hungarianTownDimension = new Dimension
            {
                Name = "Hungarian Town",
                Description = "Hungarian Town",
                IsActive = 1,
            };
            ctx.Dimensions.Add(hungarianTownDimension);
            ctx.SaveChanges();

            DimensionStructure hungarianTown = new DimensionStructure
            {
                Name = "Hungarian Town",
                Desc = "Hungarian Town",
                DimensionId = hungarianTownDimension.Id,
                IsActive = 1,
            };
            ctx.DimensionStructures.Add(hungarianTown);
            ctx.SaveChanges();

            Dimension hungarianPoBoxNumber = new Dimension
            {
                Name = "Hungarian P.O. Box number",
                Description = "Hungarian P.O. Box number",
                IsActive = 1,
            };
            ctx.Dimensions.Add(hungarianPoBoxNumber);
            ctx.SaveChanges();

            DimensionStructure poBox = new DimensionStructure
            {
                Name = "Hungarian PO Box number",
                Desc = "Hungarian PO Box number",
                DimensionId = hungarianPoBoxNumber.Id,
                IsActive = 1,
            };
            ctx.DimensionStructures.Add(poBox);
            ctx.SaveChanges();

            DimensionStructure businessPartnerAddress = new DimensionStructure
            {
                Name = "Hungarian Address Dimension Structure",
                Desc = "Hungarian Address Dimension Structure",
                IsActive = 1,
            };
            ctx.DimensionStructures.Add(businessPartnerAddress);
            ctx.SaveChanges();

            DimensionStructureDimensionStructure hungarianTownBusinessPartnerAddressConnected =
                new DimensionStructureDimensionStructure
                {
                    ParentDimensionStructureId = businessPartnerAddress.Id,
                    ChildDimensionStructureId = hungarianTown.Id,
                };
            ctx.DimensionStructureDimensionStructures.Add(hungarianTownBusinessPartnerAddressConnected);
            ctx.SaveChanges();

            DimensionStructureDimensionStructure hungarianPoBoxBusinessPartnerAddressConnected =
                new DimensionStructureDimensionStructure
                {
                    ParentDimensionStructureId = businessPartnerAddress.Id,
                    ChildDimensionStructureId = poBox.Id
                };
            ctx.DimensionStructureDimensionStructures.Add(hungarianPoBoxBusinessPartnerAddressConnected);
            ctx.SaveChanges();

            DimensionStructureDimensionStructure hungarianPublicPlaceAndBusinessPartnerAddressConnected =
                new DimensionStructureDimensionStructure
                {
                    ParentDimensionStructureId = businessPartnerAddress.Id,
                    ChildDimensionStructureId = hungarianPublicSpace.Id,
                };
            ctx.DimensionStructureDimensionStructures.Add(hungarianPublicPlaceAndBusinessPartnerAddressConnected);
            ctx.SaveChanges();

            Dimension hungarianLegalEntityFormatDimension = new Dimension
            {
                Name = "Hungarian Legal Entity Format",
                Description = "Hungarian Legal Entity Format, such as Kft., Bt., etc.",
                IsActive = 1,
            };
            ctx.Dimensions.Add(hungarianLegalEntityFormatDimension);
            ctx.SaveChanges();

            DimensionStructure hungarianLegalEntityFormat = new DimensionStructure
            {
                Name = "Hungarian Legal Entity Format",
                Desc = "Hungarian Legal Entity Format, mainly Kft., Bt., or etc.",
                DimensionId = hungarianLegalEntityFormatDimension.Id,
                IsActive = 1
            };
            ctx.DimensionStructures.Add(hungarianLegalEntityFormat);
            ctx.SaveChanges();

            Dimension hungarianLegalEntityNameDimension = new Dimension
            {
                Name = "Hungarian Legal Entity Name",
                Description = "Hungarian Legal Entity Name, it is defined by owners but regulated by law",
                IsActive = 1,
            };
            ctx.Dimensions.Add(hungarianLegalEntityNameDimension);
            ctx.SaveChanges();

            DimensionStructure hungarianLegalEntityName = new DimensionStructure
            {
                Name = "Hungarian Legal Entity Name",
                Desc = "Hungarian Legal Entity Name, mainly company name",
                DimensionId = hungarianLegalEntityNameDimension.Id,
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
            ctx.DimensionStructureDimensionStructures.Add(businessPartnerAddressBusinessPartnerConnected);
            ctx.SaveChanges();

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