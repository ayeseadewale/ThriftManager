using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ThriftManager.DTO.Requests;
using ThriftManager.Infrastructure;
using ThriftManager.Service.ContributionServices;

namespace ThriftManager.Web.Controllers
{
    public class ContributionController : Controller
    {
        private readonly IContributionService _contributionService;
        private readonly IThriftAppDbContext _context;

        public ContributionController(IContributionService contributionService, IThriftAppDbContext context)
        {
            _contributionService = contributionService;
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateContribution(CreateContributionRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var group = await _context.Groups.FindAsync(request.GroupId);
            if (group == null)
            {
                ModelState.AddModelError("", "Group not found");
                return View(request);
            }

            var contribution = await _contributionService.CreateContribution(request.Title, group);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult InitWallet(long contributionId)
        {
            ViewBag.ContributionId = contributionId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> InitWallet(long contributionId, InitWalletRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }

            try
            {
                await _contributionService.InitWallet(contributionId, request.Title, request.WalletNumber, request.Account);
                return RedirectToAction(nameof(GetContributionById), new { id = contributionId });
            }
            catch (InvalidOperationException e)
            {
                ModelState.AddModelError("", e.Message);
                return View(request);
            }
        }

        [HttpGet]
        public IActionResult AddContributingMember(long contributionId)
        {
            ViewBag.ContributionId = contributionId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddContributingMember(long contributionId, AddMemberRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }

            try
            {
                var member = await _contributionService.AddContributingMember(contributionId, request.MemberId);
                return RedirectToAction(nameof(GetContributionById), new { id = contributionId });
            }
            catch (InvalidOperationException e)
            {
                ModelState.AddModelError("", e.Message);
                return View(request);
            }
        }

        [HttpGet]
        public IActionResult MakeContribution(long contributionId)
        {
            ViewBag.ContributionId = contributionId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> MakeContribution(long contributionId, MakeContributionRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }

            try
            {
                await _contributionService.MakeContribution(contributionId, request.MemberId, request.Amount);
                return RedirectToAction(nameof(GetContributionById), new { id = contributionId });
            }
            catch (InvalidOperationException e)
            {
                ModelState.AddModelError("", e.Message);
                return View(request);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetContributionById(long id)
        {
            var contribution = await _context.Contributions.FindAsync(id);
            if (contribution == null)
            {
                return NotFound();
            }

            return View(contribution);
        }
    }
}
