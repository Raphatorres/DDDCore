using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DDDCore.Domain.Interfaces.Repositories;
using DDDCore.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace DDDCore.Infra.Data.Repository
{
    public  class Repository<T> :
        IRepository<T> where T : class 
    {
        protected DDDContext Db;

        public Repository(DDDContext context)
        {
            Db = context;
            //DbSet = Db.Set<T>();
        }

        public virtual T Adicionar(T obj)
        {
            var objReturn = Db.Set<T>().Add(obj);
            //var objReturn = DbSet.Add(obj);
            SaveChages();
            //return objReturn;
            return null;
        }

        public virtual T ObterPorId(Guid id)
        {
            return null;
            //return DbSet.Find(id);
        }

        public virtual IEnumerable<T> ObterTodos()
        {
            IEnumerable<T> query = Db.Set<T>().ToList();
            return query;
        }

        public virtual T Atualizar(T obj)
        {
            var entry = Db.Entry(obj);
            Db.Set<T>().Attach(obj);
            entry.State = EntityState.Modified;
            SaveChages();
            return obj;
        }

        public virtual void Remover(Guid id)
        {
            var obj = ObterPorId(id);
            if (obj == null) return;
            Db.Set<T>().Remove(obj);
            SaveChages();
        }

        public virtual IEnumerable<T> Buscar(Expression<Func<T, bool>> predicate)
        {
            return null;
            //return DbSet.Where(predicate);
        }

        public int SaveChages()
        {
            return Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
