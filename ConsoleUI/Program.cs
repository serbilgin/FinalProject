using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CategoryTest();
            ProductTest();
        }

        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());

            foreach (var c in categoryManager.GetAll())
            {
                Console.WriteLine(c.CategoryName);
            }
        }

        private static void ProductTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());
            var result = productManager.GetAll();
            if (result.Success == true)
            {
                foreach (var p in productManager.GetProductDetails().Data)
                {
                    Console.WriteLine(p.ProductName + "\t" + p.CategoryName);
                }
                Console.WriteLine(DateTime.Now.Hour);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
    }
}
