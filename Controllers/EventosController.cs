using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EventosCRUD.Models;
using EventosCRUD.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace EventosCRUD.Controllers
{
    public class EventosController : Controller
    {
        private readonly AppDbContext _context;

        public EventosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Eventos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Eventos.ToListAsync());
        }

        // GET: Eventos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evento = await _context.Eventos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (evento == null)
            {
                return NotFound();
            }

            return View(evento);
        }

        // GET: Eventos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Eventos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Descripcion,Fecha,Lugar,AsistentesRegistrados,CapacidadMaxima")] Evento evento)
        {
            // Validación de inteligencia de negocios
            if (evento.AsistentesRegistrados > evento.CapacidadMaxima)
            {
                ModelState.AddModelError("AsistentesRegistrados",
                    "Los asistentes registrados no pueden superar la capacidad máxima.");
            }

            if (evento.Fecha < DateTime.Today)
            {
                ModelState.AddModelError("Fecha", "No se pueden crear eventos con fecha pasada.");
            }

            if (ModelState.IsValid)
            {
                _context.Add(evento);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Evento creado exitosamente!";
                return RedirectToAction(nameof(Index));
            }
            return View(evento);
        }

        // GET: Eventos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evento = await _context.Eventos.FindAsync(id);
            if (evento == null)
            {
                return NotFound();
            }
            return View(evento);
        }

        // POST: Eventos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Descripcion,Fecha,Lugar,AsistentesRegistrados,CapacidadMaxima")] Evento evento)
        {
            if (id != evento.Id)
            {
                return NotFound();
            }

            // Validación de inteligencia de negocios
            if (evento.AsistentesRegistrados > evento.CapacidadMaxima)
            {
                ModelState.AddModelError("AsistentesRegistrados",
                    "Los asistentes registrados no pueden superar la capacidad máxima.");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(evento);
                    await _context.SaveChangesAsync();
                    TempData["Success"] = "Evento actualizado exitosamente!";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventoExists(evento.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(evento);
        }

        // GET: Eventos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evento = await _context.Eventos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (evento == null)
            {
                return NotFound();
            }

            return View(evento);
        }

        // POST: Eventos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var evento = await _context.Eventos.FindAsync(id);
            _context.Eventos.Remove(evento);
            await _context.SaveChangesAsync();
            TempData["Success"] = "Evento eliminado exitosamente!";
            return RedirectToAction(nameof(Index));
        }

        // GET: Eventos/Dashboard
        public async Task<IActionResult> Dashboard()
        {
            var eventos = await _context.Eventos.ToListAsync();

            if (!eventos.Any())
            {
                ViewData["Mensaje"] = "No hay eventos para mostrar en el dashboard.";
                return View(new DashboardViewModel());
            }

            var viewModel = new DashboardViewModel
            {
                TotalEventos = eventos.Count,
                EventosProximos = eventos.Count(e => e.Fecha >= System.DateTime.Today && e.Fecha <= System.DateTime.Today.AddDays(7)),
                EventosFinalizados = eventos.Count(e => e.Fecha < System.DateTime.Today),
                TotalAsistentes = eventos.Sum(e => e.AsistentesRegistrados),
                CapacidadTotal = eventos.Sum(e => e.CapacidadMaxima),
                PorcentajeOcupacionTotal = eventos.Sum(e => e.CapacidadMaxima) > 0 ?
                    (eventos.Sum(e => e.AsistentesRegistrados) * 100) / eventos.Sum(e => e.CapacidadMaxima) : 0,
                Eventos = eventos
            };

            return View(viewModel);
        }

        private bool EventoExists(int id)
        {
            return _context.Eventos.Any(e => e.Id == id);
        }
    }
}