using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ShopsRU.Host.Controllers.v1
{
    [ApiVersion(1)]
    [ApiController]
    [Route("api/v{version:ApiVersion}")]
    public class IdentityController : ControllerBase
    {
    }
}
