namespace DigitalLibrary.Utils.ControlPanel.DataSample.MasterData
{
    using System.Collections.Generic;

    using DigitalLibrary.MasterData.Ctx;
    using DigitalLibrary.MasterData.DomainModel;

    using Microsoft.EntityFrameworkCore;

    public static partial class MasterDataDataSample
    {
        private static void PopulateSourceFormatBusinessPartner(MasterDataContext ctx)
        {
            // structure - hierarchy
            SourceFormat businessPartner = new SourceFormat
            {
                Name = "Hungarian Business Partner Source Format",
                Desc = "Source format for being able to record Business Partners from Hungary",
                IsActive = 1,
            };
            ctx.SourceFormats.Add(businessPartner);
            ctx.SaveChanges();

            DimensionStructure businessPartnerRootDimensionStructure = new DimensionStructure
            {
                Name = "Hungarian Business Partner",
                Desc = "Root Dimension Structure for Hungarian Business Partner Dimension Structure",
                IsActive = 1,
            };
            ctx.DimensionStructures.Add(businessPartnerRootDimensionStructure);
            ctx.SaveChanges();

            businessPartner.RootDimensionStructureId = businessPartnerRootDimensionStructure.Id;
            ctx.Entry(businessPartner).State = EntityState.Modified;
            ctx.SaveChanges();

            DimensionStructure businessPartnerNameDimensionStructure = new DimensionStructure
            {
                Name = "Business Partner Name Dimension Structure",
                Desc = "Name of the business partner, a.k.a. legal entity",
                IsActive = 1,
            };
            ctx.DimensionStructures.Add(businessPartnerNameDimensionStructure);
            ctx.SaveChanges();

            DimensionStructureDimensionStructure businessPartner_businessPartnerName =
                new DimensionStructureDimensionStructure
                {
                    ParentDimensionStructureId = businessPartnerRootDimensionStructure.Id,
                    ChildDimensionStructureId = businessPartnerNameDimensionStructure.Id,
                };
            ctx.DimensionStructureDimensionStructures.Add(businessPartner_businessPartnerName);
            ctx.SaveChanges();

            DimensionStructure hungarianLegalEntityName = new DimensionStructure
            {
                Name = "Hungarian Legal Entity Name Dimension Structure",
                Desc = "Hungarian Legal Entity Name, mainly company name",
                IsActive = 1,
            };
            ctx.DimensionStructures.Add(hungarianLegalEntityName);
            ctx.SaveChanges();

            DimensionStructureDimensionStructure businessPartner_hungarianLegalEntityName =
                new DimensionStructureDimensionStructure
                {
                    ParentDimensionStructureId = businessPartnerRootDimensionStructure.Id,
                    ChildDimensionStructureId = hungarianLegalEntityName.Id,
                };
            ctx.DimensionStructureDimensionStructures.Add(businessPartner_hungarianLegalEntityName);
            ctx.SaveChanges();

            DimensionStructure hungarianLegalEntityFormat = new DimensionStructure
            {
                Name = "Hungarian Legal Entity Format",
                Desc = "Hungarian Legal Entity Format, mainly Kft., Bt., or etc.",
                IsActive = 1
            };
            ctx.DimensionStructures.Add(hungarianLegalEntityFormat);
            ctx.SaveChanges();

            DimensionStructureDimensionStructure hungarianBusinessPartner_hungarianLegalEntityFormat =
                new DimensionStructureDimensionStructure
                {
                    ParentDimensionStructureId = businessPartnerRootDimensionStructure.Id,
                    ChildDimensionStructureId = hungarianLegalEntityFormat.Id
                };
            ctx.DimensionStructureDimensionStructures.Add(hungarianBusinessPartner_hungarianLegalEntityFormat);
            ctx.SaveChanges();

            DimensionStructure hungarianBusinessPartnerAddress = new DimensionStructure
            {
                Name = "Hungarian Address Dimension Structure",
                Desc = "Hungarian Address Dimension Structure",
                IsActive = 1,
            };
            ctx.DimensionStructures.Add(hungarianBusinessPartnerAddress);
            ctx.SaveChanges();

            DimensionStructureDimensionStructure businessPartner_hungarianAddressDimensionStructure =
                new DimensionStructureDimensionStructure
                {
                    ParentDimensionStructureId = businessPartnerRootDimensionStructure.Id,
                    ChildDimensionStructureId = hungarianBusinessPartnerAddress.Id,
                };
            ctx.DimensionStructureDimensionStructures.Add(businessPartner_hungarianAddressDimensionStructure);
            ctx.SaveChanges();

            DimensionStructure hungarianTown = new DimensionStructure
            {
                Name = "Hungarian Town",
                Desc = "Hungarian Town",
                IsActive = 1,
            };
            ctx.DimensionStructures.Add(hungarianTown);
            ctx.SaveChanges();

            DimensionStructureDimensionStructure hungarianBusinessPartnerAddress_hungarianTown =
                new DimensionStructureDimensionStructure
                {
                    ParentDimensionStructureId = hungarianBusinessPartnerAddress.Id,
                    ChildDimensionStructureId = hungarianTown.Id,
                };
            ctx.DimensionStructureDimensionStructures.Add(hungarianBusinessPartnerAddress_hungarianTown);
            ctx.SaveChanges();

            DimensionStructure hungarianPoBoxNumber = new DimensionStructure
            {
                Name = "Hungarian PO Box number",
                Desc = "Hungarian PO Box number",
                IsActive = 1,
            };
            ctx.DimensionStructures.Add(hungarianPoBoxNumber);
            ctx.SaveChanges();

            DimensionStructureDimensionStructure hungarianBusinessPartnerAddress_hungarianPoBox =
                new DimensionStructureDimensionStructure
                {
                    ParentDimensionStructureId = hungarianBusinessPartnerAddress.Id,
                    ChildDimensionStructureId = hungarianPoBoxNumber.Id,
                };
            ctx.DimensionStructureDimensionStructures.Add(hungarianBusinessPartnerAddress_hungarianPoBox);
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

            DimensionStructureDimensionStructure hungarianBusinessPartner_hungarianPublicSpace =
                new DimensionStructureDimensionStructure
                {
                    ParentDimensionStructureId = hungarianBusinessPartnerAddress.Id,
                    ChildDimensionStructureId = hungarianPublicSpace.Id,
                };
            ctx.DimensionStructureDimensionStructures.Add(hungarianBusinessPartner_hungarianPublicSpace);
            ctx.SaveChanges();

            DimensionStructure hungarianPublicSpaceName = new DimensionStructure
            {
                Name = "hungarian Public Space Name",
                Desc = "Hungarian Public Space Name, which can be street name or registration number",
                IsActive = 1,
            };
            ctx.DimensionStructures.Add(hungarianPublicSpaceName);
            ctx.SaveChanges();

            DimensionStructureDimensionStructure hungarianPublicSpace_hungarianPublicSpaceName =
                new DimensionStructureDimensionStructure
                {
                    ParentDimensionStructureId = hungarianPublicSpace.Id,
                    ChildDimensionStructureId = hungarianPublicSpaceName.Id,
                };
            ctx.DimensionStructureDimensionStructures.Add(hungarianPublicSpace_hungarianPublicSpaceName);
            ctx.SaveChanges();

            DimensionStructure hungarianPublicSpaceNumber = new DimensionStructure
            {
                Name = "Hungarian Public Space Number",
                Desc = "Hungarian Public Space Number",
                IsActive = 1,
            };
            ctx.DimensionStructures.Add(hungarianPublicSpaceNumber);
            ctx.SaveChanges();

            DimensionStructureDimensionStructure hungarianPublicSpace_hungarianPublicSpaceNumber =
                new DimensionStructureDimensionStructure
                {
                    ParentDimensionStructureId = hungarianPublicSpace.Id,
                    ChildDimensionStructureId = hungarianPublicSpaceNumber.Id,
                };
            ctx.DimensionStructureDimensionStructures.Add(hungarianPublicSpace_hungarianPublicSpaceNumber);
            ctx.SaveChanges();

            DimensionStructure hungarianPublicSpaceRegistrationNumber = new DimensionStructure
            {
                Name = "Hungarian Public Space Registration Number",
                Desc = "Hungarian Public Space Registration number",
                IsActive = 1,
            };
            ctx.DimensionStructures.Add(hungarianPublicSpaceRegistrationNumber);
            ctx.SaveChanges();

            DimensionStructureDimensionStructure hungarianPublicSpace_hungarianPublicspaceRegistrationNumber =
                new DimensionStructureDimensionStructure
                {
                    ParentDimensionStructureId = hungarianPublicSpace.Id,
                    ChildDimensionStructureId = hungarianPublicSpaceRegistrationNumber.Id,
                };
            ctx.DimensionStructureDimensionStructures.Add(hungarianPublicSpace_hungarianPublicspaceRegistrationNumber);
            ctx.SaveChanges();

            // Dimensions
            Dimension hungarianPublicSpaceRegistrationNumberDimension = new Dimension
            {
                Name = "Hungarian Public Space Registration Number",
                Description = "Hungarian Public Space Registration Number",
                IsActive = 1,
            };
            ctx.Dimensions.Add(hungarianPublicSpaceRegistrationNumberDimension);
            ctx.SaveChanges();
            hungarianPublicSpaceRegistrationNumber.DimensionId = hungarianPublicSpaceRegistrationNumberDimension.Id;
            ctx.Entry(hungarianPublicSpaceRegistrationNumber).State = EntityState.Modified;
            ctx.SaveChanges();

            Dimension hungarianPublicSpaceNumberDimension = new Dimension
            {
                Name = "Hungarian Public Space Number",
                Description = "Hungarian Public Space Number",
                IsActive = 1,
            };
            ctx.Dimensions.Add(hungarianPublicSpaceNumberDimension);
            ctx.SaveChanges();
            hungarianPublicSpaceNumber.DimensionId = hungarianPublicSpaceNumberDimension.Id;
            ctx.Entry(hungarianPublicSpaceNumber).State = EntityState.Modified;
            ctx.SaveChanges();

            Dimension hungarianPublicSpaceNameDimension = new Dimension
            {
                Name = "Hungarian Public Space Name",
                Description = "Hungarian Public Space Name",
                IsActive = 1,
            };
            ctx.Dimensions.Add(hungarianPublicSpaceNameDimension);
            ctx.SaveChanges();
            hungarianPublicSpaceName.DimensionId = hungarianPublicSpaceNameDimension.Id;
            ctx.Entry(hungarianPublicSpaceName).State = EntityState.Modified;
            ctx.SaveChanges();

            Dimension hungarianTownDimension = new Dimension
            {
                Name = "Hungarian Town",
                Description = "Hungarian Town",
                IsActive = 1,
            };
            ctx.Dimensions.Add(hungarianTownDimension);
            ctx.SaveChanges();
            hungarianTown.DimensionId = hungarianTownDimension.Id;
            ctx.Entry(hungarianTown).State = EntityState.Modified;
            ctx.SaveChanges();

            Dimension hungarianPoBoxNumberDimension = new Dimension
            {
                Name = "Hungarian P.O. Box number",
                Description = "Hungarian P.O. Box number",
                IsActive = 1,
            };
            ctx.Dimensions.Add(hungarianPoBoxNumberDimension);
            ctx.SaveChanges();
            hungarianPoBoxNumber.DimensionId = hungarianPoBoxNumberDimension.Id;
            ctx.Entry(hungarianPoBoxNumber).State = EntityState.Modified;
            ctx.SaveChanges();

            Dimension hungarianLegalEntityFormatDimension = new Dimension
            {
                Name = "Hungarian Legal Entity Format",
                Description = "Hungarian Legal Entity Format, such as Kft., Bt., etc.",
                IsActive = 1,
            };
            ctx.Dimensions.Add(hungarianLegalEntityFormatDimension);
            ctx.SaveChanges();
            hungarianLegalEntityFormat.DimensionId = hungarianLegalEntityFormatDimension.Id;
            ctx.Entry(hungarianLegalEntityFormat).State = EntityState.Modified;
            ctx.SaveChanges();

            Dimension hungarianLegalEntityNameDimension = new Dimension
            {
                Name = "Hungarian Legal Entity Name",
                Description = "Hungarian Legal Entity Name, it is defined by owners but regulated by law",
                IsActive = 1,
            };
            ctx.Dimensions.Add(hungarianLegalEntityNameDimension);
            ctx.SaveChanges();
            hungarianLegalEntityName.DimensionId = hungarianLegalEntityNameDimension.Id;
            ctx.Entry(hungarianLegalEntityName).State = EntityState.Modified;
            ctx.SaveChanges();
        }
    }
}