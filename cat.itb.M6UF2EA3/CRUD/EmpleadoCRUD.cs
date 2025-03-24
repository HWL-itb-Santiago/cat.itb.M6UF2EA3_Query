using cat.itb.M6UF2EA3.Connections;
using cat.itb.M6UF2EA3.Models;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cat.itb.M6UF2EA3.CRUD
{
    //Clase CRUD de empleados con Select, Update, Insert y Delete
    public class EmpleadosCRUD
    {
        public void Delete(Empleado empleado)
        {
            using (var session = SessionFactoryCloud.Open())
            {
                using (var tx = session.BeginTransaction())
                {
                    try
                    {
                        session.Delete(empleado);
                        tx.Commit();
                        Console.WriteLine($"El empleado {empleado.Apellido} se ha eliminado correctamente");
                    }
                    catch (Exception ex)
                    {
                        if (!tx.WasCommitted)
                        {
                            tx.Rollback();
                            Console.WriteLine($"El empleado {empleado.Apellido} se ha eliminado correctamente");
                        }
                    }
                }
                session.Close();
            }
        }
        public void Update(Empleado empleado)
        {
            using (var session = SessionFactoryCloud.Open())
            {
                using (var tx = session.BeginTransaction())
                {
                    try
                    {
                        session.Update(empleado);
                        tx.Commit();
                        Console.WriteLine($"empleado {empleado.Apellido} actualizado");
                    }
                    catch (Exception)
                    {
                        if (tx.IsActive)
                        {
                            tx.Rollback();
                            Console.WriteLine($"Error al actualizar el empleado {empleado.Apellido}");
                        }
                    }
                }
                session.Close();
            }
        }

        public IList<Empleado> SelectByName(string name)
        {
            IList<Empleado> empleado;
            using (var session = SessionFactoryCloud.Open())
            {
                IQuery query = session.CreateQuery("FROM Empleado d WHERE d.Apellido = :apellido");
                query.SetParameter("apellido", name);
                empleado = query.List<Empleado>();

                session.Close();
            }

            return empleado;
        }

        public IList<object[]>? SelectByLastNameHQL(string lastName)
        {
            try
            {
                IList<object[]> empleados;
                using (var session = SessionFactoryCloud.Open())
                {
                    IQuery query = session.CreateQuery("SELECT d.Ofici, d.Apellido, d.Salario FROM Empleado d WHERE lower(d.Apellido) LIKE lower(:apellido)");
                    query.SetParameter("apellido", lastName + "%");
                    empleados = query.List<object[]>();
                    session.Close();
                }
                return empleados;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al extraer los datos: {ex.Message}");
                return null;
            }
        }

        public IList<object[]>? SelectByMaxSalari()
        {
            try
            {
                IList<object[]> empleados;
                using (var session = SessionFactoryCloud.Open())
                {
                    QueryOver<Empleado> maxSalari = QueryOver.Of<Empleado>()
                        .SelectList(c => c.SelectMax(d => d.Salario));

                    empleados = session.QueryOver<Empleado>()
                        .WithSubquery.Where(c => c.Salario == maxSalari.As<double>())
                        .Select(c => c.Apellido, c => c.Ofici, c => c.Salario)
                        .List<object[]>();
                    session.Close();
                }
                return empleados;
            }
            catch (Exception)
            {
                Console.WriteLine("Error al extraer los datos");
                return null;
            }
        }
        public IList<object[]> SelectByOficiAndSalariQueryOver(string ofici, double salari)
        {
            try
            {
                IList<object[]> empleados;
                using (var session = SessionFactoryCloud.Open())
                {
                    empleados = session.QueryOver<Empleado>()
                        .WhereRestrictionOn(c => c.Ofici).IsInsensitiveLike(ofici)
                        .And(c => c.Salario > salari)
                        .Select(c => c.Apellido, c => c.Salario)
                        .List<object[]>();
                    session.Close();
                }
                return empleados;
            }
            catch (Exception)
            {
                Console.WriteLine("Error al extraer los datos");
                return new List<object[]>();
            }
        }
        public IList<string>? SelectBySalariRangeQueryOver(double sal1, double sal2)
        {
            try
            {
                double max = Math.Max(sal1, sal2);
                double min = Math.Min(sal1, sal2);
                IList<string> empleados;
                using (var session = SessionFactoryCloud.Open())
                {
                    empleados = session.QueryOver<Empleado>()
                        .WhereRestrictionOn(c => c.Salario).IsBetween(min).And(max)
                        .Select(c => c.Apellido)
                        .OrderBy(c => c.Apellido).Asc
                        .List<string>();
                    session.Close();
                }
                return empleados;
            }
            catch (Exception)
            {
                Console.WriteLine("Error al extraer los datos");
                return null;
            }
        }
        public IList<Empleado>? SelectByOficiQueryOver(string depname)
        {
            try
            {
                IList<Empleado> emps;
                using (var session = SessionFactoryCloud.Open())
                {
                    emps = session.QueryOver<Empleado>()
                        .Where(Restrictions.On<Empleado>(c => c.Ofici).IsInsensitiveLike(depname))
                        .OrderBy(c => c.Salario).Desc
                        .List();
                }
                return emps;
            }
            catch (Exception)
            {
                Console.WriteLine("Error al extraer los datos");
                return null;
            }
        }
        public IList<Empleado> SelectByEmpno(int empno)
        {
            IList<Empleado> empleado;
            using (var session = SessionFactoryCloud.Open())
            {
                IQuery query = session.CreateQuery("FROM Empleado d WHERE d.Empno = :empno");
                query.SetParameter("empno", empno);
                empleado = query.List<Empleado>();

                session.Close();
            }

            return empleado;
        }

        public IList<Empleado>? SelectAllCriteria()
        {
            try
            {
                IList<Empleado> empleados;
                using (var session = SessionFactoryCloud.Open())
                {
                    ICriteria criteria = session.CreateCriteria<Empleado>();
                    empleados = criteria.List<Empleado>();
                    session.Close();
                }
                return empleados;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al extraer los datos de los empleados");
                return null;
            }

        }

        public IList<object[]>? SelectBySalariRangeCriteria(double range)
        {
            try
            {
                IList<object[]> empleados;
                using (var session = SessionFactoryCloud.Open() )
                {
                    empleados = session.CreateCriteria<Empleado>()
                        .Add(Restrictions.Gt("Salario", range))
                        .SetProjection(Projections.ProjectionList()
                            .Add(Projections.Property("Apellido"))
                            .Add(Projections.Property("Salario")))
                        .List<object[]>();
                    session.Close();
                }
                return empleados;
            }
            catch (Exception)
            {
                Console.WriteLine("Error al extraer los datos de los empleados");
                return null;
            }
        }
        public IList<Empleado> SelectAll()
        {
            IList<Empleado> dep;
            using (var session = SessionFactoryCloud.Open())
            {
                dep = (from c in session.Query<Empleado>() select c).ToList();
                session.Close();
            }
            return dep;
        }
        public Empleado? SelectByID(int Id)
        {
            try
            {
                using (var session = SessionFactoryCloud.Open())
                {
                    var dep = session.Get<Empleado>(Id);
                    if (dep == null)
                        throw new Exception($"No se encontró el empleado con ID {Id}");
                    session.Close();
                    return dep;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al encontrar al empleado");
                return null;
            }
        }
        public void Insert(List<Empleado> newEmpleado)
        {
            using (var session = SessionFactoryCloud.Open())
            {
                using (var tx = session.BeginTransaction())
                {
                    foreach (var item in newEmpleado)
                    {
                        session.Save(item);
                        Console.WriteLine($"Empleado {item.Id} ingresado con exito");
                    }
                    tx.Commit();
                    session.Close();
                }
            }
        }
    }
}
