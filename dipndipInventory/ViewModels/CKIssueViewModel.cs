﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dipndipInventory.ViewModels
{
    public class CKIssueViewModel
    {
        public int id { get; set; }
        public string prodCode { get; set; }
        public int itemId { get; set; }
        public string itemCode { get; set; }
        public string itemDescription { get; set; }
        public string batchNo { get; set; }
        public decimal designQty { get; set; }
        public decimal prodQty { get; set; }
        public DateTime prodDate { get; set; }
        public DateTime expDate { get; set; }
        public decimal qtyonHand { get; set; }
        public string ckUnit { get; set; }
        public decimal qtyIssued { get; set; }
        public decimal unit_cost { get; set; }
        public decimal total_cost { get; set; }
        public decimal prodItemCost { get; set; }
        public int rowIndex { get; set; }
        public List<ckUnitVM> ckunitVM { get; set; }
        public int ck_wastage_reason_id { get; set; }
        public string ck_wastage_reason_desc { get; set; }

    }
    public class ckUnitVM
    {
        public int ckunitId { get; set; }
        public string ckunitDesc { get; set; }
    }
}
