using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using MailKit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Core.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using nVideo.DATA;
using nVideo.DATA.ControllerModels;
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

        public AdminPanelController(UserManager<User> userManager, EmailSenderService sender, ILogger<AccountController> logger, AppDbContext context)
        {
            _userManager = userManager;
            _sender = sender;
            _logger = logger;
            _context = context;
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
            if(BanEmail== null) return Result(2);
            var user = await _userManager.FindByEmailAsync(BanEmail);
            if (user == null) return Result(1);
            await _userManager.AddToRoleAsync(user, "baned");
            //Indian codding mod: ON
            return Result(0);
        }
        [HttpPost]
        public async Task<IActionResult> UnBan(string UnbanEmail)
        {
            if(UnbanEmail== null) return Result(2);
            var user = await _userManager.FindByEmailAsync(UnbanEmail);
            if (user == null) return Result(1);
            await _userManager.AddToRoleAsync(user, "user");
            return Result(0);
        }
        [HttpPost]
        public async Task<IActionResult> AddAdmin(string AdminEmail)
        {
            if(AdminEmail== null) return Result(2);
            var user = await _userManager.FindByEmailAsync(AdminEmail);
            if (user == null) return Result(1);
            await _userManager.AddToRoleAsync(user, "admin");
            return Result(0);
        }


        public string CatalogAndValue;
        public string Name;
        public string Articul;
        public string  Price;
        public string Short_Desc;
        public string Long_Desc;
        public string  InStock;

        [HttpGet]
        public IActionResult AddEntity()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult AddEntityToDB()
        {
            AdminPanelModel adminPanelModel = new AdminPanelModel();
            adminPanelModel.CategoryAndValue = CatalogAndValue;
            adminPanelModel.CatalogEntity.Name = Name;
            adminPanelModel.CatalogEntity.Articul = Articul;
            adminPanelModel.CatalogEntity.Price = uint.Parse(Price);
            adminPanelModel.CatalogEntity.Short_Desc = Short_Desc;
            adminPanelModel.CatalogEntity.Long_Desc = Long_Desc;
            adminPanelModel.CatalogEntity.InStock = ushort.Parse(InStock);  
            Catalog_Entity catalogEntity = adminPanelModel.CatalogEntity;
            
            List<string> list = adminPanelModel.CategoryAndValue.Split(';').ToList();
            Dictionary<string, string> AttributeValuePaires = new Dictionary<string, string>();
            if (list.Count() % 2 != 0)
            {
                return Result(10);
            }
            for(int i = 0;i<list.Count();i++) 
                AttributeValuePaires[list[i]] = list[++i];
            AddAttributeAndValueInDB(AttributeValuePaires.Keys, AttributeValuePaires.Values,adminPanelModel.CatalogEntity);
            return Result(0);
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

        private async Task<bool>AddAttributeAndValueInDB(IEnumerable<string> Attributes, IEnumerable<string> Value, Catalog_Entity catalogEntity)
        {
            List<Catalog_Attribute> AttrList = new List<Catalog_Attribute>();
            List<Catalog_Value> ValList = new List<Catalog_Value>();
            foreach (string s in Value)
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
                    Entity = catalogEntity,
                    Value = ValList[i++]
                });
            }

            catalogEntity.Attributes = AttrList;
            await _context.AddRangeAsync(ValList);
            await _context.AddRangeAsync(AttrList);
            await _context.AddAsync(catalogEntity);
            return true;
        }
        
        
        
    }
}