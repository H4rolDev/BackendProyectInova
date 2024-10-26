using InnovaSystemBussines.Auth.models;
using InnovaSystemBussines.Auth.repositories;
using InnovaSystemBussines.Auth.services;

namespace InnovaSystemData.Auth.repositories{
    public class AuthenticationRepositoryImpl: IAuthenticationRepository
    {
        
        private readonly IAuthenticationService _authService;
        public AuthenticationRepositoryImpl(IAuthenticationService authService){
            _authService = authService;
        }
        public LoginResponse Login (LoginRequest login)
        {
            return _authService.Login(login);
        }
 
        public void Register(RegisterRequest data)
        {
            _authService.Register(data);
        }
    }
}