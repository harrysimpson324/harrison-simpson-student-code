using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Exercises.Classes;
using System.Reflection;

namespace Exercises.Tests.Classes
{
    [TestClass]
    public class ElevatorTests
    {
        [TestInitialize]
        public void Setup()
        {
            Type type = Type.GetType(typeof(Elevator).AssemblyQualifiedName);
            Assert.IsFalse(type.IsAbstract, "Elevator class must not be abstract. Remove the 'abstract' modifier on Elevator.");
        }

        [TestMethod]
        public void Elevator_HasRequiredMembers()
        {
            Type type = typeof(Elevator);

            PropertyInfo prop = type.GetProperty("CurrentLevel");
            PropertyValidator.ValidateReadPrivateWrite(prop, "CurrentLevel", typeof(int));

            prop = type.GetProperty("NumberOfLevels");
            PropertyValidator.ValidateReadPrivateWrite(prop, "NumberOfLevels", typeof(int));

            prop = type.GetProperty("DoorIsOpen");
            PropertyValidator.ValidateReadPrivateWrite(prop, "DoorIsOpen", typeof(bool));

            MethodInfo method = type.GetMethod("OpenDoor");
            MethodValidator.ValidatePublicMethod(method, "OpenDoor", typeof(void));

            method = type.GetMethod("CloseDoor");
            MethodValidator.ValidatePublicMethod(method, "CloseDoor", typeof(void));

            method = type.GetMethod("GoUp");
            MethodValidator.ValidatePublicMethod(method, "GoUp", typeof(void));
            Assert.AreEqual(1, method.GetParameters().Length, "GoUp should accept 1 parameter");

            method = type.GetMethod("GoDown");
            MethodValidator.ValidatePublicMethod(method, "GoDown", typeof(void));
            Assert.AreEqual(1, method.GetParameters().Length, "GoDown should accept 1 parameter");
        }

        [TestMethod]
        public void Elevator_Constructor()
        {
            Type type = typeof(Elevator);
            Elevator elevator = (Elevator)Activator.CreateInstance(type, 3);

            Assert.AreEqual(1, type.GetProperty("CurrentLevel").GetValue(elevator), "CurrentLevel for new Elevators should return 1.");
            Assert.AreEqual(3, type.GetProperty("NumberOfLevels").GetValue(elevator), "NumberOfLevels should be equal to the argument passed into the Constructor");
            Assert.AreEqual(false, type.GetProperty("DoorIsOpen").GetValue(elevator), "The door should be closed for new elevators");
        }

        [TestMethod]
        public void Elevator_OpenDoorTests()
        {
            Type type = typeof(Elevator);
            Elevator elevator = (Elevator)Activator.CreateInstance(type, 3);

            type.GetMethod("OpenDoor").Invoke(elevator, null);

            Assert.AreEqual(true, type.GetProperty("DoorIsOpen").GetValue(elevator), "The door should be open after calling OpenDoor");

            type.GetMethod("CloseDoor").Invoke(elevator, null);

            Assert.AreEqual(false, type.GetProperty("DoorIsOpen").GetValue(elevator), "The door should be closed after calling CloseDoor");
        }

