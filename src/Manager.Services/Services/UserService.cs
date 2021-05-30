using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Manager.Core.Exceptions;
using Manager.Domain.Entities;
using Manager.Infra.interfaces;
using Manager.Services.DTO;
using Manager.Services.Interfaces;

namespace Manager.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UserService(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<UserDTO> Create(UserDTO userDTO)
        {
            var userExists = await _userRepository.GetByEmail(userDTO.Email);

            if (userExists != null)
            {
                throw new DomainException("Já existe um usúario cadastrado com o email informado.");
            }

            var user = _mapper.Map<User>(userDTO);
            user.Validate();

            var userCreated = await _userRepository.Create(user);

            return _mapper.Map<UserDTO>(userCreated);
        }
        public async Task<UserDTO> Update(UserDTO userDTO)
        {
            var userExists = await _userRepository.Get(userDTO.Id);

            if (userExists == null)
            {
                throw new DomainException("Não existe nenhum usário com o id informado.");
            }

            var user = _mapper.Map<User>(userDTO);
            user.Validate();

            var userUpadated = await _userRepository.Create(user);

            return _mapper.Map<UserDTO>(userUpadated);
        }
        public async Task Remove(long id)
        {
            await _userRepository.Remove(id);
        }
        public async Task<UserDTO> Get(long id)
        {
            var user = await _userRepository.Get(id);

            return _mapper.Map<UserDTO>(user);
        }
        public async Task<UserDTO> Get()
        {
            var allUsers = await _userRepository.Get();

            return _mapper.Map<List<UserDTO>>(allUsers);
        }
        public async Task<List<UserDTO>> SearchByName(string name)
        {}
        public async Task<List<UserDTO>> SearchByEmail(string email)
        {}
        public async Task<UserDTO> GetByEmail(string email)
        {}
    }
}