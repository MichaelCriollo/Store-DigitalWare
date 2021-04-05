using Store.Entity.Entities;
using Store.WebSite.Models;
using Store.WebSite.ServiceConsumer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

using static Store.WebSite.Models.SweetAlertModel;

namespace Store.WebSite.Controllers
{
    public class ProductController : BaseController
    {
        private ProductSC productSC;
        private BillSC billSC;
        private DetailBillSC detailBillSC;
        private TypeProductSC typeProductSC;
        private GenderSC genderSC;
        private ColorSC colorSC;

        /// <summary>
        /// Constructor
        /// </summary>
        public ProductController()
        {
            productSC = new ProductSC();
            billSC = new BillSC();
            detailBillSC = new DetailBillSC();
            typeProductSC = new TypeProductSC();
            genderSC = new GenderSC();
            colorSC = new ColorSC();
        }

        /// <summary>
        /// Create Get
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create()
        {
            Product product = new Product();
            BindDefaultList(ref product, false);
            return Create(product);
        }

        /// <summary>
        /// Create Post
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(Product product)
        {
            try
            {
                var countProducts = productSC.FindAll().Count() + 1;
                // 1 Pantalon
                product.IdTypeProduct = 1;
                // Estado Activo
                product.IdState = 1;
                // Color Negro
                product.IdColor = 2;
                // Masculino
                product.IdGender = 1;
                product.Reference = "AAA" + countProducts;
                product.Name = "Producto " + countProducts;
                product.PriceUnit = 50000;
                product.Quantity = 10;
                product.DateCreate = DateTime.Now;
                Product productCreate = productSC.Create(product);
                if (productCreate != null && productCreate.IdProduct > 0)
                {
                    TempData[SweetAlertModel.SweetAlert.TempDataKey] = SweetAlertModel.GetSweetAlert("Información",
                                                                        "El Producto se ha creado correctamente",
                                                                        SweetAlertStyle.success);
                }
            }
            catch (Exception ex)
            {
                TempData[SweetAlertModel.SweetAlert.TempDataKey] = new SweetAlertModel.SweetAlert
                {
                    title = "Error",
                    message = "Se presento un error al crear el producto",
                    type = SweetAlertStyle.info
                };
                return RedirectToAction("List");
            }
            return RedirectToAction("List");
        }

        /// <summary>
        /// Get Product Update 
        /// </summary>
        /// <param name="IdWorkShopBanner"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Update(int IdProduct)
        {
            Product product = null;
            Product productUpdate = new Product();
            try
            {
                product = productSC.FindById(Convert.ToInt32(IdProduct));
                if (product == null)
                {
                    TempData[SweetAlertModel.SweetAlert.TempDataKey] = new SweetAlertModel.SweetAlert
                    {
                        title = "Información",
                        message = "No se encontro este producto.",
                        type = SweetAlertStyle.info
                    };

                    return RedirectToAction("List");
                }
                productUpdate = product;
                productUpdate.IdProduct = product.IdProduct;
                productUpdate.Name = "ProductEdit " + product.IdProduct;
                productUpdate.PriceUnit = product.PriceUnit;
                productUpdate.Quantity = product.Quantity;
                productUpdate.IdState = productUpdate.IdState == 1 ? 2 : 1;
                productUpdate.Quantity = 5;
                productUpdate.DateEdit = DateTime.Now;
                return Update(product);
            }
            catch (Exception ex)
            {
                TempData[SweetAlertModel.SweetAlert.TempDataKey] = SweetAlertModel.GetSweetAlert("Error",
                                                                   "Se presentó un error al consultar este producto.",
                                                                   SweetAlertStyle.error);

                SaveError(ex, "Get:EditProduct", ErrorLogLevel.ERROR);
                return RedirectToAction("List");
            }
        }

        /// <summary>
        /// Post Product Edit 
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Update(Product product)
        {
            try
            {
                var ProductIsUpdate = productSC.Update(product);
                if (ProductIsUpdate)
                {
                    TempData[SweetAlertModel.SweetAlert.TempDataKey] = SweetAlertModel.GetSweetAlert("Información",
                                                        "El producto se actualizo correctamente.",
                                                        SweetAlertStyle.success);
                }
                return RedirectToAction("List");
            }
            catch (Exception ex)
            {
                TempData[SweetAlertModel.SweetAlert.TempDataKey] = SweetAlertModel.GetSweetAlert("Error",
                                                        "Se presento un error al actualizar el producto.",
                                                        SweetAlertStyle.error);
                return RedirectToAction("List");
            }
        }

