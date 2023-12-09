using EventsPoster.BL.Admins.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsPoster.BL.Admins
{
    public interface IAdminsProvider
    {
        IEnumerable<AdminModel> GetAdmins(AdminModelFilter modelFilter = null);
        AdminModel GetAdminInfo(Guid id);

    }
}
