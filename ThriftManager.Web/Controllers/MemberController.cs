using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ThriftManager.DTO.Requests;
using ThriftManager.Service.MemberServices;
using ThriftManager.Web.Models;

namespace ThriftManager.Web.Controllers
{
    public class MemberController : Controller
    {
        private readonly IMemberService _memberService;

        public MemberController(IMemberService memberService)
        {
            _memberService = memberService;
        }

        // GET: Member/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Member/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateMemberRequest request)
        {
            if (ModelState.IsValid)
            {
                var response = await _memberService.CreateMember(request);
                if (response.IsSuccessful)
                {
                    var memberFullName = $"{request.FirstName} {request.LastName}";
                    return RedirectToAction("Success", new { name = memberFullName });
                }

                // Handle error case
                ModelState.AddModelError(string.Empty, response.Error);
            }

            // If we got this far, something failed, redisplay form
            return View(request);
        }

        public async Task<IActionResult> Success(string name)
        {
            var contributionMenus = await _memberService.GetContributionMenus();
            var viewModel = new SuccessViewModel
            {
                MemberName = name,
                ContributionMenus = contributionMenus
            };

            return View(viewModel);
        }
        [HttpPost]
        public IActionResult SubmitContributions(string name, string[] selectedMenus)
        {
            var viewModel = new SummaryViewModel
            {
                MemberName = name,
                SelectedMenus = new List<string>(selectedMenus)
            };

            return RedirectToAction("Summary", viewModel);
        }

        public IActionResult Summary(SummaryViewModel viewModel)
        {
            return View(viewModel);
        }
    }
}
