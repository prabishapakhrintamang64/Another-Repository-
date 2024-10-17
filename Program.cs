    using System;
    using System.Diagnostics;
    using System.Linq;
    using Models;
    namespace EFCoreApplication
    {
        class Data
        {
            public static void Main()
            {
                using var db = new EmployyContext();

                Console.WriteLine($"Database path : {db.Dbpath}");
                Console.WriteLine("Inserting All Employees");

                Employy employy = new Employy { EmployyId = 1, EmployyName = "momo nohara", DepartId = 10 };
                Employy employy1 = new Employy { EmployyId = 2, EmployyName = "rott wheiler", DepartId = 20 };
                Employy employy2 = new Employy { EmployyId = 3, EmployyName = "Ezaki Hikaru", DepartId = 30 };

                db.Add(employy);
                db.Add(employy1);
                db.Add(employy2);
                db.SaveChanges();


                List<Employy> allEmployy = db.Employy
                .OrderBy(E => E.EmployyName)
                .ToList();
                
                foreach (var Employee in allEmployy)
                {
                    Console.WriteLine($"EmployyId : {Employee.EmployyId},EmployyName : {Employee.EmployyName},DepartId : {Employee.DepartId}");
                }
              

                EmployyLeave employeeLeave = new EmployyLeave { LeaveId = 111, EmployyId = employy.EmployyId, NumOfDays = 2 };
                EmployyLeave employeeLeave1 = new EmployyLeave { LeaveId = 222, EmployyId = employy1.EmployyId, NumOfDays = 3 };
                EmployyLeave employeeLeave2 = new EmployyLeave { LeaveId = 333, EmployyId = employy2.EmployyId, NumOfDays = 1 };
 
                db.Add(employeeLeave);
                db.Add(employeeLeave1);
                db.Add(employeeLeave2);
                db.SaveChanges();

                Console.WriteLine($"Leave applied by {employy.EmployyName} for {employeeLeave.NumOfDays} days");
                Console.WriteLine($"Leave applied by {employy1.EmployyName} for {employeeLeave1.NumOfDays} days");
                Console.WriteLine($"Leave applied by {employy2.EmployyName} for {employeeLeave2.NumOfDays} days");
            
                db.Remove(employy);
                db.Remove(employy1);
                db.Remove(employy2);
                db.RemoveRange(employeeLeave, employeeLeave1, employeeLeave2);
                db.SaveChanges();
            }
        }
    }