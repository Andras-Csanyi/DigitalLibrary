namespace DigitalLibrary.Utils.MasterDataTestHelper.Tools
{
    using System;
    using System.Text;

    /// <summary>
    /// StringHelper implementation.
    /// </summary>
    public class StringHelper
        : IStringHelper
    {
        private readonly string _chars = "qwertyuioplkjhgfdsazxcvbnm";

        private readonly Random _rnd = new Random();

        /// <inheritdoc/>
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
    }
}