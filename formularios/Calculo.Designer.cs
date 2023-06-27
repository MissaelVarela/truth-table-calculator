namespace TablasDeVerdad.formularios
{
    partial class Calculo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Calculo));
            this.panFondo = new System.Windows.Forms.Panel();
            this.panHeader = new System.Windows.Forms.Panel();
            this.btnCalcular = new System.Windows.Forms.Button();
            this.txtEntrada = new System.Windows.Forms.TextBox();
            this.panBody = new System.Windows.Forms.Panel();
            this.dtgTabla = new System.Windows.Forms.DataGridView();
            this.panInfo = new System.Windows.Forms.Panel();
            this.lblInfo = new System.Windows.Forms.Label();
            this.btnInvertir = new System.Windows.Forms.Button();
            this.panFondo.SuspendLayout();
            this.panHeader.SuspendLayout();
            this.panBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgTabla)).BeginInit();
            this.panInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // panFondo
            // 
            this.panFondo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panFondo.BackColor = System.Drawing.SystemColors.Control;
            this.panFondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panFondo.Controls.Add(this.panHeader);
            this.panFondo.Controls.Add(this.panBody);
            this.panFondo.Controls.Add(this.panInfo);
            this.panFondo.Location = new System.Drawing.Point(12, 12);
            this.panFondo.MinimumSize = new System.Drawing.Size(500, 130);
            this.panFondo.Name = "panFondo";
            this.panFondo.Size = new System.Drawing.Size(641, 437);
            this.panFondo.TabIndex = 0;
            // 
            // panHeader
            // 
            this.panHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panHeader.Controls.Add(this.btnCalcular);
            this.panHeader.Controls.Add(this.txtEntrada);
            this.panHeader.Location = new System.Drawing.Point(0, 0);
            this.panHeader.MinimumSize = new System.Drawing.Size(400, 60);
            this.panHeader.Name = "panHeader";
            this.panHeader.Size = new System.Drawing.Size(502, 60);
            this.panHeader.TabIndex = 3;
            // 
            // btnCalcular
            // 
            this.btnCalcular.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalcular.Location = new System.Drawing.Point(262, 22);
            this.btnCalcular.Name = "btnCalcular";
            this.btnCalcular.Size = new System.Drawing.Size(75, 26);
            this.btnCalcular.TabIndex = 2;
            this.btnCalcular.Text = "Calcular";
            this.btnCalcular.UseVisualStyleBackColor = true;
            this.btnCalcular.Click += new System.EventHandler(this.btnCalcular_Click);
            // 
            // txtEntrada
            // 
            this.txtEntrada.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEntrada.Location = new System.Drawing.Point(13, 22);
            this.txtEntrada.Name = "txtEntrada";
            this.txtEntrada.Size = new System.Drawing.Size(243, 26);
            this.txtEntrada.TabIndex = 1;
            this.txtEntrada.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEntrada_KeyPress);
            // 
            // panBody
            // 
            this.panBody.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panBody.Controls.Add(this.dtgTabla);
            this.panBody.Location = new System.Drawing.Point(0, 66);
            this.panBody.MinimumSize = new System.Drawing.Size(400, 60);
            this.panBody.Name = "panBody";
            this.panBody.Size = new System.Drawing.Size(502, 371);
            this.panBody.TabIndex = 2;
            // 
            // dtgTabla
            // 
            this.dtgTabla.AllowUserToAddRows = false;
            this.dtgTabla.AllowUserToDeleteRows = false;
            this.dtgTabla.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgTabla.BackgroundColor = System.Drawing.SystemColors.ScrollBar;
            this.dtgTabla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgTabla.Location = new System.Drawing.Point(13, 14);
            this.dtgTabla.Name = "dtgTabla";
            this.dtgTabla.ReadOnly = true;
            this.dtgTabla.Size = new System.Drawing.Size(476, 338);
            this.dtgTabla.TabIndex = 0;
            this.dtgTabla.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgTabla_CellClick);
            // 
            // panInfo
            // 
            this.panInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panInfo.Controls.Add(this.lblInfo);
            this.panInfo.Controls.Add(this.btnInvertir);
            this.panInfo.Location = new System.Drawing.Point(508, 0);
            this.panInfo.Name = "panInfo";
            this.panInfo.Size = new System.Drawing.Size(132, 437);
            this.panInfo.TabIndex = 1;
            // 
            // lblInfo
            // 
            this.lblInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInfo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.Location = new System.Drawing.Point(3, 80);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(107, 296);
            this.lblInfo.TabIndex = 1;
            // 
            // btnInvertir
            // 
            this.btnInvertir.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInvertir.Location = new System.Drawing.Point(3, 14);
            this.btnInvertir.Name = "btnInvertir";
            this.btnInvertir.Size = new System.Drawing.Size(107, 34);
            this.btnInvertir.TabIndex = 0;
            this.btnInvertir.Text = "Invertir";
            this.btnInvertir.UseVisualStyleBackColor = true;
            this.btnInvertir.Click += new System.EventHandler(this.btnLogicaNegativa_Click);
            // 
            // Calculo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(665, 461);
            this.Controls.Add(this.panFondo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(600, 200);
            this.Name = "Calculo";
            this.Text = "Tablas de Verdad";
            this.panFondo.ResumeLayout(false);
            this.panHeader.ResumeLayout(false);
            this.panHeader.PerformLayout();
            this.panBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgTabla)).EndInit();
            this.panInfo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panFondo;
        private System.Windows.Forms.Panel panHeader;
        private System.Windows.Forms.Panel panBody;
        private System.Windows.Forms.Panel panInfo;
        private System.Windows.Forms.Button btnCalcular;
        private System.Windows.Forms.TextBox txtEntrada;
        private System.Windows.Forms.DataGridView dtgTabla;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Button btnInvertir;
    }
}