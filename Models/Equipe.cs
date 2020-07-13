using System.Collections.Generic;
using System.IO;
using E_Players_1.Interfaces;
using System.Linq;
using System;


namespace E_Players_1.Models
{
    public class Equipe : EPlayerBase, IEquipe
    {
        public int IdEquipe { get; set; }

        public string Nome { get; set; }

        public string Imagem { get; set; }
        // imagens/imagem.png
        //

        private const string PATH = "Database/equipes.csv";

        public Equipe(){
            CreateFolderAndFile(PATH);
            // verifica os diretorios, caso nao exista ele cria
        }

        public void Create(Equipe e){
            //throw new NotImplementedException();
            string[] linha = { PrepararLinha(e) };
            File.AppendAllLines(PATH, linha);
            //cria a linha
        }

        private string PrepararLinha(Equipe _equipe){
            return $"{_equipe.IdEquipe};{_equipe.Nome};{_equipe.Imagem}";
            // formato da linha do csv
        }

        public List<Equipe> ReadAll()
        {
            //throw new NotImplementedException();
            List<Equipe> equipes = new List<Equipe>();
            string[] linhas = File.ReadAllLines(PATH);
            foreach (var item in linhas)
            {
                string[] linha = item.Split(";");
                Equipe equipe = new Equipe();
                equipe.IdEquipe = Int32.Parse(linha[0]);
                equipe.Nome = linha[1];
                equipe.Imagem = linha[2];

                equipes.Add(equipe);
            }
            return equipes;
        }

        public void Update(Equipe e)
        {
            //throw new NotImplementedException();
            List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(x => x.Split(";")[0] == e.IdEquipe.ToString());
            linhas.Add( PrepararLinha(e) );
            RewriteCSV(PATH, linhas);
            //"alterar"
        }

        public void Delete(int id)
        {
            //throw new NotImplementedException();
            List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(x => x.Split(";")[0] == id.ToString());
            RewriteCSV(PATH, linhas);
            // deleta 
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
            // reescreve o csv (update)
        }
    }
}