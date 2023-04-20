using Aodren.Domain.Interfaces.Business;
using Aodren.Domain.Interfaces.Managers;
using Aodren.Domain.Models;
using Aodren.Domain.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aodren.Domain.Business
{
    public class UtilisateurBusiness : IUtilisateurBusiness
    {
        public IUtilisateurManager _utilisateurManager;

        public UtilisateurBusiness(IUtilisateurManager utilisateurManager)
        {
            _utilisateurManager = utilisateurManager;
        }

        public List<UtilisateurModel> GetAllUtilisateurs()
        {
            return _utilisateurManager.GetAllUtilisateurs();
        }

        public UtilisateurModel AddUtilisateur(AddUtilisateurRequest request)
        {
            var utilisateurToAdd = new UtilisateurModel
            {
                Username = request.Username,
                Password = request.Password,
                Mail = request.Mail,
                Role = request.Role,
            };
            return _utilisateurManager.AddUtilisateur(utilisateurToAdd, request.Password);
        }

    }
}