        [TestMethod]
        public void Elevator_MoveUpAndDownTests()
        {
            Type type = typeof(Elevator);
            Elevator elevator = (Elevator)Activator.CreateInstance(type, 5);

            // Newly instantieated elevator is on floor 1 and door is closed
            Assert.AreEqual(1, type.GetProperty("CurrentLevel").GetValue(elevator), "Newly instantiated elevator is not on floor 1.");
            Assert.AreEqual(false, type.GetProperty("DoorIsOpen").GetValue(elevator), "Newly instantiated elevator's door is not closed.");

            // Move up to floor 2
            type.GetMethod("GoUp").Invoke(elevator, new object[] { 2 });
            Assert.AreEqual(2, type.GetProperty("CurrentLevel").GetValue(elevator), "The elevator did not go up to the floor 2.");

            // Open the door
            type.GetMethod("OpenDoor").Invoke(elevator, null);
            Assert.AreEqual(true, type.GetProperty("DoorIsOpen").GetValue(elevator), "The elevator door did not open.");

            // Attempt to move up to floor 3 with door open
            type.GetMethod("GoUp").Invoke(elevator, new object[] { 3 });
            Assert.AreEqual(2, type.GetProperty("CurrentLevel").GetValue(elevator), "The elevator moved from floor 2 to floor 3 with the door open.");

            // Close the door
            type.GetMethod("CloseDoor").Invoke(elevator, null);
            Assert.AreEqual(false, type.GetProperty("DoorIsOpen").GetValue(elevator), "The elevator door did not close.");

            // Move up to floor 4
            type.GetMethod("GoUp").Invoke(elevator, new object[] { 4 });
            Assert.AreEqual(4, type.GetProperty("CurrentLevel").GetValue(elevator), "The elevator did not move up to floor 4.");

            // Attempt to move "up" to floor 3 from floor 4
            type.GetMethod("GoUp").Invoke(elevator, new object[] { 3 });
            Assert.AreEqual(4, type.GetProperty("CurrentLevel").GetValue(elevator), "The elevator moved \"up\" to floor 3 from floor 4.");

            // Move up to the top floor
            type.GetMethod("GoUp").Invoke(elevator, new object[] { 5 });
            Assert.AreEqual(5, type.GetProperty("CurrentLevel").GetValue(elevator), "The elevator did not move up to the top floor.");

            // Attempt to move past the top floor
            type.GetMethod("GoUp").Invoke(elevator, new object[] { 6 });
            Assert.AreEqual(5, type.GetProperty("CurrentLevel").GetValue(elevator), "The elevator went past the top floor.");

            // Move down to floor 3 from floor 5
            type.GetMethod("GoDown").Invoke(elevator, new object[] { 3 });
            Assert.AreEqual(3, type.GetProperty("CurrentLevel").GetValue(elevator), "The elevator did not move down to the floor 3.");

            // Open the door
            type.GetMethod("OpenDoor").Invoke(elevator, null);
            Assert.AreEqual(true, type.GetProperty("DoorIsOpen").GetValue(elevator), "The elevator door did not open.");

            // Attempt to move down to floor 2 with door open
            type.GetMethod("GoDown").Invoke(elevator, new object[] { 2 });
            Assert.AreEqual(3, type.GetProperty("CurrentLevel").GetValue(elevator), "The elevator moved from floor 3 to floor 2 with the door open.");

            // Close the door
            type.GetMethod("CloseDoor").Invoke(elevator, null);
            Assert.AreEqual(false, type.GetProperty("DoorIsOpen").GetValue(elevator), "The elevator door did not close.");

            // Move down to floor 2
            type.GetMethod("GoDown").Invoke(elevator, new object[] { 2 });
            Assert.AreEqual(2, type.GetProperty("CurrentLevel").GetValue(elevator), "The elevator did not move down to floor 2.");

            // Attempt to move "down" from floor 2 to floor 3
            type.GetMethod("GoDown").Invoke(elevator, new object[] { 3 });
            Assert.AreEqual(2, type.GetProperty("CurrentLevel").GetValue(elevator), "The elevator moved \"down\" to floor 3 from floor 2.");

            // Move down to the bottom floor
            type.GetMethod("GoDown").Invoke(elevator, new object[] { 1 });
            Assert.AreEqual(1, type.GetProperty("CurrentLevel").GetValue(elevator), "The elevator did not move down to the bottom floor.");

            // Attempt to move below the bottom floor
            type.GetMethod("GoDown").Invoke(elevator, new object[] { 0 });
            Assert.AreEqual(1, type.GetProperty("CurrentLevel").GetValue(elevator), "The elevator went below the bottom floor.");
        }
    }
}
