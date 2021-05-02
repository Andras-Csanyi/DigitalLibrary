namespace DigitalLibrary.Utils.MasterDataTestHelper.Helpers.ObjectPropertyValueHelper
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// A helper class which helps creating values for different properties based on rules.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class ObjectPropertyValueHelper
    {
        /// <summary>
        /// Creates output based on the provided filter.
        ///
        /// For example, if the input is "empty" and there is a provided rule for "empty", then the input
        /// will change accordingly. If there is no rule provided, then the input will be returned.
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <param name="filterRules">The dictionary contains the rules.</param>
        /// <returns>The value which is either not modified, or modified according to the provided rules.</returns>
        public static string CreateStringValueForProperty(string input, Dictionary<string, string> filterRules)
        {
            if (filterRules.ContainsKey(input.ToLower()))
            {
                return filterRules[input.ToLower()];
            }

            return input;
        }
    }
}