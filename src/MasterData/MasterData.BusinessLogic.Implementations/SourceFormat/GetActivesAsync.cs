namespace DigitalLibrary.MasterData.BusinessLogic.Implementations.SourceFormat
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using DigitalLibrary.MasterData.Ctx;
    using DigitalLibrary.MasterData.DomainModel;

    using Microsoft.EntityFrameworkCore;

    public partial class MasterDataSourceFormatBusinessLogic
    {
        /// <inheritdoc />
        public async Task<List<SourceFormat>> GetActivesAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                using (MasterDataContext ctx = new MasterDataContext(_dbContextOptions))
                {
                    return await ctx.SourceFormats
                       .AsNoTracking()
                       .Where(w => w.IsActive == 1)
                       .ToListAsync(cancellationToken)
                       .ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                string msg = $"{nameof(MasterDataSourceFormatBusinessLogic)}." +
                             $"{nameof(GetActivesAsync)} operation failed! " +
                             $"For further info see inner exception.";
                throw new MasterDataBusinessLogicSourceFormatDatabaseOperationException(msg, e);
            }
        }
    }
}