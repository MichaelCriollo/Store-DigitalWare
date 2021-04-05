using Store.DataAccess.Class;
using Store.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BusinessLogic.Class
{
    public class GenderBL : IDisposable
    {
        private UnitOfWork UnitOfWork = new UnitOfWork();

        private Repository<Gender> GenderRepository;

        public GenderBL()
        {
            GenderRepository = UnitOfWork.Repository<Gender>();
        }

        /// <summary>
        /// Find All Gender
        /// </summary>
        /// <returns>List Genders</returns>
        public IEnumerable<Gender> FindAll()
        {
            try
            {
                return GenderRepository.FindAll();
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
