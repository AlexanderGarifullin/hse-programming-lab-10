using System;
using LibraryLab10;
namespace l10
{
    public class Program
    {
        /// <summary>
        /// Найти экзамены с определенным число заданий
        /// </summary>
        /// <param name="arr"></param>
        static void GetCountExam(Trial[] arr)
        {
            int count = 0;
            int taskCount = UI.Input(0, int.MaxValue, "Введите: экзамены со сколькими заданиями вы хотите найти");
            foreach (Trial trial in arr)
                if (trial is Exam test)
                    if (test.TaskNumber == taskCount)
                    {
                        test.VirtualShow();
                        count++;
                    }
            if (count == 0)
                Console.WriteLine("Таких экзаменов нет");
        }

        /// <summary>
        /// Найти тесты по определенной дисциплине
        /// </summary>
        /// <param name="arr"></param>
        static void GetDisciplineTest(Trial[] arr)
        {
            int count = 0;
            Console.WriteLine("Введите дисциплину, тесты по которой вы хотите найти:");
            string discipline = Console.ReadLine();
            foreach (Trial trial in arr)
                if (trial is Test test)
                    if (test.Discipline == discipline)
                    {
                        test.VirtualShow();
                        count++;
                    }
            if (count == 0)
                Console.WriteLine("Таких тестов нет");
        }
        /// <summary>
        /// Количество выпускных экзаменов в определенном году
        /// </summary>
        /// <param name="arr"></param>
        static void GetCountFinalExam(Trial[] arr)
        {
            int count = 0;
            int graduationYear = UI.Input(0, int.MaxValue, "Ведите год, в котором вы хотите узнать количество выпускных экзаменов");
            foreach (Trial trial in arr)
                if (trial is FinalExam finalExam)
                    if (finalExam.GraduationYear == graduationYear)
                        count++;
            Console.WriteLine($"Количество выпускных экзаменов в {graduationYear} = {count}");

        }
        static void Main(string[] args)
        {
            Trial trial1 = new Trial();
            Trial trial2 = new Trial("Контрольная работа", "История", 5);
            Test test1 = new Test("Тест по физике №1", "Физика", "Открытый", 30);
            Test test2 = new Test("Тест по истории", "История", "Закрытый", 10);
            Test test3 = new Test("Тест по физике №2", "Физика", "Закрытый", 15);
            Exam exam1 = new Exam("Экзамен 1", "Программирование", "Необязательный", 10);
            Exam exam2 = new Exam("Экзамен 2", "Программирование", "Обязательный", 10);

            FinalExam finalExam1 = new FinalExam("ЕГЭ", "Математика", "Обязательный", 19, 2021);
            FinalExam finalExam2 = new FinalExam("ЕГЭ", "Математика", "Обязательный", 19, 2021);
            FinalExam finalExam3 = new FinalExam("ЕГЭ", "Математика", "Обязательный", 19, 2021);

            Trial[] arr = { trial1, trial2, test1, test2, test3, exam1, exam2, finalExam1, finalExam2, finalExam3 };
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
                            GetDisciplineTest(arr);
                            break;
                        }
                    case 2:
                        {
                            GetCountExam(arr);
                            break;
                        }
                    case 3:
                        {
                            GetCountFinalExam(arr);
                            break;
                        }
                    case 4:
                        break;
                }
            } while (choice != 4);
        }
    }
}
