namespace DigitalLibrary.Utils.MasterDataTestHelper.Tools
{
    using System;
    using System.Text;

    public interface IStringHelper
    {
        string GetRandomString(int length);
    }

    public class StringHelper : IStringHelper
    {
        private Random rnd;

        private string chars = "qwertyuioplkjhgfdsazxcvbnm";

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