using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace _4ChordsTool
{
    class SongBeatControl
    {
        private Control canvas;

        public class BaseRect : Label
        {
            public int Index { get; set; }
            public int RowIndex { get; set; }
            public string Value { get; set; }


            private bool _checked;
            public bool Checked
            {
                get
                {
                    return _checked;
                }
                set
                {
                    _checked = value;

                    if (_checked)
                        Text = "✔";
                    else
                        Text = string.Empty;

                }
            }

            private TextRenderingHint _hint = TextRenderingHint.SystemDefault;
            public TextRenderingHint TextRenderingHint
            {
                get { return this._hint; }
                set { this._hint = value; }
            }

            protected override void OnPaint(PaintEventArgs pe)
            {
                pe.Graphics.TextRenderingHint = TextRenderingHint;

                pe.Graphics.DrawRectangle(Pens.DarkGray, this.ClientRectangle);

                base.OnPaint(pe);
            }

            public BaseRect()
            {
                this.TextAlign = ContentAlignment.MiddleCenter;
                this.Font = new Font("Microsoft Sans Serif", 9f);
            }
        }

        public class BeatRow : List<BaseRect>
        {
            public BeatRow(int rowIndex, Color color, MouseEventHandler mouseEvent, Control canvas)
            {
                Index = rowIndex;

                var size = new Size(50, 30);

                for (int i = 0; i < 16; i++)
                {
                    var lbl = new BaseRect()
                    {
                        Index = i,
                        RowIndex = rowIndex,
                        BackColor = color,
                        Location = new Point(i * size.Width, rowIndex * size.Height),
                        Size = size
                    };

                    lbl.MouseClick += mouseEvent;

                    this.Add(lbl);
                    canvas.Controls.Add(lbl);
                }

            }

            public int Index { get; set; }

        }

        public int BeatLoaded = 0;

        BeatRow[] controlTable = new BeatRow[6];


        ToolStripDropDown dropDownPanel = new ToolStripDropDown();
        ContextMenuStrip chordMenu = new ContextMenuStrip();

        BaseRect clickedRect = new BaseRect();

        public int BeatProgress = 0;


        public BindingList<SongBeat> Song;

        internal void Paint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.DrawLine(new Pen(Color.Green, 2), new Point(BeatProgress * 50, 0), new Point(BeatProgress * 50, canvas.Height));
        }


        private void BuildChordMenu()
        {
            chordMenu.ItemClicked += ChordMenu_ItemClicked;
            foreach (var item in Enum.GetValues(typeof(ChordBase)))
            {
                ToolStripMenuItem newItem = new ToolStripMenuItem(item.ToString());

                newItem.DropDownItemClicked += ChordMenu_ItemClicked;


                foreach (Enum mod in Enum.GetValues(typeof(ChordMod)))
                {
                    newItem.DropDownItems.Add(item.ToString() + mod.GetDisplayName());
                }

                chordMenu.Items.Add(newItem);
            }
        }


        private void BuildMelodyPanel()
        {
            var hostPanel = new Panel()
            {
                BorderStyle = BorderStyle.None,
                AutoSize = true,
                BackColor = Color.White
            };


            int x = 0;
            int y = 0;
            foreach (Enum item in Enum.GetValues(typeof(Pitch)))
            {
                if (x > 11)
                {
                    x = 0;
                    y++;
                }

                Label btnLabel = new Label()
                {
                    Size = new Size(35, 20),
                    Location = new Point(x * 35, y * 20),
                    BorderStyle = BorderStyle.Fixed3D,
                    TextAlign = ContentAlignment.MiddleCenter,
                    BackColor = Color.White,
                    Text = item.GetDisplayName(),
                    Tag = item.ToString()
                };


                btnLabel.MouseMove += BtnLabel_MouseMove;
                btnLabel.MouseLeave += BtnLabel_MouseLeave;
                btnLabel.MouseClick += BtnLabel_MouseClick;
                hostPanel.Controls.Add(btnLabel);
                x++;
            }


            dropDownPanel.AutoSize = true;
            dropDownPanel.Items.Add(new ToolStripControlHost(hostPanel));
        }


        public SongBeatControl(Control p)
        {
            canvas = p;


            BuildChordMenu();
            BuildMelodyPanel();


            //Chords
            controlTable[0] = new BeatRow(0, Color.LightSalmon, Lbl_MouseClick, canvas);
            //Melody
            controlTable[1] = new BeatRow(1, Color.FromArgb(255,204,153), Lbl_MouseClick, canvas);
            //Bass
            controlTable[2] = new BeatRow(2, Color.FromArgb(255,255,204), Lbl_MouseClick, canvas);
            //Hihats
            controlTable[3] = new BeatRow(3, Color.FromArgb(204,255,204), Lbl_MouseClick, canvas);
            //Snares
            controlTable[4] = new BeatRow(4, Color.FromArgb(153,204,255), Lbl_MouseClick, canvas);
            //Claps
            controlTable[5] = new BeatRow(5, Color.FromArgb(255,204,255), Lbl_MouseClick, canvas);
        }



        internal void LoadBeat(int index)
        {
            for (int i = 0; i < 16; i++)
            {
                controlTable[0][i].Text = Song[index].Chords[i];
                controlTable[1][i].Text = Song[index].Melody[i].GetDisplayName();
                controlTable[2][i].Checked = Song[index].Bass[i];
                controlTable[3][i].Checked = Song[index].Hihats[i];
                controlTable[4][i].Checked = Song[index].Snares[i];
                controlTable[5][i].Checked = Song[index].Claps[i];
            }

            BeatLoaded = index;


        }

        internal void Init(BindingList<SongBeat> song)
        {
            Song = song;     
        }

        private void BtnLabel_MouseClick(object sender, MouseEventArgs e)
        {
            var lbl = (sender as Label);
            clickedRect.Text = lbl.Text;

            Song[BeatLoaded].Melody[clickedRect.Index] = (Pitch)Enum.Parse(typeof(Pitch), lbl.Tag.ToString());

            dropDownPanel.Close();
        }

        private void BtnLabel_MouseLeave(object sender, EventArgs e)
        {
            (sender as Label).BackColor = Color.White;
        }

        private void BtnLabel_MouseMove(object sender, MouseEventArgs e)
        {
            (sender as Label).BackColor = Color.FromArgb(196, 225, 255);
        }

        private void Lbl_MouseClick(object sender, MouseEventArgs e)
        {

            var curItem = (sender as BaseRect);

            switch (curItem.RowIndex)
            {
                case 0:
                    chordMenu.Show(canvas, new Point(curItem.Location.X, curItem.Location.Y + curItem.Height));
                    clickedRect = curItem;

                    break;
                case 1:

                    dropDownPanel.Show(canvas, new Point(curItem.Location.X, curItem.Location.Y + curItem.Height));
                    clickedRect = curItem;
                    break;

                case 2:
                    curItem.Checked = !curItem.Checked;
                    Song[BeatLoaded].Bass[curItem.Index] = curItem.Checked;
                    break;

                case 3:
                    curItem.Checked = !curItem.Checked;
                    Song[BeatLoaded].Hihats[curItem.Index] = curItem.Checked;
                    break;
                case 4:
                    curItem.Checked = !curItem.Checked;
                    Song[BeatLoaded].Snares[curItem.Index] = curItem.Checked;
                    break;
                case 5:
                    curItem.Checked = !curItem.Checked;
                    Song[BeatLoaded].Claps[curItem.Index] = curItem.Checked;
                    break;
                default:
                    break;
            }

        }


        private void ChordMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            var chordRow = controlTable[0];

            foreach (var item in chordRow)
            {
                if (item == clickedRect)
                {
                    item.Text = e.ClickedItem.Text;
                    Song[BeatLoaded].Chords[item.Index] = item.Text;
                    break;
                }
            }
        }


    }


}
