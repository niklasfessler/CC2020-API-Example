using System;
namespace TestProj.DTO
{
    public class UserDTO
    {
        public string Username { get; }
        public string jwtToken { get; }

        public UserDTO(string Username)
        {
            this.Username = Username;
            jwtToken = generateJWT();
        }

        private String generateJWT()
        {
            return "abv";
        }
    }
}
