using System;
using System.Collections.Generic;
using System.Text;

namespace Uppgift2_Lavinia
{
    class Category
    {
        //constructor
        public Category(int index, string data)
        {
            Cat = data;
            Id = index;
        }

        //modifyable property
        public string Cat { get; set; }
        public int Id { get; set; }

    }
}
