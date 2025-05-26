using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ProjetoFinalBiblioteca
{
    public class Book : Form
    {
        private NumericUpDown nudAno, nudPaginas;
        private TextBox txtGenero, txtTipoCapa;
        private ComboBox cbStatus;
        private Button btnSalvar, btnListar;
        private DataGridView dgvLivros;

        private List<Livro> listaLivros = new List<Livro>();

        public Book()
        {
            this.Text = "Cadastro de Livro";
            this.ClientSize = new Size(550, 420);
            this.StartPosition = FormStartPosition.CenterParent;

            int leftLabel = 10, leftInput = 140;

            Controls.Add(new Label { Text = "Ano:", Location = new Point(leftLabel, 20), AutoSize = true });
            nudAno = new NumericUpDown { Location = new Point(leftInput, 16), Width = 80, Minimum = 1900, Maximum = DateTime.Now.Year };
            Controls.Add(nudAno);

            Controls.Add(new Label { Text = "Gênero:", Location = new Point(leftLabel, 60), AutoSize = true });
            txtGenero = new TextBox { Location = new Point(leftInput, 56), Width = 250 };
            Controls.Add(txtGenero);

            Controls.Add(new Label { Text = "Tipo de Capa:", Location = new Point(leftLabel, 100), AutoSize = true });
            txtTipoCapa = new TextBox { Location = new Point(leftInput, 96), Width = 250 };
            Controls.Add(txtTipoCapa);

            Controls.Add(new Label { Text = "Nº de Páginas:", Location = new Point(leftLabel, 140), AutoSize = true });
            nudPaginas = new NumericUpDown { Location = new Point(leftInput, 136), Width = 80, Minimum = 1, Maximum = 10000 };
            Controls.Add(nudPaginas);

            Controls.Add(new Label { Text = "Status:", Location = new Point(leftLabel, 180), AutoSize = true });
            cbStatus = new ComboBox
            {
                Location = new Point(leftInput, 176),
                Width = 150,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cbStatus.DataSource = Enum.GetValues(typeof(EnumExemplarStatus));
            Controls.Add(cbStatus);

            btnSalvar = new Button { Text = "Salvar", Location = new Point(leftInput, 220), Width = 100 };
            btnSalvar.Click += BtnSalvar_Click;
            Controls.Add(btnSalvar);

            btnListar = new Button { Text = "Listar", Location = new Point(leftInput + 120, 220), Width = 100 };
            btnListar.Click += BtnListar_Click;
            Controls.Add(btnListar);

            dgvLivros = new DataGridView
            {
                Location = new Point(10, 270),
                Size = new Size(520, 130),
                ReadOnly = true,
                AllowUserToAddRows = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };
            Controls.Add(dgvLivros);
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                Livro livro = new Livro(
                    ano: (int)nudAno.Value,
                    genero: txtGenero.Text,
                    status: (EnumExemplarStatus)cbStatus.SelectedItem,
                    paginas: (int)nudPaginas.Value,
                    tipoCapa: txtTipoCapa.Text
                );

                listaLivros.Add(livro);
                MessageBox.Show("Livro cadastrado com sucesso!");
                LimparCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar: " + ex.Message);
            }
        }


        private void BtnListar_Click(object sender, EventArgs e)
        {
            dgvLivros.DataSource = listaLivros.Select(l => new
            {
                l.Ano,
                l.Genero,
                l.TipoCapa,
                l.Paginas,
                Status = l.Status.ToString()
            }).ToList();
        }

        private void LimparCampos()
        {
            nudAno.Value = 1900;
            txtGenero.Clear();
            txtTipoCapa.Clear();
            nudPaginas.Value = 1;
            cbStatus.SelectedIndex = 0;
        }
    }
}
