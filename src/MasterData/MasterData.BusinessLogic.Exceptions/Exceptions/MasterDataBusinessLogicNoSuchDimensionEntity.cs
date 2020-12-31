// <copyright file="MasterDataBusinessLogicNoSuchDimensionEntity.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.BusinessLogic.Exceptions
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    [ExcludeFromCodeCoverage]
    [SuppressMessage("ReSharper", "SA1600", Justification = "tmp")]
    public class MasterDataBusinessLogicNoSuchDimensionEntity : Exception
    {
        public MasterDataBusinessLogicNoSuchDimensionEntity()
        {
        }

        public MasterDataBusinessLogicNoSuchDimensionEntity(string? message)
            : base(message)
        {
        }

        public MasterDataBusinessLogicNoSuchDimensionEntity(string? message, Exception? innerException)
            : base(
                message,
                innerException)
        {
        }

        protected MasterDataBusinessLogicNoSuchDimensionEntity(SerializationInfo? info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}