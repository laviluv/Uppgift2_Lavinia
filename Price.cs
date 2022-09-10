using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift2_Lavinia
{
    class Price
    {
        //constructor
        public Price(int index, double data)
        {
            Pris = data;
            Id = index;
        }

        //modifyable property
        public double Pris { get; set; }
        public int Id { get; set; }

    }
}
