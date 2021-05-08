using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using MailKit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Core.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using nVideo.DATA;
using nVideo.DATA.ControllerModels;
using nVideo.DATA.Interfaces;
using nVideo.DATA.Services;
using nVideo.Models;

namespace nVideo.Controllers
{
    [Authorize(Roles = "admin")]

    public class AdminPanelController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly EmailSenderService _sender;
        private readonly ILogger<AccountController> _logger;
        private readonly AppDbContext _context;
        IWebHostEnvironment _appEnvironment;
        private readonly IAllCatalog _catalog;

        public AdminPanelController(UserManager<User> userManager, EmailSenderService sender, ILogger<AccountController> logger, AppDbContext context,IWebHostEnvironment appEnvironment, IAllCatalog catalog)
        {
            _userManager = userManager;
            _sender = sender;
            _logger = logger;
            _context = context;
            _appEnvironment = appEnvironment;
            _catalog = catalog;
        }
        // GET
        public async Task<IActionResult> Index()
        {
            var principal = new ClaimsPrincipal(User.Identities);
            var _admin = await _userManager.GetUserAsync(principal);
            ViewBag.Admin = _admin;
            
            return View();
        }

        public IActionResult Banhammer()
        {
            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Ban(string BanEmail)
        {
            if(BanEmail== null) return RedirectToAction("Result", new {exepNum =2});
            var user = await _userManager.FindByEmailAsync(BanEmail);
            if (user == null) return RedirectToAction("Result", new {exepNum =1});
            await _userManager.AddToRoleAsync(user, "baned");
            //Indian codding mod: ON
            return RedirectToAction("Result", new {exepNum =0});
        }
        [HttpPost]
        public async Task<IActionResult> UnBan(string UnbanEmail)
        {
            if(UnbanEmail== null) return RedirectToAction("Result", new {exepNum =2});
            var user = await _userManager.FindByEmailAsync(UnbanEmail);
            if (user == null) return RedirectToAction("Result", new {exepNum = 1});
            await _userManager.AddToRoleAsync(user, "user");
            return RedirectToAction("Result", new {exepNum =0});
        }
        [HttpPost]
        public async Task<IActionResult> AddAdmin(string AdminEmail)
        {
            if(AdminEmail== null) return Result(2);
            var user = await _userManager.FindByEmailAsync(AdminEmail);
            if (user == null) return Result(1);
            await _userManager.AddToRoleAsync(user, "admin");
            return RedirectToAction("Result", new {exepNum =0});
        }


        

        [HttpGet]
        public IActionResult AddEntity()
        {
            return View();
        }
        
        
        
        [HttpPost]
        public async Task<IActionResult> AddEntityToDB(string Name,string Articul, string Price,
            string Short_Desc, string Long_Desc, string  InStock, List<string> Attributes, 
            List<string> Values, string Category,  IFormFileCollection images)
        {

            if (InStock != null || (Price != null || int.TryParse(Price, out _) || (int.TryParse(InStock, out _))))
            {
                return RedirectToAction("Result", new {exepNum =2});
            }
            var category = _context.Categories
                .First(a => a.CategoryName == Category);

            var ce = new Catalog_Entity();

            Directory.CreateDirectory(_appEnvironment.WebRootPath + "/IMG/" + "Home");
            Directory.CreateDirectory(_appEnvironment.WebRootPath + "/IMG/" + "Home/" + Name);
            List<Picture> pictures = new List<Picture>();
                foreach (var pic in images)
            {
                if (!AssertThatImage(pic))
                {
                    return RedirectToAction("Result", new {exepNum =2});
                }
                string path = "/IMG/"+ "Home"+"/" +Name+"/"+ pic.FileName;
                Picture picture = new Picture();
                picture.Patch = path;
                picture.Entity = ce;
                pictures.Add(picture);
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await pic.CopyToAsync(fileStream);
                    
                }
            }

            
            
            List<Catalog_Attribute> AttrList = new List<Catalog_Attribute>();
            List<Catalog_Value> ValList = new List<Catalog_Value>();
            foreach (string s in Values)
            {
                ValList.Add(new Catalog_Value
                {
                    StringValue = s
                });
            }

            int i = 0;
            
            foreach (string s in Attributes)
            {
                AttrList.Add(new Catalog_Attribute
                {
                    AttributeName = s,
                    Entity = ce,
                    Value = ValList[i++]
                });
            }

            ce.Attributes = AttrList;
            ce.Category = category;
            ce.Name = Name;
            ce.Articul = Articul;
            ce.Price = uint.Parse(Price);
            ce.Short_Desc = Short_Desc;
            ce.Long_Desc = Long_Desc;
            ce.InStock = ushort.Parse(InStock);
            ce.Images = pictures;

            _context.Categories.Update(category);
            await _context.Entities.AddAsync(ce);
            await _context.Pictures.AddRangeAsync(pictures);
            await _context.Values.AddRangeAsync(ValList);
            await _context.Attributes.AddRangeAsync(AttrList);
            await _context.SaveChangesAsync();
            return RedirectToAction("Result", new {exepNum = 0});
        }

