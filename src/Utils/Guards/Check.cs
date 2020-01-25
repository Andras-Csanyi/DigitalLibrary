using GuardException = DigitalLibrary.Utils.Guards.GuardException;

namespace DigitalLibrary.Utils.Guards
{
    public static class Check
    {
        public static void IsNotNull<T>(T toBeChecked, string message = null)
        {
            if (toBeChecked == null)
            {
                ThrowGuardException(message);
            }
        }

        public static void AreNotEqual(long value, long comparedTo, string message = null)
        {
            if (value == comparedTo)
            {
                ThrowGuardException(message);
            }
        }

        public static void AreNotEqual(int value, int comparedTo, string message = null)
        {
            if (value == comparedTo)
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

        public static void NotNullOrEmptyOrWhitespace(string toBeChecked, string message = null)
        {
            if (string.IsNullOrEmpty(toBeChecked) || string.IsNullOrWhiteSpace(toBeChecked))
            {
                ThrowGuardException(message);
            }
        }
    }
}