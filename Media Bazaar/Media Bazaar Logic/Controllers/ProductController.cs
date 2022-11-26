using System.Collections.Generic;
using Media_Bazaar_Logic.Class;
using Media_Bazaar_Logic.DAL;

namespace Media_Bazaar_Logic.Controllers
{
    public class ProductController
    { 
        private List<Product> products;

        public ProductController()
        {
            products = ProductDAL.GetAllProducts();
        }

        public void AddProduct(Product p)
        {
            ProductDAL.AddProduct(p);//database add product
            ReloadProducts();
        }

        public void RemoveProductByID(int id)
        {
            foreach (Product product in products)
            {
                if (product.Id == id)
                {
                    ProductDAL.DeleteProduct(product);//database delete product
                }
            }
            ReloadProducts();
        }

        public Product GetProductByIndex(int index)
        {
            return products[index];
        }

        public List <Product> GetProducts()
        {
            ReloadProducts();
            return this.products;
        }

        public List <Product> GetProductByDepartment(string department)
        {
            ReloadProducts();

            List<Product> pd = new List<Product>();

            foreach (Product product in products)
            {
                if (product.Category.Name.Equals(department))
                {
                    pd.Add(product);
                }
            }

            return pd;
        }


        //Local products will only be overwritten if it is sorted
        public void SetProducts(List<Product> newList)
        {
            this.products.Clear();
            Product[] tempList = newList.ToArray();
            foreach (Product product in tempList)
            {
                this.products.Add(product);
            }
        }

        private void ReloadProducts()
        {
            this.products = ProductDAL.GetAllProducts();
        }





        public bool ContainsProductByName(string productName)
        {
            bool contains = false;
            foreach (Product product in products)
            {
                if (product.Name.Equals(productName))
                {
                    contains = true;
                }
            }

            return contains;
        }


        //Category Controller

        public static void AddNewCategory(ProductCategory pc)
        {
            ProductDAL.AddNewCategory(pc);
        }

        public static void UpdateCategory(ProductCategory pc)
        {
            ProductDAL.UpdateCategory(pc);
        }


        public static List <ProductCategory> GetAllCategorys()
        {
            List<ProductCategory> list = ProductDAL.GetAllCategorys();
            return list;
        }

        public static ProductCategory GetCategoryByID(int id)
        {
            ProductCategory pc = ProductDAL.GetCategoryByID(id);
            return pc;
        }


    }
}
