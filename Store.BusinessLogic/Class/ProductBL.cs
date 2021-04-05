using Store.DataAccess.Class;
using System;
using System.Data.Entity;
using Store.Entity.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Store.BusinessLogic.Class
{
    public class ProductBL : IDisposable
    {

        private UnitOfWork UnitOfWork = new UnitOfWork();

        private Repository<Product> ProductRepository;

        public ProductBL()
        {
            ProductRepository = UnitOfWork.Repository<Product>();
        }

        /// <summary>
        /// Create ProductBL
        /// </summary>
        /// <param name="product"></param>
        /// <returns>Product Create</returns>
        public Product Create(Product product)
        {
            Product ProductCreate = new Product();
            try
            {

                using (DbContextTransaction transaction = UnitOfWork.GetContext().Database.BeginTransaction())
                {
                    try
                    {
                        ProductCreate = product;
                        ProductRepository.Create(ProductCreate);
                        UnitOfWork.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
                return ProductCreate;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Update ProductsBL
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public bool Update(Product product)
        {
            
            bool bUpdate = false;
            try
            {
                using (DbContextTransaction transaction = UnitOfWork.GetContext().Database.BeginTransaction())
                {
                    try
                    {
                        ProductRepository.Update(product);
                        UnitOfWork.SaveChanges();
                        transaction.Commit();
                        bUpdate = true;
                        return bUpdate;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
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
        /// Delete Product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public bool Delete(Product product)
        {
            string responseMessage = string.Empty;
            try
            {
                using (DbContextTransaction transaction = UnitOfWork.GetContext().Database.BeginTransaction())
                {
                    try
                    {
                        ProductRepository.Delete(product);
                        UnitOfWork.SaveChanges();
                        transaction.Commit();
                        return true;
                    }
                    catch (Exception)
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
        /// Search Products with filters
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public IEnumerable<Product> Find(Product product)
        {
            try
            {
                IEnumerable<Product> Products = null;
                switch (product.SearchAction)
                {
                    // Search Product active
                    case 1:
                        Products = ProductRepository.Find(p => p.IdState != 2).ToList();
                        break;

                    // Search Product in Stock
                    case 2:
                        Products = ProductRepository.Find(p => p.Quantity >= 2).ToList();
                        break;
                }
                return Products;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Find by id a product
        /// </summary>
        /// <param name="IdProduct"></param>
        /// <returns></returns>
        public Product FindById(int IdProduct)
        {
            Product product = new Product();
            return product = ProductRepository.Find(p => p.IdProduct == IdProduct).FirstOrDefault();
        }

        /// <summary>
        /// Find All Product
        /// </summary>
        /// <returns>List Products</returns>
        public IEnumerable<Product> FindAll()
        {
            string[] includeProp = new string[] { "TypeProduct", "Color", "Gender", "State" };
            try
            {
                return ProductRepository.FindAll(includeProp);
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
