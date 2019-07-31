using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeCode
{

    public delegate void HelloFuncDelegate(string param);

    public class test
    {
        public test()
        {
            HelloFuncDelegate deleg = new HelloFuncDelegate(Hello);
            deleg("test");

            List<Employee> empList = new List<Employee>();
            empList.Add(new Employee() { ID=1,name="Test", exp=4 });
            empList.Add(new Employee() { ID=6, name = "Test", exp=7 });

            Employee emp = new Employee();
            emp.printUser(new User());
            //isPromotable delegPromotable = new isPromotable(Promote);
            emp.PromoteEmployee(empList, empLambda => empLambda.exp> 5);// use lambda

        }
        public static void Hello(string message)
        {
            Console.WriteLine("Test");
        }

        public bool Promote(Employee emp)
        {
            return emp.exp>5 ? true : false;
        }

    }


    public delegate bool isPromotable(Employee empl);

    public class Employee
    {
        public int ID { get; set; }
        public string name { get; set; }
        public int exp { get; set; }

        public void PromoteEmployee(List<Employee> empList, isPromotable forPromotion)
        {
            foreach(Employee emp in empList)
            {
                if (forPromotion(emp))
                    Console.WriteLine("Promoted");
            }
        }
        public void printUser(IUser user)
        {
            var x= user.GetPrintUserName("testUser");
        }
    }

    public interface IUser
    {
        int UserID { get; set; }
        string UserName { get; set; }

        string GetPrintUserName(string userNAme);

    }

    public class User : IUser
    {
        private int _userID;
        private string _userName;
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }


        }
        public int UserID { get; set; }

        public string GetPrintUserName(string uName)
        {
            return uName;
        }

      
    }

    public class Names
    {
        public Names()
        {
            List<string> _names = new List<string>();
            _names.Add("TestName");
            _names.Add("TestName1");
            _names.Add("TestName2");
            _names.Add("TestName3");

            string resDel = _names.Find(SearchName);//Delegate C# 1.0

            string resultAnonymous = _names.Find( // anonymous C# 2.0
                (name) =>
                { return name.Equals("TestName3"); }
                );


            string resultLambda = _names.Find(
                name => name.Equals("TestName"));// lambda C# 3.0


        }
        private static bool SearchName(string name) 
        {
            return name.Equals("TestName2");
        }


}







}
