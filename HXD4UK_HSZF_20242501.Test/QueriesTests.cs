using HXD4UK_HSZF_20242501.Application;
using HXD4UK_HSZF_20242501.Model;
using HXD4UK_HSZF_20242501.Persistence.MsSql;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXD4UK_HSZF_20242501.Test
{
    [TestFixture]
    public class QueriesTests
    {
        private Fake_Klonokhaborujadbcontext _fakeContext;
        private _501st_Legion _501St_Legion;
        private Biggest Biggest;
        private Kamino kamino;
        private Geonosis Geonosis;
        private CloneParty CloneParty;

        [SetUp]
        public void Setup()
        {
            _fakeContext = new Fake_Klonokhaborujadbcontext();
            _501St_Legion = new _501st_Legion(_fakeContext);
            Biggest = new Biggest(_fakeContext);
            kamino = new Kamino(_fakeContext);
            Geonosis = new Geonosis(_fakeContext);
            CloneParty = new CloneParty(_fakeContext);

            _fakeContext.Squads.Add(new Squads { Id = 1, Name = "Squad A", Commander = "Anakin" });
            _fakeContext.Squads.Add(new Squads { Id = 2, Name = "Squad B", Commander = "Bela" });
            _fakeContext.Squads.Add(new Squads { Id = 3, Name = "501st Legion", Commander = "Leva" });
            _fakeContext.Squads.Add(new Squads { Id = 4, Name = "212th Attack Battalion", Commander = "Commander Cody" });
            _fakeContext.Squads.Add(new Squads { Id = 5, Name = "Wolfpack", Commander = "Commander Wolffe" });

            _fakeContext.Clones.Add(new Clones { Id = 1, Name = "Clone A", Designation = "ASD", Rank = "s", Squad_id = 1 });
            _fakeContext.Clones.Add(new Clones { Id = 2, Name = "Clone B", Designation = "SD", Rank = "asds", Squad_id = 2 });
            _fakeContext.Clones.Add(new Clones { Id = 3, Name = "Clone C", Designation = "D", Rank = "as", Squad_id = 3 });
            _fakeContext.Clones.Add( new Clones { Id = 4, Name = "Clone D", Designation = "CT-7567", Rank = "Captain", Squad_id = 4});
            _fakeContext.Clones.Add(new Clones { Id = 5, Name = "Clone E", Designation = "CT-2224", Rank = "Sergeant", Squad_id = 4});
            _fakeContext.Clones.Add(new Clones { Id = 6, Name = "Clone H", Designation = "CT-1010", Rank = "Private", Squad_id = 1});

            _fakeContext.Battles.Add(new Battles { Id = 1, Name = "Battle X", Location = "Planet Y", Date = "2024-01-01", Clones = [1, 2] });
            _fakeContext.Battles.Add(new Battles { Id = 2, Name = "Battle Z", Location = "Planet K", Date = "2024-03-12", Clones = [1, 2, 3] });
            _fakeContext.Battles.Add(new Battles { Id = 3, Name = "Battle of Kamino", Location = "Kamino", Date = "2042-06-21", Clones = [3] });
            _fakeContext.Battles.Add(new Battles { Id = 4, Name = "Battle of Geonosis", Location = "Geonosis", Date = "1342-12-11", Clones = [1,4,5] });
            _fakeContext.SaveChanges();

            var battles = _fakeContext.Battles.ToList();

            foreach (var battle in battles)
            {
                foreach (var cloneId in battle.Clones)
                {
                    var relationship = new Battlestoclones
                    {
                        BattleId = battle.Id,
                        CloneId = cloneId
                    };

                    _fakeContext.Battlestoclones.Add(relationship);
                }
            }


            _fakeContext.SaveChanges();
        }

        [Test]
        public void BiggestTest()
        {
            Battles expectedBattle = _fakeContext.Battles.FirstOrDefault(x=>x.Id==2);
            var result = Biggest.Big();

            Assert.That(expectedBattle.Equals(result));

        }



        [Test]
        public void _501st_LegionTest()
        {
            var expectedBattle = _fakeContext.Clones.Where(x => x.Squad_id == 3).ToList();
            var result = _501St_Legion._501_Legion();

            Assert.That(result.Count.Equals(1));
            Assert.That(result.First().Equals(expectedBattle.First()));
        }

        [Test]
        public void _3AtlestTest()
        {
            
            var result = _501St_Legion._3_Atleast();

            Assert.That(result,Is.Empty);

        }
        [Test]
        public void KaminoTest()
        {
            var expected = _fakeContext.Clones.Where(x=>x.Id==3);

            var result = kamino.KaminoBattle();

            Assert.That(result.Count.Equals(1));
            Assert.That(result.First().Equals(expected.First()));
        }

        [Test]
        public void GeonosisTest()
        {
            var expected= _fakeContext.Clones.Where(_ => _.Id==4);

            var result = Geonosis.Geo();

            Assert.That(result,Is.Not.Null);
            Assert.That(result.First().Equals(expected.First()));
        }

        [Test]
        public void PartyTest()
        {
            Clones clone1 = _fakeContext.Clones.FirstOrDefault(x=>x.Id==1);
            Clones clone2 = _fakeContext.Clones.FirstOrDefault(x => x.Id == 2);

            List<Clones> clones = new List<Clones>();
            clones.Add(clone1);
            clones.Add(clone2);

            var result = CloneParty.Party();

            Assert.That(result,Is.Not.Null);
            Assert.That(result[0].Equals(clone1));
            Assert.That(result[1].Equals(clone2));

        }





    }
}
