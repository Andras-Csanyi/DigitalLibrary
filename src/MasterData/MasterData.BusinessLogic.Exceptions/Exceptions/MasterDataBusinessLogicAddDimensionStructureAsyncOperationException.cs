// <copyright file="MasterDataBusinessLogicAddDimensionStructureAsyncOperationException.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.BusinessLogic.Exceptions
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    [ExcludeFromCodeCoverage]
    public class MasterDataBusinessLogicAddDimensionStructureAsyncOperationException : Exception
    {
        public MasterDataBusinessLogicAddDimensionStructureAsyncOperationException()
        {
        }

        protected MasterDataBusinessLogicAddDimensionStructureAsyncOperationException(
            SerializationInfo? info,
            StreamingContext context)
            : base(info, context)
        {
        }

        public MasterDataBusinessLogicAddDimensionStructureAsyncOperationException(string? message)
            : base(message)
        {
        }

        public MasterDataBusinessLogicAddDimensionStructureAsyncOperationException(
            string? message,
            Exception? innerException)
            : base(message, innerException)
        {
        }
    }
}