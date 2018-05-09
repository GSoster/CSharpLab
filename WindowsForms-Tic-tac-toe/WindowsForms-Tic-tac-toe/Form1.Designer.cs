namespace WindowsForms_Tic_tac_toe
{
    partial class Form1
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
            this.btnTopLeft = new System.Windows.Forms.Button();
            this.btnTopCenter = new System.Windows.Forms.Button();
            this.btnTopRight = new System.Windows.Forms.Button();
            this.btnMiddleRight = new System.Windows.Forms.Button();
            this.btnMiddleCenter = new System.Windows.Forms.Button();
            this.btnMiddleLeft = new System.Windows.Forms.Button();
            this.btnBottomRight = new System.Windows.Forms.Button();
            this.btnBottomCenter = new System.Windows.Forms.Button();
            this.btnBottomLeft = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnTopLeft
            // 
            this.btnTopLeft.Location = new System.Drawing.Point(11, 44);
            this.btnTopLeft.Name = "btnTopLeft";
            this.btnTopLeft.Size = new System.Drawing.Size(85, 72);
            this.btnTopLeft.TabIndex = 0;
            this.btnTopLeft.UseVisualStyleBackColor = true;
            this.btnTopLeft.Click += new System.EventHandler(this.btnTopLeft_Click);
            // 
            // btnTopCenter
            // 
            this.btnTopCenter.Location = new System.Drawing.Point(114, 44);
            this.btnTopCenter.Name = "btnTopCenter";
            this.btnTopCenter.Size = new System.Drawing.Size(85, 72);
            this.btnTopCenter.TabIndex = 1;
            this.btnTopCenter.UseVisualStyleBackColor = true;
            this.btnTopCenter.Click += new System.EventHandler(this.btnTopCenter_Click);
            // 
            // btnTopRight
            // 
            this.btnTopRight.Location = new System.Drawing.Point(220, 44);
            this.btnTopRight.Name = "btnTopRight";
            this.btnTopRight.Size = new System.Drawing.Size(85, 72);
            this.btnTopRight.TabIndex = 2;
            this.btnTopRight.UseVisualStyleBackColor = true;
            // 
            // btnMiddleRight
            // 
            this.btnMiddleRight.Location = new System.Drawing.Point(220, 122);
            this.btnMiddleRight.Name = "btnMiddleRight";
            this.btnMiddleRight.Size = new System.Drawing.Size(85, 72);
            this.btnMiddleRight.TabIndex = 5;
            this.btnMiddleRight.UseVisualStyleBackColor = true;
            // 
            // btnMiddleCenter
            // 
            this.btnMiddleCenter.Location = new System.Drawing.Point(114, 122);
            this.btnMiddleCenter.Name = "btnMiddleCenter";
            this.btnMiddleCenter.Size = new System.Drawing.Size(85, 72);
            this.btnMiddleCenter.TabIndex = 4;
            this.btnMiddleCenter.UseVisualStyleBackColor = true;
            // 
            // btnMiddleLeft
            // 
            this.btnMiddleLeft.Location = new System.Drawing.Point(11, 122);
            this.btnMiddleLeft.Name = "btnMiddleLeft";
            this.btnMiddleLeft.Size = new System.Drawing.Size(85, 72);
            this.btnMiddleLeft.TabIndex = 3;
            this.btnMiddleLeft.UseVisualStyleBackColor = true;
            // 
            // btnBottomRight
            // 
            this.btnBottomRight.Location = new System.Drawing.Point(220, 200);
            this.btnBottomRight.Name = "btnBottomRight";
            this.btnBottomRight.Size = new System.Drawing.Size(85, 72);
            this.btnBottomRight.TabIndex = 8;
            this.btnBottomRight.UseVisualStyleBackColor = true;
            // 
            // btnBottomCenter
            // 
            this.btnBottomCenter.Location = new System.Drawing.Point(114, 200);
            this.btnBottomCenter.Name = "btnBottomCenter";
            this.btnBottomCenter.Size = new System.Drawing.Size(85, 72);
            this.btnBottomCenter.TabIndex = 7;
            this.btnBottomCenter.UseVisualStyleBackColor = true;
            // 
            // btnBottomLeft
            // 
            this.btnBottomLeft.Location = new System.Drawing.Point(11, 200);
            this.btnBottomLeft.Name = "btnBottomLeft";
            this.btnBottomLeft.Size = new System.Drawing.Size(85, 72);
            this.btnBottomLeft.TabIndex = 6;
            this.btnBottomLeft.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Turn: ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 284);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBottomRight);
            this.Controls.Add(this.btnBottomCenter);
            this.Controls.Add(this.btnBottomLeft);
            this.Controls.Add(this.btnMiddleRight);
            this.Controls.Add(this.btnMiddleCenter);
            this.Controls.Add(this.btnMiddleLeft);
            this.Controls.Add(this.btnTopRight);
            this.Controls.Add(this.btnTopCenter);
            this.Controls.Add(this.btnTopLeft);
            this.Name = "Form1";
            this.Text = "Tic-tac-toe";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTopLeft;
        private System.Windows.Forms.Button btnTopCenter;
        private System.Windows.Forms.Button btnTopRight;
        private System.Windows.Forms.Button btnMiddleRight;
        private System.Windows.Forms.Button btnMiddleCenter;
        private System.Windows.Forms.Button btnMiddleLeft;
        private System.Windows.Forms.Button btnBottomRight;
        private System.Windows.Forms.Button btnBottomCenter;
        private System.Windows.Forms.Button btnBottomLeft;
        private System.Windows.Forms.Label label1;
    }
}

