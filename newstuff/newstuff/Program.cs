using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace newstuff
{
    //public delegate R Func<T, R>(T item);

    //// extension methods
    //public static class MyUtils {
    //    public static IQueryable<T> Where<T> (this IQueryable<T> list, Expression<Func<T, bool>> w){
    //        foreach (var item in list){
    //            if (w(item))
    //                yield return item;
    //        }
    //    }

    //    public static IEnumerable<R> Select<T, R>(this IEnumerable<T> list, Func<T, R> s){
    //        foreach (var item in list)
    //            yield return s(item); 
    //    }
    //}
   

    class Model{
        public string sssname
        {
            get;
            set;
        }
    }

    class Program
    {
        private static MemberExpression GetMemberInfo(Expression method)
        {
            LambdaExpression lambda = method as LambdaExpression;
            if (lambda == null)
                throw new ArgumentNullException("method");

            MemberExpression memberExpr = null;

            if (lambda.Body.NodeType == ExpressionType.Convert)
            {
                memberExpr =
                    ((UnaryExpression)lambda.Body).Operand as MemberExpression;
            }
            else if (lambda.Body.NodeType == ExpressionType.MemberAccess)
            {
                memberExpr = lambda.Body as MemberExpression;
            }

            if (memberExpr == null)
                throw new ArgumentException("method");

            return memberExpr;
        }

        static Dictionary<string, object> items = new Dictionary<string, object>(); 

        static void test(Expression<Func<string>> namefunc){
            var expression = (MemberExpression)namefunc.Body;
            string name = expression.Member.Name;
            Console.WriteLine("getting " + name);
            Console.WriteLine(items[name]);
        }



        static void Main(string[] args)
        {
            var m = new Model() { sssname = "john" };
            items.Add("sssname", "waarde");
           
                


            test(() => m.sssname);

          


            return;



            List<Person> persons = new List<Person>() 
            { 
                new Person() { Name = "John"}, 
                new Person() { Name = "Jaap"}, 
                new Person() { Name = "Piet"}, 
                new Person() { Name = "Kees"} 
            };

            var result = persons.Where((item) => item.Name.Equals("John")).Select(item => item.Name);
            //var result = from p in persons
                         //where p.Name.Equals("John")
                         //select p.Name;

            foreach (var i in result){
                Console.WriteLine(i);
            }
        }
    }


    public class Person {
        public string Name
        {
            get;
            set;
        }
    }
}
