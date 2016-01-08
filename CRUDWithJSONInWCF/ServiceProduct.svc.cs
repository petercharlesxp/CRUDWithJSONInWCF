using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace CRUDWithJSONInWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class ServiceProduct : IServiceProduct
    {

        public List<Product> findAll()
        {
            using (ModelMydemo mde = new ModelMydemo())
            {
                return mde.mydemoproducts.Select(pe => new Product
                {
                    Id = pe.id,
                    Name = pe.Name,
                    Price = pe.Price.Value,
                    Quantity = pe.Quantity.Value
                }).ToList();
            }
        }

        public Product find(string id)
        {
            using (ModelMydemo mde = new ModelMydemo())
            {
                int nid = Convert.ToInt32(id);
                return mde.mydemoproducts.Where(pe => pe.id == nid).Select(pe => new Product
                {
                    Id = pe.id,
                    Name = pe.Name,
                    Price = pe.Price.Value,
                    Quantity = pe.Quantity.Value
                }).First();
            }
        }

        public bool create(Product product)
        {
            using (ModelMydemo mde = new ModelMydemo())
            {
                try
                {
                    mydemoproduct pe = new mydemoproduct();
                    pe.Name = product.Name;
                    pe.Price = product.Price;
                    pe.Quantity = product.Quantity;
                    mde.mydemoproducts.Add(pe);
                    mde.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public bool edit(Product product)
        {
            using (ModelMydemo mde = new ModelMydemo())
            {
                try
                {
                    int id = Convert.ToInt32(product.Id);
                    mydemoproduct pe = mde.mydemoproducts.Single(p => p.id == id);
                    pe.Name = product.Name;
                    pe.Price = product.Price;
                    pe.Quantity = product.Quantity;
                    mde.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }

        public bool delete(Product product)
        {
            using (ModelMydemo mde = new ModelMydemo())
            {
                try
                {
                    int id = Convert.ToInt32(product.Id);
                    mydemoproduct pe = mde.mydemoproducts.Single(p => p.id == id);
                    mde.mydemoproducts.Remove(pe);
                    mde.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}
