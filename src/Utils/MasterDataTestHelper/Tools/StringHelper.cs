namespace DigitalLibrary.Utils.MasterDataTestHelper.Tools
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Text;

    /// <summary>
    ///     StringHelper implementation.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StringHelper : IStringHelper
    {
        private readonly string _chars = "qwertyuioplkjhgfdsazxcvbnm";

        private readonly Random _rnd = new Random();

        /// <inheritdoc />
        public string GetRandomString(int length)
        {
            StringBuilder result = new StringBuilder();
            int amountOfDistinctChars = _chars.Length;

            for (int i = 0; i < length; i++)
            {
                result.Append(_chars.Substring(_rnd.Next(amountOfDistinctChars), 1));
            }

            return result.ToString();
        }

        /// <inheritdoc/>
        public string GetNamePropertyString(string value)
        {
            string result;

            switch (value)
            {
                case "null":
                    result = null;
                    break;

                case "empty":
                    result = string.Empty;
                    break;

                case "3spaces":
                    result = $"{string.Empty}{string.Empty}{string.Empty}";
                    break;

                case null:
                    result = GetRandomString(4);
                    break;

                default:
                    result = value;
                    break;
            }

            return result;
        }

        /// <inheritdoc/>
        public string GetDescPropertyString(string value)
        {
            string result;

            switch (value)
            {
                case "null":
                    result = null;
                    break;

                case "empty":
                    result = string.Empty;
                    break;

                case "3spaces":
                    result = $"{string.Empty}{string.Empty}{string.Empty}";
                    break;

                case null:
                    result = GetRandomString(4);
                    break;

                default:
                    result = value;
                    break;
            }

            return result;
        }
    }
}