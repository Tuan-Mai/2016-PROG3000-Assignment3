using PROG3000_asn3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PROG3000_asn3.Controllers
{
    public class InvoiceController : Controller
    {
        // GET: Invoice
        public ViewResult AddInvoice()
        {
            if (Session["user"] != null)
            {
                Invoice invoice = new Invoice();
                return View(invoice);
            }
            return View();
        }

        [HttpPost]
        public ViewResult AddedInvoice(Invoice invoice)
        {
            SaveInvoice(invoice);
            return View("../UserAccounts/Index", invoice);
        }

        private void SaveInvoice(Invoice invoice)
        {
            List<Invoice> invoiceList = HttpContext.Cache["INVOICE_LIST"] as List<Invoice>;

            if (invoiceList == null)
            {
                invoiceList = new List<Invoice>();
                HttpContext.Cache["INVOICE_LIST"] = invoiceList;
            }

            invoiceList.Add(invoice);

            Dictionary<int, Invoice> invoiceNumber = new Dictionary<int, Invoice>();
      

            for (int i = 0; i <= invoiceList.Count; i++)
            {
                invoiceNumber.Add(i, invoice);
            }
        }

        public ActionResult ManageInvoice()
        {
            return View();
        }
    }
}