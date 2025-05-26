using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ProjetoFinalBiblioteca
{
    public class Member : Form
    {
        private DateTimePicker dtpNascimento;
        private TextBox txtCpf, txtTelefone;
        private ComboBox cbTipo;
        private Button btnSalvar, btnListar;
        private DataGridView dgvLeitores;

        private List<Leitor> listaLeitores = new List<Leitor>();

        public Member()
        {
            this.Text = "Cadastro de Leitor";
            this.ClientSize = new Size(500, 400);
            this.StartPosition = FormStartPosition.CenterParent;

            int leftLabel = 10, leftInput = 140;

            Controls.Add(new Label { Text = "Nascimento:", Location = new Point(leftLabel, 20), AutoSize = true });
            dtpNascimento = new DateTimePicker { Location = new Point(leftInput, 16), Format = DateTimePickerFormat.Short };
            Controls.Add(dtpNascimento);

            Controls.Add(new Label { Text = "CPF:", Location = new Point(leftLabel, 60), AutoSize = true });
            txtCpf = new TextBox { Location = new Point(leftInput, 56), Width = 150 };
            Controls.Add(txtCpf);

            Controls.Add(new Label { Text = "Telefone:", Location = new Point(leftLabel, 100), AutoSize = true });
            txtTelefone = new TextBox { Location = new Point(leftInput, 96), Width = 150 };
            Controls.Add(txtTelefone);

            Controls.Add(new Label { Text = "Tipo:", Location = new Point(leftLabel, 140), AutoSize = true });
            cbTipo = new ComboBox
            {
                Location = new Point(leftInput, 136),
                Width = 150,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cbTipo.Items.AddRange(new string[] { "Estudante", "Professor", "Visitante" });
            cbTipo.SelectedIndex = 0;
            Controls.Add(cbTipo);

            btnSalvar = new Button { Text = "Salvar", Location = new Point(leftInput, 180), Width = 100 };
            btnSalvar.Click += BtnSalvar_Click;
            Controls.Add(btnSalvar);

            btnListar = new Button { Text = "Listar", Location = new Point(leftInput + 120, 180), Width = 100 };
            btnListar.Click += BtnListar_Click;
            Controls.Add(btnListar);

            dgvLeitores = new DataGridView
            {
                Location = new Point(10, 230),
                Size = new Size(460, 140),
                ReadOnly = true,
                AllowUserToAddRows = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };
            Controls.Add(dgvLeitores);
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                var leitor = new Leitor(
                    nascimento: dtpNascimento.Value,
                    cpf: txtCpf.Text,
                    telefone: txtTelefone.Text,
                    tipo: cbTipo.SelectedItem.ToString()
                );

                listaLeitores.Add(leitor);
                MessageBox.Show("Leitor cadastrado com sucesso!");
                LimparCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar: {ex.Message}");
            }
        }

        private void BtnListar_Click(object sender, EventArgs e)
        {
            dgvLeitores.DataSource = null;
            dgvLeitores.DataSource = listaLeitores.Select(l => new
            {
                l.Cpf,
                l.Telefone,
                l.Tipo,
                Nascimento = l.Nascimento.ToShortDateString()
            }).ToList();
        }

        private void LimparCampos()
        {
            txtCpf.Clear();
            txtTelefone.Clear();
            cbTipo.SelectedIndex = 0;
            dtpNascimento.Value = DateTime.Today;
        }
    }
}
