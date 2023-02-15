using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace pc1.Models
{
    public class Registro
    {
         [Display(Name = "Nombre Completo del estudiante:")]
         public string? Name {get; set;}

         [Display(Name = "Seleccione cursos a matricular:")]
          public curso? nomCurso {get; set;}

          public List<curso>? CursoList {get; set;}
        
    }
    public class curso{
        public String? ID {get; set;}
        public String? Nommbre {get; set;}
        public bool active {get;set;}

    }
}