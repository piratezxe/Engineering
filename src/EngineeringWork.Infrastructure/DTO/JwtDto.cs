using EngineeringWork.Core.Domain;

namespace EngineeringWork.Infrastructure.DTO
{
    public class JwtDto
    {
        public string Token { get; set; }
        public long Expires { get; set; }
        
        public RefreshToken RefreshToken { get; set; }
    }
}