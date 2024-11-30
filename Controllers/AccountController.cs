using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ScenePro.Models.ViewModel;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ScenePro.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // GET: Register
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // POST: Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // التحقق من صحة البيانات
            if (!Regex.IsMatch(model.Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                ModelState.AddModelError("Email", "Please enter a valid email address.");
                return View(model);
            }

            if (!Regex.IsMatch(model.FirstName, @"^[a-zA-Z]+$"))
            {
                ModelState.AddModelError("FirstName", "First name should contain only letters.");
                return View(model);
            }

            if (!Regex.IsMatch(model.LastName, @"^[a-zA-Z]+$"))
            {
                ModelState.AddModelError("LastName", "Last name should contain only letters.");
                return View(model);
            }

            if (string.IsNullOrWhiteSpace(model.Password) || model.Password.Length < 6)
            {
                ModelState.AddModelError("Password", "Password must be at least 6 characters long.");
                return View(model);
            }

            if (!Regex.IsMatch(model.Password, @"[A-Z]"))
            {
                ModelState.AddModelError("Password", "Password must contain at least one uppercase letter.");
                return View(model);
            }

            if (!Regex.IsMatch(model.Password, @"[a-z]"))
            {
                ModelState.AddModelError("Password", "Password must contain at least one lowercase letter.");
                return View(model);
            }

            if (!Regex.IsMatch(model.Password, @"[0-9]"))
            {
                ModelState.AddModelError("Password", "Password must contain at least one digit.");
                return View(model);
            }

            if (!Regex.IsMatch(model.Password, @"[\W_]"))
            {
                ModelState.AddModelError("Password", "Password must contain at least one special character (e.g. !, @, #, etc.).");
                return View(model);
            }


            var user = new ApplicationUser
            {
                UserName = model.Email,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Gender = model.Gender ?? "Not Specified"
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
               
                await _signInManager.SignInAsync(user, isPersistent: false);

                
                return RedirectToAction("Index", "Home");
            }

            
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View(model);
        }


        // GET: Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user == null)
                {
                    ModelState.AddModelError("", "Invalid email or password");
                    return View(model);
                }

                // Attempt to sign in the user
                var result = await _signInManager.PasswordSignInAsync(user.UserName, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    // Redirect to the home page or dashboard after successful login
                    return RedirectToAction("Index", "Home", new { area = "Dashboard" });
                }

                if (result.IsLockedOut)
                {
                    ModelState.AddModelError("", "This account is locked out.");
                    return View(model);
                }

                ModelState.AddModelError("", "Invalid login attempt.");
            }
            return View(model);
        }


        // GET: Logout
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }

    }
}
