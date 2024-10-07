using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Zapper_Interview_Assignment.Interfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Zapper_Interview_Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingsController : ControllerBase
    {
        private readonly ISettingsService _settingsService;
        private readonly ILogger<SettingsController> _logger;

        public SettingsController(ISettingsService settingsService, ILogger<SettingsController> logger)
        {
            _settingsService = settingsService;
            _logger = logger;
        }

        [Route("check-user-settings/{settings}/{settingsKey}")]
        [HttpGet]
        public IActionResult CheckUserSettings(string settings,int settingsKey)
        {
            try
            {
                var result = _settingsService.CheckUserSettings(settings, settingsKey);
                return Ok(result);
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,exception.Message);
            }

        }
        [Route("save-settings")]
        [HttpPost]
        public IActionResult SaveSettings(string settingData,int key,string type)
        {
            try
            {
                var fileName = type == "user" ? @"./UserSettings.dat" : @"./Settings.dat";

                var result = _settingsService.SaveSettings(settingData, key,fileName);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [Route("get-settings")]
        [HttpPost]
        public IActionResult GetSettings(string type)
        {
            try
            {
                var fileName = type == "user" ? @"./UserSettings.dat" : @"./Settings.dat";

                var result = _settingsService.GetSettings(fileName);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
