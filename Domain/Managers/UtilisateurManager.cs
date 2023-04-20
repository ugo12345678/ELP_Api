using Aodren.Domain.Interfaces.Managers;
using Aodren.Domain.Models;
using BDDELP.Database;
using BDDELP.Database.EntityModels;
using static Aodren.Domain.Tools.TokenTool;

namespace Aodren.Domain.Managers
{
    public class UtilisateurManager : IUtilisateurManager
    {
        private readonly DatabaseContext _databaseContext;

        public UtilisateurManager(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public List<UtilisateurModel> GetAllUtilisateurs()
        {
            return _databaseContext.Utilisateur.Select(t => new UtilisateurModel
            {
                Id = t.Id,
                Username = t.Username,
                Password = t.Password,
                Mail = t.Mail,
                Role = t.Role,
            }).ToList();
        }

        public UtilisateurModel AddUtilisateur(UtilisateurModel utilisateurModel, string clearPassword)
        {
            var utilisateurToAdd = new Utilisateur
            {
                Username = utilisateurModel.Username,
                Password = PasswordTool.HashPassword(clearPassword),
                Mail = utilisateurModel.Mail,
                Role = utilisateurModel.Role,
            };

            _databaseContext.Add(utilisateurToAdd);
            _databaseContext.SaveChanges();
            utilisateurToAdd.Id = utilisateurToAdd.Id;

            return utilisateurModel;
        }

        public UtilisateurModel AuthenticateUtilisateur(string mail, string password)
        {
            UtilisateurModel result = null;
            var utilisateur = _databaseContext.Utilisateur.Where(t => t.Mail == mail).FirstOrDefault();

            if (utilisateur != null && utilisateur.Password == PasswordTool.HashPassword(password))
            {
                result = new UtilisateurModel
                {
                    Id = utilisateur.Id,
                    Username = utilisateur.Username,
                    Mail = utilisateur.Mail,
                    Role = utilisateur.Role,
                };
            }
            return result;

        }
    }
}
