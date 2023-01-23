using Microsoft.VisualStudio.TestTools.UnitTesting;
using RenoSystem;
using System;
using System.Collections.Generic;

namespace RenoUnitTestsEx1
{
    [TestClass]
    public class RoomTests
    {
        [TestMethod]
        [DataRow("Bedroom", "Carpet")]
        [DataRow("Washroom", null)]
        public void CreateRoom_GoodRoom_RoomMade(string name, string? flooring)
        {
            try
            {
                Room theRoom = new Room(name, flooring, null);
            }

            catch (Exception ex)
            {
                Assert.Fail($"Unexpected exception of type {ex.GetType()} caught {ex.Message}");
            }

        }
        [TestMethod]
        [DataRow(" ", "Carpet")]
        [DataRow(null, "Carpet")]
        public void CreateRoom_BadRoom_RoomName(string name, string? flooring)
        {
            try
            {
                Room theRoom = new Room(name, flooring, null);
            }
            catch (ArgumentException argex)
            {
                Assert.IsTrue(argex.Message.Contains("missing"));
            }
            catch (Exception ex)
            {
                Assert.Fail($"Unexpected exception of type {ex.GetType()} caught {ex.Message}");
            }

        }
        [TestMethod]
        [DataRow("Bedroom", "Carpet")]
        public void CreateRoom_BadRoom_MissingWallCollection(string name, string? flooring)
        {
            try
            {

                Room theRoom = new Room(name, flooring, null);
                int numberofrooms = theRoom.TotalWalls;
            }

            catch (Exception ex)
            {
                Assert.Fail($"Unexpected exception of type {ex.GetType()} caught {ex.Message}");
            }

        }
        [TestMethod]
        public void CreateRoom_AddWalls_GoodAdd()
        {
            try
            {
                Opening theWindow = new Opening(OpeningType.Window, 105, 120, 15);
                Opening theDoor = new Opening(OpeningType.Door, 112, 244, 15);
                Opening theCloset = new Opening(OpeningType.Closet, 203, 182, 15);
                
                Wall wallA = new Wall("Brd1", 309, 243, "Ivory White", theDoor);
                Wall wallB = new Wall("Brd2", 213, 243, "Ivory White", theCloset);
                Wall wallC = new Wall("Brd3", 254, 243, "Ivory White", theWindow);
                Wall wallD = new Wall("Brd4", 309, 243, "Ivory White", null);
                Room theRoom = new Room("Bedroom", "Carpet", null);
                theRoom.AddWall(wallA);
                theRoom.AddWall(wallB);
                theRoom.AddWall(wallC);
                theRoom.AddWall(wallD);
                Assert.AreEqual(theRoom.TotalWalls, 4, "Total count does not equal attempted adds");
            }
            catch (Exception ex)
            {
                Assert.Fail($"Unexpected exception of type {ex.GetType()} caught {ex.Message}");
            }
        }
    }
}
