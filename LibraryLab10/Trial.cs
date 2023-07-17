using System;

namespace LibraryLab10
{
    public class Trial //испытание
    {
        protected int taskNumber; // число заданий 
        public MyEnumerator GetEnumerator() => new MyEnumerator();
        /// <summary>
        /// Свойство для числа заданий в испытании
        /// </summary>
        public int TaskNumber
        {
            get => taskNumber;
            set
            {
                if (value > 1)
                    taskNumber = value;
                else
                {
                    Console.WriteLine("Количество заданий не может быть меньше одного!");
                    taskNumber = 0;
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
            TaskNumber = 0;
            Discipline = "Error!";
            TrialName = "Error!";
        }
        public Trial(string _trialName, string _discipline, int _taskNumber)
        {
            TrialName = _trialName;
            Discipline = _discipline;
            TaskNumber = _taskNumber;
        }
        #endregion
        public void Show()
        {
            Console.WriteLine($"Название испытания = {TrialName}; дисциплина испытания = {Discipline}; количество заданий = {TaskNumber}");
        }
        public virtual void VirtualShow()
        {
            Console.WriteLine($"Название испытания = {TrialName}; дисциплина испытания = {Discipline}; количество заданий = {TaskNumber}");
        }
    }
}
