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
                ThrowGuardException(message);
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
                ThrowGuardException(message);
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
                ThrowGuardException(message);
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
                ThrowGuardException(message);
            }
        }

        /// <summary>
        ///     Checks whether toBeChecked is null or not. If message is set
        ///     then Exception message will contains the message.
        /// </summary>
        /// <param name="toBeChecked">Object will be checked</param>
        /// <param name="message">If exception is thrown this message will be added.</param>
        /// <typeparam name="T">Type of toBeCompared/</typeparam>
        public static void IsNotNull<T>(T toBeChecked, string message = null)
        {
            if (toBeChecked == null)
            {
                ThrowGuardException(message);
            }
        }

        public static void NotNullOrEmptyOrWhitespace(string toBeChecked, string message = null)
        {
            if (string.IsNullOrEmpty(toBeChecked) || string.IsNullOrWhiteSpace(toBeChecked))
            {
                ThrowGuardException(message);
            }
        }

        private static void ThrowGuardException(string message)
        {
            string msg;
            if (message == null)
            {
                msg = $"Guard exception.";
            }
            else
            {
                msg = message;
            }

            throw new GuardException(msg);
        }
    }
}