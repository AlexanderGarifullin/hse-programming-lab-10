using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task10
{
    public class Exam: Trial
    {
        static string[] TypesExam = { "Обязательный", "Необязательный" };
        public string TypeExam { get; set; }        
        public Exam():base()
        {
            TypeExam = "Нет типа экзамена";
        }
        public Exam(int num, string _trialName, string _discipline, string _typeExam, int _duration, int _taskNumber):base (num, _trialName, _discipline, _duration, _taskNumber)
        {
            TypeExam = _typeExam;
        }
        public new void Show()
        {
            base.Show();
            Console.WriteLine($"Тип экзамена = {TypeExam}");
        }
        public override void VirtualShow()
        {
            base.VirtualShow();
            Console.WriteLine($"Тип экзамена = {TypeExam}");
        }
        public override bool Equals(object obj)
        {
            if (obj is Exam Exam)
                return this.TaskNumber == Exam.TaskNumber & String.Compare(this.Discipline, Exam.Discipline) == 0
                    & String.Compare(this.TrialName, Exam.TrialName) == 0 & String.Compare(this.TypeExam, Exam.TypeExam) == 0
                    & this.Duration == Exam.Duration;
            return false;
        }
        public override string ToString()
        {
            return base.ToString() + $"; Тип экзамена = {TypeExam}";
        }
        public virtual void Init()
        {
            base.Init();
            TrialName = $"Экзамен {rnd.Next(1, 5)}";
            TypeExam = TypesExam[rnd.Next(TypesExam.Length)];
        }
    }
}
