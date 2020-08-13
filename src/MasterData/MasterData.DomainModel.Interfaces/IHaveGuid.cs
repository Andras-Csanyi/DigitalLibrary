// Digital Library project
// https://github.com/SayusiAndo/DigitalLibrary
// Licensed under MIT License

namespace DigitalLibrary.MasterData.DomainModel.Interfaces
{
    using System;

    public interface IHaveGuidId
    {
        public Guid Guid { get; set; }
    }
}