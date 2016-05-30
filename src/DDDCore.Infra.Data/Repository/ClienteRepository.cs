using DDDCore.Domain.Entities;
using DDDCore.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;
using DDDCore.Infra.Data.Context;

namespace DDDCore.Infra.Data.Repository
{
    public class ClienteRepository :Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(DDDContext context) : base(context)
        {
        }

        public Cliente ObterPorCpf(string cpf)
        {
            return Buscar(e => e.CPF == cpf).FirstOrDefault();
        }

        public Cliente ObterPorEmail(string email)
        {
            return Buscar(c => c.Email == email).FirstOrDefault();
        }

        public override IEnumerable<Cliente> ObterTodos()
        {
            //var cn = Db.Database.Connection;
            //var sql = @"Select * from Clientes";

            //return cn.Query<Cliente>(sql);


            return base.ObterTodos();
        }

    }
}
