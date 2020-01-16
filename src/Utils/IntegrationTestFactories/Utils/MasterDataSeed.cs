using System.Diagnostics.CodeAnalysis;
using DigitalLibrary.MasterData.Ctx.Ctx;
using DigitalLibrary.MasterData.DomainModel.DomainModel;

namespace DigitalLibrary.Utils.IntegrationTestFactories.Utils
{
    [ExcludeFromCodeCoverage]
    public static class MasterDataSeed
    {
        public static int DimensionsActive { get; set; } = 5;

        public static int DimensionsInActive { get; set; } = 5;

        public static int ActiveDimensionProperty { get; } = 5;

        public static int InActiveDimensionProperty { get; } = 5;

        public static void Seed(MasterDataContext db)
        {
            AddTopDimensionStructures(db);
        }

        private static void AddTopDimensionStructures(MasterDataContext db)
        {
            DimensionStructure topDimensionStructure = new DimensionStructure
            {
                Name = "top dimension structure",
                Desc = "description",
                IsActive = 1
            };
            db.DimensionStructures.Add(topDimensionStructure);
            db.SaveChanges();
        }
    }
}