using System;
using System.Text;

namespace Inheritance
{
    class Employee
    {
        public string Name { get; set; }   //Get and Set the three attributes or fields.
        public double Salary { get; set; }
        public double Hours { get; set; }

        public virtual void showEmployee() //Method that show Employee information. And is virtual because will be override it by other methods of derived class.
        {
            Console.WriteLine("Employee " +  Name + ".  Salary is: " + Salary + ". Hours worked peer Week: " + Hours);
        }
    }

    //Class SalariedEmployee. Employee that paid bay fixed salary peer week.
    class SalariedEmployee : Employee
    {
        public double FixedSalary { get; set; } // Attribute that fixed a salary

        public SalariedEmployee(string name)
        {
            double FixedPayByWeek = 2000.00;//I assume that is a Fixed Salary by week.
            Name = name;
            Salary = FixedPayByWeek;
        }

        public override void showEmployee() //Override the Main method from Class Employee.
        {
            Console.WriteLine("Employee " + Name+ ". Is paid a Fixed Salary peer week of: " + Salary);
        }   
    }


    //Class HourlyEmployee. employee that paid by hours worked.
    class HourlyEmployee : Employee
    {     
        double remaining;
        double pay1;
        double pay2;
        double totalPay;

        public HourlyEmployee(string name, double salary, double hours)
        {
            Name = name;
            Salary = salary;
            Hours = hours;
            
            if (Hours <= 40)
            {
               pay1 = Hours * Salary;
            }
            else if (Hours > 40)
            {
                pay1 = 40 * Salary;
                remaining = Hours - 40;
                pay2 = (remaining * Salary * 1.5);
                totalPay = pay1 + pay2;
            }
        }
        public override void showEmployee()
        {
            Console.WriteLine("The Employee " + Name+ ". Is paid with: " + pay1 + ".  With an extra hours of: " + pay2 + ".  Making a total peer week of : " + totalPay);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            //Create Employee 
            Employee  employee1= new Employee();
            employee1.Name = "Maria Luisa";
            employee1.Salary = 35.00;
            employee1.Hours = 40;
            employee1.showEmployee();//Method base showEmployee() 

            //Create an Hourly Employee with a type Employee. 
            Console.WriteLine();
            Employee employee2 = new HourlyEmployee("Josefina", 15.00, 67);
            employee2.showEmployee();// Override Method base showEmployee()

            //Create an Salaried Employee with a type Employee. 
            Console.WriteLine();
            Employee employee3 = new SalariedEmployee("Carlitos");
            employee3.showEmployee();// Override Method base showEmployee()

            //Create another Hourly Employee with a type Employee. 
            Console.WriteLine();
            Employee employee4 = new HourlyEmployee("Carolina", 45.00, 35);
            employee4.showEmployee();// Override Method base showEmployee()

        }
    }
}
