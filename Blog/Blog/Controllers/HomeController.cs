﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Blog.Models;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var listaDePosts = new List<Post>()
            {
                    new Post() { Titulo = "Harry Potter 1", Resumo = "Pedra Filosofal", Categoria = "Filme, Livro" },
                    new Post() { Titulo = "Cassino	Royale", Resumo = "007", Categoria = "Filme" },
                    new Post() { Titulo = "Monge e o Executivo", Resumo = "Romance sobre Liderança", Categoria  = "Livro" },
                    new Post() { Titulo = "New York, New York", Resumo = "Sucesso de Frank Sinatra", Categoria = "Música" }
        };

            ViewBag.Posts = listaDePosts;
            return View();
        }
    }
}
