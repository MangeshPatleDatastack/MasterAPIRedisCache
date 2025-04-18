using Dapper;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using Microsoft.EntityFrameworkCore;
using WorkerService.DataAccess.Repository.IRepository;
using RedisService.DataAccess.Data;


namespace WorkerService.DataAccess.Repository
{
    public class SP_Call : ISP_Call
    {
        private readonly ApplicationDbContext _db;
        private static string ConnectionString = "";

        public SP_Call(ApplicationDbContext db)
        {
            _db = db;
            ConnectionString = db.Database.GetDbConnection().ConnectionString;
        }

        public void Dispose()
        {
            _db.Dispose();
        }
        public int Execute(string procedureOrFunctionName, DynamicParameters param = null, bool isFunction = false)
        {
            using (var sqlCon = new OracleConnection(ConnectionString))
            {
                sqlCon.Open();
                string sql;

                if (isFunction)
                {
                    // For functions in Oracle, use SELECT for a single return value
                    sql = $"SELECT {procedureOrFunctionName}({string.Join(", ", param.ParameterNames.Select(p => ":" + p))}) FROM dual";
                }
                else
                {
                    // For procedures, use BEGIN...END block
                    sql = $"BEGIN {procedureOrFunctionName}({string.Join(", ", param.ParameterNames.Select(p => ":" + p))}); END;";
                }

                return sqlCon.Execute(sql, param);
            }
        }

        // Gets a list of results from a stored procedure or function
        public IEnumerable<dynamic> GetList(string procedureOrFunctionName, DynamicParameters param = null, bool isFunction = false)
        {
            using (var sqlCon = new OracleConnection(ConnectionString))
            {
                sqlCon.Open();
                string sql;

                if (isFunction)
                {
                    // For functions, use SELECT to get a list of results
                    sql = $"SELECT * FROM TABLE({procedureOrFunctionName}({string.Join(", ", param.ParameterNames.Select(p => ":" + p))}))";
                }
                else
                {
                    // For procedures
                    sql = $"BEGIN {procedureOrFunctionName}({string.Join(", ", param.ParameterNames.Select(p => ":" + p))}); END;";
                }

                var list = sqlCon.Query<dynamic>(sql, param);
                return list;
            }
        }

        // Gets multiple result sets from a stored procedure
        public Tuple<IEnumerable<T1>, IEnumerable<T2>> List<T1, T2>(string procedureName, DynamicParameters param = null)
        {
            using (var sqlCon = new OracleConnection(ConnectionString))
            {
                sqlCon.Open();

                using (var multi = sqlCon.QueryMultiple(procedureName, param, commandType: CommandType.StoredProcedure))
                {
                    var item1 = multi.Read<T1>().ToList();
                    var item2 = multi.Read<T2>().ToList();

                    return new Tuple<IEnumerable<T1>, IEnumerable<T2>>(item1, item2);
                }
            }
        }

        // Retrieves one record from a stored procedure
        public T OneRecord<T>(string procedureName, DynamicParameters param = null)
        {
            using (var sqlCon = new OracleConnection(ConnectionString))
            {
                sqlCon.Open();
                var result = sqlCon.Query<T>(procedureName, param, commandType: CommandType.StoredProcedure).FirstOrDefault();
                return (T)Convert.ChangeType(result, typeof(T));
            }
        }

        // Retrieves a single record (non-procedure SQL) from Oracle
        public T Single<T>(string procedureName, DynamicParameters param = null)
        {
            using var sqlCon = new OracleConnection(ConnectionString);
            sqlCon.Open();
            var result = sqlCon.Query<T>(
                procedureName,
                param,
                commandType: CommandType.StoredProcedure
            ).FirstOrDefault();
            return result;
        }
        public long GetSequence(string sql)
        {
            try
            {
                using (var sqlCon = new OracleConnection(ConnectionString))
                {
                    sqlCon.Open();
                    var result = sqlCon.ExecuteScalar(sql); return Convert.ToInt32(result);
                }
            }
            catch (OracleException ex)
            {
                // Log detailed information from the exception
                Console.WriteLine($"OracleException: {ex.Message}");
                throw;  // Rethrow or handle as necessary
            }
        }

    }
}
