using Store.DataAccess.Class;
using Store.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BusinessLogic.Class
{
    public class TypeProductBL : IDisposable
    {
        private UnitOfWork UnitOfWork = new UnitOfWork();

        private Repository<TypeProduct> TypeRepository;

        public TypeProductBL()
        {
            TypeRepository = UnitOfWork.Repository<TypeProduct>();
        }

        /// <summary>
        /// Find All Type
        /// </summary>
        /// <returns>List Types</returns>
        public IEnumerable<TypeProduct> FindAll()
        {
            try
            {
                return TypeRepository.FindAll();
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
