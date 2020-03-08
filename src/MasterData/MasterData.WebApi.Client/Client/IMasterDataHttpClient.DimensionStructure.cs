using DimensionStructureQueryObject = MasterData.BusinessLogic.ViewModels.DimensionStructureQueryObject;

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

        Task<List<DimensionStructure>> GetDimensionStructuresAsync(DimensionStructureQueryObject queryObject);

        /// <summary>
        /// Returns the DimensionStructure having the id.
        ///
        /// It expects a DimensionStructure object as input, where the ID represents
        /// the query. No other values in the object will be validated.
        ///
        /// It does not return with its ChildDimensionStructures.
        /// </summary>
        /// <param name="dimensionStructure">Query object</param>
        /// <returns>
        ///     <para>Returns with DimensionStructure object</para>
        ///     <para>Throws Exception if object doesn't exist.</para>
        /// </returns>
        Task<DimensionStructure> GetDimensionStructureByIdAsync(DimensionStructure dimensionStructure);

        /// <summary>
        /// Returns the DimensionStructure having the id.
        /// When <param name="childDimensionStructuresAreIncluded">true</param> child DimensionStructures
        /// will be included too.
        ///
        /// The method expects a DimensionStructure object where the Id defines the desired object.
        /// No other properties of the object will be validated.
        /// </summary>
        /// <param name="dimensionStructure">Query Object</param>
        /// <param name="childDimensionStructuresAreIncluded">With child objects or without them.</param>
        /// <returns>
        ///    <para>Returns with DimensionStructure object</para>
        ///    <para>Throws Exception</para>
        /// </returns>
        Task<DimensionStructure> GetDimensionStructureByIdAsync(
            DimensionStructure dimensionStructure,
            bool childDimensionStructuresAreIncluded);

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