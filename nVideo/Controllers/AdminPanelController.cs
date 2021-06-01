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
using nVideo.DATA.Extentions;
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
        private readonly INotificator _notificator;
        

        public AdminPanelController(UserManager<User> userManager, EmailSenderService sender,
            ILogger<AccountController> logger, AppDbContext context,
            IWebHostEnvironment appEnvironment, IAllCatalog catalog, INotificator notificator)
        {
            _userManager = userManager;
            _sender = sender;
            _logger = logger;
            _context = context;
            _appEnvironment = appEnvironment;
            _catalog = catalog;
            _notificator = notificator;
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
        public IActionResult AddUser()
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
            string Short_Desc, string Long_Desc, string  InStock, List<string> Attributes, string Awailable, 
            List<string> Values, string Category,  IFormFileCollection images)
        {
            string NormalCategory = ChangeLangCategory(Category);
            if (NormalCategory == null) return RedirectToAction("Result", new {exepNum = 2});
            var category = _context.Categories
                .First(a => a.CategoryName == NormalCategory);

            var ce = new Catalog_Entity();

            Directory.CreateDirectory(_appEnvironment.WebRootPath + "/IMG/" + Category);
            Directory.CreateDirectory(_appEnvironment.WebRootPath + "/IMG/" + Category+"/" + Name);
            List<Picture> pictures = new List<Picture>();
            
            
            foreach (var pic in images)
            {
                if (!AssertThatImage(pic))
                {
                    return RedirectToAction("Result", new {exepNum =4});
                }

                
                string path =("/IMG/" + Category +"/" +Name+"/"+ pic.FileName);
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
            ce.Awailable = Convert.ToBoolean(Awailable);

            _context.Categories.Update(category);
            await _context.Entities.AddAsync(ce);
            await _context.Pictures.AddRangeAsync(pictures);
            await _context.Values.AddRangeAsync(ValList);
            await _context.Attributes.AddRangeAsync(AttrList);
            await _context.SaveChangesAsync();
            return RedirectToAction("Result", new {exepNum = 0});
        }

        private string ChangeLangCategory(string Category) =>
            Category; // Lang changed in db.

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
                case 4 :
                    ViewBag.Message = "ERROR: Check filename";
                    break;
                case 12:
                    ViewBag.Message = "ERROR: User is allready exist!";
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
        public IActionResult EditEntity(int currentpage )
        {

           List<Catalog_Entity> ent = _context.Entities
                .OrderBy(e=> e.Id)
                .Select(e => e)
                .ToList();
           
           var pages = ent.Count() % 10 != 0 ? ent.Count() / 10 + 1 : ent.Count() / 10;
           ViewBag.Pages = pages;
           ViewBag.CurrentPage = currentpage;
           ViewBag.Entities = ent.Skip(10*(currentpage - 1)).Take(10).ToList();
            return View();
        }

        private bool AssertThatImage(IFormFile file) =>
            CheckExtention(ExtractExtension(file.FileName));

        private bool CheckExtention(string extension) =>
            extension == ".png" || extension == ".jpg" || extension == ".jpeg";

        private string ExtractExtension(string fileName) =>
            fileName.Substring(
            fileName.LastIndexOf('.'),
            fileName.Length - fileName.LastIndexOf('.'))
                .ToLower();

        [HttpGet]
        public  async Task<IActionResult> DeleteEntities(int Id)
        {
             Catalog_Entity ent =  await _context.Entities.FindAsync(Id);
             ViewBag.Ent = ent;
             return View();
        }
        
        [HttpPost]
        public  async Task<IActionResult> DeleteById(int eid)
        {
            var e = _catalog.GetItemById(eid);
            var orders = _context.Orders
                .Include(o => o.OrderedItems)
                .ThenInclude(e => e.Entity)
                .ToList();

            var listOrders = orders.Select(o => o.OrderedItems);

            bool isOrdered = false;

            foreach (var order in listOrders)
            foreach (var ordered in order)
                if (ordered.Entity.Id == eid)
                    isOrdered = true;

            if (!isOrdered)
            {
                await RemoveEntity(e);
                return RedirectToAction("Result", new {exepNum = 0});
            }
            else 
            {
                return RedirectToAction("Result", new {exepNum =3});
            }
        }


        private async Task<bool> RemoveEntity(Catalog_Entity e)
        {
            try
            {
                _context.Values
                    .RemoveRange(e.Attributes.Select(a => a.Value));

                _context.Attributes
                    .RemoveRange(e.Attributes);

                if (e.Images.Any())
                {
                    //Здесь удаление папки с пикчами
                    _context.Pictures
                        .RemoveRange(e.Images);

                }

                if (e.Comments.Any())
                    _context.Comments
                        .RemoveRange(e.Comments);
                _context.Entities.Remove(e);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        public IActionResult EditProductDb(string Id, string Name,string Articul, string Price,
            string Short_Desc, string Long_Desc, string  InStock, List<string> AttId, string Awailable, 
            List<string> Values)
        {
            var ent = _context.Entities.First(x=>x.Id == int.Parse(Id));
            ent.Name = Name;
            ent.Articul = Articul;
            
            ent.Price = PriceToRub(Convert.ToUInt32(Price));
            ent.Short_Desc = Short_Desc;
            ent.Long_Desc = Long_Desc;
            ent.InStock = Convert.ToUInt16(InStock);
            ent.Awailable = Convert.ToBoolean(Awailable);

            var Attributes = _context.Attributes
                .Where(x => x.Entity.Id == int.Parse(Id))
                .ToList();
            var values = _context.Values.Where(x => x.Attribute.Entity.Id == int.Parse(Id));


           
           var dic = AttId.Zip(Values,(k, v) => new { k, v })
               .ToDictionary(x => x.k, x => x.v);

           foreach (var id in AttId)
           {
               if (int.TryParse(dic[id], out _))
               {
                   values.First(x => x.Attribute.Id == int.Parse(id)).IntegerValue = int.Parse(dic[id]);
               }
               else
               {
                   values.First(x => x.Attribute.Id== int.Parse(id)).StringValue = dic[id];
               }
           }

           _context.SaveChanges();

           return RedirectToAction("Result", new {exepNum = 0});
        }
        
        
        [HttpGet]
        public IActionResult EditProduct(int Id)
        {
            var e = _catalog.GetItemById(Id);
            var a = _context.Attributes
                .Where(x => x.EntityId == e.Id)
                .ToList();
            ViewBag.Ent = e;
            ViewBag.Att = a;
            return View();
        }


        
        public IActionResult Orders(int currentpage)
        {
            var orders = _context.Orders
                .Where(x => x == x).ToList();

            var pages = orders.Count() % 10 != 0 ? orders.Count() / 10 + 1 : orders.Count() / 10;
            ViewBag.Pages = pages;
            ViewBag.CurrentPage = currentpage;
            ViewBag.Orders = orders.Skip(10*(currentpage - 1)).Take(10).ToList();

            return View();
        }

        public IActionResult Order(int Id)
        {
            var order = _context.Orders
                .Single(o => o.Id.Equals(Id));      

            if (order.IsSelfDelivery)
                order = _context.Orders
                    .Include(o => o.PickUpFrom)
                    .Single(x => x.Id == Id);
            else
                order = _context.Orders
                    .Include(o => o.CustomerData)
                    .Single(x => x.Id == Id);
            

            ViewBag.order = order;
            ViewBag.user = _context.Users.
                FirstOrDefault(x=>x.Orders.FirstOrDefault(x=>x.Id == order.Id) == order);

            return View();
        }

        public IActionResult ChangeOrderStatus(int Id, string Status, string Email)
        {
            
            var order = _context.Orders
                .First(x => x.Id == Id);
            if(Status!= "Closed" && Status!= "Open" && Status!="InProcess" && Status !="ReadyToPick") {return RedirectToAction("Result", new {exepNum =1});}
                order.State = Status;
            int x = Id;
            _context.SaveChanges();

            if (Status == "Closed") _notificator.AboutOrderColsed(Email, order );
            if (Status == "Open") _notificator.AboutOrderOpened(Email, order);
            if (Status == "InProcess") _notificator.AboutOrderInProgress(Email, order);
            if (Status == "ReadyToPick") _notificator.AboutReadyToPick(Email, order);
            {
                
            }
            return RedirectToAction("Order",new {Id = x});
        }

        public async Task<IActionResult> CreateUser(string Email, string pass, string Role)
        {
            if (_context.Users.FirstOrDefault(x=>x.Email == Email) != null)
            {
                return RedirectToAction("Result", new {exepNum = 12});
            }
            var user = new User
            {
                Email = Email,
                UserName = Email,
                Profile = new UserProfile()
                
            };
             
           
                Task.WhenAll(_userManager.CreateAsync(user, pass));
            
                Task.WhenAll(_userManager.AddToRoleAsync(user, Role));
            return RedirectToAction("Result", new {exepNum = 0});
        }

        private uint PriceToDollars(uint price)
        {
            return price / 74;
        }
        private uint PriceToRub(uint price)
        {
            return price * 74;
        }     
    }
}