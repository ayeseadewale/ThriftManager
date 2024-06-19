using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ThriftManager.DTO.Requests;
using ThriftManager.DTO.Common;
using ThriftManager.Services;

namespace ThriftManager.Controllers
{
    public class GroupController : Controller
    {
        private readonly IGroupService _groupServices;

        public GroupController(IGroupService groupServices)
        {
            _groupServices = groupServices;
        }

        [HttpGet]
        public  IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateGroup(CreateGroupRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await _groupServices.CreateGroupAsync(request);
            if (response.IsSuccessful)
                return Ok(response);
            else
                return BadRequest(response);
        }
    }
}
