using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task10
{
    public class Program
    {

        /// <summary>
        /// Найти экзамены с определенным числом заданий
        /// </summary>
        /// <param name="arr"></param>
        public int GetCountExam(Trial[] arr, int taskCount)
        {
            int count = 0;
            foreach (Trial trial in arr)
                if (trial is Exam exam)
                    if (exam.TaskNumber == taskCount)
                    {
                        exam.VirtualShow();
                        count++;
                    }
            return count;
        }

        /// <summary>
        /// Найти тесты по определенной дисциплине
        /// </summary>
        /// <param name="arr"></param>
        public int GetDisciplineTest(Trial[] arr, string discipline)
        {
            int count = 0;
            foreach (Trial trial in arr)
                if (trial is Test test)
                    if (test.Discipline == discipline)
                    {
                        test.VirtualShow();
                        count++;
                    }
            return count;
        }
        /// <summary>
        /// Количество выпускных экзаменов в определенном году
        /// </summary>
        /// <param name="arr"></param>
        public int GetCountFinalExam(Trial[] arr, int graduationYear)
        {
            int count = 0;
            foreach (Trial trial in arr)
                if (trial is FinalExam finalExam)
                    if (finalExam.GraduationYear == graduationYear)
                        count++;
            return count;
        }
        static void Main(string[] args)
        {
            #region Часть 1
            Trial trial1 = new Trial();
            Trial trial2 = new Trial(2,"Контрольная работа", "История", 5, 5);
            Test test1 = new Test(3,"Тест по физике №1", "Физика", "Открытый", 60, 30);
            Test test2 = new Test(4,"Тест по истории", "История", "Закрытый", 20, 10);
            Test test3 = new Test(5,"Тест по физике №2", "Физика", "Закрытый", 30, 15);
            Exam exam1 = new Exam(6,"Экзамен 1", "Программирование", "Необязательный", 60, 10);
            Exam exam2 = new Exam(7,"Экзамен 2", "Программирование", "Обязательный", 60, 10);

            FinalExam finalExam1 = new FinalExam(8,"ЕГЭ", "Математика", "Обязательный", 235, 19, 2022);
            FinalExam finalExam2 = new FinalExam(9,"ОГЭ", "Математика", "Обязательный", 235, 26, 2022);
            FinalExam finalExam3 = new FinalExam(10,"ЕГЭ", "Химия", "Обязательный", 180, 34, 2022);

            Trial[] arr = { trial1, trial2, test1, test2, test3, exam1, exam2, finalExam1, finalExam2, finalExam3 };
            Console.WriteLine("Часть 1");
            Console.WriteLine("Вывод массивов:");
            Console.WriteLine("Печть без виртуальных методов:"); // воспринимаются как объекты типа trial
            foreach (Trial trial in arr)            // повышающее преобразование
                trial.Show();
            Console.WriteLine();
            Console.WriteLine("Печть с помощью виртуальных методов:"); // воспринимаются как разные объекты
            foreach (Trial trial in arr)
                trial.VirtualShow();
            int choice;
            Console.WriteLine();
            #endregion
            #region Часть 2
            Program pr = new Program();
            Console.WriteLine("Часть 2");
            do
            {
                Console.WriteLine("Запросы:");
                Console.WriteLine("1. Найти тесты по определенной дисциплине");
                Console.WriteLine("2. Найти экзамены с определенным число заданий");
                Console.WriteLine("3. Количество выпускных экзаменов в определенном году");
                Console.WriteLine("4. Выход");
                choice = UI.Input(1, 4, "Выберите запрос: ");
                switch (choice)
                {
                    case 1:
                        {
                            Console.WriteLine("Введите дисциплину, тесты по которой вы хотите найти:");
                            string discipline = Console.ReadLine();
                            Console.WriteLine("Количество тестов по дисциплине  = " + pr.GetDisciplineTest(arr, discipline));  ;
                            break;
                        }
                    case 2:
                        {
                            int taskCount = UI.Input(1, int.MaxValue, "Введите: экзамены со сколькими заданиями вы хотите найти");
                            Console.WriteLine("Количество экзаменов = " +  pr.GetCountExam(arr, taskCount));
                            break;
                        }
                    case 3:
                        {
                            int graduationYear = UI.Input(0, int.MaxValue, "Ведите год, в котором вы хотите узнать количество выпускных экзаменов");
                            Console.WriteLine($"Количество выпускных экзаменов в {graduationYear} = {pr.GetCountFinalExam(arr, graduationYear)}");
                            break;
                        }
                    case 4:
                        break;
                }
            } while (choice != 4);
            Console.WriteLine();
            #endregion Часть 2
            #region Часть 3
            Console.WriteLine("Часть 3");
            IInit[] array = new IInit[10];
            for (int i = 0; i < 5; i++)
            {
                if (i % 3 == 0)
                {
                    Test t = new Test();
                    t.Init();
                    array[i] = t;
                }
                else if (i % 3 == 1)
                {
                    Exam e = new Exam();
                    e.Init();
                    array[i] = e;
                }
                else
                {
                    FinalExam fE = new FinalExam();
                    fE.Init();
                    array[i] = fE;
                }
            }
            for (int i = 5; i < 10; i++)
            {
                array[i] = new Animal();
                array[i].Init();
            }
            foreach (IInit x in array)
                Console.WriteLine(x);
            Console.WriteLine();

            Trial[] arrayTrial = new Trial[10];
            for (int i = 0; i < 10; i++)
            {
                if (i % 3 == 0)
                {
                    Test t = new Test();
                    t.Init();
                    arrayTrial[i] = t;
                }
                else if (i % 3 == 1)
                {
                    Exam e = new Exam();
                    e.Init();
                    arrayTrial[i] = e;
                }
                else
                {
                    FinalExam fE = new FinalExam();
                    fE.Init();
                    arrayTrial[i] = fE;

                }
            }
            Array.Sort(arrayTrial);
            Console.WriteLine("Отсортированный по названию испытания массив");
            foreach (Trial x in arrayTrial)
                Console.WriteLine(x);
            Console.WriteLine();

            Array.Sort(arrayTrial, new SortByDuration());
            Console.WriteLine("Отсортированный по длительности испытания массив");
            foreach (Trial x in arrayTrial)
                Console.WriteLine(x);
            Console.WriteLine();

            Console.WriteLine("Клонирование Animal");
            Animal[] arrAnimal = { (Animal)array[5], (Animal)array[6], (Animal)array[7] };
            Animal an1 = new Animal(arrAnimal[0].id.number, arrAnimal[0].Name, arrAnimal[0].Age);
            Animal an2 = (Animal)arrAnimal[0].Clone();
            Animal an3 = (Animal)arrAnimal[0].ShallowCopy();
            Console.WriteLine("Первоначальный элемент = " + arrAnimal[0]);
            arrAnimal[0].Name = arrAnimal[0].Name + "Clone";
            arrAnimal[0].id.number = 200;
            Console.WriteLine("Измененный элемент = " + arrAnimal[0]);
            Console.WriteLine("Клонирование");
            Console.WriteLine("Через new = " + an1);
            Console.WriteLine("Через глубокое копирование = " + an2);
            Console.WriteLine("Через поверхностное копирование = " + an3);
            Console.WriteLine();

            Console.WriteLine("Клонирование Trial");
            Trial trialNew1 = new Trial(trial2.id.number, trial2.TrialName, trial2.Discipline, trial2.Duration, trial2.TaskNumber);
            Trial trialNew2 = (Trial)trial2.Clone();
            Trial trialNew3 = (Trial)trial2.ShallowCopy();
            Console.WriteLine("Первоначальный элемент = " + trial2);
            trial2.TrialName = trial2.TrialName + "Clone";
            trial2.id.number = 200;
            Console.WriteLine("Измененный элемент = " + trial2);
            Console.WriteLine("Клонирование");
            Console.WriteLine("Через new = " + trialNew1);
            Console.WriteLine("Через глубокое копирование = " + trialNew2);
            Console.WriteLine("Через поверхностное копирование = " + trialNew3);
            Console.WriteLine();

            Console.WriteLine("Клонирование Test");
            Test testNew1 = new Test(test1.id.number, test1.TrialName, test1.Discipline, test1.TypeTest, test1.Duration, test1.TaskNumber);
            Test testNew2 = (Test)test1.Clone();
            Test testlNew3 = (Test)test1.ShallowCopy();
            Console.WriteLine("Первоначальный элемент = " + test1);
            test1.TrialName = test1.TrialName + "Clone";
            test1.id.number = 200;
            Console.WriteLine("Измененный элемент = " + test1);
            Console.WriteLine("Клонирование");
            Console.WriteLine("Через new = " + testNew1);
            Console.WriteLine("Через глубокое копирование = " + testNew2);
            Console.WriteLine("Через поверхностное копирование = " + testlNew3);
            Console.WriteLine();
            #endregion
        }
    } 
}


