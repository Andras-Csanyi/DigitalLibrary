namespace DigitalLibrary.Utils.MasterDataTestHelper.Helpers.ObjectPropertyValueHelper
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    ///     Contains filters for filter operations considering value creation for properties.
    ///     The filters are described in <see cref="Dictionary{TKey,TValue}"/> format, where the
    ///     key is the input value, the value is the produced output.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class FilterRules
    {
        /// <summary>
        ///     Rules for string values.
        /// </summary>
        public static Dictionary<string, string> StringValueFilters = new Dictionary<string, string>
        {
            { "empty", string.Empty },
            { "3spaces", "   " },
            { "null", null },
        };
    }
}