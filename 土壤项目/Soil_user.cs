using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 土壤项目
{
    class Soil_user
    {
        private string address_name;
        private string address_ad;
        private string province;
        private string soil_recycle;

        public string Address_name
        {
            get
            {
                return address_name;
            }

            set
            {
                address_name = value;
            }
        }

        public string Address_ad
        {
            get
            {
                return address_ad;
            }

            set
            {
                address_ad = value;
            }
        }

        public string Province
        {
            get
            {
                return province;
            }

            set
            {
                province = value;
            }
        }

        public string Soil_recycle
        {
            get
            {
                return soil_recycle;
            }

            set
            {
                soil_recycle = value;
            }
        }

        public Soil_user()
        { }

        public Soil_user(string address_name, string address_ad, string province, string soil_recycle)
        {
            this.Address_name = address_name;
            this.Address_ad = address_ad;
            this.Province = province;
            this.Soil_recycle = soil_recycle;
        }
    }

}
