using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using legos.Models;

namespace legos.Repositories
{
    public class SetsRepository
    {
        private readonly IDbConnection _db;
        public SetsRepository(IDbConnection db)
        {
            _db = db;
        }
        internal IEnumerable<Set> Get()
        {
            string sql = "SELECT * FROM sets";
            return _db.Query<Set>(sql);
        }

        internal Set GetById(int Id)
        {
            string sql = "SELECT * FROM sets WHERE id = @Id";
            return _db.QueryFirstOrDefault<Set>(sql, new { Id });
        }

        internal Set Create(Set newData)
        {
            string sql = @"
            INSERT INTO sets 
            (name) 
            VALUES 
            (@Name);
            SELECT LAST_INSERT_ID();
            ";
            int id = _db.ExecuteScalar<int>(sql, newData);
            newData.Id = id;
            return newData;
        }

        internal void Edit(Set update)
        {

            string sql = @"
            UPDATE sets
            SET 
            name = @Name,
            WHERE id = @Id; 
            ";
            _db.Execute(sql, update);
        }

        internal void Delete(int id)
        {
            string sql = "DELETE FROM sets WHERE id = @id";
            _db.Execute(sql, new { id });
        }

        internal IEnumerable<Set> GetSetsByLegoId(int legoId)
        {
            string sql = @"
            SELECT c.*
            FROM setslegos sl
            JOIN sets s ON s.id = sl.setId
            WHERE legoId = @legoId;";

            return _db.Query<Set>(sql, new { legoId });
        }
    }
}