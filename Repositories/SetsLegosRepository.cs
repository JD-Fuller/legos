using System.Collections.Generic;
using System.Data;
using Dapper;
using legos.Models;

namespace legos.Repositories
{
    public class SetLegosRepository
    {
        private readonly IDbConnection _db;
        public SetLegosRepository(IDbConnection db)
        {
            _db = db;
        }

        internal SetLego Find(SetLego sl)
        {
            string sql = "SELECT * FROM setlegos WHERE (legoId = @LegoId AND setId = @SetId)";
            return _db.QueryFirstOrDefault(sql, sl);
        }


        internal SetLego Create(SetLego newData)
        {
            string sql = @"
            INSERT INTO setlegos 
            (legoId, setId) 
            VALUES 
            (@LegoId, @SetId);
            SELECT LAST_INSERT_ID();
            ";
            int id = _db.ExecuteScalar<int>(sql, newData);
            newData.Id = id;
            return newData;
        }

        internal void Delete(int id)
        {
            string sql = "DELETE FROM setlegos WHERE id = @id";
            _db.Execute(sql, new { id });
        }
    }
}