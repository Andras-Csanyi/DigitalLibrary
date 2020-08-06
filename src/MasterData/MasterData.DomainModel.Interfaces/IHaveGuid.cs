namespace DigitalLibrary.MasterData.DomainModel.Interfaces
{
    using System;

    public interface IHaveGuidId
    {
        public Guid Guid { get; set; }
    }
}