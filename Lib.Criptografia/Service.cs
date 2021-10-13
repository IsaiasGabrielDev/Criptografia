using System;
using System.IO;
using System.Linq;
using System.Text;

namespace Lib.Criptografia
{
    public static class Service
    {
        public static string bytestring { get; set; }
        public static string Criptografar(string file, string chave)
        {
            try
            {
                var filebyte = File.ReadAllBytes(file);


                var filestring = System.Convert.ToBase64String(filebyte);

                var codificar = Encode(filestring);

                var codificarComChave = String.Concat(chave, "*****", codificar);

                var codificar2x = Encode(codificarComChave);

                var codificar3x = Encode(codificar2x);

                var codificado = System.Convert.FromBase64String(codificar3x);

                File.WriteAllBytes(file, codificado);

                return file;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static string Descriptografar(string file, string chave)
        {
            var filebyte = File.ReadAllBytes(file);

            var filestring64 = System.Convert.ToBase64String(filebyte);

            var decodificar = Decode(filestring64);

            var decodificar2x = Decode(decodificar);

            string[] separador = { "*****" };
            Int32 count = 2;
            var textoseparado = decodificar2x.Split(separador, count, StringSplitOptions.None);

            if (textoseparado[0].Contains(chave))
            {

                var decode = Decode(textoseparado[1].ToString());
                bytestring = decode;
                File.WriteAllBytes(file, System.Convert.FromBase64String(decode));

                //MemoryStream ms = new MemoryStream(System.Text.ASCIIEncoding.UTF8.GetBytes(decode));
                ////write to file
                //File.Delete(file);
                //FileStream filestream = new FileStream(file, FileMode.Create, FileAccess.Write);
                //ms.WriteTo(filestream);
                //filestream.Close();
                //ms.Close();

                return file;
            }

            return null;
        }

        static private string Encode(string toEncode)
        {
            byte[] toEncodebyte = System.Text.ASCIIEncoding.UTF8.GetBytes(toEncode);

            string string64 = System.Convert.ToBase64String(toEncodebyte);

            return string64;
        }

        static private string Decode(string decode)
        {
            byte[] databyte = System.Convert.FromBase64String(decode);

            string bytetostring = System.Text.ASCIIEncoding.UTF8.GetString(databyte);

            return bytetostring;
        }

        static public string Encodeteste(string toEncode)
        {
            var file = File.ReadAllBytes(toEncode);

            string string64 = System.Convert.ToBase64String(file);

            return string64;
        }

        static public string Decodeteste(string decode)
        {
            var file = File.ReadAllBytes(decode);

            var file64 = System.Text.ASCIIEncoding.UTF8.GetString(file);

            byte[] databyte = System.Convert.FromBase64String(file64);

            string bytetostring = System.Text.ASCIIEncoding.UTF8.GetString(databyte);

            return bytetostring;
        }


    }
}

