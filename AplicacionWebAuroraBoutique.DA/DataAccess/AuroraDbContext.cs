using Npgsql;

namespace AplicacionWebAuroraBoutique.DA.DataAccess
{
    public class AuroraDbContext
    {
        private readonly NpgsqlDataSource _dataSource;

        public AuroraDbContext()
        {
            _dataSource = new NpgsqlDataSourceBuilder(DbConfig.ConnString).Build();
        }

        public NpgsqlConnection CreateConnection()
        {
            return _dataSource.CreateConnection();
        }
    }
}
