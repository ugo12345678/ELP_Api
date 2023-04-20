using Aodren.Domain.Interfaces.Business;
using Aodren.Domain.Models.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class UtilisateurController : ControllerBase
{
    private static IUtilisateurBusiness _utilisateurBusiness;

    public UtilisateurController(IUtilisateurBusiness utilisateurBusiness)
    {
        _utilisateurBusiness = utilisateurBusiness;
    }

    [HttpGet]
    public ActionResult Get()
    {
        return Ok(_utilisateurBusiness.GetAllUtilisateurs());
    }

    [HttpPost]
    public ActionResult Post(AddUtilisateurRequest request)
    {
        if (ModelState.IsValid)
        {

            return Ok(_utilisateurBusiness.AddUtilisateur(request));
        }
        else
        {
            return BadRequest(ModelState);
        }
    }
}