using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using YCDemoMVC.Interfaces;
using YCDemoMVC.Models;

namespace YCDemoMVC.Controllers;

public class MemberController : Controller
{
    private readonly IMemberService _memberService;
    private readonly ILogger<MemberController> _logger;

    public MemberController(IMemberService memberService, ILogger<MemberController> logger)
    {
        _memberService = memberService;
        _logger = logger;
    }

    public IActionResult Index(MemberIndexViewModel memberIndexViewModel)
    {
        var result = _memberService.QueryMembers(memberIndexViewModel);
        
        return View(result);
    }

    [HttpGet]
    public IActionResult Create()
    {
        ViewBag.SexSelectList = SexSelectList();
        return View(new MemberModel());
    }

    [HttpGet]
    public IActionResult Edit(string id)
    {
        var member = _memberService.QueryMemberById(id);
        ViewBag.SexSelectList = SexSelectList(member.Sex);

        return View(member);
    }
    
    private static List<SelectListItem> SexSelectList(string sex = "")
    {
        return new List<SelectListItem>
        {
            new SelectListItem
            {
                Text = "男",
                Value = "M",
                Selected = sex == "M" || string.IsNullOrWhiteSpace(sex),
            },
            new SelectListItem
            {
                Text = "女",
                Value = "F",
                Selected = sex == "F",
            },
        };
    }

    [HttpPost]
    public async Task<IActionResult> Insert([FromBody]MemberModel member)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var result = await _memberService.InsertAsync(member);
        
        return Json(result);
    }

    [HttpPatch]
    public async Task<IActionResult> Update([FromBody]MemberModel member)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var result = await _memberService.UpdateAsync(member);
        
        return Json(result);
    }

    [HttpDelete]
    public IActionResult Delete(string id)
    {
        var result = _memberService.Delete(id);

        return Json(true);
    }
}