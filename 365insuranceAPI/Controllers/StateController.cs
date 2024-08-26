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

        [HttpPost("AddState")]
        public int AddState([FromBody] StateMa state)
        {
            try
            {
                StateMa sm = new StateMa();
                if(state.StateId>0)
                {
                   var stateupdate = _stateService.UpdateStateAsync(state);
                    return stateupdate.Id;
                }
                else
                {
                    var stateadd = _stateService.AddStateAsync(state);
                    return stateadd.Id;
                }
               
                
            }
            catch(Exception ex)
            {
                return 0;
            }
           
        }
        [HttpGet("GetStateById/{id}")]
        public async Task<StateMa> GetStateById(int id)
        {
            try
            {
                var state = _stateService.GetStateByIdAsync(id);
                return await state;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        [HttpDelete("DeleteState/{id}")]
        public async Task<bool> DeleteState(int id)
        {
            bool result = false;
            try
            {
              result = await _stateService.DeleteStateAsync(id);
            }
            catch(Exception ex)
            {
                return result;
            }
            return result;
        }
        [HttpDelete("EnableState/{id}")]
        public async Task<bool> EnableState(int id)
        {
            bool result = false;
            try
            {
                result = await _stateService.EnableStateAsync(id);
            }
            catch (Exception ex)
            {
                return result;
            }
            return result;
        }

    }
}
