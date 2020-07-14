using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using E_Players_1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace E_Players.Controllers
{
    public class NoticiaController : Controller
    {
        Noticias noticiaModel = new Noticias();
        public IActionResult Index()
        {
            ViewBag.Noticias = noticiaModel.ReadAll();
            return View();
        }

        public IActionResult Cadastrar(IFormCollection form)
        {
            Noticias novaNoticia  = new Noticias();
            novaNoticia.IdNoticia = Int32.Parse(form["IdNoticia"]);
            novaNoticia.Texto     = form["Texto"];
            novaNoticia.Imagem    = form["Imagem"];

            noticiaModel.Create(novaNoticia);            
            ViewBag.Equipes = noticiaModel.ReadAll();

            return LocalRedirect("~/Noticia");
        }
    }
}