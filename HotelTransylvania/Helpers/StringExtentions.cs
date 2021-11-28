namespace HotelTransylvania.Helpers
{
    public static class StringExtentions
    {
        /// <summary>
        /// Checkes if the string has a value and returns it
        /// </summary>
        /// <param name="stringToBeChecked"></param>
        /// <returns>The inputed string if the string is not empty otherwize retuens null</returns>
        public static string StringHasValue(this string stringToBeChecked) => !string.IsNullOrEmpty(stringToBeChecked) ? stringToBeChecked : null;
    }
}
