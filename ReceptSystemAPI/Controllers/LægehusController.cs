using BLL;
using Microsoft.AspNetCore.Mvc;

namespace ReceptSystemAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LægehusController : ControllerBase
{
    private readonly LægehusBLL _lægehusBll;
    private readonly ReceptBLL _receptBll;
    private readonly OrdinationBLL _ordinationBll;

    public LægehusController(LægehusBLL lægehusBll, ReceptBLL receptBll, OrdinationBLL ordinationBll)
    {
        _lægehusBll = lægehusBll;
        _receptBll = receptBll;
        _ordinationBll = ordinationBll;
    }
    
    
}