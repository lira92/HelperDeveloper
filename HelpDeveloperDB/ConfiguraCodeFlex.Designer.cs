namespace HelpDeveloperDB
{
    partial class ConfiguraCodeFlex
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
            this.btnConfirm = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPackage = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbPadrao = new System.Windows.Forms.RadioButton();
            this.rbIgualBanco = new System.Windows.Forms.RadioButton();
            this.txtDiretorio = new System.Windows.Forms.ComboBox();
            this.chkPadraoRemoting = new System.Windows.Forms.CheckBox();
            this.chkMetodoExcluir = new System.Windows.Forms.CheckBox();
            this.chkMetodoListar = new System.Windows.Forms.CheckBox();
            this.chkMetodoGravar = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(368, 116);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnConfirm.TabIndex = 10;
            this.btnConfirm.Text = "Confirmar";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(327, 116);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(32, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Package:";
            // 
            // txtPackage
            // 
            this.txtPackage.Location = new System.Drawing.Point(63, 12);
            this.txtPackage.Name = "txtPackage";
            this.txtPackage.Size = new System.Drawing.Size(139, 20);
            this.txtPackage.TabIndex = 12;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbPadrao);
            this.groupBox1.Controls.Add(this.rbIgualBanco);
            this.groupBox1.Location = new System.Drawing.Point(8, 73);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(435, 39);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Padrão";
            // 
            // rbPadrao
            // 
            this.rbPadrao.AutoSize = true;
            this.rbPadrao.Checked = true;
            this.rbPadrao.Location = new System.Drawing.Point(201, 16);
            this.rbPadrao.Name = "rbPadrao";
            this.rbPadrao.Size = new System.Drawing.Size(219, 17);
            this.rbPadrao.TabIndex = 9;
            this.rbPadrao.TabStop = true;
            this.rbPadrao.Text = "Inside (primeira minuscula, sem underline)";
            this.rbPadrao.UseVisualStyleBackColor = true;
            // 
            // rbIgualBanco
            // 
            this.rbIgualBanco.AutoSize = true;
            this.rbIgualBanco.Location = new System.Drawing.Point(6, 16);
            this.rbIgualBanco.Name = "rbIgualBanco";
            this.rbIgualBanco.Size = new System.Drawing.Size(142, 17);
            this.rbIgualBanco.TabIndex = 8;
            this.rbIgualBanco.Text = "Igual a Coluna do Banco";
            this.rbIgualBanco.UseVisualStyleBackColor = true;
            // 
            // txtDiretorio
            // 
            this.txtDiretorio.FormattingEnabled = true;
            this.txtDiretorio.Location = new System.Drawing.Point(8, 117);
            this.txtDiretorio.Name = "txtDiretorio";
            this.txtDiretorio.Size = new System.Drawing.Size(311, 21);
            this.txtDiretorio.TabIndex = 14;
            // 
            // chkPadraoRemoting
            // 
            this.chkPadraoRemoting.AutoSize = true;
            this.chkPadraoRemoting.Location = new System.Drawing.Point(208, 15);
            this.chkPadraoRemoting.Name = "chkPadraoRemoting";
            this.chkPadraoRemoting.Size = new System.Drawing.Size(136, 17);
            this.chkPadraoRemoting.TabIndex = 15;
            this.chkPadraoRemoting.Text = "Padrão Class Remoting";
            this.chkPadraoRemoting.UseVisualStyleBackColor = true;
            this.chkPadraoRemoting.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // chkMetodoExcluir
            // 
            this.chkMetodoExcluir.AutoSize = true;
            this.chkMetodoExcluir.Checked = true;
            this.chkMetodoExcluir.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMetodoExcluir.Enabled = false;
            this.chkMetodoExcluir.Location = new System.Drawing.Point(306, 38);
            this.chkMetodoExcluir.Name = "chkMetodoExcluir";
            this.chkMetodoExcluir.Size = new System.Drawing.Size(123, 17);
            this.chkMetodoExcluir.TabIndex = 17;
            this.chkMetodoExcluir.Text = "Método de Exclusão";
            this.chkMetodoExcluir.UseVisualStyleBackColor = true;
            // 
            // chkMetodoListar
            // 
            this.chkMetodoListar.AutoSize = true;
            this.chkMetodoListar.Checked = true;
            this.chkMetodoListar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMetodoListar.Enabled = false;
            this.chkMetodoListar.Location = new System.Drawing.Point(157, 38);
            this.chkMetodoListar.Name = "chkMetodoListar";
            this.chkMetodoListar.Size = new System.Drawing.Size(122, 17);
            this.chkMetodoListar.TabIndex = 18;
            this.chkMetodoListar.Text = "Método de Listagem";
            this.chkMetodoListar.UseVisualStyleBackColor = true;
            // 
            // chkMetodoGravar
            // 
            this.chkMetodoGravar.AutoSize = true;
            this.chkMetodoGravar.Checked = true;
            this.chkMetodoGravar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMetodoGravar.Enabled = false;
            this.chkMetodoGravar.Location = new System.Drawing.Point(8, 38);
            this.chkMetodoGravar.Name = "chkMetodoGravar";
            this.chkMetodoGravar.Size = new System.Drawing.Size(127, 17);
            this.chkMetodoGravar.TabIndex = 19;
            this.chkMetodoGravar.Text = "Método de Gravação";
            this.chkMetodoGravar.UseVisualStyleBackColor = true;
            // 
            // ConfiguraCodeFlex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 144);
            this.Controls.Add(this.chkMetodoGravar);
            this.Controls.Add(this.chkMetodoListar);
            this.Controls.Add(this.chkMetodoExcluir);
            this.Controls.Add(this.chkPadraoRemoting);
            this.Controls.Add(this.txtDiretorio);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtPackage);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "ConfiguraCodeFlex";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ConfiguraCodeFlex";
            this.Load += new System.EventHandler(this.ConfiguraCodeFlex_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ConfiguraCodeFlex_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPackage;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbPadrao;
        private System.Windows.Forms.RadioButton rbIgualBanco;
        private System.Windows.Forms.ComboBox txtDiretorio;
        private System.Windows.Forms.CheckBox chkPadraoRemoting;
        private System.Windows.Forms.CheckBox chkMetodoExcluir;
        private System.Windows.Forms.CheckBox chkMetodoListar;
        private System.Windows.Forms.CheckBox chkMetodoGravar;
    }
}