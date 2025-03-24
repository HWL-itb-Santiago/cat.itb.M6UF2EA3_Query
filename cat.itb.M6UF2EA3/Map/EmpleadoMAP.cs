using cat.itb.M6UF2EA3.Models;
using FluentNHibernate.Mapping;
using NHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cat.itb.M6UF2EA3.Map
{
    //Mapeo de la clas empleado
    public class EmpleadoMAP : ClassMap<Empleado>
    {
        public EmpleadoMAP()
        {
            Table("empleados");
            Id(x => x.Id);
            Map(x => x.Empno).Column("empno");
            Map(x => x.Apellido).Column("apellido");
            Map(x => x.Ofici).Column("oficio");
            Map(x => x.Dir).Column("dir");
            Map(x => x.Fechaalt).Column("fechaalt");
            Map(x => x.Salario).Column("salario");
            Map(x => x.Comissio).Column("comision");
            //Llave foránea hacia departamento
            References(x => x.Deptno)
                .Column("deptno")
                .Not.LazyLoad()
                .Fetch.Join()
                .Unique();
        }
    }
}
