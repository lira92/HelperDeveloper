namespace HelpDeveloperDB
{
    partial class formConexao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formConexao));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.btnConectar = new System.Windows.Forms.Button();
            this.btnTest = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbBanco = new System.Windows.Forms.ComboBox();
            this.lbPorta = new System.Windows.Forms.Label();
            this.txtPorta = new System.Windows.Forms.TextBox();
            this.txtHost = new System.Windows.Forms.ComboBox();
            this.txtDataBase = new System.Windows.Forms.ComboBox();
            this.txtUser = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Host:*";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "DataBase:*";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Usuário:*";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Senha:";
            // 
            // txtSenha
            // 
            this.txtSenha.Location = new System.Drawing.Point(123, 116);
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.PasswordChar = '*';
            this.txtSenha.Size = new System.Drawing.Size(200, 20);
            this.txtSenha.TabIndex = 7;
            this.txtSenha.UseSystemPasswordChar = true;
            // 
            // btnConectar
            // 
            this.btnConectar.Image = ((System.Drawing.Image)(resources.GetObject("btnConectar.Image")));
            this.btnConectar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConectar.Location = new System.Drawing.Point(124, 169);
            this.btnConectar.Name = "btnConectar";
            this.btnConectar.Size = new System.Drawing.Size(83, 29);
            this.btnConectar.TabIndex = 8;
            this.btnConectar.Text = "Conectar";
            this.btnConectar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnConectar.UseVisualStyleBackColor = true;
            this.btnConectar.Click += new System.EventHandler(this.btnConectar_Click);
            // 
            // btnTest
            // 
            this.btnTest.Image = ((System.Drawing.Image)(resources.GetObject("btnTest.Image")));
            this.btnTest.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTest.Location = new System.Drawing.Point(213, 169);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(110, 29);
            this.btnTest.TabIndex = 10;
            this.btnTest.Text = "Testar Conexão";
            this.btnTest.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F);
            this.label5.Location = new System.Drawing.Point(2, 186);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 12);
            this.label5.TabIndex = 11;
            this.label5.Text = "Desenvolvido por Alan Lira";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Banco de Dados";
            // 
            // cbBanco
            // 
            this.cbBanco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBanco.FormattingEnabled = true;
            this.cbBanco.Items.AddRange(new object[] {
            "Sql Server 2008",
            "Postgresql"});
            this.cbBanco.Location = new System.Drawing.Point(123, 6);
            this.cbBanco.Name = "cbBanco";
            this.cbBanco.Size = new System.Drawing.Size(200, 21);
            this.cbBanco.TabIndex = 13;
            this.cbBanco.SelectedIndexChanged += new System.EventHandler(this.cbBanco_SelectedIndexChanged);
            // 
            // lbPorta
            // 
            this.lbPorta.AutoSize = true;
            this.lbPorta.Location = new System.Drawing.Point(12, 147);
            this.lbPorta.Name = "lbPorta";
            this.lbPorta.Size = new System.Drawing.Size(32, 13);
            this.lbPorta.TabIndex = 14;
            this.lbPorta.Text = "Porta";
            this.lbPorta.Visible = false;
            // 
            // txtPorta
            // 
            this.txtPorta.Location = new System.Drawing.Point(123, 143);
            this.txtPorta.Name = "txtPorta";
            this.txtPorta.Size = new System.Drawing.Size(76, 20);
            this.txtPorta.TabIndex = 15;
            this.txtPorta.Text = "5432";
            this.txtPorta.Visible = false;
            // 
            // txtHost
            // 
            this.txtHost.FormattingEnabled = true;
            this.txtHost.Location = new System.Drawing.Point(124, 36);
            this.txtHost.Name = "txtHost";
            this.txtHost.Size = new System.Drawing.Size(199, 21);
            this.txtHost.TabIndex = 16;
            // 
            // txtDataBase
            // 
            this.txtDataBase.FormattingEnabled = true;
            this.txtDataBase.Location = new System.Drawing.Point(123, 64);
            this.txtDataBase.Name = "txtDataBase";
            this.txtDataBase.Size = new System.Drawing.Size(200, 21);
            this.txtDataBase.TabIndex = 17;
            // 
            // txtUser
            // 
            this.txtUser.FormattingEnabled = true;
            this.txtUser.Location = new System.Drawing.Point(123, 90);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(200, 21);
            this.txtUser.TabIndex = 18;
            // 
            // formConexao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 201);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.txtDataBase);
            this.Controls.Add(this.txtHost);
            this.Controls.Add(this.txtPorta);
            this.Controls.Add(this.lbPorta);
            this.Controls.Add(this.cbBanco);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.btnConectar);
            this.Controls.Add(this.txtSenha);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "formConexao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Conexão Com Base de Dados";
            this.Load += new System.EventHandler(this.formConexao_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.formConexao_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.Button btnConectar;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbBanco;
        private System.Windows.Forms.Label lbPorta;
        private System.Windows.Forms.TextBox txtPorta;
        private System.Windows.Forms.ComboBox txtHost;
        private System.Windows.Forms.ComboBox txtDataBase;
        private System.Windows.Forms.ComboBox txtUser;
    }
}

