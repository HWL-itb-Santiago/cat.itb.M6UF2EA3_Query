using cat.itb.M6UF2EA3.Connections;
using cat.itb.M6UF2EA3.Models;
using NHibernate;
using NHibernate.Criterion;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cat.itb.M6UF2EA3.CRUD
{
    //CRUD departamentos con Select, Insert, Update y Delete
    public class DepartamentosCRUD
    {
        public void Delete(Departamento departamento)
        {
            using (var session = SessionFactoryCloud.Open())
            {
                using (var tx = session.BeginTransaction())
                {
                    try
                    {
                        session.Delete(departamento);
                        tx.Commit();
                        Console.WriteLine($"El departamento {departamento.Dnombre} se ha eliminado correctamente");
                    }
                    catch (Exception ex)
                    {
                        if (!tx.WasCommitted)
                        {
                            tx.Rollback();
                            Console.WriteLine($"El departamento {departamento.Dnombre} se ha eliminado correctamente");
                        }
                    }
                }
                session.Close();
            }
        }
        public void Update(Departamento departamento)
        {
            using (var session = SessionFactoryCloud.Open())
            {
                using (var tx = session.BeginTransaction())
                {
                    try
                    {
                        session.Update(departamento);
                        tx.Commit();
                        Console.WriteLine($"Departamento {departamento.Dnombre} actualizado");
                    }
                    catch (Exception)
                    {
                        if (tx.IsActive)
                        {
                            tx.Rollback();
                            Console.WriteLine($"Error al actualizar el departamento {departamento.Dnombre}");
                        }
                    }
                }
                session.Close();
            }
        }

        public IList<Departamento>? SelectByLocQueryOver(string loc1, string loc2)
        {
            try
            {
                IList<Departamento> deps;
                using (var session = SessionFactoryCloud.Open())
                {
                    deps = session.QueryOver<Departamento>()
                        .Where(c => c.Loc.IsInsensitiveLike(loc1) || c.Loc.IsInsensitiveLike(loc2))
                        .List();
                }
                return deps;
            }
            catch (Exception)
            {
                Console.WriteLine("Error al extraer los datos");
                return null;
                throw;
            }
        }
        public IList<string>? SelectLocByNameHQL(string name)
        {
            try
            {
                IList<string> deps;
                using (var session = SessionFactoryCloud.Open())
                {
                    IQuery query = session.CreateQuery("SELECT d.Loc FROM Departamento d WHERE lower(d.Dnombre) LIKE lower(:name)");
                    query.SetParameter("name", name);
                    deps = query.List<string>();
                    session.Close();
                }
                return deps;
            }
            catch (Exception)
            {
                Console.WriteLine("Error al extrarer los datos");
                return null;
            }
        }
        public IList<Departamento> SelectByName(string name)
        {
            IList<Departamento> departamentos;
            using (var session = SessionFactoryCloud.Open())
            {
                IQuery query = session.CreateQuery("FROM Departamento d WHERE d.Dnombre = :name");
                query.SetParameter("name", name);
                departamentos = query.List<Departamento>();

                session.Close();
            }

            return departamentos;
        }

        public IList<Departamento>? SelectAllHQL()
        {
            try
            {
                IList<Departamento> deps;
                using (var session = SessionFactoryCloud.Open())
                {
                    IQuery query = session.CreateQuery("SELECT c FROM Departamento c");
                    deps = query.List<Departamento>();
                    session.Close();
                }
                return deps;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al extraer datos de los departamentos");
                return null;
            }
        }
        public IList<Departamento>? SelectAll()
        {
            try
            {
                IList<Departamento> dep;
                using (var session = SessionFactoryCloud.Open())
                {
                    dep = (from c in session.Query<Departamento>() select c).ToList();
                    session.Close();
                }
                return dep;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public Departamento? SelectByID(int Id)
        {
            try
            {
                using (var session = SessionFactoryCloud.Open())
                {
                    var dep = session.Get<Departamento>(Id);
                    if (dep == null)
                        throw new Exception($"No se encontró el departamento con ID {Id}");
                    session.Close();
                    return dep;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al encontrar al departamento");
                return null;
            }
        }
        public void Insert(List<Departamento> newDepartamentos)
        {
            try
            {
                using (var session = SessionFactoryCloud.Open())
                {
                    using (var tx = session.BeginTransaction())
                    {
                        foreach (var item in newDepartamentos)
                        {
                            session.Save(item);
                            Console.WriteLine($"Departamento {item.Id} ingresado con exito");
                        }
                        tx.Commit();
                        session.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
