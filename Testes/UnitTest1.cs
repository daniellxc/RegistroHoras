using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegistroHoras.DATA.classes.business;

namespace Testes
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestarTotalDiasUteisMes()
        {
            int teste = new DiaNaoUtilBO().GetDiasNaoUteisMes(12, 2016).Count;
            Assert.AreEqual(teste, 1);
        }
    }
}
