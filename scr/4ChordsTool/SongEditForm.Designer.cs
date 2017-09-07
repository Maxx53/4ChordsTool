namespace _4ChordsTool
{
    partial class SongEditForm
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
            this.components = new System.ComponentModel.Container();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.bpmNumeric = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.artistTextBox = new System.Windows.Forms.TextBox();
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.samplePackCombo = new System.Windows.Forms.ComboBox();
            this.strumIdCombo = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadSongToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveSongToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.importLyricsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importMIDIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addBeatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeBeatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyBeatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectedBeatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testInGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.lyricsDataGrid = new System.Windows.Forms.DataGridView();
            this.graphicalOverlay1 = new CodeProject.GraphicalOverlay(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bpmNumeric)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lyricsDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(247, 121);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(807, 20);
            this.textBox1.TabIndex = 4;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(207, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Lyrics";
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(247, 158);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(807, 186);
            this.panel1.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(201, 168);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Chords";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(200, 197);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Melody";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(211, 229);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Bass";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(204, 260);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Hihats";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(208, 318);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Claps";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(201, 288);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Snares";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "4Chords Songs (*.xml)|*.xml";
            this.openFileDialog1.InitialDirectory = "C:\\";
            // 
            // bpmNumeric
            // 
            this.bpmNumeric.Location = new System.Drawing.Point(247, 87);
            this.bpmNumeric.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.bpmNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.bpmNumeric.Name = "bpmNumeric";
            this.bpmNumeric.Size = new System.Drawing.Size(71, 20);
            this.bpmNumeric.TabIndex = 9;
            this.bpmNumeric.Value = new decimal(new int[] {
            120,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(211, 89);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(30, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "BPM";
            // 
            // artistTextBox
            // 
            this.artistTextBox.Location = new System.Drawing.Point(247, 35);
            this.artistTextBox.Name = "artistTextBox";
            this.artistTextBox.Size = new System.Drawing.Size(234, 20);
            this.artistTextBox.TabIndex = 11;
            // 
            // titleTextBox
            // 
            this.titleTextBox.Location = new System.Drawing.Point(247, 61);
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new System.Drawing.Size(234, 20);
            this.titleTextBox.TabIndex = 11;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(211, 38);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(30, 13);
            this.label9.TabIndex = 10;
            this.label9.Text = "Artist";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(214, 63);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(27, 13);
            this.label10.TabIndex = 10;
            this.label10.Text = "Title";
            // 
            // samplePackCombo
            // 
            this.samplePackCombo.FormattingEnabled = true;
            this.samplePackCombo.Items.AddRange(new object[] {
            "Pop",
            "Heavy"});
            this.samplePackCombo.Location = new System.Drawing.Point(585, 34);
            this.samplePackCombo.Name = "samplePackCombo";
            this.samplePackCombo.Size = new System.Drawing.Size(147, 21);
            this.samplePackCombo.TabIndex = 13;
            // 
            // strumIdCombo
            // 
            this.strumIdCombo.FormattingEnabled = true;
            this.strumIdCombo.Items.AddRange(new object[] {
            "strum-8-1",
            "strum-8-3",
            "strum-16-2",
            "strum-16-3"});
            this.strumIdCombo.Location = new System.Drawing.Point(585, 60);
            this.strumIdCombo.Name = "strumIdCombo";
            this.strumIdCombo.Size = new System.Drawing.Size(147, 21);
            this.strumIdCombo.TabIndex = 13;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(510, 37);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(70, 13);
            this.label11.TabIndex = 10;
            this.label11.Text = "Sample Pack";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(534, 60);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(46, 13);
            this.label12.TabIndex = 10;
            this.label12.Text = "Strum Id";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.playToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1062, 24);
            this.menuStrip1.TabIndex = 17;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.loadSongToolStripMenuItem,
            this.saveSongToolStripMenuItem,
            this.toolStripSeparator1,
            this.importLyricsToolStripMenuItem,
            this.importMIDIToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.newToolStripMenuItem.Text = "New...";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // loadSongToolStripMenuItem
            // 
            this.loadSongToolStripMenuItem.Name = "loadSongToolStripMenuItem";
            this.loadSongToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.loadSongToolStripMenuItem.Text = "Load Song";
            this.loadSongToolStripMenuItem.Click += new System.EventHandler(this.loadSongToolStripMenuItem_Click);
            // 
            // saveSongToolStripMenuItem
            // 
            this.saveSongToolStripMenuItem.Name = "saveSongToolStripMenuItem";
            this.saveSongToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveSongToolStripMenuItem.Text = "Save Song";
            this.saveSongToolStripMenuItem.Click += new System.EventHandler(this.saveSongToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // importLyricsToolStripMenuItem
            // 
            this.importLyricsToolStripMenuItem.Name = "importLyricsToolStripMenuItem";
            this.importLyricsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.importLyricsToolStripMenuItem.Text = "Import Lyrics";
            this.importLyricsToolStripMenuItem.Click += new System.EventHandler(this.importLyricsToolStripMenuItem_Click);
            // 
            // importMIDIToolStripMenuItem
            // 
            this.importMIDIToolStripMenuItem.Name = "importMIDIToolStripMenuItem";
            this.importMIDIToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.importMIDIToolStripMenuItem.Text = "Import MIDI";
            this.importMIDIToolStripMenuItem.Click += new System.EventHandler(this.importMIDIToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(149, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addBeatToolStripMenuItem,
            this.removeBeatToolStripMenuItem,
            this.copyBeatToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // addBeatToolStripMenuItem
            // 
            this.addBeatToolStripMenuItem.Name = "addBeatToolStripMenuItem";
            this.addBeatToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.addBeatToolStripMenuItem.Text = "Add Beat";
            this.addBeatToolStripMenuItem.Click += new System.EventHandler(this.addBeatToolStripMenuItem_Click);
            // 
            // removeBeatToolStripMenuItem
            // 
            this.removeBeatToolStripMenuItem.Name = "removeBeatToolStripMenuItem";
            this.removeBeatToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.removeBeatToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.removeBeatToolStripMenuItem.Text = "Remove Beats";
            this.removeBeatToolStripMenuItem.Click += new System.EventHandler(this.removeBeatToolStripMenuItem_Click);
            // 
            // copyBeatToolStripMenuItem
            // 
            this.copyBeatToolStripMenuItem.Name = "copyBeatToolStripMenuItem";
            this.copyBeatToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.copyBeatToolStripMenuItem.Text = "Copy Beat";
            // 
            // playToolStripMenuItem
            // 
            this.playToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.allToolStripMenuItem,
            this.selectedBeatToolStripMenuItem,
            this.testInGameToolStripMenuItem});
            this.playToolStripMenuItem.Name = "playToolStripMenuItem";
            this.playToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.playToolStripMenuItem.Text = "Play";
            // 
            // allToolStripMenuItem
            // 
            this.allToolStripMenuItem.Name = "allToolStripMenuItem";
            this.allToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.allToolStripMenuItem.Text = "All";
            this.allToolStripMenuItem.Click += new System.EventHandler(this.allToolStripMenuItem_Click);
            // 
            // selectedBeatToolStripMenuItem
            // 
            this.selectedBeatToolStripMenuItem.Name = "selectedBeatToolStripMenuItem";
            this.selectedBeatToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Space)));
            this.selectedBeatToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.selectedBeatToolStripMenuItem.Text = "Selected Beat";
            this.selectedBeatToolStripMenuItem.Click += new System.EventHandler(this.selectedBeatToolStripMenuItem_Click);
            // 
            // testInGameToolStripMenuItem
            // 
            this.testInGameToolStripMenuItem.Name = "testInGameToolStripMenuItem";
            this.testInGameToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.testInGameToolStripMenuItem.Text = "Test In-Game";
            this.testInGameToolStripMenuItem.Click += new System.EventHandler(this.testInGameToolStripMenuItem_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(331, 361);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 18;
            this.button1.Text = "Previous";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(412, 361);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 18;
            this.button2.Text = "Play";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(493, 361);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 18;
            this.button3.Text = "Next";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // lyricsDataGrid
            // 
            this.lyricsDataGrid.AllowDrop = true;
            this.lyricsDataGrid.AllowUserToAddRows = false;
            this.lyricsDataGrid.AllowUserToDeleteRows = false;
            this.lyricsDataGrid.AllowUserToResizeColumns = false;
            this.lyricsDataGrid.AllowUserToResizeRows = false;
            this.lyricsDataGrid.BackgroundColor = System.Drawing.SystemColors.Window;
            this.lyricsDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.lyricsDataGrid.ColumnHeadersVisible = false;
            this.lyricsDataGrid.Location = new System.Drawing.Point(12, 34);
            this.lyricsDataGrid.Name = "lyricsDataGrid";
            this.lyricsDataGrid.ReadOnly = true;
            this.lyricsDataGrid.RowHeadersWidth = 40;
            this.lyricsDataGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.lyricsDataGrid.RowTemplate.Height = 20;
            this.lyricsDataGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.lyricsDataGrid.ShowCellErrors = false;
            this.lyricsDataGrid.ShowCellToolTips = false;
            this.lyricsDataGrid.ShowEditingIcon = false;
            this.lyricsDataGrid.ShowRowErrors = false;
            this.lyricsDataGrid.Size = new System.Drawing.Size(182, 350);
            this.lyricsDataGrid.TabIndex = 0;
            this.lyricsDataGrid.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.lyricsDataGrid_RowPostPaint);
            this.lyricsDataGrid.SelectionChanged += new System.EventHandler(this.lyricsDataGrid_SelectionChanged);
            this.lyricsDataGrid.DragDrop += new System.Windows.Forms.DragEventHandler(this.lyricsDataGrid_DragDrop);
            this.lyricsDataGrid.DragEnter += new System.Windows.Forms.DragEventHandler(this.lyricsDataGrid_DragEnter);
            this.lyricsDataGrid.DragOver += new System.Windows.Forms.DragEventHandler(this.lyricsDataGrid_DragOver);
            this.lyricsDataGrid.Paint += new System.Windows.Forms.PaintEventHandler(this.lyricsDataGrid_Paint);
            this.lyricsDataGrid.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lyricsDataGrid_MouseDown);
            this.lyricsDataGrid.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lyricsDataGrid_MouseMove);
            this.lyricsDataGrid.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lyricsDataGrid_MouseUp);
            // 
            // graphicalOverlay1
            // 
            this.graphicalOverlay1.Paint += new System.EventHandler<System.Windows.Forms.PaintEventArgs>(this.graphicalOverlay1_Paint);
            // 
            // SongEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1062, 413);
            this.Controls.Add(this.lyricsDataGrid);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.strumIdCombo);
            this.Controls.Add(this.samplePackCombo);
            this.Controls.Add(this.titleTextBox);
            this.Controls.Add(this.artistTextBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.bpmNumeric);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "SongEditForm";
            this.Text = "Edit Song";
            this.Load += new System.EventHandler(this.SongEditForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bpmNumeric)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lyricsDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private CodeProject.GraphicalOverlay graphicalOverlay1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.NumericUpDown bpmNumeric;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox artistTextBox;
        private System.Windows.Forms.TextBox titleTextBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ComboBox samplePackCombo;
        private System.Windows.Forms.ComboBox strumIdCombo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadSongToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveSongToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importLyricsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importMIDIToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addBeatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeBeatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyBeatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectedBeatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testInGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridView lyricsDataGrid;
    }
}