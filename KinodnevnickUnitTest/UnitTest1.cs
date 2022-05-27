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
    }
}
