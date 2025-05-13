using Bilisim.HelloMvc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Bilisim.HelloMvc.Controllers
{
    public class OgrenciController : Controller
    {
        private readonly OkulDbContext _context;

        // OkulDbContext'i Controller'a constructor injection ile alıyoruz
        public OgrenciController(OkulDbContext context)
        {
            _context = context;
        }

        // Öğrencileri listeleme
        public ViewResult OgrenciListe()
        {
            var lst = _context.Ogrenciler.ToList();
            return View(lst);
        }

        // Öğrenci silme
        [HttpPost]
        public IActionResult OgrenciSil(int ogrenciId)
        {
            var ogrenci = _context.Ogrenciler.FirstOrDefault(o => o.Ogrenciid == ogrenciId);
            if (ogrenci != null)
            {
                _context.Ogrenciler.Remove(ogrenci);
                _context.SaveChanges();
            }
            return RedirectToAction("OgrenciListe");
        }

        // Öğrenci ekleme sayfası
        [HttpGet]
        public ViewResult OgrenciEkle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult OgrenciEkle(Ogrenci ogrenci)
        {
            if (ModelState.IsValid)
            {
                _context.Ogrenciler.Add(ogrenci);
                _context.SaveChanges();
                return RedirectToAction("OgrenciListe");
            }
            return View();
        }
    }
}
