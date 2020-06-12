using System;
using System.Collections.Generic;

namespace Promotion_Console_App
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number of items in the cart: ");
            int no_items_in_cart = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Number of items: " + no_items_in_cart);

            /* Current Promotions */
            Dictionary<string, int> dictCurrentPromotions = new Dictionary<string, int>();
            dictCurrentPromotions.Add("3*A", 130);
            dictCurrentPromotions.Add("2*B", 45);
            dictCurrentPromotions.Add("C+D", 30);

            //char[] SKU_IDs = { 'A', 'B', 'C', 'C', 'D', 'E', 'C','F','G'};
            Console.WriteLine("Enter the {0} items in your cart one by one. Type characters", no_items_in_cart);

            char[] _skus = new char[no_items_in_cart];
            for (int j = 0; j < no_items_in_cart; j++)
            {
                try
                {
                    char _sku = Convert.ToChar(Console.ReadLine().Substring(0, 1).ToUpper());
                    _skus[j] = _sku;
                }
                catch (Exception e) { }
            }




            Console.Write("-------------------Promotion Algorithm format----------------");
            Console.ReadLine();

            /* Dictionary that stores the Items and their unitPrice */
            Dictionary<string, int> dictItemsUnitPrice = new Dictionary<string, int>();
            dictItemsUnitPrice.Add("A", 50);
            dictItemsUnitPrice.Add("B", 30);
            dictItemsUnitPrice.Add("C", 20);
            dictItemsUnitPrice.Add("D", 15);


            var val = new PromotionEngineLibrary.PromotionEngineInvoice().GenerateInvoice(_skus, dictItemsUnitPrice, dictCurrentPromotions);
            Console.WriteLine("Final invoice:" + val.ToString());
            Console.ReadLine();
        }
    }
}
