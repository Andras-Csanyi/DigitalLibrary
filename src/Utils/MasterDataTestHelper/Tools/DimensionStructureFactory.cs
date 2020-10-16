namespace DigitalLibrary.Utils.MasterDataTestHelper.Tools
{
    using System;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.BusinessLogic.Implementations.Tests.Entities;
    using DigitalLibrary.MasterData.DomainModel;
    using DigitalLibrary.Utils.Guards;

    /// <inheritdoc />
    public class DimensionStructureFactory
        : IDimensionStructureFactory
    {
        private readonly IStringHelper _stringHelper;

        /// <summary>
        /// Initializes a new instance of the <see cref="DimensionStructureFactory"/> class.
        /// </summary>
        /// <param name="stringHelper">StringHelper instance.</param>
        public DimensionStructureFactory(IStringHelper stringHelper)
        {
            _stringHelper = stringHelper ?? throw new ArgumentNullException($"{nameof(stringHelper)}");
        }

        /// <inheritdoc/>
        public DimensionStructure Create(IDimensionStructureDomainObject instance)
        {
            Check.IsNotNull(instance);

            DimensionStructure dimensionStructure = new DimensionStructure
            {
                Name = _stringHelper.GetNamePropertyString(instance.Name),
                Desc = _stringHelper.GetDescPropertyString(instance.Desc),
                IsActive = Convert.ToInt32(instance.IsActive),
            };

            return dimensionStructure;
        }
    }
}