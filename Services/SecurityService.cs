using CST350.Models;

namespace CST350.Services
{
    public class SecurityService
    {
        SecurityDAO securityDAO;

        public SecurityService()
        {
            this.securityDAO = new SecurityDAO();
        }

        public bool Login(LoginViewModel model)
        {
            return securityDAO.Read(model);
        }

        public bool Register(RegistrationViewModel model)
        {
            return securityDAO.Create(model);
        }
    }
}
