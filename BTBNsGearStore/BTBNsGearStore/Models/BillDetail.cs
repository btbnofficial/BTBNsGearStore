using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTBNsGearStore.Models
{
    public class BillDetail
    {
        private int id;
        private int billId;
        private int productId;
        private int count;

        public int Id { get => id; set => id = value; }
        public int BillId { get => billId; set => billId = value; }
        public int ProductId { get => productId; set => productId = value; }
        public int Count { get => count; set => count = value; }
    }
}