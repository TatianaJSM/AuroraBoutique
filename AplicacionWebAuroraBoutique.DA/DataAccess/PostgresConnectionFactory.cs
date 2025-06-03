using Npgsql;

namespace AplicacionWebAuroraBoutique.DA.DataAccess
{
    public static class PostgresConnectionFactory
    {
        public static NpgsqlConnection Create()
        {
            return new NpgsqlConnection(DbConfig.ConnString);
        }
    }
}
