using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lib.Criptografia;

namespace CriptografiaInterface
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void btnIniciar_Click_1(object sender, EventArgs e)
        {
            int opcao = rdCript.Checked ? 0 : 1;

            if(string.IsNullOrEmpty(txtCaminho.Text) || txtCaminho.Text.Contains("File..."))
            {
                MessageBox.Show("Selecione o Arquivo", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(textSenha.Text))
            {
                MessageBox.Show("Digite uma Senha para Criptografia", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Lib.Criptografia.Manager.Menu(txtCaminho.Text, textSenha.Text, opcao);

            if (opcao == 0)
            {
                EscreverLog("Arquivo Criptografado");
            }
            else
            {
                EscreverLog("Arquivo Descriptografado");
                EscreverLog("Abrindo Arquivo...");
                System.Diagnostics.Process.Start(txtCaminho.Text);
                Escrevertextbyte();
            }

        }

        private void btnProcurar_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            DialogResult dialogResult = openFileDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                string fileName = openFileDialog.FileName;
                try
                {
                    txtCaminho.Text = System.IO.Path.GetFullPath(fileName);
                }
                catch (System.Exception)
                {
                }
            }
        }
        private void EscreverLog(string msg)
        {
            if (string.IsNullOrEmpty(rtxtLog.Text))
            {
                rtxtLog.Text = msg;
            }
            else
            {
                rtxtLog.Text += string.Concat("\n" + msg);
            }

        }

        private void Escrevertextbyte()
        {
            rtByte.Text = Lib.Criptografia.Service.bytestring;
        }
      
    }
}
