using Dapper;
using System;
using System.Collections.Generic;

namespace WorkerService.DataAccess.Repository.IRepository
{
    public interface ISP_Call : IDisposable
    {
        T Single<T>(string procedureName, DynamicParameters param = null);
        public long GetSequence(string procedureName);

        public int Execute(string procedureName, DynamicParameters param = null, bool isFunction = false);

        T OneRecord<T>(string procedureName, DynamicParameters param = null);

        public IEnumerable<dynamic> GetList(string procedureName, DynamicParameters param = null, bool isFunction = false);

        Tuple<IEnumerable<T1>, IEnumerable<T2>> List<T1, T2>(string procedureName, DynamicParameters param = null);
    }
}
