﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileStore
{
    class Book_Order
    {
        static List<Product.kMumbai> LProduct = JsonConvert.DeserializeObject<List<Product.kMumbai>>(File.ReadAllText(@"Product.json")); 
        public static void Search_Product()
        {
            int sflag = 0;
            Console.Write("Enter Customer's Company Name: ");
            string c_name = Console.ReadLine();
            foreach (var o in LProduct)
            {
                if (o.C_Name.ToString() == c_name)
                {
                    Console.WriteLine($"Company Name : {c_name}\tMobile Name : {o.M_Name}\tRAM : {o.Ram}\tROM : {o.Storage}\tStore : {o.Store}\n");
                    sflag = 1;
                }
            }
            if (sflag == 0)
            {
                Console.WriteLine("No such product exist");
            }
        }
        public static void Product_Book(string firstname)
        {
            string name = firstname;
        }
    }
}
