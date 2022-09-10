using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift2_Lavinia
{
    class Product
    {
        //constructor
        public Product(int index, string data)
        {
            Article = data;
            Id = index;
        }
        //modifyable property
        public string Article { get; set; }
        public int Id { get; set; }

    }
}
