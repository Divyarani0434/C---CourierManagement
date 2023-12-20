using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Oops.Entities
{
    internal class Courier
    {
  
      //  public long CourierID { get; private set; }
        public int ServiceID { get; set; }
        public int EmployeeID { get; set; }
        public int RecieverID { get; set; }
        public int LocationID { get; set; }
        public int SenderID { get; set; }
        public decimal Weight { get; set; }
        public string Status { get; set; }
        public string TrackingNumber { get; set; }
        public DateTime DeliveryDate { get; set; }
       // public int UserID { get; set; }

        public Courier(int ServiceID,  int EmployeeID,int RecieverID,int LocationID,int SenderID,decimal Weight,string Status, DateTime DeliveryDate)
        {
            this.ServiceID = ServiceID;
            this.EmployeeID = EmployeeID;
            this.RecieverID = RecieverID;
            this.LocationID = LocationID;
            this.SenderID = SenderID;
            this.Weight= Weight;
            this.Status = Status;
            this.DeliveryDate = DeliveryDate;

        }
    }
}

