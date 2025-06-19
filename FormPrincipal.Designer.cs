namespace ExamenProyectos
{
    partial class FormPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.btnDonantes = new System.Windows.Forms.Button();
            this.btnProyectos = new System.Windows.Forms.Button();
            this.btnDonaciones = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Gainsboro;
            this.label1.ForeColor = System.Drawing.Color.MediumBlue;
            this.label1.Location = new System.Drawing.Point(55, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "ONG \"Las Praderas\"";
            // 
            // btnDonantes
            // 
            this.btnDonantes.Location = new System.Drawing.Point(33, 56);
            this.btnDonantes.Name = "btnDonantes";
            this.btnDonantes.Size = new System.Drawing.Size(217, 44);
            this.btnDonantes.TabIndex = 1;
            this.btnDonantes.Text = "Gestionar Donantes";
            this.btnDonantes.UseVisualStyleBackColor = true;
            this.btnDonantes.Click += new System.EventHandler(this.btnDonantes_Click);
            // 
            // btnProyectos
            // 
            this.btnProyectos.Location = new System.Drawing.Point(33, 106);
            this.btnProyectos.Name = "btnProyectos";
            this.btnProyectos.Size = new System.Drawing.Size(217, 44);
            this.btnProyectos.TabIndex = 2;
            this.btnProyectos.Text = "Gestionar Proyectos";
            this.btnProyectos.UseVisualStyleBackColor = true;
            this.btnProyectos.Click += new System.EventHandler(this.btnProyectos_Click);
            // 
            // btnDonaciones
            // 
            this.btnDonaciones.Location = new System.Drawing.Point(33, 156);
            this.btnDonaciones.Name = "btnDonaciones";
            this.btnDonaciones.Size = new System.Drawing.Size(217, 44);
            this.btnDonaciones.TabIndex = 3;
            this.btnDonaciones.Text = "Registrar Donaciones ";
            this.btnDonaciones.UseVisualStyleBackColor = true;
            this.btnDonaciones.Click += new System.EventHandler(this.btnDonaciones_Click);
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(293, 219);
            this.Controls.Add(this.btnDonaciones);
            this.Controls.Add(this.btnProyectos);
            this.Controls.Add(this.btnDonantes);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormPrincipal";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FormPrincipal_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDonantes;
        private System.Windows.Forms.Button btnProyectos;
        private System.Windows.Forms.Button btnDonaciones;
    }
}

