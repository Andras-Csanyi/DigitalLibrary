// <copyright file="MasterDataDataSample.SourceFormat.BusinessPartner.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace DigitalLibrary.Utils.ControlPanel.DataSample.MasterData
{
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    [SuppressMessage("ReSharper", "InconsistentNaming", Justification = "Reviewed.")]
    public static partial class MasterDataDataSample
    {
        // private const int AmountOfSourceFormatBusinessPartner = 1;
        //
        // public const string HungarianBusinessPartnerAddressName = "Hungarian Address Dimension Structure";
        //
        // public const string HungarianBusinessPartnerNameDimensionStructureName =
        //     "Business Partner Name Dimension Structure";
        //
        // public const string HungarianBusinessPartnerRootDimensionStructureName = "Hungarian Business Partner";
        //
        // private static void PopulateSourceFormatBusinessPartner(MasterDataContext ctx)
        // {
        //     // structure - hierarchy
        //     SourceFormat businessPartnerSourceFormat = new SourceFormat
        //     {
        //         Name = "Hungarian Business Partner Source Format",
        //         Desc = "Source format for being able to record Business Partners from Hungary",
        //         IsActive = 1,
        //     };
        //     ctx.SourceFormats.Add(businessPartnerSourceFormat);
        //     ctx.SaveChanges();
        //
        //     DimensionStructure hungarianBusinessPartnerRootDimensionStructure = new DimensionStructure
        //     {
        //         Name = HungarianBusinessPartnerRootDimensionStructureName,
        //         Desc = "Root Dimension Structure for Hungarian Business Partner Dimension Structure",
        //         IsActive = 1,
        //     };
        //     ctx.DimensionStructures.Add(hungarianBusinessPartnerRootDimensionStructure);
        //     ctx.SaveChanges();
        //
        //     businessPartnerSourceFormat.DimensionStructureTreeRootId = hungarianBusinessPartnerRootDimensionStructure.Id;
        //     ctx.Entry(businessPartnerSourceFormat).State = EntityState.Modified;
        //     ctx.SaveChanges();
        //
        //     Dimension hungarianBusinessPartnerNameDimension = new Dimension
        //     {
        //         Name = "Hungarian Business Partner Name",
        //         Description = "This is the name of the legal entity, which is not equal to the place name",
        //         IsActive = 1,
        //     };
        //     ctx.Dimensions.Add(hungarianBusinessPartnerNameDimension);
        //     ctx.SaveChanges();
        //
        //     DimensionStructure hungarianBusinessPartnerNameDimensionStructure = new DimensionStructure
        //     {
        //         Name = HungarianBusinessPartnerNameDimensionStructureName,
        //         Desc = "Name of the business partner, a.k.a. legal entity",
        //         IsActive = 1,
        //         DimensionId = hungarianBusinessPartnerNameDimension.Id,
        //     };
        //     ctx.DimensionStructures.Add(hungarianBusinessPartnerNameDimensionStructure);
        //     ctx.SaveChanges();
        //
        //     DimensionStructureDimensionStructure hungarianBusinessPartner_hungarianBusinessPartnerName =
        //         new DimensionStructureDimensionStructure
        //         {
        //             DimensionStructureId = hungarianBusinessPartnerRootDimensionStructure.Id,
        //             ChildDimensionStructureId = hungarianBusinessPartnerNameDimensionStructure.Id,
        //         };
        //     ctx.DimensionStructureDimensionStructures.Add(hungarianBusinessPartner_hungarianBusinessPartnerName);
        //     ctx.SaveChanges();
        //
        //     DimensionStructure hungarianLegalEntityName = new DimensionStructure
        //     {
        //         Name = "Hungarian Legal Entity Name Dimension Structure",
        //         Desc = "Hungarian Legal Entity Name, mainly company name",
        //         IsActive = 1,
        //     };
        //     ctx.DimensionStructures.Add(hungarianLegalEntityName);
        //     ctx.SaveChanges();
        //
        //     DimensionStructureDimensionStructure hungarianBusinessPartner_hungarianLegalEntityName =
        //         new DimensionStructureDimensionStructure
        //         {
        //             DimensionStructureId = hungarianBusinessPartnerRootDimensionStructure.Id,
        //             ChildDimensionStructureId = hungarianLegalEntityName.Id,
        //         };
        //     ctx.DimensionStructureDimensionStructures.Add(hungarianBusinessPartner_hungarianLegalEntityName);
        //     ctx.SaveChanges();
        //
        //     DimensionStructure hungarianLegalEntityFormat = new DimensionStructure
        //     {
        //         Name = "Hungarian Legal Entity Format",
        //         Desc = "Hungarian Legal Entity Format, mainly Kft., Bt., or etc.",
        //         IsActive = 1,
        //     };
        //     ctx.DimensionStructures.Add(hungarianLegalEntityFormat);
        //     ctx.SaveChanges();
        //
        //     DimensionStructureDimensionStructure hungarianBusinessPartner_hungarianLegalEntityFormat =
        //         new DimensionStructureDimensionStructure
        //         {
        //             DimensionStructureId = hungarianBusinessPartnerRootDimensionStructure.Id,
        //             ChildDimensionStructureId = hungarianLegalEntityFormat.Id,
        //         };
        //     ctx.DimensionStructureDimensionStructures.Add(hungarianBusinessPartner_hungarianLegalEntityFormat);
        //     ctx.SaveChanges();
        //
        //     DimensionStructure hungarianBusinessPartnerAddress = new DimensionStructure
        //     {
        //         Name = HungarianBusinessPartnerAddressName,
        //         Desc = "Hungarian Address Dimension Structure",
        //         IsActive = 1,
        //     };
        //     ctx.DimensionStructures.Add(hungarianBusinessPartnerAddress);
        //     ctx.SaveChanges();
        //
        //     DimensionStructureDimensionStructure businessPartner_hungarianAddressDimensionStructure =
        //         new DimensionStructureDimensionStructure
        //         {
        //             DimensionStructureId = hungarianBusinessPartnerRootDimensionStructure.Id,
        //             ChildDimensionStructureId = hungarianBusinessPartnerAddress.Id,
        //         };
        //     ctx.DimensionStructureDimensionStructures.Add(businessPartner_hungarianAddressDimensionStructure);
        //     ctx.SaveChanges();
        //
        //     DimensionStructure hungarianTown = new DimensionStructure
        //     {
        //         Name = "Hungarian Town",
        //         Desc = "Hungarian Town",
        //         IsActive = 1,
        //     };
        //     ctx.DimensionStructures.Add(hungarianTown);
        //     ctx.SaveChanges();
        //
        //     DimensionStructureDimensionStructure hungarianBusinessPartnerAddress_hungarianTown =
        //         new DimensionStructureDimensionStructure
        //         {
        //             DimensionStructureId = hungarianBusinessPartnerAddress.Id,
        //             ChildDimensionStructureId = hungarianTown.Id,
        //         };
        //     ctx.DimensionStructureDimensionStructures.Add(hungarianBusinessPartnerAddress_hungarianTown);
        //     ctx.SaveChanges();
        //
        //     DimensionStructure hungarianPoBoxNumber = new DimensionStructure
        //     {
        //         Name = "Hungarian PO Box number",
        //         Desc = "Hungarian PO Box number",
        //         IsActive = 1,
        //     };
        //     ctx.DimensionStructures.Add(hungarianPoBoxNumber);
        //     ctx.SaveChanges();
        //
        //     DimensionStructureDimensionStructure hungarianBusinessPartnerAddress_hungarianPoBox =
        //         new DimensionStructureDimensionStructure
        //         {
        //             DimensionStructureId = hungarianBusinessPartnerAddress.Id,
        //             ChildDimensionStructureId = hungarianPoBoxNumber.Id,
        //         };
        //     ctx.DimensionStructureDimensionStructures.Add(hungarianBusinessPartnerAddress_hungarianPoBox);
        //     ctx.SaveChanges();
        //
        //     DimensionStructure hungarianPublicSpace = new DimensionStructure
        //     {
        //         Name = "Hungarian Public Place",
        //         Desc = "Hungarian Public Place, which consists of place name, place type and place number," +
        //                "or registration number",
        //         IsActive = 1,
        //     };
        //     ctx.DimensionStructures.Add(hungarianPublicSpace);
        //     ctx.SaveChanges();
        //
        //     DimensionStructureDimensionStructure hungarianBusinessPartner_hungarianPublicSpace =
        //         new DimensionStructureDimensionStructure
        //         {
        //             DimensionStructureId = hungarianBusinessPartnerAddress.Id,
        //             ChildDimensionStructureId = hungarianPublicSpace.Id,
        //         };
        //     ctx.DimensionStructureDimensionStructures.Add(hungarianBusinessPartner_hungarianPublicSpace);
        //     ctx.SaveChanges();
        //
        //     DimensionStructure hungarianPublicSpaceName = new DimensionStructure
        //     {
        //         Name = "hungarian Public Space Name",
        //         Desc = "Hungarian Public Space Name, which can be street name or registration number",
        //         IsActive = 1,
        //     };
        //     ctx.DimensionStructures.Add(hungarianPublicSpaceName);
        //     ctx.SaveChanges();
        //
        //     DimensionStructureDimensionStructure hungarianPublicSpace_hungarianPublicSpaceName =
        //         new DimensionStructureDimensionStructure
        //         {
        //             DimensionStructureId = hungarianPublicSpace.Id,
        //             ChildDimensionStructureId = hungarianPublicSpaceName.Id,
        //         };
        //     ctx.DimensionStructureDimensionStructures.Add(hungarianPublicSpace_hungarianPublicSpaceName);
        //     ctx.SaveChanges();
        //
        //     DimensionStructure hungarianPublicSpaceNumber = new DimensionStructure
        //     {
        //         Name = "Hungarian Public Space Number",
        //         Desc = "Hungarian Public Space Number",
        //         IsActive = 1,
        //     };
        //     ctx.DimensionStructures.Add(hungarianPublicSpaceNumber);
        //     ctx.SaveChanges();
        //
        //     DimensionStructureDimensionStructure hungarianPublicSpace_hungarianPublicSpaceNumber =
        //         new DimensionStructureDimensionStructure
        //         {
        //             DimensionStructureId = hungarianPublicSpace.Id,
        //             ChildDimensionStructureId = hungarianPublicSpaceNumber.Id,
        //         };
        //     ctx.DimensionStructureDimensionStructures.Add(hungarianPublicSpace_hungarianPublicSpaceNumber);
        //     ctx.SaveChanges();
        //
        //     DimensionStructure hungarianPublicSpaceRegistrationNumber = new DimensionStructure
        //     {
        //         Name = "Hungarian Public Space Registration Number",
        //         Desc = "Hungarian Public Space Registration number",
        //         IsActive = 1,
        //     };
        //     ctx.DimensionStructures.Add(hungarianPublicSpaceRegistrationNumber);
        //     ctx.SaveChanges();
        //
        //     DimensionStructureDimensionStructure hungarianPublicSpace_hungarianPublicspaceRegistrationNumber =
        //         new DimensionStructureDimensionStructure
        //         {
        //             DimensionStructureId = hungarianPublicSpace.Id,
        //             ChildDimensionStructureId = hungarianPublicSpaceRegistrationNumber.Id,
        //         };
        //     ctx.DimensionStructureDimensionStructures.Add(hungarianPublicSpace_hungarianPublicspaceRegistrationNumber);
        //     ctx.SaveChanges();
        //
        //     // Dimensions
        //     Dimension hungarianPublicSpaceRegistrationNumberDimension = new Dimension
        //     {
        //         Name = "Hungarian Public Space Registration Number",
        //         Description = "Hungarian Public Space Registration Number",
        //         IsActive = 1,
        //     };
        //     ctx.Dimensions.Add(hungarianPublicSpaceRegistrationNumberDimension);
        //     ctx.SaveChanges();
        //     hungarianPublicSpaceRegistrationNumber.DimensionId = hungarianPublicSpaceRegistrationNumberDimension.Id;
        //     ctx.Entry(hungarianPublicSpaceRegistrationNumber).State = EntityState.Modified;
        //     ctx.SaveChanges();
        //
        //     Dimension hungarianPublicSpaceNumberDimension = new Dimension
        //     {
        //         Name = "Hungarian Public Space Number",
        //         Description = "Hungarian Public Space Number",
        //         IsActive = 1,
        //     };
        //     ctx.Dimensions.Add(hungarianPublicSpaceNumberDimension);
        //     ctx.SaveChanges();
        //     hungarianPublicSpaceNumber.DimensionId = hungarianPublicSpaceNumberDimension.Id;
        //     ctx.Entry(hungarianPublicSpaceNumber).State = EntityState.Modified;
        //     ctx.SaveChanges();
        //
        //     Dimension hungarianPublicSpaceNameDimension = new Dimension
        //     {
        //         Name = "Hungarian Public Space Name",
        //         Description = "Hungarian Public Space Name",
        //         IsActive = 1,
        //     };
        //     ctx.Dimensions.Add(hungarianPublicSpaceNameDimension);
        //     ctx.SaveChanges();
        //     hungarianPublicSpaceName.DimensionId = hungarianPublicSpaceNameDimension.Id;
        //     ctx.Entry(hungarianPublicSpaceName).State = EntityState.Modified;
        //     ctx.SaveChanges();
        //
        //     Dimension hungarianTownDimension = new Dimension
        //     {
        //         Name = "Hungarian Town",
        //         Description = "Hungarian Town",
        //         IsActive = 1,
        //     };
        //     ctx.Dimensions.Add(hungarianTownDimension);
        //     ctx.SaveChanges();
        //     hungarianTown.DimensionId = hungarianTownDimension.Id;
        //     ctx.Entry(hungarianTown).State = EntityState.Modified;
        //     ctx.SaveChanges();
        //
        //     Dimension hungarianPoBoxNumberDimension = new Dimension
        //     {
        //         Name = "Hungarian P.O. Box number",
        //         Description = "Hungarian P.O. Box number",
        //         IsActive = 1,
        //     };
        //     ctx.Dimensions.Add(hungarianPoBoxNumberDimension);
        //     ctx.SaveChanges();
        //     hungarianPoBoxNumber.DimensionId = hungarianPoBoxNumberDimension.Id;
        //     ctx.Entry(hungarianPoBoxNumber).State = EntityState.Modified;
        //     ctx.SaveChanges();
        //
        //     Dimension hungarianLegalEntityFormatDimension = new Dimension
        //     {
        //         Name = "Hungarian Legal Entity Format",
        //         Description = "Hungarian Legal Entity Format, such as Kft., Bt., etc.",
        //         IsActive = 1,
        //     };
        //     ctx.Dimensions.Add(hungarianLegalEntityFormatDimension);
        //     ctx.SaveChanges();
        //     hungarianLegalEntityFormat.DimensionId = hungarianLegalEntityFormatDimension.Id;
        //     ctx.Entry(hungarianLegalEntityFormat).State = EntityState.Modified;
        //     ctx.SaveChanges();
        //
        //     Dimension hungarianLegalEntityNameDimension = new Dimension
        //     {
        //         Name = "Hungarian Legal Entity Name",
        //         Description = "Hungarian Legal Entity Name, it is defined by owners but regulated by law",
        //         IsActive = 1,
        //     };
        //     ctx.Dimensions.Add(hungarianLegalEntityNameDimension);
        //     ctx.SaveChanges();
        //     hungarianLegalEntityName.DimensionId = hungarianLegalEntityNameDimension.Id;
        //     ctx.Entry(hungarianLegalEntityName).State = EntityState.Modified;
        //     ctx.SaveChanges();
        // }
    }
}