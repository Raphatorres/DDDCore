using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DDDCore.Domain.Services;
using DDDCore.Infra.Data.Context;
using DDDCore.Services;
using DDDCore.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using DDDCore.Infra.Data.Repository;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace DDDCore.Presentation.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteAppService _clietenteClienteAppService;

        public ClienteController(IClienteAppService clietenteClienteAppService)
        {
            _clietenteClienteAppService = clietenteClienteAppService;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            //var options = new DbContextOptions<DDDContext>();
            //var  ctx = new  DDDContext(options);
            //var _clienteRepository = new ClienteRepository(ctx);
            //var _clienteService = new ClienteService(_clienteRepository);
            //var _clietenteClienteAppService = new ClienteAppService(_clienteService);
            return View(_clietenteClienteAppService.ObterTodos());
        }
    }
}
