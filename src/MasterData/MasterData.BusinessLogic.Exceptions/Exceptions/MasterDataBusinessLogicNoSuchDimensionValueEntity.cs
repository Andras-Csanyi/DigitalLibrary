// <copyright file="MasterDataBusinessLogicNoSuchDimensionValueEntity.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.BusinessLogic.Exceptions
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    [ExcludeFromCodeCoverage]
    public class MasterDataBusinessLogicNoSuchDimensionValueEntity : Exception
    {
        public MasterDataBusinessLogicNoSuchDimensionValueEntity()
        {
        }

        protected MasterDataBusinessLogicNoSuchDimensionValueEntity(SerializationInfo? info, StreamingContext context)
            : base(info, context)
        {
        }

        public MasterDataBusinessLogicNoSuchDimensionValueEntity(string? message)
            : base(message)
        {
        }

        public MasterDataBusinessLogicNoSuchDimensionValueEntity(string? message, Exception? innerException)
            : base(
                message, innerException)
        {
        }
    }
}