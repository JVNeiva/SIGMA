namespace Projeto_SIGMA.Telas
{
    partial class frmApresentacao
    {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblVersion = new System.Windows.Forms.Label();
            this.lblNCompleto = new System.Windows.Forms.Label();
            this.lblNome = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.BackColor = System.Drawing.Color.Transparent;
            this.lblVersion.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblVersion.Location = new System.Drawing.Point(327, 132);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(75, 17);
            this.lblVersion.TabIndex = 5;
            this.lblVersion.Text = "v1.0.0 Beta";
            this.lblVersion.Click += new System.EventHandler(this.lblVersion_Click);
            // 
            // lblNCompleto
            // 
            this.lblNCompleto.AutoSize = true;
            this.lblNCompleto.BackColor = System.Drawing.Color.Transparent;
            this.lblNCompleto.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNCompleto.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblNCompleto.Location = new System.Drawing.Point(2, 158);
            this.lblNCompleto.Name = "lblNCompleto";
            this.lblNCompleto.Size = new System.Drawing.Size(478, 17);
            this.lblNCompleto.TabIndex = 4;
            this.lblNCompleto.Text = "Sistema de Gerenciamento Operacional para Oficina Mecânica de Automóveis";
            this.lblNCompleto.Click += new System.EventHandler(this.lblNCompleto_Click);
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.BackColor = System.Drawing.Color.Transparent;
            this.lblNome.Font = new System.Drawing.Font("Segoe UI", 48F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNome.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblNome.Location = new System.Drawing.Point(112, 79);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(237, 86);
            this.lblNome.TabIndex = 3;
            this.lblNome.Text = "SIGMA";
            // 
            // frmApresentacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Projeto_SIGMA.Properties.Resources.Logo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.lblNCompleto);
            this.Controls.Add(this.lblNome);
            this.ForeColor = System.Drawing.Color.Turquoise;
            this.Name = "frmApresentacao";
            this.Size = new System.Drawing.Size(482, 342);
            this.Load += new System.EventHandler(this.frmApresentacao_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label lblNCompleto;
        private System.Windows.Forms.Label lblNome;
    }
}
