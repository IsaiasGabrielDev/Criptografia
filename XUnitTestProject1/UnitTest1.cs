using System;
using Xunit;
using Lib.Criptografia;
using System.IO;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            string caminho = @"C:\Users\Isaias\Documents\Folha de Ponto\Espelho Colaborador New - Copia - Copia - Copia - Copia.PDF";

            var code = Lib.Criptografia.Service.Encodeteste(caminho);

            var codestring = System.Convert.FromBase64String(code);

            var codestring2 = System.Text.ASCIIEncoding.UTF8.GetString(codestring);

            File.WriteAllBytes(caminho, codestring);

            code = Lib.Criptografia.Service.Decodeteste(caminho);

            File.WriteAllBytes(caminho, System.Text.ASCIIEncoding.UTF8.GetBytes(code));

        }
    }
}