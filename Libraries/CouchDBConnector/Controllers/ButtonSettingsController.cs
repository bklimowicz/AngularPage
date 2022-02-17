using CouchDBConnector.Interfaces;
using CouchDBConnector.Model;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CouchDBConnector.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ButtonSettingsController : ControllerBase
    {
        private readonly IButtonOptionsRepository _buttonOptionsRepository;
        public ButtonSettingsController(IButtonOptionsRepository buttonOptionsRepository)
        {
            _buttonOptionsRepository = buttonOptionsRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetButtonOptions()
        {
            var callResult = await _buttonOptionsRepository.GetButtonOptionsAsync();

            if (callResult.IsSuccess)
            {
                Documents result = JsonSerializer.Deserialize<Documents>(callResult.SuccessContentObject);
                var anotherResult = new List<ButtonOption>();

                for (int i = 0; i < result.TotalRows; i++)
                {
                    callResult = await _buttonOptionsRepository.GetButtonOptionByIdAsync(result.Rows[i].Id);
                    ButtonOption tempResult = JsonSerializer.Deserialize<ButtonOption>(callResult.SuccessContentObject);
                    if (tempResult.Type != "ButtonOption") continue;
                    anotherResult.Add(tempResult);
                }

                return Ok(anotherResult);
            }

            return NotFound("Not found");
        }
    }
}
