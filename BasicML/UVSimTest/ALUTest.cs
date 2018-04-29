using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using UVSim;

//-----------------------------------------------------------------------------------------------------------------------
//  File Designed by: Nikita Pestin

// Implementation file for the "UVSimTest" class.

namespace UVSimTest
{
    [TestClass]
    public class ALUTest
    {
        [TestMethod]
        public void TestAddition()
        {
            // arrange
            int op1 = 15;
            int op2 = 25;
            int expected = 40;
            ALU alu = new ALU();

            // act
            int actual = alu.Add(op1, op2);

            // assert
            Assert.AreEqual(expected, actual, 0.001, "Addition failed.");
        }

        [TestMethod]
        public void TestDivision()
        {
            // arrange
            int op1 = 100;
            int op2 = 5;
            int expected = 20;
            ALU alu = new ALU();

            // act
            int actual = alu.Divide(op1, op2);

            // assert
            Assert.AreEqual(expected, actual, 0.001, "Division failed.");
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void TestDivision_WithException()
        {
            // arrange
            int op1 = 100;
            int op2 = 0;
            ALU alu = new ALU();

            // act
            int actual = alu.Divide(op1, op2);

            // assert is handled by ExpectedException
        }
    }
}
