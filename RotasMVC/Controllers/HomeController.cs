using RotasMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RotasMVC.Controllers
{

    //HomeController herda de Controller
    public class HomeController : Controller
    {

        //criação de uma variável todasAsNoticias que é do tipo IEnumerable<Params>
        private readonly IEnumerable<Noticia> todasAsNoticias;

        //O Controller Home
        public HomeController() 
        {
            //o objeto todasAsNoticias recebe o conteúdo do método TodasAsNoticias, da nossa Model Noticia, ordenado pela data
            todasAsNoticias = new Noticia().TodasAsNoticias().OrderByDescending(x => x.Data);
        }

        //Action Index
        public ActionResult Index()
        {

            //Aqui ultimasNoticias recebe as três primeiras noticias armazenadas em todasAsNoticias.
            var ultimasNoticias = todasAsNoticias.Take(3);

            //a variável todasAsCategorias recebe a lista distinta das categorias em todasAsNoticias
            var todasAsCategorias = todasAsNoticias.Select(x => x.Categoria).Distinct().ToList();

            //A ViweBag.Categoria recebe todasAsCategorias
            ViewBag.Categoria = todasAsCategorias;

            //Aqui retornamos ultimasNoticias na view.
            return View(ultimasNoticias);
        }


        //Action TodasAsNoticias(). Não confundir com o método TodasAsNoticias() da Model. Esse é um ActionResult, não um IEnumerable
        public ActionResult TodasAsNoticias()
        {
            //Retorna todasAsNoticias na view
            return View(todasAsNoticias);
        }


        //Action MostraNoticia, recebe por parâmetro o id da noticia, seu título e sua categoria.
        public ActionResult MostraNoticia(int noticiaId, string titulo, string categoria)
        {
            //Retorna na View o primeiro ou o default do conteúdo de todasAsNoticias onde o id corrente da noticia da Model for igual ao parâmetro noticiaId, passado na view
            return View(todasAsNoticias.FirstOrDefault(x => x.NoticiaId == noticiaId));
        }

        //Action MostraCategoria, que recebe uma string que é a categoria selecionada
        public ActionResult MostraCategoria(string categoria)
        {

            //A variável categoriaEspecífica recebe o conteúdo de todasAsNocicias onde o valor corrente da categoria na Model for igual ao valor de categoria passado por parâmetro
            var categoriaEspecifica = todasAsNoticias.Where(x => x.Categoria.ToLower() == categoria.ToLower()).ToList();

            //A ViewBag.Categoria recebe o parâmetro da action, que é a string categoria.
            ViewBag.Categoria = categoria;

            //E o retorno é o conteúdo de categoriaEspecifica na view.
            return View(categoriaEspecifica);
        }
    } 
}
