using Store.DataAccess.Class;
using Store.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BusinessLogic.Class
{
    public class BillBL : IDisposable
    {
        private UnitOfWork UnitOfWork = new UnitOfWork();

        private Repository<Bill> BillRepository;
        private Repository<DetailBill> DetailBillRepository;
        private Repository<Product> ProductRepository;

        private DetailBillBL DetailBillBL;
        private ProductBL ProductBL;
        public BillBL()
        {
            BillRepository = UnitOfWork.Repository<Bill>();
            DetailBillRepository = UnitOfWork.Repository<DetailBill>();
            ProductRepository = UnitOfWork.Repository<Product>();
            DetailBillBL = new DetailBillBL();
            ProductBL = new ProductBL();
        }

        /// <summary>
        /// Create BillBL
        /// </summary>
        /// <param name="bill"></param>
        /// <returns>Bill Create</returns>
        public Bill Create(Bill bill)
        {
            Bill BillCreate = new Bill();
           
            List<Product> ListProducts = new List<Product>();
            List<DetailBill> ListDetailBill = new List<DetailBill>();
            var PriceTotal = 0;
            try
            {
                using (DbContextTransaction transaction = UnitOfWork.GetContext().Database.BeginTransaction())
                {
                    try
                    {
                        BillCreate = bill;
                        ListProducts = ProductRepository.Find(p => p.IdState != 2 && p.Quantity >= 2).ToList();
                        // Create DetailBill
                       
                        foreach (var prod in ListProducts)
                        {
                            DetailBill detailBill = new DetailBill();
                            // Add detailBill
                            detailBill.IdProduct = prod.IdProduct;
                            detailBill.Quantity = 2;
                            detailBill.Price = prod.PriceUnit * detailBill.Quantity;
                            detailBill.DateCreate = DateTime.Now;
                            ListDetailBill.Add(detailBill);
                            // Update Quantity Product
                            prod.Quantity = prod.Quantity - detailBill.Quantity;
                            ProductBL.Update(prod);
                            PriceTotal = (int)(PriceTotal + detailBill.Price);
                        }
                        
                       
                        bill.TotalPrice = PriceTotal;
                        BillRepository.Create(BillCreate);
                        UnitOfWork.SaveChanges();
                        // Create DetailBill
                        foreach (var detail in ListDetailBill)
                        {
                            detail.IdBill = BillCreate.IdBill;
                            DetailBillRepository.Create(detail);
                            UnitOfWork.SaveChanges();
                        }

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
                return BillCreate;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Delete Bill
        /// </summary>
        /// <param name="bill"></param>
        /// <returns></returns>
        public bool Delete(Bill bill)
        {
            string responseMessage = string.Empty;
            try
            {
                using (DbContextTransaction transaction = UnitOfWork.GetContext().Database.BeginTransaction())
                {
                    try
                    {
                        BillRepository.Delete(bill);
                        UnitOfWork.SaveChanges();
                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Find by id a bill
        /// </summary>
        /// <param name="IdBill"></param>
        /// <returns></returns>
        public Bill FindById(int IdBill)
        {
            Bill bill = new Bill();
            bill = BillRepository.Find(p => p.IdBill == IdBill).FirstOrDefault();
            if (bill.IdBill > 0)
            {
                bill.DetailBills = DetailBillRepository.Find(d => d.IdBill == IdBill).ToList();
            }
            return bill;
        }

        /// <summary>
        /// Find All Bill
        /// </summary>
        /// <returns>List Bill</returns>
        public IEnumerable<Bill> FindAll()
        {
            string[] includeProp = new string[] { "Client" };
            try
            {
                return BillRepository.FindAll(includeProp);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void Dispose()
        {
            UnitOfWork.Dispose();
        }
    }
}
