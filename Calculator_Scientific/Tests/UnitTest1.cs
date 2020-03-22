using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExpressionClass;

namespace Tests
{
    [TestClass]
    public class ExpressionTests
    {
        [TestMethod]
        public void CheckExpressions()
        {
            // Arrange
            Expression opr1 = new TerminalExpression(3.5);
            Expression opr2 = new TerminalExpression(2);

            Expression add = new Addition(opr1, opr2);
            Expression subs = new Substraction(opr1, opr2);
            Expression mult = new Multiplication(opr1, opr2);
            Expression div = new Division(opr1, opr2);
            Expression pow = new Power(opr1, opr2);
            Expression sqrt = new SquareRoot(opr1);
            Expression neg = new NegativeExpression(opr1);

            // Act
            double addRes = add.solve();
            double subsRes = subs.solve();
            double multRes = mult.solve();
            double divRes = div.solve();
            double powRes = pow.solve();
            double sqrtRes = sqrt.solve();
            double negRes = neg.solve();

            // Assert
            Assert.AreEqual(3.5 + 2, addRes);
            Assert.AreEqual(3.5 - 2, subsRes);
            Assert.AreEqual(3.5 * 2, multRes);
            Assert.AreEqual(3.5 / 2, divRes);
            Assert.AreEqual(Math.Pow(3.5, 2), powRes);
            Assert.AreEqual(Math.Pow(3.5, 0.5), sqrtRes);
            Assert.AreEqual(-3.5, negRes);
        }

        [TestMethod]
        public void CheckNegativeSqrt()
        {
            // TODO
        }
    }
}
