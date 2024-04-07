using System;

namespace LegacyApp
{
    public class UserService
    {
        private Client getClient(int clientId)
        {
            var clientRepository = new ClientRepository();
            return clientRepository.GetById(clientId);
        }

        private void SetUserCreditLimit(User user)
        {
            var userCreditService = new UserCreditService();
            int creditLimit = 0;

            switch (user.Client.Type)
            {
                case "VeryImportantClient":
                    user.HasCreditLimit = false;
                    return;

                case "ImportantClient":
                    creditLimit = userCreditService.GetCreditLimit(user.LastName) * 2;
                    user.HasCreditLimit = true;
                    break;

                default:
                    creditLimit = userCreditService.GetCreditLimit(user.LastName);
                    user.HasCreditLimit = true;
                    break;
            }

            user.CreditLimit = creditLimit;
        }

        public bool AddUser(string firstName, string lastName, string email, DateTime dateOfBirth, int clientId)
        {
            var clientRepository = new ClientRepository();
            var client = clientRepository.GetById(clientId);

            var user = new User{
                Client = client,
                DateOfBirth = dateOfBirth,
                EmailAddress = email,
                FirstName = firstName,
                LastName = lastName
            };

            SetUserCreditLimit(user);

            if (user.HasCreditLimit && user.CreditLimit < 500)
            {
                return false;
            }

            UserDataAccess.AddUser(user);
            return true;
        }
    }
}
