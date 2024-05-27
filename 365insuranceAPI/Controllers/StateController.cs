using _365Insurance.Core.Domain.Models;
using _365Insurance.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _365insuranceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly IStateService _stateService;
        public StateController(IStateService stateService) 
        {
            _stateService = stateService;
        }

        [HttpGet("GetState")]
        public async Task<List<StateMa>> GetState() 
        { 
            return await _stateService.GetState();
        
        }
    }
}
