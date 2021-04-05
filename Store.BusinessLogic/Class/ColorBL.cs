using Store.DataAccess.Class;
using Store.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BusinessLogic.Class
{
    public class ColorBL : IDisposable
    {
        private UnitOfWork UnitOfWork = new UnitOfWork();

        private Repository<Color> ColorRepository;

        public ColorBL()
        {
            ColorRepository = UnitOfWork.Repository<Color>();
        }

        /// <summary>
        /// Find All Color
        /// </summary>
        /// <returns>List Colors</returns>
        public IEnumerable<Color> FindAll()
        {
            try
            {
                return ColorRepository.FindAll();
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
