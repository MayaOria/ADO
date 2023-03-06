using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest_Exemple.Test
{
    class StringTest
    {
        [Test]
        public void PalindromeTest()
        {
            StringTools st = new StringTools();
            //ARRANGE
            //IN
            string entree = "kayak";

            //OUT 
            string retour;
            string ExpectedReturn = "Palindrome";

            //ACT
            retour = st.CheckIt(entree);

            //ASSERT

            Assert.That(retour, Is.EqualTo(ExpectedReturn));

        }

        [Test]

        public void DoublonLettre()
        {
            StringTools st = new StringTools();
            //ARRANGE
            //IN

            string entree = "hello";

            //OUT
            string retour;
            string ExpectedReturn = "Double lettre";

            //ACT
            retour = st.CheckIt(entree);
            //ASSERT

            Assert.That(retour, Is.EqualTo(ExpectedReturn));
        }

        [Test]

        public void NotDoublonLettre()
        {
            StringTools st = new StringTools();
            //ARRANGE
            //IN

            string entree = "world";

            //OUT
            string retour;
            string ExpectedReturn = "Double lettre";

            //ACT
            retour = st.CheckIt(entree);
            //ASSERT

            Assert.That(retour, Is.Not.EqualTo(ExpectedReturn));
        }

        [Test]

        public void Mot2Lettres()
        {
            StringTools st = new StringTools();
            //ARRANGE
            //IN

            string entree = "l";
            //OUT
            string retour;
            
            
            //ASSERT

            Assert.Throws<TropPeudeLettreException>(()=>st.CheckIt(entree));

        }
    }
}
