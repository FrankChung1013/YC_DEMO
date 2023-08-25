using Microsoft.AspNetCore.Mvc;
using YCDemoMVC.Interfaces;
using YCDemoMVC.Models;

namespace YCDemoMVC.Controllers;

public class MemberController : Controller
{
    private readonly IMemberService _memberService;

    public MemberController(IMemberService memberService)
    {
        _memberService = memberService;
    }

    public IActionResult Index(MemberIndexViewModel memberIndexViewModel)
    {
        var result = _memberService.QueryMembers(memberIndexViewModel);
        
        return View(result);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View(new MemberModel());
    }

    [HttpGet]
    public IActionResult Update(string id)
    {
        var result = _memberService.QueryMemberById(id);

        return View(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody]MemberModel member)
    {

        return Json(true);
    }

    [HttpPatch]
    public async Task<IActionResult> Update([FromBody]MemberModel member)
    {
        return Json(true);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(string id)
    {
        return Json(true);
    }
}