using Microsoft.AspNetCore.Mvc;

namespace ProjectY.Web.Api.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        
    }
}
