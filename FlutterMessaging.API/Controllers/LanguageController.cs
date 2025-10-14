using FlutterMessaging.API.Controllers.Base;
using FlutterMessaging.Logic;
using FlutterMessaging.State.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FlutterMessaging.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LanguageController(LanguageLogic languageLogic) : BaseController<Language>(languageLogic)
    {


    }
}
