using System;

namespace Movies.DAO
{
    /// <summary>
    /// Rather than scattering a number of duplicate code blocks to test nullable SQL
    /// Server columns to see if they are indeed null and then set nullable C# variables,
    /// the NullableDateTime, NullableString, and NullableInt methods were written in 
    /// order to follow the DRY (don't repeat yourself) principle. These methods are mostly
    /// used within the private MapRowToObject() methods of the SQL DAO implementation 
    /// classes.
    /// </summary>
    ///
    public class SqlUtil
    {
        /// <summary>
        /// DRY: Sets a nullable C# DateTime to null if the passed in dbValue is DBNull, 
        /// or converts the dbValue to a proper DateTime.
        /// </summary>
        /// <param name="dbValue">the DateTime value extracted from the SqlDataReader.</param>
        ///<returns>a null or properly converted DateTime?</returns> 
        ///
        public static DateTime? NullableDateTime(object dbValue)
        {
            if (dbValue is DBNull)
            {
                return null;
            }
            else
            {
                return Convert.ToDateTime(dbValue);
            }
        }

        /// <summary>
        /// DRY: Sets a C# string to null if the passed in dbValue is DBNull, or converts
        /// the dbValue to a proper string.
        /// </summary>
        /// <param name="dbValue">the string value extracted from the SqlDataReader.</param>
        ///<returns>a null or properly converted string</returns> 
        ///
        public static string NullableString(object dbValue)
        {
            if (dbValue is DBNull)
            {
                return null;
            }
            else
            {
                return Convert.ToString(dbValue);
            }
        }

        /// <summary>
        /// DRY: Sets a nullable C# int to null if the passed in dbValue is DBNull, 
        /// or converts the dbValue to a proper int.
        /// </summary>
        /// <param name="dbValue">the int value extracted from the SqlDataReader.</param>
        ///<returns>a null or properly converted int?</returns> 
        ///
        public static int? NullableInt(object dbValue)
        {
            if (dbValue is DBNull)
            {
                return null;
            }
            else
            {
                return Convert.ToInt32(dbValue);
            }
        }

    }
}
