namespace Rijndael
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.encryptButton = new System.Windows.Forms.Button();
            this.decryptButton = new System.Windows.Forms.Button();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.sourceLabel = new System.Windows.Forms.Label();
            this.encryptedLabel = new System.Windows.Forms.Label();
            this.passwordText = new System.Windows.Forms.TextBox();
            this.sourceText = new System.Windows.Forms.TextBox();
            this.encryptedText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // encryptButton
            // 
            this.encryptButton.Location = new System.Drawing.Point(53, 90);
            this.encryptButton.Name = "encryptButton";
            this.encryptButton.Size = new System.Drawing.Size(75, 23);
            this.encryptButton.TabIndex = 0;
            this.encryptButton.Text = "Encrypt";
            this.encryptButton.UseVisualStyleBackColor = true;
            this.encryptButton.Click += new System.EventHandler(this.EncryptButton_Click);
            // 
            // decryptButton
            // 
            this.decryptButton.Location = new System.Drawing.Point(163, 90);
            this.decryptButton.Name = "decryptButton";
            this.decryptButton.Size = new System.Drawing.Size(75, 23);
            this.decryptButton.TabIndex = 1;
            this.decryptButton.Text = "Decrypt";
            this.decryptButton.UseVisualStyleBackColor = true;
            this.decryptButton.Click += new System.EventHandler(this.DecryptButton_Click);
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(12, 12);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(53, 12);
            this.passwordLabel.TabIndex = 2;
            this.passwordLabel.Text = "password";
            // 
            // sourceLabel
            // 
            this.sourceLabel.AutoSize = true;
            this.sourceLabel.Location = new System.Drawing.Point(12, 39);
            this.sourceLabel.Name = "sourceLabel";
            this.sourceLabel.Size = new System.Drawing.Size(39, 12);
            this.sourceLabel.TabIndex = 3;
            this.sourceLabel.Text = "source";
            // 
            // encryptedLabel
            // 
            this.encryptedLabel.AutoSize = true;
            this.encryptedLabel.Location = new System.Drawing.Point(12, 68);
            this.encryptedLabel.Name = "encryptedLabel";
            this.encryptedLabel.Size = new System.Drawing.Size(55, 12);
            this.encryptedLabel.TabIndex = 4;
            this.encryptedLabel.Text = "encrypted";
            // 
            // passwordText
            // 
            this.passwordText.Location = new System.Drawing.Point(71, 9);
            this.passwordText.Name = "passwordText";
            this.passwordText.Size = new System.Drawing.Size(201, 19);
            this.passwordText.TabIndex = 5;
            // 
            // sourceText
            // 
            this.sourceText.Location = new System.Drawing.Point(71, 36);
            this.sourceText.Name = "sourceText";
            this.sourceText.Size = new System.Drawing.Size(201, 19);
            this.sourceText.TabIndex = 6;
            // 
            // encryptedText
            // 
            this.encryptedText.Location = new System.Drawing.Point(71, 65);
            this.encryptedText.Name = "encryptedText";
            this.encryptedText.Size = new System.Drawing.Size(201, 19);
            this.encryptedText.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 121);
            this.Controls.Add(this.encryptedText);
            this.Controls.Add(this.sourceText);
            this.Controls.Add(this.passwordText);
            this.Controls.Add(this.encryptedLabel);
            this.Controls.Add(this.sourceLabel);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.decryptButton);
            this.Controls.Add(this.encryptButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button encryptButton;
        private System.Windows.Forms.Button decryptButton;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Label sourceLabel;
        private System.Windows.Forms.Label encryptedLabel;
        private System.Windows.Forms.TextBox passwordText;
        private System.Windows.Forms.TextBox sourceText;
        private System.Windows.Forms.TextBox encryptedText;
    }
}

