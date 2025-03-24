using cat.itb.M6UF2EA3.Models;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cat.itb.M6UF2EA3.Map
{
    //Mapeo de la clase Departamento
    public class DepartamentoMAP : ClassMap<Departamento>
    {
        public DepartamentoMAP()
        {
            Table("departamentos");
            Id(x => x.Id);
            Map(x => x.Dnombre).Column("dnombre");
            Map(x => x.Loc).Column("loc");
            //el departamento posee muchos empleados, por lo que se referencia como HasMany hacia empleado
            HasMany(x => x.Empleado)
                .Cascade.All();
        }
    }
}
