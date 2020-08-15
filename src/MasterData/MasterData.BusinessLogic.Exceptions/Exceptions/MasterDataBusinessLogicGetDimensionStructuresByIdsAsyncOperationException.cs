// <copyright file="MasterDataBusinessLogicGetDimensionStructuresByIdsAsyncOperationException.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.BusinessLogic.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    public class MasterDataBusinessLogicGetDimensionStructuresByIdsAsyncOperationException : Exception
    {
        public MasterDataBusinessLogicGetDimensionStructuresByIdsAsyncOperationException()
        {
        }

        protected MasterDataBusinessLogicGetDimensionStructuresByIdsAsyncOperationException(
            SerializationInfo? info,
            StreamingContext context) : base(info, context)
        {
        }

        public MasterDataBusinessLogicGetDimensionStructuresByIdsAsyncOperationException(string? message) :
            base(message)
        {
        }

        public MasterDataBusinessLogicGetDimensionStructuresByIdsAsyncOperationException(
            string? message,
            Exception? innerException) : base(message, innerException)
        {
        }
    }
}