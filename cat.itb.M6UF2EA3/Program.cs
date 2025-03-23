using cat.itb.M6UF2EA3.CRUD;
using cat.itb.M6UF2EA3.Models;

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

        //var listdeps = departamentosCRUD.SelectAllHQL();
        //foreach (var dep in listdeps)
        //{
        //    Console.WriteLine(dep.Dnombre);
        //}

        //var listemps = empleadosCRUD.SelectAllCriteria();
        //foreach (var emp in listemps)
        //{
        //    Console.WriteLine(emp.Apellido);
        //}

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

        var empFilterHQL = empleadosCRUD.SelectByLastNameHQL("S");
        foreach (var emp in empFilterHQL)
        {
            Console.WriteLine($"Oficio: {emp[0]}, Apellido: {emp[1]}, Salario: {emp[2]}");
        }

        var depsLoc = departamentosCRUD.SelectByLocQueryOver("Sevilla", "Barcelona");
        foreach (var dep in depsLoc)
            { Console.WriteLine(dep.Dnombre); }
        //int option = 0;
        //while (option != -1)
        //{
        //    Console.Clear();
        //    Console.WriteLine("----------------------- MENU DE BASE DE DATOS ----------------------");
        //    Console.WriteLine("1.-  Inserta tres nous departaments a la taula DEPARTAMENTOS");
        //    Console.WriteLine("2.-  Inserta un nou empleat a cada departament nou");
        //    Console.WriteLine("3.-  Actualitza el nom del departament número 3, ara es dirà MARKETING.");
        //    Console.WriteLine("4.-  Actualitza el salari de l’empleat amb empno = 7839, ara cobra 5500.");
        //    Console.WriteLine("5.-  Elimina l’empleat que es diu NEGRO.");
        //    Console.WriteLine("6.-  Mostra per pantalla el cognom i el salari dels empleats que cobrin menys de 2500.");
        //    Console.WriteLine("7.-  Mostra el nom i la ciutat del department de l’empleat amb id = 8.");
        //    Console.WriteLine("8.-  Mostra el cognom, l’ofici i el salari de tots els empleats del departament amb id = 3.");
        //    Console.WriteLine("R -  Restaura");
        //    //Console.WriteLine("0 - Create Tables");
        //    Console.WriteLine("Ingrese la opcion a desear: ");
        //    // Correct input reading
        //    string? input = Console.ReadLine();
        //    if (input == "r" || input == "R")
        //    {
        //        Console.Clear();
        //        generalCRUD.DeleteTables(["empleados", "departamentos"]);
        //        generalCRUD.CreateTables();
        //        Console.ReadLine();
        //        continue;
        //    }
        //    else if (!int.TryParse(input, out option))
        //    {
        //        Console.WriteLine("Por favor ingrese una opción válida.");
        //        continue;
        //    }
        //    switch (option)
        //    {
        //        case 1:
        //            {
        //                Console.Clear();
        //                departamentosCRUD.Insert([d1, d2, d3]);
        //                Console.ReadLine();
        //                break;
        //            }
        //        case 2:
        //            {
        //                Console.Clear();
        //                empleadosCRUD.Insert([e1, e2, e3]);
        //                Console.ReadLine();
        //                break;
        //            }
        //        case 3:
        //            {
        //                Console.Clear();
        //                var subject = departamentosCRUD.SelectByID(3);
        //                if (subject != null)
        //                {
        //                    subject.Dnombre = "MARKETING";
        //                    departamentosCRUD.Update(subject);
        //                }
        //                else
        //                    Console.WriteLine("Departamento no encontrado");
        //                Console.ReadLine();
        //                break;
        //            }
        //        case 4:
        //            {
        //                Console.Clear();
        //                var subject2 = empleadosCRUD.SelectByEmpno(7839);
        //                if (subject2.Count > 0)
        //                {
        //                    var emp = subject2.First();
        //                    emp.Salario = 5500;
        //                    empleadosCRUD.Update(emp);
        //                }
        //                else
        //                    Console.WriteLine("Empleado no encontrado");
        //                Console.ReadLine();
        //                break;
        //            }
        //        case 5:
        //            {
        //                Console.Clear();
        //                var subject3 = empleadosCRUD.SelectByName("NEGRO");
        //                if (subject3.Count > 0)
        //                {
        //                    var emp = subject3.First();
        //                    empleadosCRUD.Delete(emp);
        //                }
        //                else
        //                    Console.WriteLine("Empleado no encontrado, no existe");
        //                Console.ReadLine();
        //                break;
        //            }
        //        case 6:
        //            {
        //                Console.Clear();
        //                var subject4 = empleadosCRUD.SelectAll();
        //                if (subject4.Count > 0)
        //                {
        //                    string apellidos = "APELLIDOS";
        //                    string salario = "SALARIO";
        //                    Console.WriteLine($"{apellidos,-15} {salario,-5}");
        //                    foreach (var emp in subject4)
        //                    {
        //                        if (emp.Salario >= 2500)
        //                            continue;
        //                        Console.WriteLine($"{emp.Apellido,-15} {emp.Salario,-5}");
        //                    }
        //                }
        //                else Console.WriteLine("No se existen empleados en la base de datos");
        //                Console.ReadLine();
        //                break;
        //            }
        //        case 7:
        //            {
        //                Console.Clear();
        //                var subject5 = empleadosCRUD.SelectByID(8);
        //                if (subject5 != null)
        //                    Console.WriteLine($"{subject5.Deptno.Loc,-10} {subject5.Deptno.Dnombre}");
        //                else Console.WriteLine("EL empleado no existe");
        //                Console.ReadLine();
        //                break;
        //            }
        //        case 8:
        //            {
        //                Console.Clear();
        //                var subject6 = empleadosCRUD.SelectAll();
        //                if (subject6.Count > 0)
        //                {
        //                    foreach (var emp in subject6)
        //                    {
        //                        if (emp.Deptno.Id != 3)
        //                            continue;
        //                        Console.WriteLine($"{emp.Apellido,-8} {emp.Salario,-8} {emp.Ofici,-8}");
        //                    }
        //                }
        //                else
        //                    Console.WriteLine("La consulta no arrojó resultados");
        //                Console.ReadLine();
        //                break;
        //            }
        //        case 0:
        //            {
        //                Console.Clear();
        //                Console.ReadLine();
        //                break;
        //            }
        //    }
        //}
    }
}