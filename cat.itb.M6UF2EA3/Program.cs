using cat.itb.M6UF2EA3.CRUD;
using cat.itb.M6UF2EA3.Models;
using System.Runtime.Intrinsics.Arm;

class Program
{
    static void Main(string[] args)
    {
        // Inicialización de las clases de CRUD para gestionar la base de datos
        GeneralCRUD generalCRUD = new();
        DepartamentosCRUD departamentosCRUD = new();
        EmpleadosCRUD empleadosCRUD = new();

        // Eliminación y creación de tablas al iniciar la aplicación
        generalCRUD.DeleteTables(["empleados", "departamentos"]);
        generalCRUD.CreateTables();

        //Menu principal de la aplicación donde se muestra los 10 ejercicios de la practica de NHibernate querys
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
            Console.WriteLine("Ingrese la opcion a desear: ");
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
                        string empId = "ID";
                        string empApellido = "Apellido";
                        string empOficio = "Oficio";
                        string empDir = "Dir";
                        string empFecha = "Fecha";
                        string empSalario = "Salario";
                        string empComision = "Comision";
                        string empDeptno = "Deptno";
                        Console.WriteLine($"{empId, -10} {empApellido, -15} {empOficio, -10} {empDir, -10} {empFecha, -20} {empSalario, -10} {empComision, -10} {empDeptno, -10}");
                        foreach (var emp in listemps)
                        {
                            Console.WriteLine($"{emp.Id,-10} {emp.Apellido,-15} {emp.Ofici,-10} {(emp.Dir != null ? emp.Dir : "N/A"),-10} {emp.Fechaalt,-20} {emp.Salario, -10} {(emp.Comissio != null ? emp.Comissio : "N/A"), -10} {emp.Deptno.Id, -10}");
                        }
                        Console.ReadLine();
                        break;
                    }
                case 2:
                    {
                        Console.Clear();
                        var listSalariEmps = empleadosCRUD.SelectBySalariRangeCriteria(2000);
                        string apellido = "APELLIDO";
                        string salario = "SALARIO";
                        Console.WriteLine($"{apellido,-20} {salario}");
                        foreach (var emp in listSalariEmps)
                        {
                            Console.WriteLine($"{emp[0],-20} {emp[1], -20}");
                        }
                        Console.ReadLine();
                        break;
                    }
                case 3:
                    {
                        Console.Clear();
                        string depto = "ventas";
                        var departamentos = departamentosCRUD.SelectLocByNameHQL(depto);

                        if (departamentos != null && departamentos.Count > 0)
                        {
                            foreach (var dep in departamentos)
                            {
                                Console.WriteLine($"Departamento: {depto}, Localización: {dep}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No se encontraron departamentos en esa localización.");
                        }
                        Console.ReadLine();
                        break;
                    }
                case 4:
                    {
                        Console.Clear();
                        var empOfici = empleadosCRUD.SelectByOficiQueryOver("vendedor");
                        string empId = "ID";
                        string empApellido = "Apellido";
                        string empOficio = "Oficio";
                        string empDir = "Dir";
                        string empFecha = "Fecha";
                        string empSalario = "Salario";
                        string empComision = "Comision";
                        string empDeptno = "Deptno";
                        Console.WriteLine($"{empId,-10} {empApellido,-15} {empOficio,-10} {empDir,-10} {empFecha,-20} {empSalario,-10} {empComision,-10} {empDeptno,-10}");
                        foreach (var emp in empOfici)
                        {
                            Console.WriteLine($"{emp.Id,-10} {emp.Apellido,-15} {emp.Ofici,-10} {(emp.Dir != null ? emp.Dir : "N/A"),-10} {emp.Fechaalt,-20} {emp.Salario,-10} {(emp.Comissio != null ? emp.Comissio : "N/A"),-10} {emp.Deptno.Id,-10}");
                        }
                        Console.ReadLine();
                        break;
                    }
                case 5:
                    {
                        Console.Clear();
                        var empFilterHQL = empleadosCRUD.SelectByLastNameHQL("S");
                        foreach (var emp in empFilterHQL)
                        {
                            Console.WriteLine($"Oficio: {emp[0]}, Apellido: {emp[1]}, Salario: {emp[2]}");
                        }
                        Console.ReadLine();
                        break;
                    }
                case 6:
                    {
                        Console.Clear();
                        string depId = "ID";
                        string depNombre = "DepNombre";
                        string depLoc = "Loc";
                        Console.WriteLine($"{depId,-10} {depNombre,-20} {depLoc,-10}");
                        var depsLoc = departamentosCRUD.SelectByLocQueryOver("Sevilla", "Barcelona");
                        foreach (var dep in depsLoc)
                        {
                            Console.WriteLine($"{dep.Id,-10} {dep.Dnombre,-20} {dep.Loc,-10}");
                        }
                        Console.ReadLine();
                        break;
                    }
                case 7:
                    {
                        Console.Clear();
                        var orderEmps = empleadosCRUD.SelectBySalariRangeQueryOver(3500, 2000);
                        foreach (var emp in orderEmps)
                        {
                            Console.WriteLine($"{emp,-5}");
                        }
                        Console.ReadLine();
                        break;
                    }
                case 8:
                    {
                        Console.Clear();
                        var empsalari1400 = empleadosCRUD.SelectByOficiAndSalariQueryOver("EMPLEADO", 1400);
                        string apellido = "APELLIDO";
                        string salario = "SALARIO";
                        Console.WriteLine($"{apellido,-20} {salario,-10}");
                        foreach (var emp in empsalari1400)
                        {
                            Console.WriteLine($"{emp[0], -20} {emp[1],-10}");
                        }
                        Console.ReadLine();
                        break;
                    }
                case 9:
                    {
                        Console.Clear();
                        var emp = empleadosCRUD.SelectByMaxSalari();
                        string apellido = "APELLIDO";
                        string oficio = "OFICIO";
                        string salario = "SALARIO";
                        Console.WriteLine($"{apellido, -20} {oficio, -20} {salario}");
                        foreach (var empleado in emp)
                            Console.WriteLine($"{empleado[0],-20} {empleado[1],-20} {empleado[2],-10}");
                        Console.ReadLine();
                        break;
                    }
            }
        }
    }
}