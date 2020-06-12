using System;
using System.Collections.Generic;

namespace PromotionEngineLibrary
{
    public class PromotionEngineInvoice
    {
        public int GenerateInvoice(char[] skus, Dictionary<string, int> dictItemsUnitPrice, Dictionary<string, int> dictCurrentPromotions)
        {
            int invoiceTotal = 0;

            /*  Logic - To loop through the array to find duplicates*/
            var dictSkuCount = new Dictionary<char, int>();
            foreach (var value in skus)
            {
                if (dictSkuCount.ContainsKey(value)) dictSkuCount[value]++;
                else dictSkuCount[value] = 1;
            }

            foreach (var promotion in dictCurrentPromotions)
            {
                var promotionEq = promotion.Key;
                var promotionVal = promotion.Value;

                if (promotionEq.Contains("*"))
                {
                    var eq = promotionEq.Split('*');
                    Console.WriteLine(eq[0]);
                    Console.WriteLine(eq[1]);

                    foreach (var skuCount in dictSkuCount)
                    {
                        if (skuCount.Key.ToString() == eq[1].ToString())
                        {
                            var pValue = int.Parse(skuCount.Value.ToString()) / int.Parse(eq[0]) * int.Parse(promotionVal.ToString());
                            var pRemaining = int.Parse(skuCount.Value.ToString()) % int.Parse(eq[0]) * int.Parse(dictItemsUnitPrice[eq[1]].ToString());
                            var total = pValue + pRemaining;
                            invoiceTotal = invoiceTotal + total;
                        }
                    }


                }

            }

            return invoiceTotal;
        }
    }
}
