// <copyright file="Check.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace DigitalLibrary.Utils.Guards
{
    using System;

    /// <summary>
    ///     Checking different things, mostly inputs.
    /// </summary>
    public static class Check
    {
        /// <summary>
        ///     Compares two objects and throws exception when they are equal.
        ///     Equality is the default.
        /// </summary>
        /// <param name="value">Value will be compared.</param>
        /// <param name="comparedTo">Value will be compared to this.</param>
        /// <param name="message">Message added to exception thrown.</param>
        public static void AreNotEqual(long value, long comparedTo, string message = null)
        {
            if (value == comparedTo)
            {
                if (string.IsNullOrEmpty(message))
                {
                    message = $"{value} cannot be equal to {comparedTo}";
                }

                throw new GuardException(message);
            }
        }

        /// <summary>
        ///     Compares two objects and throws exception when they are equal.
        ///     Equality is the default.
        /// </summary>
        /// <param name="value">Value will be compared.</param>
        /// <param name="comparedTo">Value will be compared to this.</param>
        /// <param name="message">Message added to exception thrown.</param>
        public static void AreNotEqual(long? value, long comparedTo, string message = null)
        {
            if (value == comparedTo)
            {
                if (string.IsNullOrEmpty(message))
                {
                    message = $"{value} cannot be equal to {comparedTo}";
                }

                throw new GuardException(message);
            }
        }

        /// <summary>
        ///     Compares two objects and throws exception when they are equal.
        ///     Equality is the default.
        /// </summary>
        /// <param name="value">Value will be compared.</param>
        /// <param name="comparedTo">Value will be compared to this.</param>
        /// <param name="message">Message added to exception thrown.</param>
        public static void AreNotEqual(int value, int comparedTo, string message = null)
        {
            if (value == comparedTo)
            {
                if (string.IsNullOrEmpty(message))
                {
                    message = $"{value} cannot be equal to {comparedTo}";
                }

                throw new GuardException(message);
            }
        }

        /// <summary>
        ///     Compares two objects and throws exception when they are equal.
        ///     Equality is the default.
        /// </summary>
        /// <param name="value">Value will be compared.</param>
        /// <param name="comparedTo">Value will be compared to this.</param>
        /// <param name="message">Message added to exception thrown.</param>
        public static void AreNotEqual(Guid value, Guid comparedTo, string message = null)
        {
            if (value == comparedTo)
            {
                if (string.IsNullOrEmpty(message))
                {
                    message = $"{value} cannot be equal to {comparedTo}";
                }

                throw new GuardException(message);
            }
        }

        /// <summary>
        ///     Checks whether toBeChecked is null or not. If message is set
        ///     then Exception message will contains the message.
        /// </summary>
        /// <param name="toBeChecked">Object will be checked.</param>
        /// <param name="message">If exception is thrown this message will be added.</param>
        /// <typeparam name="T">Type of toBeCompared.</typeparam>
        public static void IsNotNull<T>(T toBeChecked, string message = null)
        {
            // ReSharper disable once CompareNonConstrainedGenericWithNull
            if (toBeChecked == null)
            {
                if (string.IsNullOrEmpty(message))
                {
                    message = $"Type {typeof(T)} cannot be null.";
                }

                throw new GuardException(message);
            }
        }

        /// <summary>
        ///     Checks whether given string is empty, null or whitespace. If the string is empty, null
        ///     or whitespace then <see cref="ThrowGuardException" /> is thrown.
        /// </summary>
        /// <param name="toBeChecked">String to be checked.</param>
        /// <param name="message">Custom error message.</param>
        public static void NotNullOrEmptyOrWhitespace(string toBeChecked, string message = null)
        {
            if (string.IsNullOrEmpty(toBeChecked) || string.IsNullOrWhiteSpace(toBeChecked))
            {
                if (string.IsNullOrEmpty(message))
                {
                    message = $"Given string cannot be empty, null or whitespace";
                }

                throw new GuardException(message);
            }
        }
    }
}