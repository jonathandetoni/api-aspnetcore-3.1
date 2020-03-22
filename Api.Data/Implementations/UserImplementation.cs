using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Entities.CadastrosGerais;
using Api.Domain.Interfaces.Service.Autenticacao;
using Api.Domain.Repository.CadastrosGerais;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Implementations
{
    public class UserImplementation : BaseRepository<UserEntity>, IUserRepository
    {
        private DbSet<UserEntity> _dataset;
        public UserImplementation(MyContext context) : base(context)
        {
            _dataset = context.Set<UserEntity>();
        }

        public async Task<UserEntity> FindByLogin(string email)
        {
            if (string.IsNullOrEmpty(email))
                return null;

            var user = await _dataset.FirstOrDefaultAsync(u => u.Email.Equals(email));

            // check if username exists
            if (user == null)
                return null;

            return user;
        }

        public async Task<bool> CheckExistingEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                return false;

            var result = await _dataset.AnyAsync(u => u.Email.Equals(email));

            if (result)
            {
                return true;
            }

            return false;
        }
    }
}
