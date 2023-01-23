using Microsoft.VisualStudio.TestTools.UnitTesting;
using RenoSystem;
using System;

namespace RenoUnitTestsEx1
{
    [TestClass]
    public class WallTests
    {
        [TestMethod]

        public void CreateWall_GoodWallwithOpening_WallMade()
        {
            try
            {
                Opening theOpening = new Opening(OpeningType.Window, 100, 120);
                Wall theWall = new Wall("Brd1", 367, 244, "White", theOpening);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Unexpected exception of type {ex.GetType()} caught {ex.Message}");
            }

        }
        [TestMethod]

        public void CreateWall_GoodWallwithoutOpening_WallMade()
        {
            try
            {
                
                Wall theWall = new Wall("Brd1", 367, 244, "White", null);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Unexpected exception of type {ex.GetType()} caught {ex.Message}");
            }

        }

        [TestMethod]
        [DataRow("", 0, 244, "White")]
        [DataRow("Brd1", 0, 244, "White")]
        [DataRow("Brd1", -10, 244, "White")]
        [DataRow("Brd1", 16, 244, "White")]
        [DataRow("Brd1", 367, 0, "White")]
        [DataRow("Brd1", 367, -10, "White")]
        [DataRow("Brd1", 367, 20, "White")]
        [DataRow("Brd1", 367, 244, " ")]


        public void CreateWall_BadMeasurementsColor_ExceptionThrown(string planid, int width, int height, string color)
        {
            try
            {
                Opening theOpening = new Opening(OpeningType.Window, 100, 120, 15);
                Wall theWall = new Wall(planid, width, height, color, theOpening);

                Assert.Fail("Exception was expected and failed to be thrown.");
            }
            catch (ArgumentException argex)
            {
                Assert.IsTrue(argex.Message.Contains("positive")
                        || argex.Message.Contains("minimum")
                        || argex.Message.Contains("missing"));


            }
            catch (Exception ex)
            {
                Assert.IsFalse(ex.Message.Contains("Assert.Fail"));
                Assert.IsTrue(ex.Message.Length > 0, "Exception contained no message.");
            }
        }

        [TestMethod]
        [DataRow("Brd1", 105, 125, "White")]

        public void WallArea_Insufficient_OpeningTooLarge(string planid, int width, int height, string color)
        {
            try
            {
                Opening theOpening = new Opening(OpeningType.Window, 100, 120, 15);
                Wall theWall = new Wall(planid, width, height, color, theOpening);
                Assert.Fail("Exception was expected and failed to be thrown.");
            }
            catch (ArgumentException argex)
            {
                Assert.IsTrue(argex.Message.Contains("Opening limit exceeded"));
            }
            catch (Exception ex)
            {
                Assert.Fail($"Unexpected exception of type {ex.GetType()} caught {ex.Message}");
            }
        }

        [TestMethod]
        [DataRow("Brd1", 367, 244, "White")]
        public void SurfaceAreaCheck_GoodCalculationwithOpening(string planid, int width, int height, string color)
        {
            try
            {
                Opening theOpening = new Opening(OpeningType.Window, 100, 120, 15);
                Wall theWall = new Wall(planid, width, height, color, theOpening);
                Assert.AreEqual(theWall.SurfaceArea, 77548, "Area did not calculate as expected.");

            }
            catch (Exception ex)
            {
                Assert.Fail($"Unexpected exception of type {ex.GetType()} caught {ex.Message}");
            }
        }

        [TestMethod]
        [DataRow("Brd1", 367, 244, "White")]
        public void SurfaceAreaCheck_GoodCalculationwithoutOpening(string planid, int width, int height, string color)
        {
            try
            {
              
                Wall theWall = new Wall(planid, width, height, color, null);
                Assert.AreEqual(theWall.SurfaceArea, 89548, "Area did not calculate as expected.");

            }
            catch (Exception ex)
            {
                Assert.Fail($"Unexpected exception of type {ex.GetType()} caught {ex.Message}");
            }
        }

        [TestMethod]
        [DataRow("Brd1", 367, 244, "White")]
        public void Wall_ToStringDisplaywithOpening_GoodDisplay(string planid, int width, int height, string color)
        {
            try
            {
                Opening theOpening = new Opening(OpeningType.Window, 100, 120, 10);
                Wall theWall = new Wall(planid, width, height, color, theOpening);
                Assert.AreEqual(theWall.ToString(), "Brd1,367,244,White,Window,100,120,10",
                    $"ToString {theWall.ToString()} not as expected.");
            }
            catch (Exception ex)
            {
                Assert.Fail($"Unexpected exception of type {ex.GetType()} caught {ex.Message}");
            }
        }

        [TestMethod]
        [DataRow("Brd1", 367, 244, "White")]
        public void Wall_ToStringDisplaywithoutOpening_GoodDisplay(string planid, int width, int height, string color)
        {
            try
            {
                
                Wall theWall = new Wall(planid, width, height, color, null);
                Assert.AreEqual(theWall.ToString(), "Brd1,367,244,White",
                    $"ToString {theWall.ToString()} not as expected.");
            }
            catch (Exception ex)
            {
                Assert.Fail($"Unexpected exception of type {ex.GetType()} caught {ex.Message}");
            }
        }
    }
}
