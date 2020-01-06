namespace DigitalLibrary.IaC.TeamManager.WebApi.Client.Client.Title
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DomainModel.Entities;

    public interface ITitleApiWebClient
    {
        Task<Title> AddAsync(Title title);

        Task DeleteAsync(Title title);

        Task<Title> FindAsync(Title title);

        Task<List<Title>> GetAllAsync();

        Task<List<Title>> GetAllActiveAsync();

        Task<Title> ModifyAsync(Title title);
    }
}