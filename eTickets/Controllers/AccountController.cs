using eTickets.Data;
using eTickets.Data.Enums;
using eTickets.Data.Services;
using eTickets.Data.ViewModels;
using eTickets.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace eTickets.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly AppDbContext _context;
        private readonly IAccountService _accountService;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, AppDbContext context,IAccountService accountService, RoleManager<ApplicationRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _accountService = accountService;
            _roleManager = roleManager;

        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        public async Task<IActionResult> AllUsers()
        {
            var users = await _context.Users.ToListAsync();

            return View(users);
        }


        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerVM)
        {
            if(!ModelState.IsValid)
            {
                ViewBag.Error = ModelState.Values.SelectMany(temp => temp.Errors).Select(temp => temp.ErrorMessage);
                return View(registerVM);
            }

            var ExistingUser = await _userManager.FindByEmailAsync(registerVM.EmailAddress);

            if(ExistingUser !=null)
            {
                ModelState.AddModelError(string.Empty, "This email is already registered.");
                return View(registerVM);
            }
            ApplicationUser user = new ApplicationUser()
            {
                Email = registerVM.EmailAddress,
                FullName = registerVM.FullName,
                UserName = registerVM.EmailAddress,
            };
           IdentityResult result =  await _userManager.CreateAsync(user,registerVM.Password);

            if(result.Succeeded)
            {
                var roleExists = await _roleManager.RoleExistsAsync(UserRoles.User);

                if (!roleExists)
                {
                    await _roleManager.CreateAsync(new ApplicationRole(UserRoles.User));
                }
               await  _userManager.AddToRoleAsync(user, UserRoles.User);

                await _accountService.CheckRegisteredStatusAsync();

                return View("RegisterCompleted");
            }
            else
            {
                foreach (IdentityError Error in result.Errors)
                {
                    ModelState.AddModelError("Register", Error.Description);
                }
            }
            return View(registerVM);
        }


        [HttpGet]
        public IActionResult Login()
        {
            // full name : payam khavari
            //email : payamkhav@gmail.com
            //pass : Payam@1982
            return View();
        }


        [HttpPost]
        public async  Task<IActionResult> Login(LoginViewModel loginVM)
        {
            if(!ModelState.IsValid)
            {
                return View(loginVM);
            }

            var user = await _userManager.FindByEmailAsync(loginVM.EmailAddress);
            if(user != null) 
            {
                var passwordCheck = await _userManager.CheckPasswordAsync(user, loginVM.Password); 
                if(passwordCheck)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password,isPersistent:false,lockoutOnFailure:false); 
                    if(result.Succeeded)
                    {
                        return RedirectToAction("Index", "Movie");   
                    }
                }

                TempData["Error"] = "Wrong credentials. please , try again!";
                return View(loginVM);
            }
            TempData["Error"] = "Wrong credentials. please , try again!";
            return View(loginVM);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Movie");
        }
      
    }
}
