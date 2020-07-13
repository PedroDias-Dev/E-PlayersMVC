using E_Players_1.Models;
using System.Collections.Generic;

namespace E_Players_1.Interfaces
{
    // cria um contrato para todos os metodos CRUD do Equipe.cs
    // CRUD: 
    // CREATE
    // UPDATE
    // DELETE

    public interface IEquipe
    {
        void Create(Equipe e);

        List<Equipe> ReadAll();

        void Update(Equipe e);

        void Delete(int id);
    }
}