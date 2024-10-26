using InnovaSystemBussines.Auth.models;

namespace InnovaSystemBussines.Auth.repositories{
    public interface IAuthenticationRepository{
        public LoginResponse Login(LoginRequest login);

        public void Register(RegisterRequest data);
        
    }
}