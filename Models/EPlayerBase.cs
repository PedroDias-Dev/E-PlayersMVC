using System.IO;

namespace E_Players_1.Models
{
    public class EPlayerBase
    {
        public void CreateFolderAndFile(string _path){

            string folder   = _path.Split("/")[0];
            //string file     = _path.Split("/")[1];

            if(!Directory.Exists(folder)){
                Directory.CreateDirectory(folder);
            }

            if(!File.Exists(_path)){
                File.Create(_path).Close();
            }
            // VERIIFICA A EXISTENCIA DOS DIRETORIOS
            // CASO NAO EXISTA ELE CRIA
            // PODE SER USADO EM QUALQUER CLASSE POR HERANÇA
        }
    }
}