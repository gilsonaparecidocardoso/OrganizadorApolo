using System;
using System.Data.SqlClient;

namespace OrganizadorApolo.Functions
{
    public static class TrataData
    {
        public static DateTime SafeGetDateTime(this SqlDataReader reader, int colIndex)
        {
            if (!reader.IsDBNull(colIndex))
                return reader.GetDateTime(colIndex);
            return DateTime.MinValue;
        }

        public static TimeSpan SafeGetTimeSpan(this SqlDataReader reader, int colIndex)
        {
            if (!reader.IsDBNull(colIndex))
                return reader.GetTimeSpan(colIndex);
            return TimeSpan.Zero;
        }
    }
}
