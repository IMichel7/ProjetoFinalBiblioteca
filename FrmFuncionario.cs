using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ProjetoFinalBiblioteca
{
    public class FrmFuncionario : Form
    {
        private DateTimePicker dtpNascimento;
        private TextBox txtCpf, txtTelefone, txtFuncao, txtSalario;
        private NumericUpDown nudCarga;
        private ComboBox cbCargo;
        private Button btnSalvar, btnListar;
        private DataGridView dgvFuncionarios;

        private List<Funcionario> listaFuncionarios = new List<Funcionario>();

        public FrmFuncionario()
        {
            this.Text = "Cadastro de Funcionário";
            this.ClientSize = new Size(600, 500);
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

            Controls.Add(new Label { Text = "Cargo:", Location = new Point(leftLabel, 140), AutoSize = true });
            cbCargo = new ComboBox { Location = new Point(leftInput, 136), Width = 150, DropDownStyle = ComboBoxStyle.DropDownList };
            cbCargo.DataSource = Enum.GetValues(typeof(EnumFuncionarioCargo));
            Controls.Add(cbCargo);

            Controls.Add(new Label { Text = "Salário:", Location = new Point(leftLabel, 180), AutoSize = true });
            txtSalario = new TextBox { Location = new Point(leftInput, 176), Width = 150 };
            Controls.Add(txtSalario);

            Controls.Add(new Label { Text = "Carga Horária:", Location = new Point(leftLabel, 220), AutoSize = true });
            nudCarga = new NumericUpDown { Location = new Point(leftInput, 216), Width = 60, Minimum = 1, Maximum = 44 };
            Controls.Add(nudCarga);

            Controls.Add(new Label { Text = "Função:", Location = new Point(leftLabel, 260), AutoSize = true });
            txtFuncao = new TextBox { Location = new Point(leftInput, 256), Width = 200 };
            Controls.Add(txtFuncao);

            btnSalvar = new Button { Text = "Salvar", Location = new Point(leftInput, 300), Width = 100 };
            btnSalvar.Click += BtnSalvar_Click;
            Controls.Add(btnSalvar);

            btnListar = new Button { Text = "Listar", Location = new Point(leftInput + 120, 300), Width = 100 };
            btnListar.Click += BtnListar_Click;
            Controls.Add(btnListar);

            dgvFuncionarios = new DataGridView
            {
                Location = new Point(10, 350),
                Size = new Size(560, 130),
                ReadOnly = true,
                AllowUserToAddRows = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };
            Controls.Add(dgvFuncionarios);
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                var funcionario = new Funcionario(
                    nascimento: dtpNascimento.Value,
                    cpf: txtCpf.Text,
                    telefone: txtTelefone.Text,
                    cargo: (EnumFuncionarioCargo)cbCargo.SelectedItem,
                    salario: decimal.Parse(txtSalario.Text),
                    cargaHoraria: (int)nudCarga.Value,
                    funcao: txtFuncao.Text
                );

                listaFuncionarios.Add(funcionario);
                MessageBox.Show("Funcionário cadastrado com sucesso!");
                LimparCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar: {ex.Message}");
            }
        }

        private void BtnListar_Click(object sender, EventArgs e)
        {
            dgvFuncionarios.DataSource = null;
            dgvFuncionarios.DataSource = listaFuncionarios.Select(f => new
            {
                f.Cpf,
                f.Telefone,
                f.Cargo,
                f.Salario,
                f.CargaHoraria,
                f.Funcao,
                Nascimento = f.Nascimento.ToShortDateString()
            }).ToList();
        }


        private void LimparCampos()
        {
            txtCpf.Clear();
            txtTelefone.Clear();
            txtSalario.Clear();
            txtFuncao.Clear();
            nudCarga.Value = 1;
            cbCargo.SelectedIndex = 0;
            dtpNascimento.Value = DateTime.Today;
        }
    }
}
