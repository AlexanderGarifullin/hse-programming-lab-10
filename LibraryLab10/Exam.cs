using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryLab10
{
    public class Exam : Trial
    {
        public string TypeExam { get; set; }
        public Exam() : base()
        {
            TypeExam = "Нет типа экзамена";
        }
        public Exam(string _trialName, string _discipline, string _typeExam, int _taskNumber) : base(_trialName, _discipline, _taskNumber)
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
    }
}
