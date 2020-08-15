// <copyright file="GuardException.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace DigitalLibrary.Utils.Guards
{
    using System;
    using System.Runtime.Serialization;

    public class GuardException : Exception
    {
        public GuardException()
        {
        }

        protected GuardException(SerializationInfo? info, StreamingContext context)
            : base(info, context)
        {
        }

        public GuardException(string? message)
            : base(message)
        {
        }

        public GuardException(string? message, Exception? innerException)
            : base(message, innerException)
        {
        }
    }
}