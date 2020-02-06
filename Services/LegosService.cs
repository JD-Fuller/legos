using System;
using System.Collections.Generic;
using legos.Models;
using legos.Repositories;

namespace legos.Services
{
    public class LegosService
    {
        private readonly LegosRepository _repo;
        public LegosService(LegosRepository lr)
        {
            _repo = lr;
        }

        internal IEnumerable<Lego> Get()
        {
            return _repo.Get();
        }

        internal Lego GetById(int id)
        {
            var exists = _repo.GetById(id);
            if (exists == null) { throw new Exception("Invalid Id"); }
            return exists;
        }

        internal Lego Create(Lego newData)
        {
            _repo.Create(newData);
            return newData;
        }

        internal Lego Edit(Lego update)
        {
            var exists = _repo.GetById(update.Id);
            if (exists == null) { throw new Exception("Invalid Id"); }

            // update.AuthorId = exists.AuthorId

            _repo.Edit(update);
            return update;
        }

        internal string Delete(int id)
        {
            var exists = _repo.GetById(id);
            if (exists == null) { throw new Exception("Invalid Id"); }
            _repo.Delete(id);
            return "Successfully Deleted";
        }

        internal object GetBySetId(int id)
        {

            throw new NotImplementedException();
        }
    }
}