using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oops.Service
{
    internal interface ICourierAdminService
    {
        void AddCourierStaff();
        void RemoveCourierStaff();
        void DeliveryReport();
    }
}
