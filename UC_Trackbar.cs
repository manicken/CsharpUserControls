using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace SequencerDemo
{
    public partial class UC_Trackbar : UserControl
    {
        public delegate void SendHandler(int data1, int data2);
        public event SendHandler SendData;
        public void Send(int data1, int data2)
        {
            if (SendData == null) return;
            SendData(data1, data2);
        }

        private int _uid = -1;
        public float trkBarLblValueMult = 1.0f;
        private bool valuesUpdating = false;

        public UC_Trackbar()
        {
            InitializeComponent();
            trkBar.MouseWheel += trkBar_MouseWheel;
            trkBar.ValueChanged += trkBar_ValueChanged;

            lblUid.Text = "uid:" + _uid.ToString();
        }

        [Browsable(true)]
        public string A_title
        {
            get { return lblTitle.Text; }
            set { lblTitle.Text = value; }
        }

        [Browsable(true)]
        public int Uid
        {
            get { return _uid; }
            set { _uid = value; lblUid.Text = "uid:" + value.ToString(); }
        }

        [Browsable(true)]
        public float lblValueMult
        {
            get { return trkBarLblValueMult; }
            set { trkBarLblValueMult = value; lblValue.Text = (trkBar.Value * trkBarLblValueMult).ToString(); }
        }

        [Browsable(true)]
        public int maxValue
        {
            get { return trkBar.Maximum; }
            set { trkBar.Maximum = value; }
        }

        [Browsable(true)]
        public int minValue
        {
            get { return trkBar.Minimum; }
            set { trkBar.Minimum = value; }
        }
        [Browsable(true)]
        public int Value
        {
            get { return trkBar.Value; }
            set { valuesUpdating = true; trkBar.Value = value; valuesUpdating = false; }
        }

        private void trkBar_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;

            if (e.Delta > 0) IncreaseValue();
            else if (e.Delta < 0) DecreaseValue();
        }

        private void trkBar_ValueChanged(object sender, EventArgs e)
        {
             lblValue.Text = (trkBar.Value*trkBarLblValueMult).ToString();
            if (valuesUpdating) return;
             Send(_uid, trkBar.Value);
        }

        public void IncreaseValue()
        {
            int value = trkBar.Value + trkBar.SmallChange;
            if (value > trkBar.Maximum)
                trkBar.Value = trkBar.Maximum;
            else
                trkBar.Value = value;
        }
        public void DecreaseValue()
        {
            int value = trkBar.Value - trkBar.SmallChange;
            if (value < trkBar.Minimum)
                trkBar.Value = trkBar.Minimum;
            else
                trkBar.Value = value;
        }
    }
}
