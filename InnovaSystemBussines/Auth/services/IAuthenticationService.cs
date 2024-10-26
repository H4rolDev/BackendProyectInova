using InnovaSystemBussines.Auth.models;

namespace InnovaSystemBussines.Auth.services{
    public interface IAuthenticationService{
        public LoginResponse Login(LoginRequest login);
        public void Register(RegisterRequest data);
    }
}