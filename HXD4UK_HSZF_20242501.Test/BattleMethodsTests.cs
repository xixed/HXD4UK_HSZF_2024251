using HXD4UK_HSZF_20242501.Application;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXD4UK_HSZF_20242501.Test
{
    [TestFixture]
    public class BattleMethodsTests
    {

        private BattleMethods battleMethods;

        [SetUp]
        public void Innit()
        {
            battleMethods = new BattleMethods(new Fake_Klonokhaborujadbcontext(),new Fake_WrongInput());
        }

        [Test]

        public void DataTest()
        {
            
        }


    }
}
