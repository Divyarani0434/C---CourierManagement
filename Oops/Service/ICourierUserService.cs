using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oops.Service
{
    internal interface ICourierUserService
    {
        void TakeUserInputsAndPlaceOrder();
        void TakeUserInputsAndGetOrderStatus();
        void CancelOrder();
        void AssignCourier();
         void MarkOrderDelivered();

        void GetAssignedOrders();
    }
}
