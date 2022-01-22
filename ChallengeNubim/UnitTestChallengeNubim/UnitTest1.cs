using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChallengeNubim.Services;
using ChallengeNubim.Entities;
using System.Threading.Tasks;
using ChallengeNubim;
using System.Net.Http;
using System.Web.Http;

namespace UnitTestChallengeNubim
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestCodigoPaisEmpty()
        {
            //PaisService paisService = new PaisService();
            //Pais pais = new Pais();
            //pais = paisService.Get(string.Empty);
            //Assert.IsNull(pais);


        }

        [TestMethod]
        public void TestCodigoPaisInexistente()
        {
            try
            {
                //PaisService paisService = new PaisService();
                //Pais pais = new Pais();
                //pais = paisService.Get("XXXXX");
                //Assert.Fail("Se produce una excepcion");
                
            }
            catch (Exception e)
            {
                Assert.AreEqual(-2146233088, e.HResult);

            }



        }
    }
}
