using cat.itb.M6UF2EA3.CRUD;
using cat.itb.M6UF2EA3.Models;
using System.Runtime.Intrinsics.Arm;

class Program
{
    static void Main(string[] args)
    {
        GeneralCRUD generalCRUD = new();
        DepartamentosCRUD departamentosCRUD = new();
        EmpleadosCRUD empleadosCRUD = new();

        Departamento d1 = new()
        {
            Dnombre = "TIC",
            Loc = "BURGOS",
        };

        Departamento d2 = new()
        {
            Dnombre = "DESARROLLO",
            Loc = "ALICANTE",
        };

        Departamento d3 = new()
        {
            Dnombre = "INVESTIGACION",
            Loc = "ALMERIA",
        };

        generalCRUD.DeleteTables(["empleados", "departamentos"]);
        generalCRUD.CreateTables();


        Empleado e1 = new()
        {
            Empno = 800,
            Apellido = "LOPEZ",
            Ofici = "EMPLEADO",
            Dir = 7698,
            Fechaalt = new DateTime(2017, 12, 31, 5, 10, 20, DateTimeKind.Utc),
            Salario = 1605d,
            Comissio = 100,
            Deptno = d1,
        };

        Empleado e2 = new()
        {
            Empno = 801,
            Apellido = "GUILLERMO",
            Ofici = "EMPLEADO",
            Dir = 7647,
            Fechaalt = new DateTime(2017, 11, 18, 5, 20, 00, DateTimeKind.Utc),
            Salario = 1741d,
            Comissio = null,
            Deptno = d2,
        };

        Empleado e3 = new()
        {
            Empno = 801,
            Apellido = "FERNANDEZ",
            Ofici = "VENDEDOR",
            Dir = 7447,
            Fechaalt = new DateTime(2018, 11, 18, 5, 20, 00, DateTimeKind.Utc),
            Salario = 2500d,
            Comissio = null,
            Deptno = d3,
        };





        //var listSalariEmps = empleadosCRUD.SelectBySalariRangeCriteria(2000);
        //foreach (var emp in listSalariEmps)
        //{
        //    var salario = emp.Salario;
        //    var apellido = emp.Apellido;
        //    Console.WriteLine($"{apellido, -10} {salario}");
        //}

        //var departamentos = departamentosCRUD.SelectLocByNameHQL("VENTAS");

        //if (departamentos.Count > 0)
        //{
        //    foreach (var dep in departamentos)
        //    {
        //        Console.WriteLine($"Departamento: {dep.Dnombre}, Localización: {dep.Loc}");
        //    }
        //}
        //else
        //{
        //    Console.WriteLine("No se encontraron departamentos en esa localización.");
        //}

        //var empOfici = empleadosCRUD.SelectByOficiQueryOver("vendedor");
        //foreach (var item in empOfici)
        //{
        //    Console.WriteLine($"{item.Apellido, -8} {item.Salario, -10}");
        //}

        //var empFilterHQL = empleadosCRUD.SelectByLastNameHQL("S");
        //foreach (var emp in empFilterHQL)
        //{
        //    Console.WriteLine($"Oficio: {emp[0]}, Apellido: {emp[1]}, Salario: {emp[2]}");
        //}

        //var depsLoc = departamentosCRUD.SelectByLocQueryOver("Sevilla", "Barcelona");
        //foreach (var dep in depsLoc)
        //    { Console.WriteLine(dep.Dnombre); }

        //var orderEmps = empleadosCRUD.SelectBySalariRangeQueryOver(3500, 2000);
        //foreach (var emp in orderEmps)
        //{
        //    Console.WriteLine($"{emp,-5}");
        //}

        //var empsalari1400 = empleadosCRUD.SelectByOficiAndSalariQueryOver("EMPLEADO", 1400);
        //foreach (var emp in empsalari1400)
        //    Console.WriteLine(emp[0]);

        //var emp = empleadosCRUD.SelectByMaxSalari();
        //foreach (var empleado in emp)
        //    Console.WriteLine($"{empleado[0], -10} {empleado[1], -10} {empleado[2], -10}");


        int option = 0;
        while (option != -1)
        {
            Console.Clear();
            Console.WriteLine("----------------------- MENU DE BASE DE DATOS ----------------------");
            Console.WriteLine("0.-  Mostra les dades de tots els departaments utiltzant HQL.");
            Console.WriteLine("1.-  Mostra les dades de tots els empleats utiltzant Criteria.");
            Console.WriteLine("2.-  Mostra per pantalla el cognom i el salari dels empleats que cobrin més de 2000 utilitzant Criteria.");
            Console.WriteLine("3.-  Mostra la localització del departament de VENTAS utiltzant HQL.");
            Console.WriteLine("4.-  Mostra les dades dels empleats que el seu ofici sigui VENDEDOR i els ordenes per salari de forma descendent utilitzant \r\n\tQueryOver.");
            Console.WriteLine("5.-  Mostra el cognom, l’ofici i el salari de tots els empleats que el seu cognom comenci per «S» utilitzant HQL.");
            Console.WriteLine("6.-  Mostra les dades dels departaments que estigui a SEVILLA o a BARCELONA utilitzant QueryOver.");
            Console.WriteLine("7.-  Mostra npmés els cognoms dels empleats que el seu salari estigui entre 2000 i 3500, els ordenes de foma\r\n\tascendent per cognom i fes la projecció del cognom utilitzant QueryOver.");
            Console.WriteLine("8.-  Mostra els cognoms i els salaris dels empleats que el seu ofici sigui EMPLEADO i cobrin més de 1400.\r\n\tutilitzant QueryOver.");
            Console.WriteLine("9.-  Mostra el cognom, l’ofici i el salari de l’empleat que tingui el salari més alt utilitzant les Subqueries del\r\n\tQueryOver.");
            Console.WriteLine("R -  Restaura");
            //Console.WriteLine("0 - Create Tables");
            Console.WriteLine("Ingrese la opcion a desear: ");
            // Correct input reading
            string? input = Console.ReadLine();
            if (input == "r" || input == "R")
            {
                Console.Clear();
                generalCRUD.DeleteTables(["empleados", "departamentos"]);
                generalCRUD.CreateTables();
                Console.ReadLine();
                continue;
            }
            else if (!int.TryParse(input, out option))
            {
                Console.WriteLine("Por favor ingrese una opción válida.");
                continue;
            }
            switch (option)
            {
                case 0:
                    {
                        Console.Clear();
                        var listdeps = departamentosCRUD.SelectAllHQL();
                        string depId = "ID";
                        string depNombre = "DepNombre";
                        string depLoc = "Loc";
                        Console.WriteLine($"{depId,-10} {depNombre,-20} {depLoc,-10}");
                        foreach (var dep in listdeps)
                        {
                            Console.WriteLine($"{dep.Id, -10} {dep.Dnombre, -20} {dep.Loc, -10}");
                        }
                        Console.ReadLine();
                        break;
                    }
                case 1:
                    {
                        Console.Clear();
                        var listemps = empleadosCRUD.SelectAllCriteria();
                        foreach (var emp in listemps)
                        {
                            Console.WriteLine(emp.Apellido);
                        }
                        Console.ReadLine();
                        break;
                    }
                case 2:
                    {
                        Console.Clear();

                        Console.ReadLine();
                        break;
                    }
                case 3:
                    {
                        Console.Clear();

                        Console.ReadLine();
                        break;
                    }
                case 4:
                    {
                        Console.Clear();

                        Console.ReadLine();
                        break;
                    }
                case 5:
                    {
                        Console.Clear();

                        Console.ReadLine();
                        break;
                    }
                case 6:
                    {
                        Console.Clear();

                        Console.ReadLine();
                        break;
                    }
                case 7:
                    {
                        Console.Clear();

                        Console.ReadLine();
                        break;
                    }
                case 8:
                    {
                        Console.Clear();

                        Console.ReadLine();
                        break;
                    }
            }
        }
    }
}