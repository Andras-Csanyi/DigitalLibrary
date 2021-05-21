// <copyright file="IHaveId.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace DigitalLibrary.MasterData.DomainModel.Interfaces
{
    /// <summary>
    ///     Interface for domain entities which have Id value.
    /// </summary>
    public interface IHaveId
    {
        /// <summary>
        ///     Gets or sets the Id value.
        /// </summary>
        public long Id { get; set; }
    }
}
