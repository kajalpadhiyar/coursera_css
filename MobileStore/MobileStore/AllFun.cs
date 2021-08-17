using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileStore
{
    class AllFun
    {
        static List<Product.kMumbai> LProduct = JsonConvert.DeserializeObject<List<Product.kMumbai>>(File.ReadAllText(@"Product.json"));
        static List<Customer.kCustomer> LCustomer = JsonConvert.DeserializeObject<List<Customer.kCustomer>>(File.ReadAllText(@"customer.json"));
        public static void Search_Customer()
        {
            int sflag = 0;
            Console.Write("Enter Customer's First Name: ");
            string sfirstName = Console.ReadLine();
            Console.Write("Enter Customer's Last Name: ");
            string slastName = Console.ReadLine();
            string slocation = "", sdob = "";
            foreach (var o in LCustomer)
            {
                if (o.FirstName.ToString() == sfirstName && o.LastName.ToString() == slastName)
                {
                    slocation = o.Location.ToString();
                    sdob = o.Dob.ToShortDateString();
                    sflag = 1;
                }
            }
            if (sflag == 0)
            {
                Console.WriteLine("No such customer exist");
            }
            else
            {
                Console.WriteLine($"Customer's First Name : {sfirstName}\nLast Name : {slastName}\n Location : {slocation}\n Dob : {sdob}");
            }
        }
        public static void Add_Products()
        {
            Console.Write("Enter Mobile Company: ");
            string c_name = Console.ReadLine();
            Console.Write("Enter Mobile Name: ");
            string m_name = Console.ReadLine();
            Console.Write("Enter RAM: ");
            int ram = int.Parse(Console.ReadLine());
            Console.Write("Enter ROM: ");
            int rom = int.Parse(Console.ReadLine());
            Console.Write("Enter color: ");
            string color = Console.ReadLine();

            Console.Write("Enter store: ");
            string store = Console.ReadLine();

            int id = LProduct.Count() + 1;
            //assigning values to the keys
            Product.kMumbai dproduct = new Product.kMumbai()
            {
                P_Id = id,
                C_Name = c_name,
                M_Name = m_name,
                Ram = ram,
                Storage = rom,
                Color = color,
                Store = store,
                Store_Count = (c_name + "_" + m_name + "_" + ram + "_" + rom + "_" + color + "_" + store).ToUpper()
            };
            LProduct.Add(dproduct);
            var jsonString = JsonConvert.SerializeObject(LProduct, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(@"Product.json", jsonString);
            Console.WriteLine("Successfully Added");

        }

    }
}
