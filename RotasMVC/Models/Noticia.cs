using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RotasMVC.Models
{
    public class Noticia
    {

        //Propriedades da classe Noticia, da nossa Model
        public int NoticiaId { get; set; }
        public string Titulo { get; set; }
        public string Conteudo { get; set; }
        public string Categoria { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Data { get; set; }

        //Criação do objeto TodasAsNoticias, do tipo IEnumerable<Params>, que permite armazenar objetos.
        public IEnumerable<Noticia> TodasAsNoticias()
        {

            //Retorno recebe uma Collection de Noticia
            var retorno = new Collection<Noticia>
            {

                //Os objetos Noticia, inseridos na collection retorno, são criados
                new Noticia
                {
                    NoticiaId =1,
                    Categoria = "Esportes",
                    Titulo = "Campeonato de Punheta",
                    Conteudo = "Jovens de São Paulo organizam o primeiro campeonato de punheta, cujos critérios vão de coloração até volume e distância do jato",
                    Data = new DateTime(2015,12,11)
                },

                  new Noticia
                {
                    NoticiaId =2,
                    Categoria = "Culinaria",
                    Titulo = "Palmirinha cheira polvilho",
                    Conteudo = "Palmirinha coloca cocaína nos bolinhos de polvilho confundindo com a farinha e é internada por aspiração de glutem",
                    Data = new DateTime(2012,3,6)
                },

                  new Noticia
                {
                    NoticiaId =3,
                    Categoria = "Cinema",
                    Titulo = "Larissa Transante",
                    Conteudo = "Garota de programa da região central da capital paulista, Larissa Olivério conta a trama de sua vida. 'Foi foda. Adoro' - Diz",
                    Data = new DateTime(2016,6,3)
                }


            };


            //O retorno de TodasAsNoticias() é retorno, que é a tal da collection com todos os objetos "NOticia"
            return retorno;

        }
    }
}