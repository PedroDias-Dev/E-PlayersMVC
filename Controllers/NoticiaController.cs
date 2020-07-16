using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
            novaNoticia.Texto = form["Texto"];
            // upload de imagem
            //novaNoticia.Imagem    = form["Imagem"];
            var file    = form.Files[0];
            var folder  = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/Noticias");

            if(file != null)
            {
                if(!Directory.Exists(folder)){
                    Directory.CreateDirectory(folder);
                }

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/", folder, file.FileName);
                using (var stream = new FileStream(path, FileMode.Create))  
                {  
                    file.CopyTo(stream);  
                }
                novaNoticia.Imagem   = file.FileName;
            }
            else
            {
                novaNoticia.Imagem   = "padrao.png";
            }
            // fim upload

            noticiaModel.Create(novaNoticia);            
            ViewBag.Equipes = noticiaModel.ReadAll();

            return LocalRedirect("~/Noticia");
        }

        [Route("[controller]/{id}")]
        public IActionResult Excluir(int id)
        {
            noticiaModel.Delete(id);
            //ViewBag.Equipes = equipeModel.ReadAll();
            return LocalRedirect("~/Noticia");
        }
    }
}