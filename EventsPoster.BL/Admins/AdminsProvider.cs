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
    public class AdminsProvider : IAdminsProvider
    {
        private readonly IRepository<AdminEntity> _adminRepository;
        private readonly IMapper _mapper;

        public AdminsProvider(IRepository<AdminEntity> adminsRepository, IMapper mapper)
        {
            _adminRepository = adminsRepository;
            _mapper = mapper;
        }

        public IEnumerable<AdminModel> GetAdmins(AdminModelFilter modelFilter = null)
        {
            var login = modelFilter.Login;
        

            var admins = _adminRepository.GetAll(x => (
            (login == null || login == x.Login)));

            return _mapper.Map<IEnumerable<AdminModel>>(admins);
        }

        public AdminModel GetAdminInfo(Guid id)
        {
            var admin = _adminRepository.GetById(id);
            if (admin is null)
                throw new ArgumentException("Admin not found.");

            return _mapper.Map<AdminModel>(admin);
        }

    }
}
