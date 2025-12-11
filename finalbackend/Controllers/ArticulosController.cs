using AlmacenMvc.Dtos;
using AlmacenMvc.Models;
using AlmacenMvc.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AlmacenMvc.Controllers
{
    public class ArticulosController : Controller
    {
        private readonly IArticuloRepository _repo;
        private readonly IMapper _mapper;

        public ArticulosController(IArticuloRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var articulos = await _repo.GetAllAsync();
            var dto = _mapper.Map<List<ArticuloDto>>(articulos);
            return View(dto);
        }

        public async Task<IActionResult> Details(int id)
        {
            var articulo = await _repo.GetByIdAsync(id);
            if (articulo == null) return NotFound();

            var dto = _mapper.Map<ArticuloDto>(articulo);
            return View(dto);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ArticuloDto dto)
        {
            if (!ModelState.IsValid) return View(dto);

            var entidad = _mapper.Map<Articulo>(dto);
            await _repo.AddAsync(entidad);
            await _repo.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var articulo = await _repo.GetByIdAsync(id);
            if (articulo == null) return NotFound();

            var dto = _mapper.Map<ArticuloDto>(articulo);
            return View(dto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ArticuloDto dto)
        {
            if (id != dto.Id) return BadRequest();
            if (!ModelState.IsValid) return View(dto);

            var entidad = _mapper.Map<Articulo>(dto);
            await _repo.UpdateAsync(entidad);
            await _repo.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var articulo = await _repo.GetByIdAsync(id);
            if (articulo == null) return NotFound();

            var dto = _mapper.Map<ArticuloDto>(articulo);
            return View(dto);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _repo.DeleteAsync(id);
            await _repo.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
