using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Task10;
namespace UnitTestProject10
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CreateTestTrial_durationException()
        {
            Test t1 = new Test(2, "Контрольная работа", "История", "Открытый", 0, 10);
            Test t2 = new Test(2, "Контрольная работа", "История", "Открытый", 1, 10);
            Assert.AreEqual(t1, t2);
        }
        [TestMethod]
        public void CreateTestTrial_taskNumberException()
        {
            Test t1 = new Test(2, "Контрольная работа", "История", "Открытый", 5, 0);
            Test t2 = new Test(2, "Контрольная работа", "История", "Открытый", 5, 1);
            Assert.AreEqual(t1, t2);
        }
        [TestMethod]
        public void CreateTrial_defaultСonstructor()
        {
            Trial t1 = new Trial();
            Trial t2 = new Trial(1, "Error!", "Error!", 1, 1);
            Assert.AreEqual(t1, t2);
        }
        [TestMethod]
        public void CreateTrial_Clone()
        {
            Trial t1 = new Trial(2, "Контрольная работа", "История", 5, 5);
            Trial t2 = (Trial)t1.Clone();
            Assert.AreEqual(t1, t2);
        }
        [TestMethod]
        public void CreateTrial_ShallowCopy()
        {
            Trial t1 = new Trial(2, "Контрольная работа", "История", 5, 5);
            Trial t2 = (Trial)t1.ShallowCopy();
            Assert.AreEqual(t1, t2);
        }
        [TestMethod]
        public void Trial_CompareTo_True()
        {
            Trial t1 = new Trial(2, "Контрольная работа 1", "История", 5, 5);
            Trial t2 = new Trial(2, "Контрольная работа 2", "История", 5, 5); ;
            Trial[] tArray1 = { t2, t1 };
            Trial[] tArray2 = { t1, t2 };
            Array.Sort(tArray1);
            Assert.AreEqual(tArray1[0], tArray2[0]);
        }
        [TestMethod]
        public void Trial_CompareTo_false()
        {
            Trial t1 = new Trial(); 
            Animal a = new Animal();
            Assert.AreEqual(-1, t1.CompareTo(a));
        }
        [TestMethod]
        public void Trial_Compare_SortByDuration_FirstMoreSecond()
        {
            Trial t1 = new Trial(2, "Контрольная работа", "История", 50, 5);
            Trial t2 = new Trial(2, "Контрольная работа", "История", 5, 5);
            
            Trial[] tArray1 = { t1, t2 };
            Trial[] tArray2 = { t2, t1 };
            Array.Sort(tArray1, new SortByDuration());
            Assert.AreEqual(tArray1[0], tArray2[0]);
        }
        [TestMethod]
        public void Trial_Compare_SortByDuration_FirstLessSecond()
        {
            Trial t1 = new Trial(2, "Контрольная работа", "История", 50, 5);
            Trial t2 = new Trial(2, "Контрольная работа", "История", 5, 5);

            Trial[] tArray1 = { t2, t1 };
            Trial[] tArray2 = { t2, t1 };
            Array.Sort(tArray1, new SortByDuration());
            Assert.AreEqual(tArray1[0], tArray2[0]);
        }
        [TestMethod]
        public void Trial_Compare_SortByDuration_EqualObj()
        {
            Trial t1 = new Trial(2, "Контрольная работа", "История", 50, 5);
            Trial[] tArray1 = { t1, t1 };
            Trial[] tArray2 = { t1, t1 };
            Array.Sort(tArray1, new SortByDuration());
            Assert.AreEqual(tArray1[0], tArray2[0]);
        }
        [TestMethod]
        public void Trial_ToString()
        {
            Trial t1 = new Trial(2, "Контрольная работа", "История", 50, 5);
            string s = "2: Название испытания = Контрольная работа; дисциплина испытания = История; длительность испытания = 50 мин; количество заданий = 5";
            Assert.AreEqual(s, t1.ToString());
        }
        [TestMethod]
        public void Test_ToString()
        {
            Trial t1 = new Test(2, "Контрольная работа", "История", "Открытый", 1, 1);
            string s = "2: Название испытания = Контрольная работа; дисциплина испытания = История; длительность испытания = 1 мин; количество заданий = 1; Тип теста = Открытый";
            Assert.AreEqual(s, t1.ToString());
        }
        [TestMethod]
        public void Examt_ToString()
        {
            Exam exam1 = new Exam(6, "Экзамен", "Программирование", "Необязательный", 60, 10);
            string s = "6: Название испытания = Экзамен; дисциплина испытания = Программирование; длительность испытания = 60 мин; количество заданий = 10; Тип экзамена = Необязательный";
            Assert.AreEqual(s, exam1.ToString());
        }
        [TestMethod]
        public void FinalExamt_ToString()
        {
            Exam fe = new FinalExam(6, "Экзамен", "Программирование", "Необязательный", 60, 10, 2022);
            string s = "6: Название испытания = Экзамен; дисциплина испытания = Программирование; длительность испытания = 60 мин; количество заданий = 10; Тип экзамена = Необязательный; Год выпуска = 2022";
            Assert.AreEqual(s, fe.ToString());
        }
        [TestMethod]
        public void Animal_ToString()
        {
            Animal a = new Animal(1, "Волк", 10);
            string s = "1: Волк, 10";
            Assert.AreEqual(s, a.ToString());
        }
        [TestMethod]
        public void CheckTest_Init()
        {
            Test t = new Test();
            t.Init();
            Trial t1 = new Trial(2, "Контрольная работа", "История", 5, 5);
            Assert.AreNotEqual(t, t1);
        }
        [TestMethod]
        public void CreateTest_Clone()
        {
            Test t1 = new Test(3, "Тест по физике №1", "Физика", "Открытый", 60, 30);
            Test t2 = (Test)t1.Clone();
            Assert.AreEqual(t1, t2);
        }
        [TestMethod]
        public void CreateTest_ShallowCopy()
        {
            Test t1 = new Test(3, "Тест по физике №1", "Физика", "Открытый", 60, 30);
            Test t2 = (Test)t1.ShallowCopy();
            Assert.AreEqual(t1, t2);
        }
        [TestMethod]
        public void CreateExam_defaultСonstructor()
        {
            Exam e1 = new Exam();
            Exam e2 = new Exam(1, "Error!", "Error!", "Нет типа экзамена", 1, 1);
            Assert.AreEqual(e1, e2);
        }
        [TestMethod]
        public void CheckExam_Init()
        {
            Exam e = new Exam();
            e.Init();
            Exam e1 = new Exam(6, "Экзамен 1", "Программирование", "Необязательный", 60, 10);
            Assert.AreNotEqual(e, e1);
        }
        [TestMethod]
        public void CreateFinalExam_defaultСonstructor()
        {
            FinalExam fe1 = new FinalExam();
            FinalExam fe2 = new FinalExam(1, "Error!", "Error!", "Нет типа экзамена", 1, 1, 0);
            Assert.AreEqual(fe1, fe2);
        }
        [TestMethod]
        public void CheckFinalExam_Init()
        {
            FinalExam fe = new FinalExam();
            fe.Init();
            FinalExam fe1 = new FinalExam(6, "Экзамен 1", "Программирование", "Необязательный", 60, 10, 0);
            Assert.AreNotEqual(fe, fe1);
        }
        [TestMethod]
        public void CreateFinalExam_graduationYearException()
        {
            FinalExam fe1 = new FinalExam(6, "Экзамен 1", "Программирование", "Необязательный", 60, 10, -1);
            FinalExam fe2 = new FinalExam(6, "Экзамен 1", "Программирование", "Необязательный", 60, 10, 0);
            Assert.AreEqual(fe1, fe2);
        }
        [TestMethod]
        public void CreateIdNumber_Equal()
        {
            IdNumber id1 = new IdNumber(1);
            IdNumber id2 = new IdNumber(1);
            Assert.AreEqual(id1, id2);
        }
        [TestMethod]
        public void CheckAnimal_Init()
        {
            Animal a1 = new Animal();
            a1.Init();
            Animal a2 = new Animal(200, "Лиса", 10);
            Assert.AreNotEqual(a1, a2);
        }
        [TestMethod]
        public void CreateAnimal_defaultСonstructor()
        {
            Animal a1 = new Animal();
            Animal a2 = new Animal(1, "NoName", 1);
            Assert.AreEqual(a1, a2);
        }
        [TestMethod]
        public void CreateAnimal_ageException()
        {
            Animal a1 = new Animal(1, "Кошка", 0);
            Animal a2 = new Animal(1, "Кошка", 1);
            Assert.AreEqual(a1, a2);
        }
        [TestMethod]
        public void CreateAnimal_Clone()
        {
            Animal a1 = new Animal(1, "Кошка", 10);
            Animal a2 = (Animal)a1.Clone();
            Assert.AreEqual(a1, a2);
        }
        [TestMethod]
        public void CreateAnimal_ShallowCopy()
        {
            Animal a1 = new Animal(1, "Кошка", 10);
            Animal a2 = (Animal)a1.ShallowCopy();
            Assert.AreEqual(a1, a2);
        }
        [TestMethod]
        public void GetCount_TaskNumber_exam()
        {
            Exam exam1 = new Exam(6, "Экзамен 1", "Программирование", "Необязательный", 60, 10);
            Exam exam2 = new Exam(7, "Экзамен 2", "Программирование", "Обязательный", 60, 5);
            Test test1 = new Test(3, "Тест по физике №1", "Физика", "Открытый", 60, 30);
            Trial[] arr = { exam1, exam2, test1 };
            Program pr = new Program();
            Assert.AreEqual(1, pr.GetCountExam(arr, 10));
        }
        [TestMethod]
        public void GetCount_Discipline_Test()
        {
            Exam exam1 = new Exam(6, "Экзамен 1", "Программирование", "Необязательный", 60, 10);
            Test test2 = new Test(5, "Тест по физике №2", "Физика", "Закрытый", 30, 15);
            Test test1 = new Test(3, "Тест по истории №1", "История", "Открытый", 60, 30);
            Trial[] arr = { exam1, test2, test1 };
            Program pr = new Program();
            Assert.AreEqual(1, pr.GetDisciplineTest(arr, "История"));
        }
        [TestMethod]
        public void GetCount_GraduationYear_FinalExam()
        {
            Exam exam1 = new Exam(6, "Экзамен 1", "Программирование", "Необязательный", 60, 10);
            FinalExam finalExam1 = new FinalExam(8, "ЕГЭ", "Математика", "Обязательный", 235, 19, 2022);
            FinalExam finalExam2 = new FinalExam(9, "ОГЭ", "Математика", "Обязательный", 235, 26, 2021);
            Trial[] arr = { exam1, finalExam1, finalExam2 };
            Program pr = new Program();
            Assert.AreEqual(1, pr.GetCountFinalExam(arr, 2022));
        }
        [TestMethod]
        public void IdNumber_Equal_False()
        {
            IdNumber Id = new IdNumber(1);
            Exam exam1 = new Exam(6, "Экзамен 1", "Программирование", "Необязательный", 60, 10);
            Assert.AreEqual(false, Id.Equals(exam1));
        }
        [TestMethod]
        public void Animal_Equal_False()
        {
            Animal a1 = new Animal(1, "Кошка", 10); ;
            Exam exam1 = new Exam(6, "Экзамен 1", "Программирование", "Необязательный", 60, 10);
            Assert.AreEqual(false, a1.Equals(exam1));
        }
        [TestMethod]
        public void Trial_Equal_True()
        {
            Trial t1 = new Trial();
            Trial t2 = new Trial();
            Assert.AreEqual(true,t1.Equals(t2));
        }
        [TestMethod]
        public void Trial_Equal_False()
        {
            Animal a = new Animal();
            Trial trial = new Trial(2, "Контрольная работа", "История", 5, 5);
            Assert.AreEqual(false, trial.Equals(a));
        }
        [TestMethod]
        public void Exam_Equal_False()
        {
            Animal a = new Animal();
            Exam e = new Exam(2, "Контрольная работа", "История","Открытый", 5, 5);
            Assert.AreEqual(false,e.Equals(a));
        }
        [TestMethod]
        public void FinalExam_Equal_False()
        {
            Animal a = new Animal();
            FinalExam fe = new FinalExam(2, "Контрольная работа", "История", "Открытый", 5, 5,2022);
            Assert.AreEqual(false, fe.Equals(a));
        }
    }
}