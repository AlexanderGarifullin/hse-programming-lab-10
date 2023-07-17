using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task10
{
    public class Test:Trial
    {
        static string[] TypesTest = { "Открытый", "Закрытый" };
        public string TypeTest { get; set; }
        public Test():base()
        {
            TypeTest = "Нет типа теста";
        }
        public Test(int num, string _trialName, string _discipline, string _typetest, int _duration, int _taskNumber):base(num, _trialName, _discipline, _duration, _taskNumber)
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
        public override bool Equals(object obj)
        {
            if (obj is Test test)
                return this.TaskNumber == test.TaskNumber & String.Compare(this.Discipline, test.Discipline) == 0 
                    & String.Compare(this.TrialName, test.TrialName) == 0 & String.Compare(this.TypeTest, test.TypeTest) == 0
                    & this.Duration == test.Duration;       
            return false;
        }
        public override string ToString()
        {
            return base.ToString() + $"; Тип теста = {TypeTest}";
        }
        public override void Init()
        {
            base.Init();
            TrialName = $"Тест {rnd.Next(1,15)}";
            TypeTest = TypesTest[rnd.Next(TypesTest.Length)];
        }
        public override object Clone() // глубокое копирование
        {
            return new Test(this.id.number, this.TrialName, this.Discipline, this.TypeTest, this.Duration, this.TaskNumber);
        }
        public override object ShallowCopy() // поверхностное копирование, скопирутет только ссылку
        {
            return this.MemberwiseClone();
        }
    } 
}
