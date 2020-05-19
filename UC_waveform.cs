using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace SequencerDemo
{
    public partial class UC_waveform : UserControl
    {
        public delegate void SendHandler(int data1, int data2);
        public event SendHandler SendData;

        public void Send(int data1, int data2)
        {
            if (SendData == null)
                return;
            SendData(data1, data2);
        }

        public int uid_oscA = 0;
        public int uid_oscB = 0;
        public int uid_oscC = 0;

        [Browsable(true)]
        public int UID_A
        {
            get { return uid_oscA; }
            set { uid_oscA = value; lblUidA.Text = "uid:" + value.ToString(); }
        }
        [Browsable(true)]
        public int UID_B
        {
            get { return uid_oscB; }
            set { uid_oscB = value; lblUidB.Text = "uid:" + value.ToString(); }
        }
        [Browsable(true)]
        public int UID_C
        {
            get { return uid_oscC; }
            set { uid_oscC = value; lblUidC.Text = "uid:" + value.ToString(); }
        }

        public void Hide_UidDesignerLbls()
        {
            lblUidA.Visible = false;
            lblUidB.Visible = false;
            lblUidC.Visible = false;
        }

        private bool valuesUpdating = false;

        public UC_waveform()
        {
            InitializeComponent();

            lstBoxWaveformOscA.MouseWheel += LstBoxWaveformSel_MouseWheel;
            lstBoxWaveformOscB.MouseWheel += LstBoxWaveformSel_MouseWheel;
            lstBoxWaveformOscC.MouseWheel += LstBoxWaveformSel_MouseWheel;
            lstBoxWaveformOscA.SelectedIndex = 0;
            lstBoxWaveformOscB.SelectedIndex = 0;
            lstBoxWaveformOscC.SelectedIndex = 0;
            lstBoxWaveformOscA.SelectedIndexChanged += lstBoxWaveformOscA_SelectedIndexChanged;
            lstBoxWaveformOscB.SelectedIndexChanged += lstBoxWaveformOscB_SelectedIndexChanged;
            lstBoxWaveformOscC.SelectedIndexChanged += lstBoxWaveformOscC_SelectedIndexChanged;
        }

        public bool SetValue(int uid, int value)
        {
            valuesUpdating = true;
            if (uid == uid_oscA)
            {
                lstBoxWaveformOscA.SelectedIndex = value;
                valuesUpdating = false;
                return true;
            }
            else if (uid == uid_oscB)
            {
                lstBoxWaveformOscB.SelectedIndex = value;
                valuesUpdating = false;
                return true;
            }
            else if (uid == uid_oscC)
            {
                lstBoxWaveformOscC.SelectedIndex = value;
                valuesUpdating = false;
                return true;
            }
            valuesUpdating = false;
            return false;
        }

        private void lstBoxWaveformOscA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (valuesUpdating) return;
            SendData(uid_oscA, lstBoxWaveformOscA.SelectedIndex);
        }

        private void lstBoxWaveformOscB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (valuesUpdating) return;
            SendData(uid_oscB, lstBoxWaveformOscB.SelectedIndex);
        }

        private void lstBoxWaveformOscC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (valuesUpdating) return;
            SendData(uid_oscC, lstBoxWaveformOscC.SelectedIndex);
        }

        private void LstBoxWaveformSel_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;
            ListBox lb = (ListBox)sender;
            if (e.Delta > 0)
            {
                if (lb.SelectedIndex != 0)
                    lb.SelectedIndex--;
            }
            else if (e.Delta < 0)
            {
                if (lb.SelectedIndex != (lb.Items.Count - 1))
                    lb.SelectedIndex++;
            }
        }
    }
}
