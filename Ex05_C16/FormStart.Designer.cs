namespace Ex05_C16
{
    partial class FormStart
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
            this.labelFirstPlayerName = new System.Windows.Forms.Label();
            this.labelSecondPlayerName = new System.Windows.Forms.Label();
            this.textBoxFirstPlayerName = new System.Windows.Forms.TextBox();
            this.textBoxSecondPlayerName = new System.Windows.Forms.TextBox();
            this.buttonAgainstWho = new System.Windows.Forms.Button();
            this.labelBoardSize = new System.Windows.Forms.Label();
            this.buttonBoardSize = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonFirstPlayerColor = new System.Windows.Forms.Button();
            this.buttonSeconedPlayerColor = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.SuspendLayout();
            // 
            // labelFirstPlayerName
            // 
            this.labelFirstPlayerName.AutoSize = true;
            this.labelFirstPlayerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelFirstPlayerName.Location = new System.Drawing.Point(17, 9);
            this.labelFirstPlayerName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelFirstPlayerName.Name = "labelFirstPlayerName";
            this.labelFirstPlayerName.Size = new System.Drawing.Size(124, 17);
            this.labelFirstPlayerName.TabIndex = 0;
            this.labelFirstPlayerName.Text = "First Player Name:";
            this.labelFirstPlayerName.Click += new System.EventHandler(this.label1_Click);
            // 
            // labelSecondPlayerName
            // 
            this.labelSecondPlayerName.AutoSize = true;
            this.labelSecondPlayerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelSecondPlayerName.Location = new System.Drawing.Point(17, 45);
            this.labelSecondPlayerName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelSecondPlayerName.Name = "labelSecondPlayerName";
            this.labelSecondPlayerName.Size = new System.Drawing.Size(145, 17);
            this.labelSecondPlayerName.TabIndex = 1;
            this.labelSecondPlayerName.Text = "Second Player Name:";
            this.labelSecondPlayerName.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // textBoxFirstPlayerName
            // 
            this.textBoxFirstPlayerName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxFirstPlayerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.textBoxFirstPlayerName.Location = new System.Drawing.Point(165, 6);
            this.textBoxFirstPlayerName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxFirstPlayerName.Name = "textBoxFirstPlayerName";
            this.textBoxFirstPlayerName.Size = new System.Drawing.Size(159, 23);
            this.textBoxFirstPlayerName.TabIndex = 2;
            // 
            // textBoxSecondPlayerName
            // 
            this.textBoxSecondPlayerName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSecondPlayerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.textBoxSecondPlayerName.Location = new System.Drawing.Point(165, 41);
            this.textBoxSecondPlayerName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxSecondPlayerName.Name = "textBoxSecondPlayerName";
            this.textBoxSecondPlayerName.ReadOnly = true;
            this.textBoxSecondPlayerName.Size = new System.Drawing.Size(159, 23);
            this.textBoxSecondPlayerName.TabIndex = 3;
            this.textBoxSecondPlayerName.Text = "Computer";
            this.textBoxSecondPlayerName.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // buttonAgainstWho
            // 
            this.buttonAgainstWho.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAgainstWho.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.buttonAgainstWho.Location = new System.Drawing.Point(349, 41);
            this.buttonAgainstWho.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonAgainstWho.Name = "buttonAgainstWho";
            this.buttonAgainstWho.Size = new System.Drawing.Size(132, 24);
            this.buttonAgainstWho.TabIndex = 4;
            this.buttonAgainstWho.Text = "Against A Friend";
            this.buttonAgainstWho.UseVisualStyleBackColor = true;
            this.buttonAgainstWho.Click += new System.EventHandler(this.buttonAgainstWho_Click);
            // 
            // labelBoardSize
            // 
            this.labelBoardSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelBoardSize.AutoSize = true;
            this.labelBoardSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelBoardSize.Location = new System.Drawing.Point(17, 108);
            this.labelBoardSize.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelBoardSize.Name = "labelBoardSize";
            this.labelBoardSize.Size = new System.Drawing.Size(81, 17);
            this.labelBoardSize.TabIndex = 5;
            this.labelBoardSize.Text = "Board Size:";
            this.labelBoardSize.Click += new System.EventHandler(this.label1_Click_2);
            // 
            // buttonBoardSize
            // 
            this.buttonBoardSize.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBoardSize.BackColor = System.Drawing.Color.Thistle;
            this.buttonBoardSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.buttonBoardSize.Location = new System.Drawing.Point(20, 138);
            this.buttonBoardSize.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonBoardSize.Name = "buttonBoardSize";
            this.buttonBoardSize.Size = new System.Drawing.Size(125, 81);
            this.buttonBoardSize.TabIndex = 6;
            this.buttonBoardSize.Text = "4X4";
            this.buttonBoardSize.UseVisualStyleBackColor = false;
            this.buttonBoardSize.Click += new System.EventHandler(this.buttonBoardSize_Click);
            // 
            // buttonStart
            // 
            this.buttonStart.BackColor = System.Drawing.Color.Lime;
            this.buttonStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.buttonStart.Location = new System.Drawing.Point(377, 185);
            this.buttonStart.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(104, 34);
            this.buttonStart.TabIndex = 7;
            this.buttonStart.Text = "Start!";
            this.buttonStart.UseVisualStyleBackColor = false;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonFirstPlayerColor
            // 
            this.buttonFirstPlayerColor.Location = new System.Drawing.Point(165, 73);
            this.buttonFirstPlayerColor.Name = "buttonFirstPlayerColor";
            this.buttonFirstPlayerColor.Size = new System.Drawing.Size(65, 23);
            this.buttonFirstPlayerColor.TabIndex = 8;
            this.buttonFirstPlayerColor.Text = "Player1";
            this.buttonFirstPlayerColor.UseVisualStyleBackColor = true;
            this.buttonFirstPlayerColor.Click += new System.EventHandler(this.buttonFirstPlayerColor_Click);
            // 
            // buttonSeconedPlayerColor
            // 
            this.buttonSeconedPlayerColor.Location = new System.Drawing.Point(259, 73);
            this.buttonSeconedPlayerColor.Name = "buttonSeconedPlayerColor";
            this.buttonSeconedPlayerColor.Size = new System.Drawing.Size(65, 23);
            this.buttonSeconedPlayerColor.TabIndex = 9;
            this.buttonSeconedPlayerColor.Text = "Player2";
            this.buttonSeconedPlayerColor.UseVisualStyleBackColor = true;
            this.buttonSeconedPlayerColor.Click += new System.EventHandler(this.buttonSeconedPlayerColor_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(17, 75);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "Color:";
            // 
            // FormStart
            // 
            this.AcceptButton = this.buttonStart;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 248);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonSeconedPlayerColor);
            this.Controls.Add(this.buttonFirstPlayerColor);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.buttonBoardSize);
            this.Controls.Add(this.labelBoardSize);
            this.Controls.Add(this.buttonAgainstWho);
            this.Controls.Add(this.textBoxSecondPlayerName);
            this.Controls.Add(this.textBoxFirstPlayerName);
            this.Controls.Add(this.labelSecondPlayerName);
            this.Controls.Add(this.labelFirstPlayerName);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(507, 287);
            this.Name = "FormStart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Memory Game - Settings";
            this.Load += new System.EventHandler(this.FormStart_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelFirstPlayerName;
        private System.Windows.Forms.Label labelSecondPlayerName;
        private System.Windows.Forms.TextBox textBoxFirstPlayerName;
        private System.Windows.Forms.TextBox textBoxSecondPlayerName;
        private System.Windows.Forms.Button buttonAgainstWho;
        private System.Windows.Forms.Label labelBoardSize;
        private System.Windows.Forms.Button buttonBoardSize;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonFirstPlayerColor;
        private System.Windows.Forms.Button buttonSeconedPlayerColor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColorDialog colorDialog1;
    }
}