// <copyright file="IMasterDataBusinessLogic.SourceFormat.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.BusinessLogic.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using DigitalLibrary.MasterData.DomainModel;

    public partial interface IMasterDataBusinessLogic
    {
        Task<SourceFormat> AddSourceFormatAsync(SourceFormat sourceFormat);

        Task<long> CountSourceFormatsAsync();

        Task DeleteSourceFormatAsync(SourceFormat secondResult);

        Task<SourceFormat> GetSourceFormatByIdAsync(SourceFormat sourceFormat);

        Task<SourceFormat> GetSourceFormatByIdWithFullDimensionStructureTreeAsync(SourceFormat querySourceFormat);

        Task<List<SourceFormat>> GetSourceFormatsAsync();

        Task<SourceFormat> UpdateSourceFormatAsync(SourceFormat sourceFormat);
    }
}