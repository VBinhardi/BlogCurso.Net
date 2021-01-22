using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Blog.Models;
using System.Data.SqlClient;
using Blog.Infra;

namespace Blog.Controllers
{
    public class PostController : Controller
    {
        private IList<Post> lista;

        public PostController()
        {
            this.lista = new List<Post>
            {
                new Post() { Titulo = "Harry Potter 1", Resumo = "Pedra Filosofal", Categoria = "Filme, Livro" },
                    new Post() { Titulo = "Cassino	Royale", Resumo = "007", Categoria = "Filme" },
                    new Post() { Titulo = "Monge e o Executivo", Resumo = "Romance sobre Liderança", Categoria  = "Livro" },
                    new Post() { Titulo = "New York, New York", Resumo = "Sucesso de Frank Sinatra", Categoria = "Música" }
            };
        }
        public IActionResult Index()
        {
            IList<Post> lista = new List<Post>();
            using (SqlConnection cnx = ConnectionFactory.CriaConexaoAberta())
            {
                SqlCommand comando = cnx.CreateCommand();
                comando.CommandText = "select * from Posts";
                SqlDataReader leitor = comando.ExecuteReader();

                while (leitor.Read())
                {
                    Post post = new Post()
                    {
                        Id = Convert.ToInt32(leitor["id"]),
                        Titulo = Convert.ToString(leitor["titulo"]),
                        Resumo = Convert.ToString(leitor["Resumo"]),
                        Categoria = Convert.ToString(leitor["categoria"])
                    };
                }
            }
            return View(lista);
        }
        



        public IActionResult Novo()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Adiciona(Post post)
        {
            lista.Add(post);
            return View("Index", lista);
        }
    }
}
