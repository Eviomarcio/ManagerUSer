using System.Collections.Generic;
using Manager.Domain.Validator;
using Manager.Core.Exceptions;

namespace Manager.Domain.Entities
{
    public class User : Base
    {
        //Propriedades
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }

        //EF
        protected User(){}
        public User(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
            _errors = new List<string>();
        }
        
        //Comportamentos
        public void ChangeName(string name)
        {
            Name = name;
            Validate();
        }
        public void ChangeEmail(string email)
        {
            Email = email;
            Validate();
        }
        public void ChangePassword(string password)
        {
            Password = password;
            Validate();
        }

        //AutoValida
        public override bool Validate()
        {
            var validator = new UserValidator();
            var validation = validator.Validate(this);

            if (!validation.IsValid)
            {
                foreach (var error in validation.Errors)
                {
                    _errors.Add(error.ErrorMessage);
                }

                throw new DomainException("Alguns compos estão invalidos, por favor corrija-os!" , _errors);
            }

            return true;
        }
    }
}