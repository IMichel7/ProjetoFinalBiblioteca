using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ProjetoFinalBiblioteca
{
    public class FrmGenerico : Form
    {
        private NumericUpDown nudAno;
        private TextBox txtGenero;
        private ComboBox cbStatus, cbTipo;
        private Button btnSalvar, btnListar;
        private DataGridView dgvGenericos;

        private List<Generico> listaGenericos = new List<Generico>();

        public FrmGenerico()
        {
            this.Text = "Cadastro de Genérico";
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

            Controls.Add(new Label { Text = "Tipo:", Location = new Point(leftLabel, 140), AutoSize = true });
            cbTipo = new ComboBox
            {
                Location = new Point(leftInput, 136),
                Width = 150,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cbTipo.DataSource = Enum.GetValues(typeof(EnumGenericoTipo));
            Controls.Add(cbTipo);

            btnSalvar = new Button { Text = "Salvar", Location = new Point(leftInput, 180), Width = 100 };
            btnSalvar.Click += BtnSalvar_Click;
            Controls.Add(btnSalvar);

            btnListar = new Button { Text = "Listar", Location = new Point(leftInput + 120, 180), Width = 100 };
            btnListar.Click += BtnListar_Click;
            Controls.Add(btnListar);

            dgvGenericos = new DataGridView
            {
                Location = new Point(10, 230),
                Size = new Size(460, 130),
                ReadOnly = true,
                AllowUserToAddRows = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };
            Controls.Add(dgvGenericos);
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                var item = new Generico(
                    ano: (int)nudAno.Value,
                    genero: txtGenero.Text,
                    status: (EnumExemplarStatus)cbStatus.SelectedItem,
                    tipo: (EnumGenericoTipo)cbTipo.SelectedItem
                );

                listaGenericos.Add(item);
                MessageBox.Show("Genérico cadastrado com sucesso!");
                LimparCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar: " + ex.Message);
            }
        }

        private void BtnListar_Click(object sender, EventArgs e)
        {
            dgvGenericos.DataSource = null;
            dgvGenericos.DataSource = listaGenericos.Select(g => new
            {
                g.Ano,
                g.Genero,
                g.Tipo,
                Status = g.Status.ToString()
            }).ToList();
        }

        private void LimparCampos()
        {
            nudAno.Value = 1900;
            txtGenero.Clear();
            cbStatus.SelectedIndex = 0;
            cbTipo.SelectedIndex = 0;
        }
    }
}
