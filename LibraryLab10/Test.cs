using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryLab10
{
    public class Test : Trial
    {
        public string TypeTest { get; set; }
        public Test() : base()
        {
            TypeTest = "Нет типа теста";
        }
        public Test(string _trialName, string _discipline, string _typetest, int _taskNumber) : base(_trialName, _discipline, _taskNumber)
        {
            TypeTest = _typetest;
        }
        public new void Show()
        {
            base.Show();
            Console.WriteLine($"Тип теста = {TypeTest}");
        }
        public override void VirtualShow()
        {
            base.VirtualShow();
            Console.WriteLine($"Тип теста = {TypeTest}");
        }
    }
}
