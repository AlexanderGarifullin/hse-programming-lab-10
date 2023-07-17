using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task10
{
    public class Trial: IInit, IComparable, ICloneable //испытание
    {
        const int BASE_MINUTE = 5;
        public IdNumber id;
        protected int taskNumber; // число заданий 
        protected int duration; // длительность в минутах
        protected static Random rnd = new Random();
        static string[] Disciplines = { "Физика", "Математика", "Русский язык", "Английский язык", "Химия", "Биология", "Программирование", "История", "Обществознание"};
        static string[] TrialNames = { "Тест", "Экзамен", "Финальный экзамен", "ЕГЭ", "ОГЭ"};
        /// <summary>
        /// Свойство для числа заданий в испытании
        /// </summary>
        public int TaskNumber
        {
            get => taskNumber;
            set
            {
                if (value > 0)
                    taskNumber = value;
                else
                {
                    Console.WriteLine("Количество заданий должно быть больше нуля!");
                    taskNumber = 1;
                }
            }
        }
        /// <summary>
        /// Свойство для длительности испытания в минутах 
        /// </summary>
        public int Duration
        {
            get => duration;
            set
            {
                if (value > 0)
                    duration = value;
                else
                {
                    Console.WriteLine("Длительность испытания должна быть больше нуля!");
                    duration = 1;
                }
            }
        }
        /// <summary>
        /// Свойства для наименования дисциплины 
        /// </summary>
        public string Discipline { get; set; }
        /// <summary>
        /// Свойство для наименования испытания
        /// </summary>
        public string TrialName { get; set; }
        #region Конструкторы
        public Trial()
        {
            TaskNumber = 1;
            Duration = 1;
            Discipline = "Error!";
            TrialName = "Error!";
            id = new IdNumber(1);
        }
        public Trial(int num, string _trialName, string _discipline, int _duration, int _taskNumber)
        {
            TrialName = _trialName;
            Discipline = _discipline;
            TaskNumber = _taskNumber;
            Duration = _duration;
            id = new IdNumber(num);
        }
        #endregion
        public void Show()
        {
            Console.WriteLine($"{id}: Название испытания = {TrialName}; дисциплина испытания = {Discipline}; длительность испытания = {Duration} мин; количество заданий = {TaskNumber}");
        }
        public virtual void VirtualShow()
        {
            Console.WriteLine($"{id}: Название испытания = {TrialName}; дисциплина испытания = {Discipline}; длительность испытания = {Duration} мин; количество заданий = {TaskNumber}");
        }
        public override bool Equals(object obj)
        {
            if (obj is Trial trial)
                return this.TaskNumber == trial.TaskNumber & String.Compare(this.Discipline, trial.Discipline) == 0  & String.Compare(this.TrialName, trial.TrialName) == 0 & this.Duration == trial.Duration;
            return false;            
        }
        public override string ToString()
        {
            return $"{id}: Название испытания = {TrialName}; дисциплина испытания = {Discipline}; длительность испытания = {Duration} мин; количество заданий = {TaskNumber}";
        }
        public virtual void Init()
        {
            TaskNumber = rnd.Next(1, 60);
            id = new IdNumber(rnd.Next(2, 100));
            Duration = BASE_MINUTE * TaskNumber;
            Discipline = Disciplines[rnd.Next(Disciplines.Length)];
            TrialName = TrialNames[rnd.Next(TrialNames.Length)];
        }

        public int CompareTo(object obj)
        {
            if (obj is Trial trial)
                return String.Compare(this.TrialName, trial.TrialName);
            return -1;
        }

        public virtual object Clone() // глубокое копирование
        {
            return new Trial(this.id.number, this.TrialName, this.Discipline, this.Duration, this.TaskNumber);
        }
        public virtual object ShallowCopy() // поверхностное копирование, скопирутет только ссылку
        {
            return this.MemberwiseClone();
        }
    }
}
