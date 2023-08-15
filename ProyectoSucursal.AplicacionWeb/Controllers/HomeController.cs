using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileSystemGlobbing.Internal;
using ProyectoSucursal.AplicacionWeb.Models;
using ProyectoSucursal.AplicacionWeb.Models.ViewModels;
using ProyectoSucursal.BLL.Service;
using ProyectoSucursal.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Text.RegularExpressions;

namespace ProyectoSucursal.AplicacionWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISucursalService _sucursalService;
        private readonly ITecnicoService _tecnicoService;
        private readonly IAsignacionService _asignacionservice;
        private readonly IElementoService _elementoService;

        public HomeController(ISucursalService sucursalService, ITecnicoService tecnicoService, IAsignacionService asignacionservice, IElementoService elementoService)
        {
            _sucursalService = sucursalService;
            _tecnicoService = tecnicoService;
            _asignacionservice = asignacionservice;
            _elementoService = elementoService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            IQueryable<Sucursal> querySucursalSQL = await _sucursalService.GetAll();
            
            List<VMSucursal> list = querySucursalSQL.Select(c=> new VMSucursal()
            {
                Codigo = c.Codigo,
                Nombre = c.Nombre,
            }).ToList();
            
            return StatusCode(StatusCodes.Status200OK, list);
        }

        [HttpGet]
        public async Task<IActionResult> ListElementos()
        {
            IQueryable<Elemento> queryElementoSQL = await _elementoService.GetAll();

            List<VMElemento> list = queryElementoSQL.Select(c => new VMElemento()
            {
                Codigo = c.Codigo,
                Nombre = c.Nombre,
            }).ToList();

            return StatusCode(StatusCodes.Status200OK, list);
        }

        [HttpGet]
        public async Task<IActionResult> ListTecnico()
        {
            IQueryable<Tecnico> queryTecnicoSQL = await _tecnicoService.GetAll();
            List<VMTecnico> list = queryTecnicoSQL.Select(c => new VMTecnico()
            {
                Id = c.Id,
                Codigo = c.Codigo,
                Nombre = c.Nombre,
                SueldoBase = c.SueldoBase,
                IdSucursal = c.IdSucursal,
                Asignacions = c.Asignacions,
                IdSucursalNavigation = c.IdSucursalNavigation,
            }).ToList();
            return StatusCode(StatusCodes.Status200OK, list);
        }

        [HttpGet]
        public async Task<IActionResult> ListAsignaciones(int id)
        {
            IQueryable<Asignacion> queryTecnicoSQL = await _asignacionservice.GetByTecnico(id);
            List<VMAsignacion> list =  queryTecnicoSQL.Select( c => new VMAsignacion()
            {
                Id = c.Id,
                IdElemento = c.IdElemento,
                Cantidad = c.IdElemento,
                IdElementoNavigation = c.IdElementoNavigation
            }).ToList();

            return StatusCode(StatusCodes.Status200OK, list);
        }

        [HttpPost]
        public async Task<IActionResult> InsertTecnico([FromBody] VMTecnico model)
        {
            Tecnico tecnico = await _tecnicoService.GetByCodigo(model.Codigo);
            
            if (tecnico != null) {
                return StatusCode(StatusCodes.Status400BadRequest, new { valor = false });
            }

            Console.Write(tecnico.Id);

            Tecnico NewModel = new Tecnico()
            {
                Nombre = model.Nombre,
                Codigo = model.Codigo,
                IdSucursal = model.IdSucursal,
                SueldoBase = model.SueldoBase,
            };

            bool resepuesta = await _tecnicoService.Insert(NewModel);

            return StatusCode(StatusCodes.Status200OK, new { valor = resepuesta });
        }

        [HttpPost]
        public async Task<IActionResult> InsertAsicnacion([FromBody] VMAsignacion model)
        {

            Tecnico queryTecnicoSQL = await _tecnicoService.GetByLast();

            Asignacion NewModel = new Asignacion()
            {
                IdTecnico = queryTecnicoSQL.Id,
                IdElemento = model.IdElemento,
                Cantidad = model.Cantidad,
            };

            bool resepuesta = await _asignacionservice.Insert(NewModel);

            return StatusCode(StatusCodes.Status200OK, new { valor = resepuesta });
        }

        [HttpPost]
        public async Task<IActionResult> InsertAsicnacionByID(int id, [FromBody] VMAsignacion model)
        {

            Asignacion NewModel = new Asignacion()
            {
                IdTecnico = id,
                IdElemento = model.IdElemento,
                Cantidad = model.Cantidad,
            };

            bool resepuesta = await _asignacionservice.Insert(NewModel);

            return StatusCode(StatusCodes.Status200OK, new { valor = resepuesta });
        }


        [HttpPut]
        public async Task<IActionResult> UpdateTecnico([FromBody] VMTecnico model)
        {

            await _asignacionservice.DeleteByTecnico(model.Id);

            Tecnico NewModel = new Tecnico()
            {
                Id = model.Id,
                Nombre = model.Nombre,
                Codigo = model.Codigo,
                SueldoBase = model.SueldoBase,
                IdSucursal = model.IdSucursal
            };

            bool resepuesta = await _tecnicoService.Update(NewModel);


            return StatusCode(StatusCodes.Status200OK, new { valor = resepuesta });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _asignacionservice.DeleteByTecnico(id);
            
            bool resepuesta = await _tecnicoService.Delete(id);

            return StatusCode(StatusCodes.Status200OK, new { valor = resepuesta });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}