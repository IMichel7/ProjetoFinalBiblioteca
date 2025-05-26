using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ProjetoFinalBiblioteca
{
    // BaseForm: fornece cabeçalho estilizado, canto arredondado e botão fechar
    public abstract class BaseForm : Form
    {
        private Panel pnlHeader;
        private Label lblTitle;
        private Button btnClose;

        // Para arredondar cantos
        [DllImport("gdi32.dll")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect, int nTopRect, int nRightRect, int nBottomRect,
            int nWidthEllipse, int nHeightEllipse);

        // Para arrastar a janela pelo header
        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HTCAPTION = 0x2;

        protected BaseForm(string title)
        {
            // configurações gerais da janela
            FormBorderStyle = FormBorderStyle.None;
            DoubleBuffered = true;
            BackColor = Color.FromArgb(245, 245, 245);
            Font = new Font("Segoe UI", 10);
            Padding = new Padding(0);
            StartPosition = FormStartPosition.CenterScreen;

            // cabeçalho
            pnlHeader = new Panel
            {
                Dock = DockStyle.Top,
                Height = 60,
                BackColor = Color.Red
            };
            Controls.Add(pnlHeader);

            lblTitle = new Label
            {
                Text = title,
                Dock = DockStyle.Fill,
                ForeColor = Color.White,
                Font = new Font(Font.FontFamily, 16, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter
            };
            pnlHeader.Controls.Add(lblTitle);

            btnClose = new Button
            {
                FlatStyle = FlatStyle.Flat,
                BackColor = pnlHeader.BackColor,
                ForeColor = Color.White,
                Text = "✕",
                Font = new Font(Font.FontFamily, 12, FontStyle.Regular),
                Size = new Size(60, 60),
                Dock = DockStyle.Right
            };
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.Click += (s, e) => Close();
            pnlHeader.Controls.Add(btnClose);

            // arrastar pela header
            pnlHeader.MouseDown += (s, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    ReleaseCapture();
                    SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
                }
            };

            // arredondar cantos ao carregar
            Load += (s, e) =>
            {
                IntPtr hRgn = CreateRoundRectRgn(0, 0, Width, Height, 20, 20);
                Region = Region.FromHrgn(hRgn);
            };
        }
    }

    // FrmMenu: janela principal com botões 2×4 centralizados
    public class FrmMenu : BaseForm
    {
        public FrmMenu()
            : base("Biblioteca do Saber")
        {
            // Janela maior e menos retangular
            ClientSize = new Size(900, 600);

            // Layout 2×4 centralizado
            var table = new TableLayoutPanel
            {
                RowCount = 2,
                ColumnCount = 4,
                Size = new Size(760, 340),
                Location = new Point(
                                 (ClientSize.Width - 760) / 2,
                                 (ClientSize.Height - 340) / 2 + 20
                             ),
                BackColor = BackColor
            };
            // define proporções
            table.ColumnStyles.Clear();
            for (int i = 0; i < 4; i++)
                table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            table.RowStyles.Clear();
            for (int i = 0; i < 2; i++)
                table.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));

            Controls.Add(table);

            // Função para criar botões grandes
            void AddButton(string text, Form form, int row, int col)
            {
                var btn = new Button
                {
                    Text = text,
                    Dock = DockStyle.Fill,
                    Margin = new Padding(10),
                    FlatStyle = FlatStyle.Flat,
                    BackColor = Color.Red,
                    ForeColor = Color.White,
                    Font = new Font(Font.FontFamily, 14, FontStyle.Bold)
                };
                btn.FlatAppearance.BorderSize = 0;
                btn.Click += (_, __) => { form.Font = Font; form.ShowDialog(); };
                table.Controls.Add(btn, col, row);
            }

            // Títulos e formulários
            var titles = new[]
            {
                "Pessoa", "Leitor", "Funcionário", "Exemplar",
                "Livro",  "Revista", "HQ",          "Genérico"
            };
            var forms = new Form[]
            {
                new Customer(), new Member(), new FrmFuncionario(), new FrmExemplar(),
                new Book(),  new Magazine(), new Comic(),         new FrmGenerico()
            };

            // Popula a grade
            for (int idx = 0; idx < titles.Length; idx++)
                AddButton(titles[idx], forms[idx], idx / 4, idx % 4);
        }
    }
}
