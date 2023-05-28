namespace TakvimUygulaması
{
    partial class LoginForm
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttongirisyap = new System.Windows.Forms.Button();
            this.linkLabelkayit = new System.Windows.Forms.LinkLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxpassword = new System.Windows.Forms.TextBox();
            this.textBoxkullaniciad = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttongirisyap
            // 
            this.buttongirisyap.BackColor = System.Drawing.SystemColors.Desktop;
            this.buttongirisyap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttongirisyap.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttongirisyap.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttongirisyap.Location = new System.Drawing.Point(65, 339);
            this.buttongirisyap.Name = "buttongirisyap";
            this.buttongirisyap.Size = new System.Drawing.Size(276, 48);
            this.buttongirisyap.TabIndex = 32;
            this.buttongirisyap.Text = "Giriş Yap";
            this.buttongirisyap.UseVisualStyleBackColor = false;
            // 
            // linkLabelkayit
            // 
            this.linkLabelkayit.AutoSize = true;
            this.linkLabelkayit.Location = new System.Drawing.Point(125, 408);
            this.linkLabelkayit.Name = "linkLabelkayit";
            this.linkLabelkayit.Size = new System.Drawing.Size(161, 16);
            this.linkLabelkayit.TabIndex = 31;
            this.linkLabelkayit.TabStop = true;
            this.linkLabelkayit.Text = "Kayıt olmak için tıklayınız ..";
            this.linkLabelkayit.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelkayit_LinkClicked);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label4.Location = new System.Drawing.Point(61, 265);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 20);
            this.label4.TabIndex = 30;
            this.label4.Text = "Şifre :";
            // 
            // textBoxpassword
            // 
            this.textBoxpassword.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxpassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxpassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxpassword.Location = new System.Drawing.Point(65, 288);
            this.textBoxpassword.Multiline = true;
            this.textBoxpassword.Name = "textBoxpassword";
            this.textBoxpassword.Size = new System.Drawing.Size(278, 25);
            this.textBoxpassword.TabIndex = 29;
            // 
            // textBoxkullaniciad
            // 
            this.textBoxkullaniciad.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxkullaniciad.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxkullaniciad.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxkullaniciad.Location = new System.Drawing.Point(63, 222);
            this.textBoxkullaniciad.Multiline = true;
            this.textBoxkullaniciad.Name = "textBoxkullaniciad";
            this.textBoxkullaniciad.Size = new System.Drawing.Size(278, 25);
            this.textBoxkullaniciad.TabIndex = 28;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label5.Location = new System.Drawing.Point(61, 199);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 20);
            this.label5.TabIndex = 27;
            this.label5.Text = "Kullanıcı Adınız :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label1.Location = new System.Drawing.Point(89, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 38);
            this.label1.TabIndex = 26;
            this.label1.Text = "Hoşgeldiniz";
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(405, 573);
            this.Controls.Add(this.buttongirisyap);
            this.Controls.Add(this.linkLabelkayit);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxpassword);
            this.Controls.Add(this.textBoxkullaniciad);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LoginForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttongirisyap;
        private System.Windows.Forms.LinkLabel linkLabelkayit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxpassword;
        private System.Windows.Forms.TextBox textBoxkullaniciad;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
    }
}

