using Aodren.Domain.Models;
using Aodren.Domain.Models.Requests;

namespace Aodren.Domain.Interfaces.Business
{
    public interface IUtilisateurBusiness
    {
        List<UtilisateurModel> GetAllUtilisateurs();
        UtilisateurModel AddUtilisateur(AddUtilisateurRequest request);
    }
}
