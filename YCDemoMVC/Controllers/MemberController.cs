using Microsoft.AspNetCore.Mvc;

namespace YCDemoMVC.Controllers;

public class MemberController : Controller
{
    public MemberController()
    {
        
    }

    public IActionResult Index(string id)
    {

        return View();
    }

    public IActionResult Create()
    {
        return View();
    }

    public IActionResult Update(string id)
    {
        return View();
    }

    public IActionResult Delete(string id)
    {
        return View();
    }
}