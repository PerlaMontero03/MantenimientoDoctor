using MantenimientoDoctor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace MantenimientoDoctor.Controllers
{
    public class DoctorController : Controller
    {
        private readonly ConsultorioMedicoContext _context;

        public DoctorController(ConsultorioMedicoContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var listadoDoctores = await _context.Doctor.ToListAsync();

            return View(listadoDoctores);
        }

        //GET
        public IActionResult Create()
        {
            return View();    
        }

        //GET
        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();  
            }

            var doctor = await _context.Doctor.FirstOrDefaultAsync(x=>x.Id == id);
            if(doctor == null)
            {
                return NotFound();
            }

            return View(doctor);
        }

        //GET
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctor = await _context.Doctor.FirstOrDefaultAsync(x => x.Id == id);
            if (doctor == null)
            {
                return NotFound();
            }

            return View(doctor);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Doctor doctor)
        {
            if(ModelState.IsValid)
            {
                _context.Add(doctor);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int? Id, Doctor doctor)
        {
            if(Id != doctor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(doctor);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int? Id)
        {
            var doctor = await _context.Doctor.FirstOrDefaultAsync(x=>x.Id == Id);

            if(doctor == null)
            {
                return NotFound();
            }

            _context.Doctor.Remove(doctor);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
