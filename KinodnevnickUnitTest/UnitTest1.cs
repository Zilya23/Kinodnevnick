using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Core;
using Core.DateBase;
using System.Linq;
using System.Collections.Generic;

namespace KinodnevnickUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMergeCollection()
        {
            List<Film_Collection> expectedFilm_Collection = new List<Film_Collection>()
            {
                new Film_Collection { ID_Film = 2, ID_Collection = 15 }
            };
            List<Film_Collection> actualFilm_Collection = FriendFunction.TestMerge();
            
            CollectionAssert.AreEqual(expectedFilm_Collection.Select(c => c.ID_Collection).ToList(), actualFilm_Collection.Select(c => c.ID_Collection).ToList());
            CollectionAssert.AreEqual(expectedFilm_Collection.Select(c => c.ID_Film).ToList(), actualFilm_Collection.Select(c => c.ID_Film).ToList());
        }

        [TestMethod]
        public void TestGetFilmID()
        {
            Film expectedFilm = new Film()
            {
                ID = 1,
                Name = "Бэтмен",
                Description = "После двух лет поисков правосудия на улицах Готэма для своих сограждан Бэтмен становится олицетворением" +
                " беспощадного возмездия. Когда в городе происходит серия жестоких нападений на представителей элиты, улики приводят" +
                " Брюса Уэйна в самые темные закоулки преступного мира, где он встречает Женщину-Кошку, Пингвина, Кармайна Фальконе" +
                " и Загадочника. Теперь под прицелом оказывается сам Бэтмен, которому предстоит отличить друга от врага и восстановить" +
                " справедливость во имя Готэма.",
                Poster = null,
                Date_Issue = new DateTime(2022, 03, 01, 0, 0, 0),
                Duration = 176
            };
            Film actualFilm = FilmFunction.GetFilmInfo(1);
            Assert.AreEqual(expectedFilm.ID, actualFilm.ID);
            Assert.AreEqual(expectedFilm.Name, actualFilm.Name);
        }

        [TestMethod]
        public void TestAwardDone()
        {
            List<Award_User> exeptedAward_s = new List<Award_User>()
            {
                new Award_User { ID_Award = 1, ID_User = 7, IsDone = null },
                new Award_User { ID_Award = 2, ID_User = 7, IsDone = true },
                new Award_User { ID_Award = 3, ID_User = 7, IsDone = null },
                new Award_User { ID_Award = 4, ID_User = 7, IsDone = null },
                new Award_User { ID_Award = 5, ID_User = 7, IsDone = null },
                new Award_User { ID_Award = 6, ID_User = 7, IsDone = true },
                new Award_User { ID_Award = 7, ID_User = 7, IsDone = null }
            };
            List<Award_User> actualAward_s = AwardFunction.GetAward_Users(7);
            CollectionAssert.AreEqual(exeptedAward_s.Select(x => x.ID_User).ToList(), actualAward_s.Select(x => x.ID_User).ToList());
            CollectionAssert.AreEqual(exeptedAward_s.Select(x => x.ID_Award).ToList(), actualAward_s.Select(x => x.ID_Award).ToList());
            CollectionAssert.AreEqual(exeptedAward_s.Select(x => x.IsDone).ToList(), actualAward_s.Select(x => x.IsDone).ToList());
        }
        [TestMethod]
        public void TestStatisticCorrect()
        {
            int actualVF = StatisticFunction.CountViewedFilm(7);
            int expectedVF = 1;
            Assert.AreEqual(actualVF, expectedVF);
            int actualVT = StatisticFunction.CountTimeViewedFilm(7);
            int exeptedVT = 148;
            Assert.AreEqual(actualVT, exeptedVT);
            int actualAC = StatisticFunction.CountAward(7);
            int exeptedAC = 2;
            Assert.AreEqual(actualAC, exeptedAC);
            int actualTC = StatisticFunction.CountDoneTest(7);
            int exeptedTC = 5;
            Assert.AreEqual(actualTC, exeptedTC);
         }
    }
}
