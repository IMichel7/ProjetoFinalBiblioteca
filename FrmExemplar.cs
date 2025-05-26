using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ProjetoFinalBiblioteca
{
    public class FrmExemplar : Form
    {
        private NumericUpDown nudAno;
        private TextBox txtGenero;
        private ComboBox cbStatus;
        private Button btnSalvar;

        public FrmExemplar()
        {
            this.Text = "Cadastro de Exemplar";
            this.ClientSize = new Size(350, 200);
            this.StartPosition = FormStartPosition.CenterParent;

            var lblAno = new Label { Text = "Ano:", Location = new Point(10, 20), AutoSize = true };
            nudAno = new NumericUpDown { Location = new Point(100, 16), Width = 80, Minimum = 1900, Maximum = DateTime.Now.Year };

            var lblGen = new Label { Text = "Gênero:", Location = new Point(10, 60), AutoSize = true };
            txtGenero = new TextBox { Location = new Point(100, 56), Width = 200 };

            var lblStatus = new Label { Text = "Status:", Location = new Point(10, 100), AutoSize = true };
            cbStatus = new ComboBox { Location = new Point(100, 96), Width = 200, DropDownStyle = ComboBoxStyle.DropDownList };
            cbStatus.DataSource = Enum.GetValues(typeof(EnumExemplarStatus));

            btnSalvar = new Button { Text = "Salvar", Location = new Point(220, 140), Size = new Size(80, 30) };
            btnSalvar.Click += BtnSalvar_Click;

            this.Controls.AddRange(new Control[] { lblAno, nudAno, lblGen, txtGenero, lblStatus, cbStatus, btnSalvar });
        }

        private void BtnSalvar_Click(object? sender, EventArgs e)
        {
            int ano = (int)nudAno.Value;
            string genero = txtGenero.Text;
            var status = (EnumExemplarStatus)cbStatus.SelectedItem!;
            MessageBox.Show($"Exemplar → Ano: {ano}, Gênero: {genero}, Status: {status.GetDescription()}", "Exemplar Salvo");
            this.Close();
        }
    }
}