using System;
using System.Collections.Generic;
using System.Text;

namespace Lib.Criptografia
{
    public class Manager
    {


        public static void Menu(string caminhofile, string chave, int opcao)
        {

            string file = opcao == 0 ? Service.Criptografar(caminhofile, chave) : Service.Descriptografar(caminhofile, chave);
                            
        }
    }
}
