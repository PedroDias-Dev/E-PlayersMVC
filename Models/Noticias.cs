using System;
using System.Collections.Generic;
using System.IO;
using E_PlayersMVC.Interfaces;

namespace E_Players_1.Models
{
    public class Noticias : EPlayerBase, INoticias
    {
        public int IdNoticia { get; set; }

        public string Titulo { get; set; }

        public string Texto { get; set; }

        public string Imagem { get; set; }

        private const string PATH = "Database/noticias.csv";

        public Noticias(){
            CreateFolderAndFile(PATH);
            // verifica a existencia dos diretorios
        }

        public void Create(Noticias n){
            //throw new NotImplementedException();
            string[] linha = { PrepararLinha(n) };
            File.AppendAllLines(PATH, linha);
            //cria as linhas
        }

        private string PrepararLinha(Noticias _noticia){
            return $"{_noticia.IdNoticia};{_noticia.Titulo};{_noticia.Imagem}";
            // formato do return
        }

        public List<Noticias> ReadAll()
        {
            //throw new NotImplementedException();
            List<Noticias> noticias = new List<Noticias>();
            string[] linhas = File.ReadAllLines(PATH);
            foreach (var item in linhas)
            {
                string[] linha = item.Split(";");
                Noticias n = new Noticias();
                n.IdNoticia = Int32.Parse(linha[0]);
                n.Texto = linha[1];
                n.Imagem = linha[2];

                noticias.Add(n);
            }
            return noticias;
        }

        public void Update(Noticias n)
        {
            //throw new NotImplementedException();
            List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(x => x.Split(";")[0] == n.IdNoticia.ToString());
            linhas.Add( PrepararLinha(n) );
            RewriteCSV(PATH, linhas);
            // "alterar"
        }

        public void Delete(int id)
        {
            //throw new NotImplementedException();
            List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(x => x.Split(";")[0] == id.ToString());
            RewriteCSV(PATH, linhas);
            // deleta noticia
        }

        public List<string> ReadAllLinesCSV(string PATH){
            
            List<string> linhas = new List<string>();
            using(StreamReader file = new StreamReader(PATH))
            {
                string linha;
                while((linha = file.ReadLine()) != null)
                {
                    linhas.Add(linha);
                }
            }
            return linhas;
            // lê todas as linhas do csv
        }

        public void RewriteCSV(string PATH, List<string> linhas)
        {
            using(StreamWriter output = new StreamWriter(PATH))
            {
                foreach (var item in linhas)
                {
                    output.Write(item + "\n");
                }
            }
            //reescreve o csv (reformulaçao)
        }

        List<Noticias> INoticias.ReadAll()
        {
            throw new NotImplementedException();
        }
    }
}