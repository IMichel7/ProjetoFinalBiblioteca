using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ProjetoFinalBiblioteca
{
    public class Comic : Form
    {
        private NumericUpDown nudAno, nudEdicao;
        private TextBox txtGenero;
        private ComboBox cbStatus;
        private Button btnSalvar, btnListar;
        private DataGridView dgvHQs;

        private List<HQ> listaHQs = new List<HQ>();

        public Comic()
        {
            this.Text = "Cadastro de HQ";
            this.ClientSize = new Size(500, 400);
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

            btnSalvar = new Button { Text = "Salvar", Location = new Point(leftInput, 180), Width = 100 };
            btnSalvar.Click += BtnSalvar_Click;
            Controls.Add(btnSalvar);

            btnListar = new Button { Text = "Listar", Location = new Point(leftInput + 120, 180), Width = 100 };
            btnListar.Click += BtnListar_Click;
            Controls.Add(btnListar);

            dgvHQs = new DataGridView
            {
                Location = new Point(10, 230),
                Size = new Size(460, 130),
                ReadOnly = true,
                AllowUserToAddRows = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };
            Controls.Add(dgvHQs);
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                var hq = new HQ(
                    ano: (int)nudAno.Value,
                    genero: txtGenero.Text,
                    status: (EnumExemplarStatus)cbStatus.SelectedItem,
                    edicao: (int)nudEdicao.Value
                );

                listaHQs.Add(hq);
                MessageBox.Show("HQ cadastrada com sucesso!");
                LimparCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar: " + ex.Message);
            }
        }

        private void BtnListar_Click(object sender, EventArgs e)
        {
            dgvHQs.DataSource = null;
            dgvHQs.DataSource = listaHQs.Select(h => new
            {
                h.Ano,
                h.Genero,
                h.Edicao,
                Status = h.Status.ToString()
            }).ToList();
        }

        private void LimparCampos()
        {
            nudAno.Value = 1900;
            txtGenero.Clear();
            nudEdicao.Value = 1;
            cbStatus.SelectedIndex = 0;
        }
    }
}
