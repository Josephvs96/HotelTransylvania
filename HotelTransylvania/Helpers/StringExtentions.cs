namespace HotelTransylvania.Helpers
{
    public static class StringExtentions
    {
        /// <summary>
        /// Checkes if the string has a value and returns it
        /// </summary>
        /// <param name="stringToBeChecked"></param>
        /// <returns>The string if it has a value and is not empty otherwize retuens null</returns>
        public static string StringHasValue(this string stringToBeChecked) =>
                    !string.IsNullOrEmpty(stringToBeChecked) ? stringToBeChecked : null;

        /// <summary>
        /// Checkes a string weather it's null and returns another string otherwize returens the string
        /// </summary>
        /// <param name="stringToBeChecked">The string to be checked</param>
        /// <param name="outputString">The string to be returend if the string is empty or null</param>
        /// <returns>The string it has a value and not empty otherwize retures another predeffined string</returns>
        public static string StringHasValue(this string stringToBeChecked, string outputString) =>
                    !string.IsNullOrEmpty(stringToBeChecked) ? stringToBeChecked : outputString;
    }
}
