using System;
using System.Drawing;
using System.Windows.Forms;

namespace ProjetoFinalBiblioteca
{
    public class Customer : BaseForm
    {
        public Customer() : base("Cadastro de Pessoa")
        {
            ClientSize = new Size(400, 260);
            var tbl = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(20, 80, 20, 20),
                ColumnCount = 2,
                RowCount = 4
            };
            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30)); tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70));
            for (int i = 0; i < 4; i++) tbl.RowStyles.Add(new RowStyle(SizeType.Absolute, 40f));
            Controls.Add(tbl);
            var dtp = new DateTimePicker { Dock = DockStyle.Fill, Format = DateTimePickerFormat.Short };
            var txtCpf = new TextBox { Dock = DockStyle.Fill }; var txtTel = new TextBox { Dock = DockStyle.Fill };
            var btn = new Button { Text = "Salvar", Anchor = AnchorStyles.Right, Size = new Size(100, 30) };
            btn.Click += (s, e) => { var p = new Leitor(dtp.Value, txtCpf.Text, txtTel.Text, "Comum"); MessageBox.Show(p.GetInfo(), "Salvo"); Close(); };
            tbl.Controls.Add(new Label { Text = "Nascimento:", TextAlign = ContentAlignment.MiddleRight }, 0, 0); tbl.Controls.Add(dtp, 1, 0);
            tbl.Controls.Add(new Label { Text = "CPF:", TextAlign = ContentAlignment.MiddleRight }, 0, 1); tbl.Controls.Add(txtCpf, 1, 1);
            tbl.Controls.Add(new Label { Text = "Telefone:", TextAlign = ContentAlignment.MiddleRight }, 0, 2); tbl.Controls.Add(txtTel, 1, 2);
            tbl.Controls.Add(btn, 1, 3);
        }
    }
}