using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cat.itb.M6UF2EA3.Connections
{
    //Clase para trabjar con el entorno de NHibernate
    public class SessionFactoryCloud
    {
        public static string conectionString = "Server=postgresql-santiagovr.alwaysdata.net; Port=5432; Database=santiagovr_maps; User Id = santiagovr; Password = Chistrees69@";
        public static ISessionFactory? session;
        //creamos nuestra session, con esta vamos a poder realizar distintas llamadas a querys, get, save, etc
        public static ISessionFactory CreateSession()
        {
            if (session != null)
                return session;

            IPersistenceConfigurer configurer = PostgreSQLConfiguration.PostgreSQL82.ConnectionString(conectionString);
            var configMap =
                Fluently.Configure().Database(configurer).Mappings(c => c.FluentMappings.AddFromAssemblyOf<Program>());

            session = configMap.BuildSessionFactory();
            return session;
        }

        public static ISession Open()
        {
            return CreateSession().OpenSession();
        }
    }
}
