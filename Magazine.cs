using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ProjetoFinalBiblioteca
{
    public class Magazine : Form
    {
        private NumericUpDown nudAno, nudEdicao, nudPaginas;
        private TextBox txtGenero;
        private ComboBox cbStatus;
        private Button btnSalvar, btnListar;
        private DataGridView dgvRevistas;

        private List<Revista> listaRevistas = new List<Revista>();

        public Magazine()
        {
            this.Text = "Cadastro de Revista";
            this.ClientSize = new Size(550, 420);
            this.StartPosition = FormStartPosition.CenterParent;

            int leftLabel = 10, leftInput = 140;

            Controls.Add(new Label { Text = "Ano:", Location = new Point(leftLabel, 20), AutoSize = true });
            nudAno = new NumericUpDown { Location = new Point(leftInput, 16), Width = 80, Minimum = 1900, Maximum = DateTime.Now.Year };
            Controls.Add(nudAno);

            Controls.Add(new Label { Text = "Gênero:", Location = new Point(leftLabel, 60), AutoSize = true });
            txtGenero = new TextBox { Location = new Point(leftInput, 56), Width = 250 };
            Controls.Add(txtGenero);

            Controls.Add(new Label { Text = "Status:", Location = new Point(leftLabel, 100), AutoSize = true });
            cbStatus = new ComboBox
            {
                Location = new Point(leftInput, 96),
                Width = 150,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cbStatus.DataSource = Enum.GetValues(typeof(EnumExemplarStatus));
            Controls.Add(cbStatus);

            Controls.Add(new Label { Text = "Edição:", Location = new Point(leftLabel, 140), AutoSize = true });
            nudEdicao = new NumericUpDown { Location = new Point(leftInput, 136), Width = 80, Minimum = 1, Maximum = 1000 };
            Controls.Add(nudEdicao);

            Controls.Add(new Label { Text = "Páginas:", Location = new Point(leftLabel, 180), AutoSize = true });
            nudPaginas = new NumericUpDown { Location = new Point(leftInput, 176), Width = 80, Minimum = 1, Maximum = 2000 };
            Controls.Add(nudPaginas);

            btnSalvar = new Button { Text = "Salvar", Location = new Point(leftInput, 220), Width = 100 };
            btnSalvar.Click += BtnSalvar_Click;
            Controls.Add(btnSalvar);

            btnListar = new Button { Text = "Listar", Location = new Point(leftInput + 120, 220), Width = 100 };
            btnListar.Click += BtnListar_Click;
            Controls.Add(btnListar);

            dgvRevistas = new DataGridView
            {
                Location = new Point(10, 270),
                Size = new Size(520, 130),
                ReadOnly = true,
                AllowUserToAddRows = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };
            Controls.Add(dgvRevistas);
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                var revista = new Revista(
                    ano: (int)nudAno.Value,
                    genero: txtGenero.Text,
                    status: (EnumExemplarStatus)cbStatus.SelectedItem,
                    edicao: (int)nudEdicao.Value,
                    paginas: (int)nudPaginas.Value
                );

                listaRevistas.Add(revista);
                MessageBox.Show("Revista cadastrada com sucesso!");
                LimparCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar: " + ex.Message);
            }
        }

        private void BtnListar_Click(object sender, EventArgs e)
        {
            dgvRevistas.DataSource = null;
            dgvRevistas.DataSource = listaRevistas.Select(r => new
            {
                r.Ano,
                r.Genero,
                r.Edicao,
                r.Paginas,
                Status = r.Status.ToString()
            }).ToList();
        }

        private void LimparCampos()
        {
            nudAno.Value = 1900;
            txtGenero.Clear();
            nudEdicao.Value = 1;
            nudPaginas.Value = 1;
            cbStatus.SelectedIndex = 0;
        }
    }
}
