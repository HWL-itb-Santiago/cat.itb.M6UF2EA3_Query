using cat.itb.M6UF2EA3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cat.itb.M6UF2EA3.Models
{
    public class Empleado
    {
        public virtual int Id { get; set; }
        public virtual int Empno { get; set; }
        public virtual string? Apellido { get; set; }
        public virtual string? Ofici { get; set; }
        public virtual int Dir { get; set; }
        public virtual DateTime Fechaalt { get; set; }
        public virtual double Salario { get; set; }
        public virtual double? Comissio { get; set; }
        public virtual Departamento Deptno { get; set; }
    }
}
