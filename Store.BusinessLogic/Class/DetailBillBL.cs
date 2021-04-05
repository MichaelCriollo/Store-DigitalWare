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
    public class DetailBillBL : IDisposable
    {
        private UnitOfWork UnitOfWork = new UnitOfWork();

        private Repository<DetailBill> DetailBillRepository;

        public DetailBillBL()
        {
            DetailBillRepository = UnitOfWork.Repository<DetailBill>();
        }

        /// <summary>
        /// Create DetailBillBL
        /// </summary>
        /// <param name="DetailBill"></param>
        /// <returns>Product Create</returns>
        public DetailBill Create(DetailBill detailBill)
        {
            DetailBill detailBillCreate = new DetailBill();
            try
            {

                using (DbContextTransaction transaction = UnitOfWork.GetContext().Database.BeginTransaction())
                {
                    try
                    {
                        detailBillCreate = detailBill;
                        DetailBillRepository.Create(detailBillCreate);
                        UnitOfWork.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
                return detailBillCreate;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Search DetailBills with filters
        /// </summary>
        /// <param name="DetailBill"></param>
        /// <returns></returns>
        public IEnumerable<DetailBill> Find(DetailBill DetailBill)
        {
            try
            {
                IEnumerable<DetailBill> DetailBills = null;
                switch (DetailBill.SearchAction)
                {
                    // Search Product active
                    case 1:
                        DetailBills = DetailBillRepository.Find(p => p.IdProduct == DetailBill.IdProduct).ToList();
                        break;
                }
                return DetailBills;
            }
            catch (Exception)
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
