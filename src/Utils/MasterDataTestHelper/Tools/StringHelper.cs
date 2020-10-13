namespace DigitalLibrary.Utils.MasterDataTestHelper.Tools
{
    using System;
    using System.Text;

    public class StringHelper
        : IStringHelper
    {
        private string chars = "qwertyuioplkjhgfdsazxcvbnm";

        private Random rnd = new Random();

        public string GetRandomString(int length)
        {
            StringBuilder result = new StringBuilder();
            int amountOfDistinctChars = chars.Length;

            for (int i = 0; i < length; i++)
            {
                result.Append(chars.Substring(rnd.Next(amountOfDistinctChars), 1));
            }

            return result.ToString();
        }
    }
}