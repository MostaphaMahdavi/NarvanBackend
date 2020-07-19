using System;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Narvan.WebApi.Controllers
{
    //[Route("api/[controller]")]
    [Route("[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {


        public JsonResult Success()
        {
            return new JsonResult(new {status="success",code=210});
        }

        public JsonResult Success(Object data)
        {
            return new JsonResult(new { status = "success", code = 210,data=data });
        }

        public JsonResult Error()
        {
            return new JsonResult(new { status ="error",code=410 });
        }

        public JsonResult Error(Object data)
        {
            return new JsonResult(new { status = "error", code = 410,data=data });
        }


        public JsonResult NotFound()
        {
            return new JsonResult(new { status="notFound",code=404});
        }

        public JsonResult NotFound(Object data)
        {
            return new JsonResult(new { status = "notFound",code=404,data=data });
        }
    }
}
