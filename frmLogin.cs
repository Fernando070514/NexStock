using NexStock.UI.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NexStock.UI
{
    public partial class frmLogin : Form
    {
        private readonly UsuarioApiService _usuarioApiService = new();
        public frmLogin()
        {
            InitializeComponent();
        }

        private async void btnEntrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text) || 
                string.IsNullOrWhiteSpace(txtSenha.Text))
            {
                MessageBox.Show("Preencha seu email e sua senha corretamente.", "Atenção", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            btnEntrar.Enabled = false;
            btnEntrar.Text = "Entrando...";

            try
            {
                var resultado = await _usuarioApiService.LoginAsync(
                    email: txtEmail.Text.Trim(),
                    senha: txtSenha.Text);
               
                if (resultado == null)
                {
                    return;
                }

                if (resultado.Sucesso)
                {
                    var principal = new frmPrincipal();
                    principal.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show($"Acesso negado. \n{resultado.Mensagem}",
                      "Login Errado",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            finally
            {
                btnEntrar.Enabled = true;
                btnEntrar.Text = "Entrar";
            }
        }
    }
}
