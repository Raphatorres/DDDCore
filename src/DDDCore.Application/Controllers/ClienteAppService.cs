using System;
using System.Collections.Generic;
using AutoMapper;
using DDDCore.Application.Interfaces;
using DDDCore.Application.ViewModels;
using DDDCore.Domain.Entities;
using DDDCore.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace DDDCore.Application.Controllers
{


    [Route("api/[controller]")]
    public class ClienteAppService : Controller, IClienteAppService
    {

        private readonly IClienteService _clieteService;

        public ClienteAppService(IClienteService clieteServeService)
        {
            _clieteService = clieteServeService;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        [HttpPut]
        public ClienteEnderecoViewModel Adicionar(ClienteEnderecoViewModel clienteEnderecoViewModel)
        {
            var cliente = Mapper.Map<ClienteEnderecoViewModel, Cliente>(clienteEnderecoViewModel);
            var endereco = Mapper.Map<ClienteEnderecoViewModel, Endereco>(clienteEnderecoViewModel);
            cliente.Enderecos.Add(endereco);
            cliente.DataCadastro = DateTime.Now;

            var clienteReturn = _clieteService.Adicionar(cliente);

            clienteEnderecoViewModel = Mapper.Map<Cliente, ClienteEnderecoViewModel>(clienteReturn);

            return clienteEnderecoViewModel;
        }

        public ClienteViewModel ObterPorId(Guid id)
        {
            return Mapper.Map<Cliente, ClienteViewModel>(_clieteService.ObterPorId(id));
        }

        public ClienteViewModel ObterPorCpf(string cpf)
        {
            return Mapper.Map<Cliente, ClienteViewModel>(_clieteService.ObterPorCpf(cpf));
        }

        public ClienteViewModel ObterPorEmail(string email)
        {
            return Mapper.Map<Cliente, ClienteViewModel>(_clieteService.ObterPorEmail(email));
        }

        public IEnumerable<ClienteViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteViewModel>>(_clieteService.ObterTodos());
        }

        public ClienteViewModel Atualizar(ClienteViewModel cliente)
        {
            return Mapper.Map<Cliente, ClienteViewModel>(_clieteService.Atualizar(Mapper.Map<ClienteViewModel, Cliente>(cliente)));
        }

        public void Remover(Guid id)
        {
            _clieteService.Remover(id);
        }
    }
}
