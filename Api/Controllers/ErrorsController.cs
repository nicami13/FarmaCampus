
using Api.Controllers;
using Api.Helpers;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;


namespace ApiJwt.Controllers;

[Microsoft.AspNetCore.Components.Route("errors/{code}")]
public class ErrorsController:BaseController
{
    public IActionResult Error(int code)
    {
        return new ObjectResult(new ApiResponse(code));
    }
}
