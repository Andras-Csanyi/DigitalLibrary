// <copyright file="MasterDataBusinessLogicGetDimensionStructureByIdAsyncOperationException.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.BusinessLogic.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    public class MasterDataBusinessLogicGetDimensionStructureByIdAsyncOperationException : Exception
    {
        public MasterDataBusinessLogicGetDimensionStructureByIdAsyncOperationException()
        {
        }

        protected MasterDataBusinessLogicGetDimensionStructureByIdAsyncOperationException(
            SerializationInfo? info,
            StreamingContext context)
            : base(info, context)
        {
        }

        public MasterDataBusinessLogicGetDimensionStructureByIdAsyncOperationException(string? message)
            : base(message)
        {
        }

        public MasterDataBusinessLogicGetDimensionStructureByIdAsyncOperationException(
            string? message,
            Exception? innerException)
            : base(message, innerException)
        {
        }
    }
}