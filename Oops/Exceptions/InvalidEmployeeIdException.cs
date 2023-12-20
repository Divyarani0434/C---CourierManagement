using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oops.Exceptions
{
    internal class InvalidEmployeeIdException:Exception
    {
        public InvalidEmployeeIdException(int employeeId)
        : base($"Invalid employee ID '{employeeId}'. Employee does not exist in the system.")
        {
        }
    }
}
