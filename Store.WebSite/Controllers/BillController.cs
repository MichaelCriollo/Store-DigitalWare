using Store.Entity.Entities;
using Store.WebSite.Models;
using Store.WebSite.ServiceConsumer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static Store.WebSite.Models.SweetAlertModel;

namespace Store.WebSite.Controllers
{
    public class BillController : BaseController
    {
        private BillSC billSC;
        private ProductSC productSC;

        /// <summary>
        /// Constructor
        /// </summary>
        public BillController()
        {
            billSC = new BillSC();
            productSC = new ProductSC();
        }

        /// <summary>
        /// Create Get
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create()
        {
            Bill bill = new Bill();
            return Create(bill);
        }

        /// <summary>
        /// Create Post
        /// </summary>
        /// <param name="bill"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(Bill bill)
        {
            List<Product> ListProducts = new List<Product>();
            Product product = new Product();
            try
            {
                // Search Product active
                product.SearchAction = 1;
                ListProducts = productSC.Find(product).ToList();
                if (ListProducts.Count == 0)
                {
                    TempData[SweetAlertModel.SweetAlert.TempDataKey] = SweetAlertModel.GetSweetAlert("Información",
                                                                        "No hay productos activos o no existen productos, para la creacion de esta factura",
                                                                        SweetAlertStyle.success);
                    return RedirectToAction("List");
                }

                // Search Product in Stock
                product.SearchAction = 2;
                ListProducts = productSC.Find(product).ToList();
                if (ListProducts.Count < 0)
                {
                    TempData[SweetAlertModel.SweetAlert.TempDataKey] = SweetAlertModel.GetSweetAlert("Información",
                                                                        "No hay productos activos o no existen productos",
                                                                        SweetAlertStyle.success);
                    return RedirectToAction("List");
                }

                // Create Bill
                bill.IdClient = 1;
                bill.DateCreate = DateTime.Now;

                Bill billCreate = billSC.Create(bill);
                if (billCreate != null && billCreate.IdBill > 0)
                {
                    TempData[SweetAlertModel.SweetAlert.TempDataKey] = SweetAlertModel.GetSweetAlert("Información",
                                                                        "La factura se ha creado correctamente",
                                                                        SweetAlertStyle.success);
                }
            }
            catch (Exception ex)
            {
                TempData[SweetAlertModel.SweetAlert.TempDataKey] = new SweetAlertModel.SweetAlert
                {
                    title = "Error",
                    message = "Se presento un error al crear la factura",
                    type = SweetAlertStyle.info
                };
                return RedirectToAction("List");
            }
            return RedirectToAction("List");
        }

        /// <summary>
        /// Bill of details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Details(int IdBill)
        {
            Bill bill = new Bill();
            bill = billSC.FindById(IdBill);
            if (bill == null)
            {
                TempData[SweetAlertModel.SweetAlert.TempDataKey] = SweetAlertModel.GetSweetAlert("Información",
                                                                   "No se encontraron facturas registradas con este id",
                                                                   SweetAlertStyle.info);
            }
            else
            {
                return View(bill);
            }
            return View();
        }

        /// <summary>
        /// Delete Bill
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(int IdBill)
        {
            SweetAlertModel.SweetAlert sweetAlert = new SweetAlert();
            try
            {
                Bill bill = billSC.FindById(IdBill);
                if (bill == null)
                {
                    sweetAlert = SweetAlertModel.GetSweetAlert("Error", "La factura que intenta eliminar no es valida.", SweetAlertStyle.error);
                    return Json(sweetAlert, JsonRequestBehavior.AllowGet);
                }

                if (bill.IdBill > 1)
                {
                    sweetAlert = SweetAlertModel.GetSweetAlert("Info", "Esta factura no se puede eliminar debido a que contiene detalles de factura asociados.", SweetAlertStyle.info);
                    return Json(sweetAlert, JsonRequestBehavior.AllowGet);
                }

                var BillIsDelete = billSC.Delete(bill);
                if (BillIsDelete)
                {
                    sweetAlert = SweetAlertModel.GetSweetAlert("Información", "La factura se ha eliminado correctamente.", SweetAlertStyle.success);
                }


                return Json(sweetAlert, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                sweetAlert = SweetAlertModel.GetSweetAlert("Error", "Se ha presentado un error al eliminar la factura.",
                                                            SweetAlertStyle.error);

                SaveError(ex, "Post:DeleteBill", ErrorLogLevel.ERROR);
                return Json(sweetAlert, JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>
        /// Get List All Bills
        /// </summary>
        /// <returns></returns>
        public ActionResult List()
        {
            IEnumerable<Bill> bills = null;
            try
            {
                bills = billSC.FindAll();
                if (bills == null)
                {
                    TempData[SweetAlertModel.SweetAlert.TempDataKey] = SweetAlertModel.GetSweetAlert("Información",
                                                                   "No se encontraron facturas registradas",
                                                                   SweetAlertStyle.info);
                }
                else
                {
                    return View(bills.ToList());
                }
                return View();
            }
            catch (Exception ex)
            {
                TempData[SweetAlertModel.SweetAlert.TempDataKey] = SweetAlertModel.GetSweetAlert("Error",
                                                                   "Se presentó un error al consultar el listado de las facturas.",
                                                                   SweetAlertStyle.error);

                SaveError(ex, "Get:ListBills", ErrorLogLevel.ERROR);
                return RedirectToAction("Index", "Home");
            }
        }
    }
}