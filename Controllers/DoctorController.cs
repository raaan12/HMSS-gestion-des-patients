using HMSS.Data;
using HMSS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HMSS.Controllers
{
    public class DoctorController : Controller
    {
        private readonly ApplicationDbContext _context;
        public DoctorController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return _context.Doctors != null ?
                        View(await _context.Doctors.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.Departments'  is null.");
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(Doctor model)
        {
            if (ModelState.IsValid)
            {
                var existingDoctor = await _context.Doctors.FirstOrDefaultAsync(c => c.email == model.email);

                if (existingDoctor == null)
                {
                    var doctor = new Doctor
                    {
                        DoctorId = model.DoctorId,
                        nom = model.nom,
                        prenom = model.prenom,
                        email = model.email,
                        password = model.password,
                        speciality = model.speciality,
                        Department_id = model.Department_id

                    };

                    _context.Doctors.Add(doctor);
                    await _context.SaveChangesAsync();

                    // Redirection vers l'action Login
                    return RedirectToAction("Login", "Doctor");
                }
                else
                {
                    ModelState.AddModelError("", "Un compte avec cet email existe déjà.");
                }
            }

            return View(model);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Doctor model)
        {
            var user = await _context.Doctors.FirstOrDefaultAsync(c => c.email == model.email && c.password == model.password);

            if (user != null)
            {
                // Enregistrer l'ID du client dans le cookie de l'utilisateur pour garder sa session

                return new RedirectResult(url: "/Patient/Index", permanent: true,
                                 preserveMethod: true);
            }
            else
            {
                ModelState.AddModelError("", "Email ou mot de passe incorrect.");
                return RedirectToAction("Login");

            }
        }
    }
}
