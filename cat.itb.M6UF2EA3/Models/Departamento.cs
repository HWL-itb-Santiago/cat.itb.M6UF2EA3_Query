using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cat.itb.M6UF2EA3.Models
{
    //Clase Departamento
    //Necesaria para el mapeo con NHibernate
    public class Departamento
    {
        public virtual int Id { get; set; }
        public virtual string? Dnombre { get; set; }
        public virtual string? Loc { get; set; }
        public virtual IList<Empleado> Empleado { get; set; }
    }
}
