using HXD4UK_HSZF_20242501.Application;
using HXD4UK_HSZF_20242501.Model;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXD4UK_HSZF_20242501.Test
{
    [TestFixture]
    public class CloneMethodsTests
    {
        private Fake_Klonokhaborujadbcontext _fakeContext;
        private Fake_WrongInput _fakeWrongInput;
        private CloneMethods   cloneMethods;
        private FakeInputReader _fakeInputReader;
        private Fake_CloneEventHandler _fakeCloneEventHandler;

        [SetUp]
        public void Setup()
        {
            _fakeContext = new Fake_Klonokhaborujadbcontext();
            _fakeWrongInput = new Fake_WrongInput();
            _fakeInputReader = new FakeInputReader(new Queue<ConsoleKey>(new[] { ConsoleKey.D1 }));
            _fakeCloneEventHandler = new Fake_CloneEventHandler();

            cloneMethods = new CloneMethods(_fakeContext, _fakeCloneEventHandler, _fakeWrongInput, _fakeInputReader);



            _fakeContext.Squads.Add(new Squads { Id = 1, Name = "Squad A", Commander = "Anakin" });
            _fakeContext.Squads.Add(new Squads { Id = 2, Name = "Squad B", Commander = "Bela" });
            _fakeContext.Clones.Add(new Clones { Id = 1, Name = "Clone A", Designation = "ASD", Rank = "s", Squad_id =1 });
            _fakeContext.Clones.Add(new Clones { Id = 2, Name = "Clone B", Designation = "SD", Rank = "asds", Squad_id = 2 });
            _fakeContext.Clones.Add(new Clones { Id = 3, Name = "Clone C", Designation = "D", Rank = "as", Squad_id = 2 });
            _fakeContext.Battles.Add(new Battles { Id = 1, Name = "Battle X", Location = "Planet Y", Date = "2024-01-01", Clones = [1, 2] });



            _fakeContext.SaveChanges();
        }

        [Test]
        public void Data_ShouldReturnAllBattles()
        {
            var result = cloneMethods.Data();

            Assert.That(result, Is.Not.Null);
            Assert.That(3.Equals(result.Count));
            Assert.That("Clone A".Equals(result[0].Name));
        }

        [Test]
        public void Add_ShouldInsertNewBattle()
        {
            
            _fakeWrongInput.NextInputs = new Queue<string>(new[]
            {
            "Clone D", 
            "Deed", 
            "Commander", 
            "1",
            });

            Console.SetIn(new StringReader(string.Join(Environment.NewLine, _fakeWrongInput.NextInputs)));

            
            cloneMethods.Add();

            
            var clones = _fakeContext.Clones.ToList();
            Assert.That(4.Equals(clones.Count));
            Assert.That("Clone D".Equals(clones[3].Name));
            Assert.That("Deed".Equals(clones[3].Designation));
            Assert.That("Commander".Equals(clones[3].Rank));
            Assert.That(1.Equals(clones[3].Squad_id));
            
        }

        [Test]
        public void Remove_ShouldDeleteExistingBattle()
        {
            
            _fakeWrongInput.NextInputs = new Queue<string>(new[] { "1" }); 
            Console.SetIn(new StringReader(string.Join(Environment.NewLine, _fakeWrongInput.NextInputs)));

            
            cloneMethods.Remove();

            
            var clones = _fakeContext.Clones.ToList();
            Assert.That(2.Equals(clones.Count));
        }

        [Test]
        public void Update_ShouldModifyExistingBattle()
        {
            
            _fakeWrongInput.NextInputs = new Queue<string>(new[]
            {
              "1", "Updated Clone Name"
            });
            Console.SetIn(new StringReader(string.Join(Environment.NewLine, _fakeWrongInput.NextInputs)));




            
            cloneMethods.Update();

            
            var clone = _fakeContext.Clones.FirstOrDefault(b => b.Id == 1);
            
            Assert.That(clone, Is.Not.Null);
            Assert.That("Updated Clone Name".Equals(clone.Name));
        }
    }
}
