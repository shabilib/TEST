using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using PromotionEngineLibrary;

namespace PromotionEngineUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void PositiveCheck()
        {

            Dictionary<string, int> dictItemsUnitPrice = new Dictionary<string, int>();
            dictItemsUnitPrice.Add("A", 50);
            dictItemsUnitPrice.Add("B", 30);
            dictItemsUnitPrice.Add("C", 20);
            dictItemsUnitPrice.Add("D", 15);

            char[] _skus = new char[5];
            _skus[0] = 'A';
            _skus[1] = 'A';
            _skus[2] = 'A';
            _skus[3] = 'A';
            _skus[4] = 'A';

            /* Current Promotions */
            Dictionary<string, int> dictCurrentPromotions = new Dictionary<string, int>();
            dictCurrentPromotions.Add("3*A", 130);
            dictCurrentPromotions.Add("2*B", 45);
            dictCurrentPromotions.Add("C+D", 30);

            //AAA
            var promotionTest = new PromotionEngineInvoice().GenerateInvoice(_skus, dictItemsUnitPrice, dictCurrentPromotions);
            Assert.AreEqual(230, promotionTest);

        }

        [TestMethod]
        public void NegativeCheck()
        {

            Dictionary<string, int> dictItemsUnitPrice = new Dictionary<string, int>();
            dictItemsUnitPrice.Add("A", 50);
            dictItemsUnitPrice.Add("B", 30);
            dictItemsUnitPrice.Add("C", 20);
            dictItemsUnitPrice.Add("D", 15);

            char[] _skus = new char[5];
            _skus[0] = 'A';
            _skus[1] = 'A';
            _skus[2] = 'B';
            _skus[3] = 'A';
            _skus[4] = 'A';

            /* Current Promotions */
            Dictionary<string, int> dictCurrentPromotions = new Dictionary<string, int>();
            dictCurrentPromotions.Add("3*A", 130);
            dictCurrentPromotions.Add("2*B", 45);
            dictCurrentPromotions.Add("C+D", 30);

            //AAA
            var promotionTest = new PromotionEngineInvoice().GenerateInvoice(_skus, dictItemsUnitPrice, dictCurrentPromotions);
            Assert.AreNotEqual(230, promotionTest);

        }
    }
}
