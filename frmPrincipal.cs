using Movimentações.UI;

namespace NexStock.UI
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void btnEntrarProdutos_Click(object sender, EventArgs e)
        {
            var produtos = new frmProdutos();
            produtos.ShowDialog();
        }

        private void btnEntrarMovimentacoes_Click(object sender, EventArgs e)
        {
            var movimentacoes = new frmMovimentacoes();
            movimentacoes.ShowDialog();
        }

        private void btnEntrarCategorias_Click(object sender, EventArgs e)
        {
            var categorias = new frmCategorias();
            categorias.ShowDialog();
        }


    }
}
