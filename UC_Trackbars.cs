using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace SequencerDemo
{
    public partial class UC_Trackbars : UserControl
    {
        public delegate void SendHandler(int data1, int data2);
        public event SendHandler SendData;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public UC_Trackbar[] trackbars = new UC_Trackbar[0];

        [Browsable(true)]
        public string[] Trackbar_Titles
        {
            get {
                string[] titles = new string[trackbars.Length];
                for (int i = 0; i < titles.Length; i++)
                {
                    titles[i] = trackbars[i].A_title;
                }
                return titles;
            }
            set
            {
                if (trackbars.Length != value.Length)
                    Trackbar_Count = value.Length; // this will init trackbar array

                for (int i = 0; i < value.Length; i++)
                {
                    trackbars[i].A_title = value[i];
                }
            }
        }
        [Browsable(true)]
        public int[] TrackBar_Uids
        {
            get
            {
                int[] titles = new int[trackbars.Length];
                for (int i = 0; i < titles.Length; i++)
                {
                    titles[i] = trackbars[i].Uid;
                }
                return titles;
            }
            set
            {
                if (trackbars.Length != value.Length)
                    Trackbar_Count = value.Length; // this will init trackbar array

                for (int i = 0; i < value.Length; i++)
                {
                    trackbars[i].Uid = value[i];
                }
            }
        }
        [Browsable(true)]
        public int[] TrackBar_MinValues
        {
            get
            {
                int[] titles = new int[trackbars.Length];
                for (int i = 0; i < titles.Length; i++)
                {
                    titles[i] = trackbars[i].minValue;
                }
                return titles;
            }
            set
            {
                if (trackbars.Length != value.Length)
                    Trackbar_Count = value.Length; // this will init trackbar array

                for (int i = 0; i < value.Length; i++)
                {
                    trackbars[i].minValue = value[i];
                }
            }
        }
        [Browsable(true)]
        public int[] TrackBar_MaxValues
        {
            get
            {
                int[] titles = new int[trackbars.Length];
                for (int i = 0; i < titles.Length; i++)
                {
                    titles[i] = trackbars[i].maxValue;
                }
                return titles;
            }
            set
            {
                if (trackbars.Length != value.Length)
                    Trackbar_Count = value.Length; // this will init trackbar array

                for (int i = 0; i < value.Length; i++)
                {
                    trackbars[i].maxValue = value[i];
                }
            }
        }
        [Browsable(true)]
        public float[] TrackBar_valueLblMult
        {
            get
            {
                float[] titles = new float[trackbars.Length];
                for (int i = 0; i < titles.Length; i++)
                {
                    titles[i] = trackbars[i].lblValueMult;
                }
                return titles;
            }
            set
            {
                if (trackbars.Length != value.Length)
                    Trackbar_Count = value.Length; // this will init trackbar array

                for (int i = 0; i < value.Length; i++)
                {
                    trackbars[i].lblValueMult = value[i];
                }
            }
        }

        public UC_Trackbars()
        {
            InitializeComponent();

            /*
            flowLayout.Controls.Clear();
            for (int i = 0; i < trackbars.Length; i++)
            {
                trackbars[i] = new UC_Trackbar();
                flowLayout.Controls.Add(trackbars[i]);
            }
            */
        }

        public void Hide_UidDesignerLbls()
        {
            for (int i = 0; i < trackbars.Length; i++)
                trackbars[i].lblUid.Visible = false;
        }

        public void Send(int data1, int data2)
        {
            if (SendData == null)
                return;
            SendData(data1, data2);
        }

        public int Trackbar_Count
        {
            get { return trackbars.Length; }
            set {
                flowLayout.Controls.Clear();
                UC_Trackbar[] newTrackbars = new UC_Trackbar[value];
                int minLenght = 0;
                if (trackbars.Length < value)
                    minLenght = trackbars.Length;
                else
                    minLenght = value;

                for (int i = 0; i < minLenght; i++) // first copy old trackbars to new sized array
                {
                    newTrackbars[i] = trackbars[i];
                    flowLayout.Controls.Add(newTrackbars[i]);
                }

                for (int i = minLenght; i < value; i++) // this creates new trackbars if needed
                {
                    newTrackbars[i] = new UC_Trackbar();
                    newTrackbars[i].Margin = new Padding(trackbarPadding);
                    newTrackbars[i].Height = flowLayout.Height-3;
                    newTrackbars[i].SendData += Send;
                    flowLayout.Controls.Add(newTrackbars[i]);
                }
                trackbars = newTrackbars;
                //ItemTitles = ItemTitles;
            }
        }

        [Browsable(true)]
        public UC_Trackbar[] Trackbar_Items
        {
            get { return trackbars; }
            set { trackbars = value; }
        }

        [Browsable(true)]
        public string TitleLabel
        {
            get { return this.lblMain.Text; }
            set { lblMain.Text = value; }
        }

        private int trackbarPadding = 0;

        [Browsable(true)]
        public int Trackbar_Padding
        {
            get { return trackbarPadding; }
            set {
                trackbarPadding = value;
                for (int i = 0; i < trackbars.Length; i++)
                    trackbars[i].Margin = new Padding(trackbarPadding);
            }
        }

        public bool TrySetValue(int uid, int value)
        {
            for (int i = 0; i < trackbars.Length; i++)
            {
                if (trackbars[i].Uid == uid)
                {
                    trackbars[i].Value = value;
                    return true;
                }
            }
            return false;
        }

        private void flowLayout_SizeChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < trackbars.Length; i++)
            {
                trackbars[i].Height = flowLayout.Height-3;
            }
        }
    }
}
