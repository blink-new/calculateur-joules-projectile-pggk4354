using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace CalculateurJoulesWindows
{
    public partial class MainForm : Form
    {
        private TextBox txtGrains;
        private TextBox txtWeight;
        private TextBox txtVelocity;
        private Label lblResult;
        private Label lblGrainsValue;
        private Label lblWeightValue;
        private Label lblVelocityValue;
        private Panel resultPanel;
        private Button btnReset;
        private Label lblFormula;

        public MainForm()
        {
            InitializeComponent();
            SetupEventHandlers();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();

            // Configuration de la fenêtre principale
            this.Text = "Calculateur d'énergie en joules pour projectiles";
            this.Size = new Size(900, 700);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(248, 250, 252);
            this.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            // Titre principal
            Label titleLabel = new Label();
            titleLabel.Text = "🧮 Calculateur d'énergie";
            titleLabel.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            titleLabel.ForeColor = Color.FromArgb(30, 64, 175);
            titleLabel.Location = new Point(50, 30);
            titleLabel.Size = new Size(800, 40);
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(titleLabel);

            // Sous-titre
            Label subtitleLabel = new Label();
            subtitleLabel.Text = "Calculez l'énergie cinétique d'un projectile en joules à partir du nombre de grains,\\ndu poids de la balle et de sa vitesse";
            subtitleLabel.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
            subtitleLabel.ForeColor = Color.FromArgb(75, 85, 99);
            subtitleLabel.Location = new Point(50, 80);
            subtitleLabel.Size = new Size(800, 50);
            subtitleLabel.TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(subtitleLabel);

            // Panel de gauche - Formulaire
            Panel leftPanel = new Panel();
            leftPanel.Location = new Point(50, 150);
            leftPanel.Size = new Size(380, 450);
            leftPanel.BackColor = Color.White;
            leftPanel.BorderStyle = BorderStyle.None;
            leftPanel.Paint += (s, e) => {
                ControlPaint.DrawBorder(e.Graphics, leftPanel.ClientRectangle,
                    Color.FromArgb(226, 232, 240), ButtonBorderStyle.Solid);
            };
            this.Controls.Add(leftPanel);

            // Titre du formulaire
            Label formTitle = new Label();
            formTitle.Text = "🎯 Paramètres du projectile";
            formTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            formTitle.ForeColor = Color.FromArgb(30, 64, 175);
            formTitle.Location = new Point(20, 20);
            formTitle.Size = new Size(340, 25);
            leftPanel.Controls.Add(formTitle);

            Label formSubtitle = new Label();
            formSubtitle.Text = "Saisissez les valeurs pour calculer l'énergie cinétique";
            formSubtitle.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            formSubtitle.ForeColor = Color.FromArgb(107, 114, 128);
            formSubtitle.Location = new Point(20, 50);
            formSubtitle.Size = new Size(340, 20);
            leftPanel.Controls.Add(formSubtitle);

            // Champ Grains
            Label lblGrains = new Label();
            lblGrains.Text = "● Nombre de grains de poudre";
            lblGrains.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblGrains.ForeColor = Color.FromArgb(30, 64, 175);
            lblGrains.Location = new Point(20, 90);
            lblGrains.Size = new Size(340, 20);
            leftPanel.Controls.Add(lblGrains);

            txtGrains = new TextBox();
            txtGrains.Font = new Font("Segoe UI", 12F);
            txtGrains.Location = new Point(20, 115);
            txtGrains.Size = new Size(340, 30);
            txtGrains.PlaceholderText = "Ex: 42";
            leftPanel.Controls.Add(txtGrains);

            Label lblGrainsHelp = new Label();
            lblGrainsHelp.Text = "Quantité de poudre utilisée";
            lblGrainsHelp.Font = new Font("Segoe UI", 8F);
            lblGrainsHelp.ForeColor = Color.FromArgb(107, 114, 128);
            lblGrainsHelp.Location = new Point(20, 150);
            lblGrainsHelp.Size = new Size(340, 15);
            leftPanel.Controls.Add(lblGrainsHelp);

            // Champ Poids
            Label lblWeight = new Label();
            lblWeight.Text = "● Poids de la balle (grammes)";
            lblWeight.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblWeight.ForeColor = Color.FromArgb(245, 158, 11);
            lblWeight.Location = new Point(20, 180);
            lblWeight.Size = new Size(340, 20);
            leftPanel.Controls.Add(lblWeight);

            txtWeight = new TextBox();
            txtWeight.Font = new Font("Segoe UI", 12F);
            txtWeight.Location = new Point(20, 205);
            txtWeight.Size = new Size(340, 30);
            txtWeight.PlaceholderText = "Ex: 9.5";
            leftPanel.Controls.Add(txtWeight);

            Label lblWeightHelp = new Label();
            lblWeightHelp.Text = "Masse du projectile en grammes";
            lblWeightHelp.Font = new Font("Segoe UI", 8F);
            lblWeightHelp.ForeColor = Color.FromArgb(107, 114, 128);
            lblWeightHelp.Location = new Point(20, 240);
            lblWeightHelp.Size = new Size(340, 15);
            leftPanel.Controls.Add(lblWeightHelp);

            // Champ Vitesse
            Label lblVelocity = new Label();
            lblVelocity.Text = "● Vitesse (m/s)";
            lblVelocity.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblVelocity.ForeColor = Color.FromArgb(34, 197, 94);
            lblVelocity.Location = new Point(20, 270);
            lblVelocity.Size = new Size(340, 20);
            leftPanel.Controls.Add(lblVelocity);

            txtVelocity = new TextBox();
            txtVelocity.Font = new Font("Segoe UI", 12F);
            txtVelocity.Location = new Point(20, 295);
            txtVelocity.Size = new Size(340, 30);
            txtVelocity.PlaceholderText = "Ex: 350";
            leftPanel.Controls.Add(txtVelocity);

            Label lblVelocityHelp = new Label();
            lblVelocityHelp.Text = "Vitesse du projectile en mètres par seconde";
            lblVelocityHelp.Font = new Font("Segoe UI", 8F);
            lblVelocityHelp.ForeColor = Color.FromArgb(107, 114, 128);
            lblVelocityHelp.Location = new Point(20, 330);
            lblVelocityHelp.Size = new Size(340, 15);
            leftPanel.Controls.Add(lblVelocityHelp);

            // Bouton Reset
            btnReset = new Button();
            btnReset.Text = "🔄 Réinitialiser";
            btnReset.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnReset.Location = new Point(20, 370);
            btnReset.Size = new Size(340, 45);
            btnReset.BackColor = Color.White;
            btnReset.ForeColor = Color.FromArgb(75, 85, 99);
            btnReset.FlatStyle = FlatStyle.Flat;
            btnReset.FlatAppearance.BorderColor = Color.FromArgb(209, 213, 219);
            btnReset.UseVisualStyleBackColor = false;
            leftPanel.Controls.Add(btnReset);

            // Panel de droite - Résultats
            Panel rightPanel = new Panel();
            rightPanel.Location = new Point(470, 150);
            rightPanel.Size = new Size(380, 450);
            rightPanel.BackColor = Color.White;
            rightPanel.BorderStyle = BorderStyle.None;
            rightPanel.Paint += (s, e) => {
                ControlPaint.DrawBorder(e.Graphics, rightPanel.ClientRectangle,
                    Color.FromArgb(226, 232, 240), ButtonBorderStyle.Solid);
            };
            this.Controls.Add(rightPanel);

            // Titre des résultats
            Label resultTitle = new Label();
            resultTitle.Text = "⚡ Énergie cinétique";
            resultTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            resultTitle.ForeColor = Color.FromArgb(245, 158, 11);
            resultTitle.Location = new Point(20, 20);
            resultTitle.Size = new Size(340, 25);
            rightPanel.Controls.Add(resultTitle);

            Label resultSubtitle = new Label();
            resultSubtitle.Text = "Résultat du calcul en temps réel";
            resultSubtitle.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            resultSubtitle.ForeColor = Color.FromArgb(107, 114, 128);
            resultSubtitle.Location = new Point(20, 50);
            resultSubtitle.Size = new Size(340, 20);
            rightPanel.Controls.Add(resultSubtitle);

            // Panel de résultat principal
            resultPanel = new Panel();
            resultPanel.Location = new Point(20, 80);
            resultPanel.Size = new Size(340, 180);
            resultPanel.BackColor = Color.FromArgb(248, 250, 252);
            resultPanel.BorderStyle = BorderStyle.None;
            resultPanel.Paint += (s, e) => {
                ControlPaint.DrawBorder(e.Graphics, resultPanel.ClientRectangle,
                    Color.FromArgb(226, 232, 240), ButtonBorderStyle.Solid);
            };
            rightPanel.Controls.Add(resultPanel);

            // Résultat principal
            lblResult = new Label();
            lblResult.Text = "Saisissez les valeurs\\npour voir le résultat";
            lblResult.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblResult.ForeColor = Color.FromArgb(107, 114, 128);
            lblResult.Location = new Point(20, 40);
            lblResult.Size = new Size(300, 60);
            lblResult.TextAlign = ContentAlignment.MiddleCenter;
            resultPanel.Controls.Add(lblResult);

            // Valeurs récapitulatives
            Panel valuesPanel = new Panel();
            valuesPanel.Location = new Point(20, 110);
            valuesPanel.Size = new Size(300, 50);
            valuesPanel.BackColor = Color.Transparent;
            resultPanel.Controls.Add(valuesPanel);

            // Grains
            Panel grainsPanel = new Panel();
            grainsPanel.Location = new Point(0, 0);
            grainsPanel.Size = new Size(95, 50);
            grainsPanel.BackColor = Color.FromArgb(239, 246, 255);
            valuesPanel.Controls.Add(grainsPanel);

            Label lblGrainsLabel = new Label();
            lblGrainsLabel.Text = "Grains";
            lblGrainsLabel.Font = new Font("Segoe UI", 8F);
            lblGrainsLabel.ForeColor = Color.FromArgb(107, 114, 128);
            lblGrainsLabel.Location = new Point(5, 5);
            lblGrainsLabel.Size = new Size(85, 15);
            lblGrainsLabel.TextAlign = ContentAlignment.MiddleCenter;
            grainsPanel.Controls.Add(lblGrainsLabel);

            lblGrainsValue = new Label();
            lblGrainsValue.Text = "-";
            lblGrainsValue.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblGrainsValue.ForeColor = Color.FromArgb(30, 64, 175);
            lblGrainsValue.Location = new Point(5, 25);
            lblGrainsValue.Size = new Size(85, 20);
            lblGrainsValue.TextAlign = ContentAlignment.MiddleCenter;
            grainsPanel.Controls.Add(lblGrainsValue);

            // Poids
            Panel weightPanel = new Panel();
            weightPanel.Location = new Point(102, 0);
            weightPanel.Size = new Size(95, 50);
            weightPanel.BackColor = Color.FromArgb(255, 251, 235);
            valuesPanel.Controls.Add(weightPanel);

            Label lblWeightLabel = new Label();
            lblWeightLabel.Text = "Poids";
            lblWeightLabel.Font = new Font("Segoe UI", 8F);
            lblWeightLabel.ForeColor = Color.FromArgb(107, 114, 128);
            lblWeightLabel.Location = new Point(5, 5);
            lblWeightLabel.Size = new Size(85, 15);
            lblWeightLabel.TextAlign = ContentAlignment.MiddleCenter;
            weightPanel.Controls.Add(lblWeightLabel);

            lblWeightValue = new Label();
            lblWeightValue.Text = "-";
            lblWeightValue.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblWeightValue.ForeColor = Color.FromArgb(245, 158, 11);
            lblWeightValue.Location = new Point(5, 25);
            lblWeightValue.Size = new Size(85, 20);
            lblWeightValue.TextAlign = ContentAlignment.MiddleCenter;
            weightPanel.Controls.Add(lblWeightValue);

            // Vitesse
            Panel velocityPanel = new Panel();
            velocityPanel.Location = new Point(204, 0);
            velocityPanel.Size = new Size(95, 50);
            velocityPanel.BackColor = Color.FromArgb(240, 253, 244);
            valuesPanel.Controls.Add(velocityPanel);

            Label lblVelocityLabel = new Label();
            lblVelocityLabel.Text = "Vitesse";
            lblVelocityLabel.Font = new Font("Segoe UI", 8F);
            lblVelocityLabel.ForeColor = Color.FromArgb(107, 114, 128);
            lblVelocityLabel.Location = new Point(5, 5);
            lblVelocityLabel.Size = new Size(85, 15);
            lblVelocityLabel.TextAlign = ContentAlignment.MiddleCenter;
            velocityPanel.Controls.Add(lblVelocityLabel);

            lblVelocityValue = new Label();
            lblVelocityValue.Text = "-";
            lblVelocityValue.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblVelocityValue.ForeColor = Color.FromArgb(34, 197, 94);
            lblVelocityValue.Location = new Point(5, 25);
            lblVelocityValue.Size = new Size(85, 20);
            lblVelocityValue.TextAlign = ContentAlignment.MiddleCenter;
            velocityPanel.Controls.Add(lblVelocityValue);

            // Panel de formule
            Panel formulaPanel = new Panel();
            formulaPanel.Location = new Point(20, 280);
            formulaPanel.Size = new Size(340, 150);
            formulaPanel.BackColor = Color.White;
            formulaPanel.BorderStyle = BorderStyle.None;
            formulaPanel.Paint += (s, e) => {
                ControlPaint.DrawBorder(e.Graphics, formulaPanel.ClientRectangle,
                    Color.FromArgb(226, 232, 240), ButtonBorderStyle.Solid);
            };
            rightPanel.Controls.Add(formulaPanel);

            Label formulaTitle = new Label();
            formulaTitle.Text = "Formule utilisée";
            formulaTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            formulaTitle.ForeColor = Color.FromArgb(17, 24, 39);
            formulaTitle.Location = new Point(15, 15);
            formulaTitle.Size = new Size(310, 20);
            formulaPanel.Controls.Add(formulaTitle);

            Panel formulaBox = new Panel();
            formulaBox.Location = new Point(15, 45);
            formulaBox.Size = new Size(310, 90);
            formulaBox.BackColor = Color.FromArgb(249, 250, 251);
            formulaBox.BorderStyle = BorderStyle.None;
            formulaBox.Paint += (s, e) => {
                ControlPaint.DrawBorder(e.Graphics, formulaBox.ClientRectangle,
                    Color.FromArgb(229, 231, 235), ButtonBorderStyle.Solid);
            };
            formulaPanel.Controls.Add(formulaBox);

            lblFormula = new Label();
            lblFormula.Text = "E = ½ × m × v²\\n\\nE = Énergie cinétique (Joules)\\nm = Masse (kg)\\nv = Vitesse (m/s)";
            lblFormula.Font = new Font("Consolas", 10F, FontStyle.Regular);
            lblFormula.ForeColor = Color.FromArgb(75, 85, 99);
            lblFormula.Location = new Point(10, 10);
            lblFormula.Size = new Size(290, 70);
            lblFormula.TextAlign = ContentAlignment.MiddleCenter;
            formulaBox.Controls.Add(lblFormula);

            // Footer
            Label footerLabel = new Label();
            footerLabel.Text = "Calculateur d'énergie cinétique pour projectiles • Résultats en temps réel";
            footerLabel.Font = new Font("Segoe UI", 8F, FontStyle.Regular);
            footerLabel.ForeColor = Color.FromArgb(107, 114, 128);
            footerLabel.Location = new Point(50, 620);
            footerLabel.Size = new Size(800, 20);
            footerLabel.TextAlign = ContentAlignment.MiddleCenter;
            this.Controls.Add(footerLabel);

            this.ResumeLayout(false);
        }

        private void SetupEventHandlers()
        {
            txtGrains.TextChanged += OnInputChanged;
            txtWeight.TextChanged += OnInputChanged;
            txtVelocity.TextChanged += OnInputChanged;
            btnReset.Click += OnResetClick;

            // Validation des entrées numériques
            txtGrains.KeyPress += OnNumericKeyPress;
            txtWeight.KeyPress += OnDecimalKeyPress;
            txtVelocity.KeyPress += OnDecimalKeyPress;
        }

        private void OnInputChanged(object sender, EventArgs e)
        {
            CalculateEnergy();
        }

        private void CalculateEnergy()
        {
            try
            {
                // Parsing des valeurs avec support des virgules et points
                string grainsText = txtGrains.Text.Replace(',', '.');
                string weightText = txtWeight.Text.Replace(',', '.');
                string velocityText = txtVelocity.Text.Replace(',', '.');

                if (double.TryParse(grainsText, NumberStyles.Float, CultureInfo.InvariantCulture, out double grains) &&
                    double.TryParse(weightText, NumberStyles.Float, CultureInfo.InvariantCulture, out double weight) &&
                    double.TryParse(velocityText, NumberStyles.Float, CultureInfo.InvariantCulture, out double velocity) &&
                    grains > 0 && weight > 0 && velocity > 0)
                {
                    // Calcul de l'énergie cinétique: E = 1/2 * m * v²
                    // Conversion du poids en kg (supposant que le poids est en grammes)
                    double massInKg = weight / 1000.0;
                    double energyInJoules = 0.5 * massInKg * Math.Pow(velocity, 2);

                    // Affichage du résultat
                    lblResult.Text = $"{energyInJoules:F2}\\nJoules (J)";
                    lblResult.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
                    lblResult.ForeColor = Color.FromArgb(30, 64, 175);

                    // Mise à jour des valeurs récapitulatives
                    lblGrainsValue.Text = grains.ToString("F0");
                    lblWeightValue.Text = $"{weight:F1}g";
                    lblVelocityValue.Text = $"{velocity:F1} m/s";

                    // Classification de l'énergie
                    string classification = GetEnergyClassification(energyInJoules);
                    lblFormula.Text = $"E = ½ × m × v²\\n\\nE = Énergie cinétique (Joules)\\nm = Masse (kg)\\nv = Vitesse (m/s)\\n\\nClassification: {classification}";
                }
                else
                {
                    // Réinitialisation de l'affichage
                    lblResult.Text = "Saisissez les valeurs\\npour voir le résultat";
                    lblResult.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
                    lblResult.ForeColor = Color.FromArgb(107, 114, 128);

                    lblGrainsValue.Text = "-";
                    lblWeightValue.Text = "-";
                    lblVelocityValue.Text = "-";

                    lblFormula.Text = "E = ½ × m × v²\\n\\nE = Énergie cinétique (Joules)\\nm = Masse (kg)\\nv = Vitesse (m/s)";
                }
            }
            catch (Exception ex)
            {
                lblResult.Text = $"Erreur de calcul:\\n{ex.Message}";
                lblResult.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
                lblResult.ForeColor = Color.FromArgb(220, 38, 38);
            }
        }

        private string GetEnergyClassification(double energy)
        {
            if (energy < 100) return "Faible";
            else if (energy < 500) return "Modérée";
            else if (energy < 1000) return "Élevée";
            else return "Très haute";
        }

        private void OnResetClick(object sender, EventArgs e)
        {
            txtGrains.Clear();
            txtWeight.Clear();
            txtVelocity.Clear();
            txtGrains.Focus();
        }

        private void OnNumericKeyPress(object sender, KeyPressEventArgs e)
        {
            // Autoriser seulement les chiffres, backspace et delete
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void OnDecimalKeyPress(object sender, KeyPressEventArgs e)
        {
            // Autoriser les chiffres, backspace, delete, point et virgule
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && 
                e.KeyChar != '.' && e.KeyChar != ',')
            {
                e.Handled = true;
            }

            // Autoriser seulement un séparateur décimal
            TextBox textBox = sender as TextBox;
            if ((e.KeyChar == '.' || e.KeyChar == ',') && 
                (textBox.Text.Contains('.') || textBox.Text.Contains(',')))
            {
                e.Handled = true;
            }
        }
    }

    // Point d'entrée de l'application
    public static class Program
    {
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}