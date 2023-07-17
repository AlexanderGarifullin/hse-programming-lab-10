using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryLab10
{
    public class FinalExam : Exam
    {
        private int graduationYear;
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
        public FinalExam(string _trialName, string _discipline, string _typeExam, int _taskNumber, int _graduationYear) : base(_trialName, _discipline, _typeExam, _taskNumber)
        {
            GraduationYear = _graduationYear;
        }
        public new void Show()
        {
            base.Show();
            Console.WriteLine($"Год выпуска = {GraduationYear}");
        }
        public override void VirtualShow()
        {
            base.VirtualShow();
            Console.WriteLine($"Год выпуска = {GraduationYear}");
        }
    }
}
