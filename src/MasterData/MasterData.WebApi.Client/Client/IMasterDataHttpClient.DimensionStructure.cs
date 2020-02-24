using DimensionStructureIds = MasterData.BusinessLogic.ViewModels.DimensionStructureIds;

namespace DigitalLibrary.MasterData.WebApi.Client
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DomainModel;

    public partial interface IMasterDataHttpClient
    {
        Task<DimensionStructure> ModifyDimensionStructureAsync(DimensionStructure dimensionStructure);

        /// <summary>
        ///     Returns list of DimensionStructures.
        /// </summary>
        /// <returns>
        ///     <para>Returns list of dimension values.</para>
        ///     <para>If error happens then returns 400 with exception details.</para>
        /// </returns>
        Task<List<DimensionStructure>> GetDimensionStructuresAsync();

        Task<List<DimensionStructure>> GetDimensionStructuresAsync(DimensionStructureIds ids);

        Task<DimensionStructure> GetDimensionStructureById(DimensionStructure dimensionStructure);

        /// <summary>
        ///     Deletes a DimensionStructure
        /// </summary>
        /// <param name="dimensionStructure">Dimension structure to be deleted.</param>
        /// <returns>
        ///     <para>Returns 200 Ok message.</para>
        ///     <para>If error happens returns 400 with exception details.</para>
        /// </returns>
        Task DeleteDimensionStructureAsync(DimensionStructure dimensionStructure);

        /// <summary>
        ///     Adds a new dimension structure.
        /// </summary>
        /// <param name="dimensionStructure">The dimension structure should be added.</param>
        /// <returns>
        ///     <para>Returns OK 200 with the created Dimension Structure object.</para>
        ///     <para>If error happens returns 400 Bad request with exception details.</para>
        /// </returns>
        Task<DimensionStructure> AddDimensionStructureAsync(DimensionStructure dimensionStructure);

        /// <summary>
        ///     Updates a dimension structure object.
        /// </summary>
        /// <param name="updatedDimensionStructure">The new dimension structure, which contains the id and new data.</param>
        /// <returns>
        ///     <para>Returns 200 Ok and the updated dimension structure object.</para>
        ///     <para>If error happens returns 400 Bad Request and exception details.</para>
        /// </returns>
        Task<DimensionStructure> UpdateDimensionStructureAsync(DimensionStructure updatedDimensionStructure);
    }
}