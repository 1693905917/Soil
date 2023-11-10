using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 土壤项目
{
    class soil_form3
    {
        private string year;
        private string name;
        private string soil_sort;
        private string mo_soil;

        public string Year
        {
            get
            {
                return year;
            }

            set
            {
                year = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public string Soil_sort
        {
            get
            {
                return soil_sort;
            }

            set
            {
                soil_sort = value;
            }
        }

        public string Mo_soil
        {
            get
            {
                return mo_soil;
            }

            set
            {
                mo_soil = value;
            }
        }

        public soil_form3() { }

        public soil_form3(string year, string name, string soil_sort, string mo_soil)
        {
            this.year = year;
            this.name = name;
            this.soil_sort = soil_sort;
            this.mo_soil = mo_soil;
        }
    }
}
