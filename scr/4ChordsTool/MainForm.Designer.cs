namespace _4ChordsTool
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.buildDlcButton = new System.Windows.Forms.Button();
            this.spNameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.sPathTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.browseSongsPath = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.unityPathTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.browseUnityButton = new System.Windows.Forms.Button();
            this.gamePathTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.browseGameButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // buildDlcButton
            // 
            this.buildDlcButton.Image = global::_4ChordsTool.Properties.Resources.start;
            this.buildDlcButton.Location = new System.Drawing.Point(324, 47);
            this.buildDlcButton.Name = "buildDlcButton";
            this.buildDlcButton.Size = new System.Drawing.Size(122, 27);
            this.buildDlcButton.TabIndex = 1;
            this.buildDlcButton.Text = "Build DLC";
            this.buildDlcButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buildDlcButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buildDlcButton.UseVisualStyleBackColor = true;
            this.buildDlcButton.Click += new System.EventHandler(this.buildDlcButton_Click);
            // 
            // spNameTextBox
            // 
            this.spNameTextBox.Location = new System.Drawing.Point(74, 51);
            this.spNameTextBox.Name = "spNameTextBox";
            this.spNameTextBox.Size = new System.Drawing.Size(244, 20);
            this.spNameTextBox.TabIndex = 2;
            this.spNameTextBox.Text = "My Custom DLC";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "DLC Name";
            // 
            // sPathTextBox
            // 
            this.sPathTextBox.Location = new System.Drawing.Point(74, 22);
            this.sPathTextBox.Name = "sPathTextBox";
            this.sPathTextBox.Size = new System.Drawing.Size(333, 20);
            this.sPathTextBox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Songs Path";
            // 
            // browseSongsPath
            // 
            this.browseSongsPath.Location = new System.Drawing.Point(413, 20);
            this.browseSongsPath.Name = "browseSongsPath";
            this.browseSongsPath.Size = new System.Drawing.Size(33, 23);
            this.browseSongsPath.TabIndex = 4;
            this.browseSongsPath.Text = "...";
            this.browseSongsPath.UseVisualStyleBackColor = true;
            this.browseSongsPath.Click += new System.EventHandler(this.browseSongsPath_Click);
            // 
            // unityPathTextBox
            // 
            this.unityPathTextBox.Location = new System.Drawing.Point(74, 24);
            this.unityPathTextBox.Name = "unityPathTextBox";
            this.unityPathTextBox.Size = new System.Drawing.Size(333, 20);
            this.unityPathTextBox.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Unity4 Exe";
            // 
            // browseUnityButton
            // 
            this.browseUnityButton.Location = new System.Drawing.Point(413, 19);
            this.browseUnityButton.Name = "browseUnityButton";
            this.browseUnityButton.Size = new System.Drawing.Size(33, 23);
            this.browseUnityButton.TabIndex = 4;
            this.browseUnityButton.Text = "...";
            this.browseUnityButton.UseVisualStyleBackColor = true;
            this.browseUnityButton.Click += new System.EventHandler(this.browseUnityButton_Click);
            // 
            // gamePathTextBox
            // 
            this.gamePathTextBox.Location = new System.Drawing.Point(74, 50);
            this.gamePathTextBox.Name = "gamePathTextBox";
            this.gamePathTextBox.Size = new System.Drawing.Size(333, 20);
            this.gamePathTextBox.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Game Path";
            // 
            // browseGameButton
            // 
            this.browseGameButton.Location = new System.Drawing.Point(413, 48);
            this.browseGameButton.Name = "browseGameButton";
            this.browseGameButton.Size = new System.Drawing.Size(33, 23);
            this.browseGameButton.TabIndex = 4;
            this.browseGameButton.Text = "...";
            this.browseGameButton.UseVisualStyleBackColor = true;
            this.browseGameButton.Click += new System.EventHandler(this.browseGameButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.browseGameButton);
            this.groupBox1.Controls.Add(this.unityPathTextBox);
            this.groupBox1.Controls.Add(this.browseUnityButton);
            this.groupBox1.Controls.Add(this.gamePathTextBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 103);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(455, 82);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 195);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(479, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Image = global::_4ChordsTool.Properties.Resources.ready;
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(55, 17);
            this.statusLabel.Text = "Ready";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Unity (*.exe)|*.exe";
            this.openFileDialog1.InitialDirectory = "C:\\";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buildDlcButton);
            this.groupBox2.Controls.Add(this.spNameTextBox);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.browseSongsPath);
            this.groupBox2.Controls.Add(this.sPathTextBox);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(455, 85);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Custom DLC";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 217);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "4ChordsTool";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buildDlcButton;
        private System.Windows.Forms.TextBox spNameTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox sPathTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button browseSongsPath;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox unityPathTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button browseUnityButton;
        private System.Windows.Forms.TextBox gamePathTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button browseGameButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}

