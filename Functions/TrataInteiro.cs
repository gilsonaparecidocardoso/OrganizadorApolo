using System.Data.SqlClient;

namespace OrganizadorApolo.Functions
{
    public static class TrataInteiro
    {
        public static int SafeGetInt(this SqlDataReader reader, int colIndex)
        {
            if (!reader.IsDBNull(colIndex))
                return reader.GetInt32(colIndex);
            return -1;
        }
    }
}
