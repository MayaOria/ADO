using NUnit.Framework;

namespace UnitTest_Exemple.Test
{
    public class OperationTest
    {
        [Test]
        public void AdditionTest()
        {
            //ARRANGE

            //IN
            Operation Op = new Operation();
            int x = 8;
            int y = 15;
            //OUT
            int result = 0;
            int ExpectedResult = 23;

            //ACT
            result = Op.Addition(x, y);

            //Assert
            Assert.AreEqual(ExpectedResult, result);
        }

        
    }
}