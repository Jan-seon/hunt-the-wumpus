
namespace HuntTheWumpus
{
    partial class GameUI
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
            this.buttonMove1 = new System.Windows.Forms.Button();
            this.buttonMove2 = new System.Windows.Forms.Button();
            this.buttonMove3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonMove1
            // 
            this.buttonMove1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMove1.Location = new System.Drawing.Point(440, 50);
            this.buttonMove1.Name = "buttonMove1";
            this.buttonMove1.Size = new System.Drawing.Size(100, 100);
            this.buttonMove1.TabIndex = 0;
            this.buttonMove1.Text = "##";
            this.buttonMove1.UseVisualStyleBackColor = true;
            // 
            // buttonMove2
            // 
            this.buttonMove2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMove2.Location = new System.Drawing.Point(685, 150);
            this.buttonMove2.Name = "buttonMove2";
            this.buttonMove2.Size = new System.Drawing.Size(100, 100);
            this.buttonMove2.TabIndex = 1;
            this.buttonMove2.Text = "##";
            this.buttonMove2.UseVisualStyleBackColor = true;
            // 
            // buttonMove3
            // 
            this.buttonMove3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMove3.Location = new System.Drawing.Point(685, 350);
            this.buttonMove3.Name = "buttonMove3";
            this.buttonMove3.Size = new System.Drawing.Size(100, 100);
            this.buttonMove3.TabIndex = 2;
            this.buttonMove3.Text = "##";
            this.buttonMove3.UseVisualStyleBackColor = true;
            // 
            // GameUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 703);
            this.Controls.Add(this.buttonMove3);
            this.Controls.Add(this.buttonMove2);
            this.Controls.Add(this.buttonMove1);
            this.Name = "GameUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hunt the Wumpus";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonMove1;
        private System.Windows.Forms.Button buttonMove2;
        private System.Windows.Forms.Button buttonMove3;
    }
}

