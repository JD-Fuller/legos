using System;
using System.Collections.Generic;
using legos.Models;
using legos.Repositories;

namespace legos.Services
{
    public class SetsService
    {
        private readonly SetsRepository _repo;
        public SetsService(SetsRepository lr)
        {
            _repo = lr;
        }

        internal IEnumerable<Set> Get()
        {
            return _repo.Get();
        }

        internal Set GetById(int id)
        {
            var exists = _repo.GetById(id);
            if (exists == null) { throw new Exception("Invalid Id"); }
            return exists;
        }

        internal Set Create(Set newData)
        {
            _repo.Create(newData);
            return newData;
        }

        internal Set Edit(Set update)
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

        internal IEnumberable<Set> GetByLegoId(int legoid)
        {

            return _repo.GetByLegoId(legoId);
        }
    }
}