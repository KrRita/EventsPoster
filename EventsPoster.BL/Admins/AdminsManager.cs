using AutoMapper;
using EventsPoster.DataAccess.Entities;
using EventsPoster.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventsPoster.BL.Admins.Entities;

namespace EventsPoster.BL.Admins
{
    public class AdminsManager : IAdminsManager
    {
        private readonly IRepository<AdminEntity> _adminsRepository;
        private readonly IMapper _mapper;
        public AdminsManager(IRepository<AdminEntity> adminsRepository, IMapper mapper)
        {
            _adminsRepository = adminsRepository;
            _mapper = mapper;
        }

        public AdminModel CreateAdmin(CreateAdminModel model)
        {
            var entity = _mapper.Map<AdminEntity>(model);

            _adminsRepository.Save(entity); //id, modification, externalId

            return _mapper.Map<AdminModel>(entity);
        }
        public void DeleteAdmin(Guid id)
        {
            var entity = _adminsRepository.GetById(id);
            if (entity == null)
                throw new ArgumentException("Admin not found");
            _adminsRepository.Delete(entity);
        }
        public AdminModel UpdateAdmin(Guid id, UpdateAdminModel model)
        {
            //validate data
            var entity = _adminsRepository.GetById(id);
            if (entity == null)
                throw new ArgumentException("Admin not found");
            entity.PasswordHash = model.PasswordHash;
            entity.Login=model.Login;
            _adminsRepository.Save(entity);
            return _mapper.Map<AdminModel>(entity);
        }

    }
}
