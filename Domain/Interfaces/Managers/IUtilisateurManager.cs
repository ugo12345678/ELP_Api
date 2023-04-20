using Aodren.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aodren.Domain.Interfaces.Managers
{
    public interface IUtilisateurManager
    {
        List<UtilisateurModel> GetAllUtilisateurs();

        UtilisateurModel AddUtilisateur(UtilisateurModel request, string clearPassword);

        UtilisateurModel AuthenticateUtilisateur(string mail, string password);
    }

}
