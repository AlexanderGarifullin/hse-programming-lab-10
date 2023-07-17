using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task10
{
    public class FinalExam: Exam
    {
        private int graduationYear;
        static string[] TrialNames = {"Финальный экзамен", "ЕГЭ", "ОГЭ" };
        public int GraduationYear
        {
            get => graduationYear;
            set
            {
                if (value >= 0)
                    graduationYear = value;
                else
                {
                    Console.WriteLine("Год выпуска не может быть меньше 0!");
                    graduationYear = 0;
                }
            }
        }
        public FinalExam() : base()
        {
            GraduationYear = 0;
        }
        public FinalExam(int num, string _trialName, string _discipline, string _typeExam, int _duration, int _taskNumber, int _graduationYear): base(num, _trialName, _discipline, _typeExam, _duration, _taskNumber)
        {
            GraduationYear = _graduationYear;
        }
        public new void Show()
        {
            base.Show();
            Console.WriteLine($"; Год выпуска = {GraduationYear}");
        }
        public override void VirtualShow()
        {
            base.VirtualShow();
            Console.WriteLine($"Год выпуска = {GraduationYear}");
        }
        public override bool Equals(object obj)
        {
            if (obj is FinalExam finalExam)
                return this.TaskNumber == finalExam.TaskNumber & String.Compare(this.Discipline, finalExam.Discipline) == 0 
                    & String.Compare(this.TrialName, finalExam.TrialName) == 0 & this.GraduationYear == finalExam.graduationYear
                    & String.Compare(this.TypeExam, finalExam.TypeExam) == 0 & this.Duration == finalExam.Duration;
            return false;
        }
        public override string ToString()
        {
            return base.ToString() + $"; Год выпуска = {GraduationYear}";
        }
        public override void Init()
        {
            base.Init();
            GraduationYear = rnd.Next(2000, 2022);
            TrialName = TrialNames[rnd.Next(TrialNames.Length)];
        }
    }
}
