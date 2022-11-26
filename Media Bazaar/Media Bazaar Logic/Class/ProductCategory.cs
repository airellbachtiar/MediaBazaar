using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Media_Bazaar_Logic.Class
{
    public class ProductCategory
    {
        public ProductCategory(int id,string name)
        {

            ID = id;
            Name = name;

        }

        public ProductCategory(string name)
        {

            
            Name = name;

        }



        public int ID { get; set; }
        public string Name { get; set; }




    }
}
