using System;

namespace Api.Domain.Models.CadastroGerais
{
    public class UserModel
    {
        private Guid _id;
        public Guid Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _email;
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        private byte[] _senhaHash;
        public byte[] SenhaHash
        {
            get { return _senhaHash; }
            set { _senhaHash = value; }
        }

        private byte[] _senhaSalt;
        public byte[] SenhaSalt
        {
            get { return _senhaSalt; }
            set { _senhaSalt = value; }
        }

        private DateTime _createAt;
        public DateTime CreateAt
        {
            get { return _createAt; }
            set
            {
                _createAt = value == null ? DateTime.UtcNow : value;
            }
        }

        private DateTime _updateAt;
        public DateTime UpdateAt
        {
            get { return _updateAt; }
            set { _updateAt = value; }
        }


    }
}
