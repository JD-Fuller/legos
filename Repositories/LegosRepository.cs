using System.Collections.Generic;
using System.Data;
using Dapper;
using legos.Models;

namespace legos.Repositories
{
    public class LegosRepository
    {
        private readonly IDbConnection _db;
        public LegosRepository(IDbConnection db)
        {
            _db = db;
        }
        internal IEnumerable<Lego> Get()
        {
            string sql = "SELECT * FROM legos";
            return _db.Query<Lego>(sql);
        }

        internal Lego GetById(int Id)
        {
            string sql = "SELECT * FROM legos WHERE id = @Id";
            return _db.QueryFirstOrDefault<Lego>(sql, new { Id });
        }

        internal Lego Create(Lego newData)
        {
            string sql = @"
            INSERT INTO legos 
            (name) 
            VALUES 
            (@Name);
            SELECT LAST_INSERT_ID();
            ";
            int id = _db.ExecuteScalar<int>(sql, newData);
            newData.Id = id;
            return newData;
        }

        internal void Edit(Lego update)
        {

            string sql = @"
            UPDATE legos
            SET 
            name = @Name,
            WHERE id = @Id; 
            ";
            _db.Execute(sql, update);
        }

        internal void Delete(int id)
        {
            string sql = "DELETE FROM legos WHERE id = @id";
            _db.Execute(sql, new { id });
        }
    }
}