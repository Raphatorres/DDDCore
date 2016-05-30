using System;
using System.Collections.Generic;
using DDDCore.Domain.Entities;
using DDDCore.Domain.Interfaces.Repositories;
using DDDCore.Domain.Interfaces.Services;

namespace DDDCore.Domain.Services
{
    public class ClienteService : IClienteService
    {

        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public Cliente Adicionar(Cliente cliente)
        {
            //if (!cliente.IsValid())
            //{

            return _clienteRepository.Adicionar(cliente);

            //return cliente;
            //}


        }

        public Cliente ObterPorId(Guid id)
        {
            return _clienteRepository.ObterPorId(id);
        }

        public Cliente ObterPorCpf(string cpf)
        {
            return _clienteRepository.ObterPorCpf(cpf);
        }

        public Cliente ObterPorEmail(string email)
        {
            return _clienteRepository.ObterPorEmail(email);
        }

        public IEnumerable<Cliente> ObterTodos()
        {
            return _clienteRepository.ObterTodos();
        }

        public Cliente Atualizar(Cliente cliente)
        {
            return _clienteRepository.Atualizar(cliente);
        }

        public void Remover(Guid id)
        {
            _clienteRepository.Remover(id);
        }
    }
}
