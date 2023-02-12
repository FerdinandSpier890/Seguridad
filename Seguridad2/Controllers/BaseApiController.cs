using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Seguridad2.Controllers
{
    //Controlador para heredar a todos los controladores de la explicación
    [Route("api/[controller]")]
    [ApiController]
    public class BaseApiController : ControllerBase
    {

    }
}
