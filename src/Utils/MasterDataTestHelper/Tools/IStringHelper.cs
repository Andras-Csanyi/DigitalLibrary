namespace DigitalLibrary.Utils.MasterDataTestHelper.Tools
{
    /// <summary>
    /// StringHelper interface.
    /// </summary>
    public interface IStringHelper
    {
        /// <summary>
        /// Provides random string in the given length.
        /// </summary>
        /// <param name="length">Length of the string.</param>
        /// <returns>Result string.</returns>
        string GetRandomString(int length);
    }
}