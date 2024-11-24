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
    public class SquadMethodsTests
    {
        private Fake_Klonokhaborujadbcontext _fakeContext;
        private Fake_WrongInput _fakeWrongInput;
        private SquadMethods squadMethods;
        private FakeInputReader _fakeInputReader;
        

        [SetUp]
        public void Setup()
        {
            _fakeContext = new Fake_Klonokhaborujadbcontext();
            _fakeWrongInput = new Fake_WrongInput();
            _fakeInputReader = new FakeInputReader(new Queue<ConsoleKey>(new[] { ConsoleKey.D1 }));
            

            squadMethods = new SquadMethods(_fakeContext, _fakeWrongInput, _fakeInputReader);



            _fakeContext.Squads.Add(new Squads { Id = 1, Name = "Squad A", Commander = "Anakin" });
            _fakeContext.Squads.Add(new Squads { Id = 2, Name = "Squad B", Commander = "Bela" });
            _fakeContext.Clones.Add(new Clones { Id = 1, Name = "Clone A", Designation = "ASD", Rank = "s", Squad_id = 1 });
            _fakeContext.Clones.Add(new Clones { Id = 2, Name = "Clone B", Designation = "SD", Rank = "asds", Squad_id = 2 });
            _fakeContext.Clones.Add(new Clones { Id = 3, Name = "Clone C", Designation = "D", Rank = "as", Squad_id = 2 });
            _fakeContext.Battles.Add(new Battles { Id = 1, Name = "Battle X", Location = "Planet Y", Date = "2024-01-01", Clones = [1, 2] });



            _fakeContext.SaveChanges();
        }

        [Test]
        public void Data_ShouldReturnAllBattles()
        {
            var result = squadMethods.Data();

            Assert.That(result, Is.Not.Null);
            Assert.That(2.Equals(result.Count));
            Assert.That("Squad A".Equals(result[0].Name));
        }

        [Test]
        public void Add_ShouldInsertNewBattle()
        {

            _fakeWrongInput.NextInputs = new Queue<string>(new[]
            {
            "Squad C",
            "Yoda",
            });

            Console.SetIn(new StringReader(string.Join(Environment.NewLine, _fakeWrongInput.NextInputs)));

            
            squadMethods.Add();

            
            var squads = _fakeContext.Squads.ToList();
            Assert.That(3.Equals(squads.Count));
            Assert.That("Squad C".Equals(squads[2].Name));
            Assert.That("Yoda".Equals(squads[2].Commander));
            

        }

        [Test]
        public void Remove_ShouldDeleteExistingBattle()
        {
            
            _fakeWrongInput.NextInputs = new Queue<string>(new[] { "1" });
            Console.SetIn(new StringReader(string.Join(Environment.NewLine, _fakeWrongInput.NextInputs)));

            
            squadMethods.Remove();

            
            var squad = _fakeContext.Squads.ToList();
            Assert.That(1.Equals(squad.Count));
        }

        [Test]
        public void Update_ShouldModifyExistingBattle()
        {
            
            _fakeWrongInput.NextInputs = new Queue<string>(new[]
            {
              "1", "Updated Squad Name"
            });
            Console.SetIn(new StringReader(string.Join(Environment.NewLine, _fakeWrongInput.NextInputs)));




            
            squadMethods.Update();

            
            var squads = _fakeContext.Squads.FirstOrDefault(b => b.Id == 1);
            
            Assert.That(squads, Is.Not.Null);
            Assert.That("Updated Squad Name".Equals(squads.Name));
        }
    }
}