        /// <summary>
        /// Delete Product
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(int IdProduct)
        {
            SweetAlertModel.SweetAlert sweetAlert = new SweetAlert();
            try
            {
                Product product = productSC.FindById(IdProduct);
                if (product == null)
                {
                    sweetAlert = SweetAlertModel.GetSweetAlert("Error", "El producto que intenta eliminar no es valido.", SweetAlertStyle.error);
                    return Json(sweetAlert, JsonRequestBehavior.AllowGet);
                }

                // Validate if exist the product in a bill
                DetailBill DetailBill = new DetailBill();
                DetailBill.IdProduct = IdProduct;
                DetailBill.SearchAction = 1;
                var ListBills = detailBillSC.Find(DetailBill).ToList();
                if (ListBills.Count > 0)
                {
                    sweetAlert = SweetAlertModel.GetSweetAlert("Info", "El producto no puede ser eliminado ya que esta asociado a una factura", SweetAlertStyle.info);
                    return Json(sweetAlert, JsonRequestBehavior.AllowGet);
                }
                // Delete Product
                var ProductIsDelete = productSC.Delete(product);
                if (ProductIsDelete)
                {
                    sweetAlert = SweetAlertModel.GetSweetAlert("Información", "El producto se ha eliminado correctamente.", SweetAlertStyle.success);
                }
                

                return Json(sweetAlert, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                sweetAlert = SweetAlertModel.GetSweetAlert("Error", "Se ha presentado un error al eliminar el producto.",
                                                            SweetAlertStyle.error);

                SaveError(ex, "Post:DeleteProduct", ErrorLogLevel.ERROR);
                return Json(sweetAlert, JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>
        /// Search Product
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Search()
        {
            Product product = new Product();
            BindDefaultList(ref product, false);
            return View(product);
        }

        /// <summary>
        /// Search Product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public ActionResult Search(Product product)
        {
            List<Product> ListProducts = new List<Product>();
            return View();
        }

        /// <summary>
        /// Get All Products
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult List()
        {
            IEnumerable<Product> products = null;
            try
            {
                products = productSC.FindAll();
                if (products == null)
                {
                    TempData[SweetAlertModel.SweetAlert.TempDataKey] = SweetAlertModel.GetSweetAlert("Información",
                                                                   "No se encontraron productos registrados",
                                                                   SweetAlertStyle.info);
                }
                else
                {
                    TempData["Product"] = products;
                    return View(products.ToList());
                }
                return View();
            }
            catch (Exception ex)
            {
                TempData[SweetAlertModel.SweetAlert.TempDataKey] = SweetAlertModel.GetSweetAlert("Error",
                                                                   "Se presentó un error al consultar el listado de los productos.",
                                                                   SweetAlertStyle.error);

                SaveError(ex, "Get:ListProducts", ErrorLogLevel.ERROR);
                return RedirectToAction("Index", "Home");
            }
        }

        /// <summary>
        /// Fill all the lists
        /// </summary>
        /// <param name="product"></param>
        /// <param name="bSelectItem"></param>
        private void BindDefaultList(ref Product product, bool bSelectItem)
        {
            int _idType = product.IdTypeProduct;
            int _idGender = product.IdGender;
            int _idColor = product.IdColor;


            product.ListTypes = typeProductSC.FindAll().ToList().Select(c => new SelectListItem()
            {
                Value = c.IdTypeProduct.ToString(),
                Text = c.Name,
                Selected = _idType == c.IdTypeProduct && bSelectItem ? true : false
            });

            product.ListGender = genderSC.FindAll().ToList().Select(c => new SelectListItem()
            {
                Value = c.IdGender.ToString(),
                Text = c.Name,
                Selected = _idGender == c.IdGender && bSelectItem ? true : false
            });

            product.ListColors = colorSC.FindAll().ToList().Select(c => new SelectListItem()
            {
                Value = c.IdColor.ToString(),
                Text = c.Name,
                Selected = _idColor == c.IdColor && bSelectItem ? true : false
            });
        }
    }
}