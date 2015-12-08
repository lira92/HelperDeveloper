namespace HelpDeveloperDB
{
    partial class ExibeCampos
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
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExibeCampos));
            this.listTabelas = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.listColunas = new System.Windows.Forms.ListView();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCriar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listTabelas
            // 
            this.listTabelas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.listTabelas.Enabled = false;
            this.listTabelas.FullRowSelect = true;
            this.listTabelas.Location = new System.Drawing.Point(12, 31);
            this.listTabelas.MultiSelect = false;
            this.listTabelas.Name = "listTabelas";
            this.listTabelas.Size = new System.Drawing.Size(269, 450);
            this.listTabelas.TabIndex = 0;
            this.listTabelas.UseCompatibleStateImageBehavior = false;
            this.listTabelas.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listTabelas_ItemSelectionChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tabelas";
            // 
            // listColunas
            // 
            this.listColunas.Enabled = false;
            this.listColunas.Location = new System.Drawing.Point(287, 31);
            this.listColunas.Name = "listColunas";
            this.listColunas.Size = new System.Drawing.Size(367, 450);
            this.listColunas.TabIndex = 2;
            this.listColunas.UseCompatibleStateImageBehavior = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(284, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Colunas";
            // 
            // btnCriar
            // 
            this.btnCriar.Location = new System.Drawing.Point(565, 487);
            this.btnCriar.Name = "btnCriar";
            this.btnCriar.Size = new System.Drawing.Size(89, 23);
            this.btnCriar.TabIndex = 4;
            this.btnCriar.Text = "Criar Classe C#";
            this.btnCriar.UseVisualStyleBackColor = true;
            this.btnCriar.Click += new System.EventHandler(this.btnCriar_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(466, 487);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Criar Classe Flex";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ExibeCampos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 513);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnCriar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listColunas);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listTabelas);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ExibeCampos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ExibeCampos";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ExibeCampos_FormClosed);
            this.Shown += new System.EventHandler(this.ExibeCampos_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listTabelas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listColunas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCriar;
        private System.Windows.Forms.Button button1;
    }
}