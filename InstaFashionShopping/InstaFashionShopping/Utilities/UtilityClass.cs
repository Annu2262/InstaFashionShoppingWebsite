using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Data.SqlClient;
using System.Configuration;

namespace InstaFashionShopping
{
    public static class Utility
    {
        /// <summary>
        /// Connection String to be used across the application
        /// </summary>
        public static  string ConnString {
            get
            {
               return  ConfigurationManager.ConnectionStrings["Insta-FashionDB"].ConnectionString;
            }
        }

        public static int ProdCount(string[] tempProductArray)
        {
            return CountProductsInCart(tempProductArray);
        }

        
        private static int CountProductsInCart(string[] tempProductArray)
        {
            int prodCount = 0;
            for (int i = 0; i < tempProductArray.Length; i++)
            {
                bool isDuplicate = false;
                for (int j = 0; j < i; j++)
                {
                    if (tempProductArray[i] == tempProductArray[j])
                    {
                        isDuplicate = true;
                        break;
                    }
                }

                if (!isDuplicate)
                {
                    ++prodCount;

                }
            }

            return prodCount;
        }
    }
}