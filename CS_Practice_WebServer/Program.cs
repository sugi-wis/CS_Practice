using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

//hogehoge
namespace CS_Practice_WebServer
{
    class Program
    {
        static void Main(string[] args)
        {

            #region ListIEnumerable_Practice
            /*
            List<string> list = new List<string>() { "11", "22", "33" };
            list.Add("hoge4");

            IEnumerable<string> where = list.Where((p,index) => p.Length >= 2&&index>=2);

            foreach(string s in where)
            {
                Console.WriteLine(s);
            }
            List<string> list2 = new List<string>(list);
            */
            #endregion
            #region BasicThings

            DynamicBasic1 db1 = new DynamicBasic1();

            db1.Sample(new DynamicBasic1());
            //db1.Sample(new DynamicBasic2());

            #endregion
            #region OtherThings
            BasicEnum be = new BasicEnum();
            new BasicEnum().Sample(BasicEnum.Signal.Red);

            int a = 5;
            new ClassRef().Triple(ref a);
            Console.WriteLine(a);

            ClassParams sum = new ClassParams();
            Console.WriteLine(sum.SumValues(1,2,3));

            #endregion
            #region AboutClass
            
            new ClassInheritance().DispSumValues(1, 2, 3);
            #endregion
            #region Property

            var c = new ClassProp();
            c.TypeProp = 5;
            Console.WriteLine(c.TypeProp);

            #endregion
            #region ClassIs

            var isVar = new BasicClass();
            Console.WriteLine(isVar is BasicClass);
            #endregion
            #region ClassAs
            var c1 = new ClassInheritance();
            object c2 = c1 as BasicClass;
            object c3 = (BasicClass)c1;
            object c4 = c2 as string;
            //object c5 = (string)c1;
            #endregion
            #region Generic

            var gc1 = new GenericClass<int>();
            gc1.SetValue(123);
            Console.WriteLine(gc1.value);

            var gc2 = new GenericClass<string>();
            gc2.SetValue("123");
            Console.WriteLine(gc2.value);

            #endregion
            #region Anonymous
            var top = new { name = "Hoge",age = 20};
            Console.WriteLine(top.name);

            #endregion
            #region deligate
        
            SampleDelegate d = new Program().Reverse;
            d = Double;
            d += Disp;

            d(2);
            #endregion
            #region Exceptions
            try
            {
                int a1 = 0;
                int b = 3 / a1;
            }
            catch(ArithmeticException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("end");
            }
            #endregion
            #region Using
            using(StreamReader sr = new StreamReader(@"../../Program.cs",System.Text.Encoding.Default))
            {
                string text = sr.ReadToEnd();
                Console.Write(text);
            }
            #endregion
        }
        void Reverse(int n) { n *= -1; }
        static void Double(int n) { n *= 2; }
        static void Disp(int n) { Console.WriteLine(n); }
        
    }

    delegate void SampleDelegate(int x);
    class Delegate
    {
        
    }
    class GenericClass<T>
    {
        public T value;
        public void SetValue(T val) { value = val; }
        public T GetValue() { return value; }
    }
    class ClassProp
    {
        int val = 0;
        public int TypeProp
        {
            //get;set;
            set { this.val = value; }
            get { return this.val; }

        }
    }
    public class ClassInheritance:BasicClass
    {
        public void DispSumValues(params int[] values)
        {
            Console.WriteLine(SumValues(values));
        }
    }
    public class BasicClass
    {
        public int SumValues(params int[] values)
        {
            int sum = 0;
            foreach (int v in values) sum += v;
            
            return sum;
        }
    }
    class DynamicBasic1
    {
        public void Sample(dynamic obj)
        {
            obj.method();
        }
        void method()
        {

        }
    }
    class DynamicBasic2
    {
        void method()
        {

        }
    }
    class BasicEnum
    {
        public enum Signal {Blue,Yellow,Red };
        public void Sample(Signal s)
        {
            switch(s)
            {
                case Signal.Yellow:
                case Signal.Red: Console.WriteLine("危険"); break;
            }
        }
    }
    class ClassRef
    {
        public void Triple(ref int a)
        {
            a *= 3;
        }
    }
    class ClassParams
    {
        public int SumValues(params int[] value)
        {
            int sum = 0;
            foreach(int v in value)
            {
                sum += v;
            }
            return sum;
        }
    }
}
