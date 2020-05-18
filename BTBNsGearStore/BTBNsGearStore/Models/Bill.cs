using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTBNsGearStore.Models
{
    public class Bill
    {
        private int id;
        private int customerId;
        private DateTime dateOrdered;
        private int status; //da thanh toan:1, chua thanh toan:0

        public int Id { get => id; set => id = value; }
        public int CustomerId { get => customerId; set => customerId = value; }
        public DateTime DateOrdered { get => dateOrdered; set => dateOrdered = value; }
        public int Status { get => status; set => status = value; }
    }
}