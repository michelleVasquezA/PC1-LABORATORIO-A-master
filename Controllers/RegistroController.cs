using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using pc1.Models;
namespace pc1.Controllers
{

    public class RegistroController : Controller
    {
        private readonly ILogger<RegistroController> _logger;

        public RegistroController(ILogger<RegistroController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View("Index");
        }
          [HttpPost]
        public IActionResult Calcular(Registro objReg)
        {
             string? nom=null;
             string CursoInscrito=null;
             double cur=0;
             double solcurso=0;
             double solIgv=0;
             double total=0;


            nom=objReg.Name;
            
            List<curso> cursito = objReg.CursoList;
            
            for (int i = 0; i < cursito.Count; i++){
                if(cursito[i].active == true){
                   CursoInscrito += cursito[i].Nommbre+ ".";
                    cur++;
              }
            }
            solcurso=cur*300;
            solIgv=solcurso*0.18;
            total=solcurso*1.18;


             ViewData["Message0"] = "BIENVENIDO" +" " +nom;
             ViewData["Message1"] = "Usted se matriculo en " + CursoInscrito;
             ViewData["Message2"] = "El precio por los/el curso/curso es:" +" S/." +solcurso ;
             ViewData["Message3"] = "El IGV por los/el curso/curso es: " +" S/." +solIgv;
             ViewData["Message4"] = "El total a pagar es: " +" S/." +total;


             return View("total");
             
        }
[HttpGet]
public ActionResult Index(Registro objReg)
{
   
       var cursos = new Registro 
    {
        //CHECKBOX CURSO 
       CursoList = new List<curso>
        {
            new curso{ID="1" , Nommbre = "Ingenieria de Software"}, 
            new curso{ID="2" , Nommbre = "Programación I"},
            new curso{ID="3" , Nommbre = "Teoria y Diseño de base de datos"}
        }   , 

         
    } ;   

    return View(cursos);
}      

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}