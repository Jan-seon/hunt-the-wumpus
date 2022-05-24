
namespace HuntTheWumpus
{
    partial class HighScoresUI
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
            this.labelTitle = new System.Windows.Forms.Label();
            this.buttonBack = new System.Windows.Forms.Button();
            this.richTextBoxHighScores = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.Location = new System.Drawing.Point(309, 50);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(365, 69);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "High Scores";
            // 
            // buttonBack
            // 
            this.buttonBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBack.Location = new System.Drawing.Point(50, 50);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(100, 35);
            this.buttonBack.TabIndex = 1;
            this.buttonBack.Text = "Back";
            this.buttonBack.UseVisualStyleBackColor = true;
            // 
            // richTextBoxHighScores
            // 
            this.richTextBoxHighScores.Location = new System.Drawing.Point(41, 150);
            this.richTextBoxHighScores.Name = "richTextBoxHighScores";
            this.richTextBoxHighScores.Size = new System.Drawing.Size(900, 500);
            this.richTextBoxHighScores.TabIndex = 2;
            this.richTextBoxHighScores.Text = "";
            // 
            // HighScoresUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 703);
            this.Controls.Add(this.richTextBoxHighScores);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.labelTitle);
            this.Name = "HighScoresUI";
            this.Text = "HighScoresUI";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.RichTextBox richTextBoxHighScores;
    }
}