        public IActionResult Result(int exepNum)
        {
            switch (exepNum)
            {
                case 0:
                    ViewBag.Message = "The action ended successfully!";
                    break;
                case 1:
                    ViewBag.Message = "ERROR:Cant find the user!";
                    break;
                case 2: 
                    ViewBag.Message = "ERROR:Check forms!";
                    break;
                case 3: 
                    ViewBag.Message = "ERROR: Write normal attribute!";
                    break;
                default:
                    ViewBag.Message = "ERROR:Something wrong happen!";
                    break;
                
            }

            return View();
        }

       

        [HttpPost]
        public IActionResult AddEntityPartial(string Number, string Imgs)
        {
            if (( Int32.Parse(Number)< 1)||( Int32.Parse(Imgs)<1) || ( Int32.Parse(Number)>15) || ( Int32.Parse(Imgs) > 5))
            {
                return RedirectToAction("Result", new {exepNum =3});
            }
            ViewBag.Number = Int32.Parse(Number);
            ViewBag.NumImg = Int32.Parse(Imgs);
            return View();
        }

        [HttpGet]
        public IActionResult EditEntity()
        {

           IEnumerable<Catalog_Entity> ent = _context.Entities
                .OrderBy(e=> e.Id)
                .Select(e => e);
           ViewBag.Entities = ent;
            return View();
        }
        
        private bool AssertThatImage(IFormFile file)
        {
            var name = file.FileName;
            var extension = name //Extract extension
                .Substring(name.LastIndexOf('.'), name.Length - name.LastIndexOf('.')) 
                .ToLower();

            if (extension == ".png" || extension == ".jpg" || extension == ".jpeg")
                return 1 != 0;

            return false;
        }

        [HttpGet]
        public  async Task<IActionResult> DeleteEntities(int Id)
        {
             Catalog_Entity ent =  await _context.Entities.FindAsync(Id);
             ViewBag.Ent = ent;
             return View();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteById(int Id)
        {
           var ent = await _context.Entities.FindAsync(Id);
           IEnumerable<Catalog_Attribute> att = _context.Attributes
               .Where(x => x.EntityId == Id);
          
           
           foreach (var attribute in att)
           {
               var value = _context.Values
                   .Where(x => x.Attribute.Id == attribute.Id);
               _context.Attributes.Remove(attribute);
               _context.Values.RemoveRange(value);
               

           }
           IEnumerable<Picture> pics = _context.Pictures
               .Where(x => x.Entity == ent);
           foreach (var p in pics)
           {
               _context.Pictures.Remove(p);
               Directory.Delete(_appEnvironment.WebRootPath + p.Patch);
           }
           

           _context.Entities.Remove(ent);
           await _context.SaveChangesAsync();
           return RedirectToAction("Result", new {exepNum = 0});
        }
    }
}