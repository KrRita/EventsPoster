using EventsPoster.BL.Admins.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsPoster.BL.Admins
{
    public interface IAdminsManager
    {
        AdminModel CreateAdmin(CreateAdminModel model);
        void DeleteAdmin(Guid id);
        AdminModel UpdateAdmin(Guid id, UpdateAdminModel model);

    }
}
