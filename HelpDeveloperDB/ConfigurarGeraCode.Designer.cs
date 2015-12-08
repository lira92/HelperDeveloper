namespace HelpDeveloperDB
{
    partial class ConfigurarGeraCode
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
            this.chkMetGravacao = new System.Windows.Forms.CheckBox();
            this.chkMetListagem = new System.Windows.Forms.CheckBox();
            this.chkMetExclusao = new System.Windows.Forms.CheckBox();
            this.chkRedGravacao = new System.Windows.Forms.CheckBox();
            this.chkRedListagem = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.rbIgualBanco = new System.Windows.Forms.RadioButton();
            this.rbPadrao = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkFunc = new System.Windows.Forms.CheckBox();
            this.txtDiretorio = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkMetGravacao
            // 
            this.chkMetGravacao.AutoSize = true;
            this.chkMetGravacao.Location = new System.Drawing.Point(13, 13);
            this.chkMetGravacao.Name = "chkMetGravacao";
            this.chkMetGravacao.Size = new System.Drawing.Size(125, 17);
            this.chkMetGravacao.TabIndex = 0;
            this.chkMetGravacao.Text = "Método de gravação";
            this.chkMetGravacao.UseVisualStyleBackColor = true;
            this.chkMetGravacao.CheckedChanged += new System.EventHandler(this.chkMetGravacao_CheckedChanged);
            // 
            // chkMetListagem
            // 
            this.chkMetListagem.AutoSize = true;
            this.chkMetListagem.Location = new System.Drawing.Point(13, 36);
            this.chkMetListagem.Name = "chkMetListagem";
            this.chkMetListagem.Size = new System.Drawing.Size(122, 17);
            this.chkMetListagem.TabIndex = 1;
            this.chkMetListagem.Text = "Método de Listagem";
            this.chkMetListagem.UseVisualStyleBackColor = true;
            this.chkMetListagem.CheckedChanged += new System.EventHandler(this.chkMetListagem_CheckedChanged);
            // 
            // chkMetExclusao
            // 
            this.chkMetExclusao.AutoSize = true;
            this.chkMetExclusao.Location = new System.Drawing.Point(12, 59);
            this.chkMetExclusao.Name = "chkMetExclusao";
            this.chkMetExclusao.Size = new System.Drawing.Size(122, 17);
            this.chkMetExclusao.TabIndex = 2;
            this.chkMetExclusao.Text = "Método de exclusão";
            this.chkMetExclusao.UseVisualStyleBackColor = true;
            // 
            // chkRedGravacao
            // 
            this.chkRedGravacao.AutoSize = true;
            this.chkRedGravacao.Enabled = false;
            this.chkRedGravacao.Location = new System.Drawing.Point(168, 13);
            this.chkRedGravacao.Name = "chkRedGravacao";
            this.chkRedGravacao.Size = new System.Drawing.Size(71, 17);
            this.chkRedGravacao.TabIndex = 3;
            this.chkRedGravacao.Text = "Reduzido";
            this.chkRedGravacao.UseVisualStyleBackColor = true;
            this.chkRedGravacao.CheckedChanged += new System.EventHandler(this.chkRedGravacao_CheckedChanged);
            // 
            // chkRedListagem
            // 
            this.chkRedListagem.AutoSize = true;
            this.chkRedListagem.Enabled = false;
            this.chkRedListagem.Location = new System.Drawing.Point(168, 36);
            this.chkRedListagem.Name = "chkRedListagem";
            this.chkRedListagem.Size = new System.Drawing.Size(71, 17);
            this.chkRedListagem.TabIndex = 4;
            this.chkRedListagem.Text = "Reduzido";
            this.chkRedListagem.UseVisualStyleBackColor = true;
            this.chkRedListagem.CheckedChanged += new System.EventHandler(this.chkRedListagem_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(284, 135);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(32, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(348, 135);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnConfirm.TabIndex = 7;
            this.btnConfirm.Text = "Confirmar";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
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
            // rbPadrao
            // 
            this.rbPadrao.AutoSize = true;
            this.rbPadrao.Checked = true;
            this.rbPadrao.Location = new System.Drawing.Point(178, 16);
            this.rbPadrao.Name = "rbPadrao";
            this.rbPadrao.Size = new System.Drawing.Size(219, 17);
            this.rbPadrao.TabIndex = 9;
            this.rbPadrao.TabStop = true;
            this.rbPadrao.Text = "Inside (primeira minuscula, sem underline)";
            this.rbPadrao.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbPadrao);
            this.groupBox1.Controls.Add(this.rbIgualBanco);
            this.groupBox1.Location = new System.Drawing.Point(13, 82);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(403, 39);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Padrão";
            // 
            // chkFunc
            // 
            this.chkFunc.AutoSize = true;
            this.chkFunc.Enabled = false;
            this.chkFunc.Location = new System.Drawing.Point(264, 13);
            this.chkFunc.Name = "chkFunc";
            this.chkFunc.Size = new System.Drawing.Size(148, 17);
            this.chkFunc.TabIndex = 11;
            this.chkFunc.Text = "Adicionar Classe Funcoes";
            this.chkFunc.UseVisualStyleBackColor = true;
            // 
            // txtDiretorio
            // 
            this.txtDiretorio.FormattingEnabled = true;
            this.txtDiretorio.Location = new System.Drawing.Point(13, 136);
            this.txtDiretorio.Name = "txtDiretorio";
            this.txtDiretorio.Size = new System.Drawing.Size(265, 21);
            this.txtDiretorio.TabIndex = 12;
            // 
            // ConfigurarGeraCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 163);
            this.Controls.Add(this.txtDiretorio);
            this.Controls.Add(this.chkFunc);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.chkRedListagem);
            this.Controls.Add(this.chkRedGravacao);
            this.Controls.Add(this.chkMetExclusao);
            this.Controls.Add(this.chkMetListagem);
            this.Controls.Add(this.chkMetGravacao);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "ConfigurarGeraCode";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Configurar";
            this.Load += new System.EventHandler(this.ConfigurarGeraCode_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ConfigurarGeraCode_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkMetGravacao;
        private System.Windows.Forms.CheckBox chkMetListagem;
        private System.Windows.Forms.CheckBox chkMetExclusao;
        private System.Windows.Forms.CheckBox chkRedGravacao;
        private System.Windows.Forms.CheckBox chkRedListagem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.RadioButton rbIgualBanco;
        private System.Windows.Forms.RadioButton rbPadrao;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkFunc;
        private System.Windows.Forms.ComboBox txtDiretorio;
    }
}