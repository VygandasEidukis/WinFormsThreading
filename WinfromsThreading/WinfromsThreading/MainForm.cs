using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinfromsThreading
{
    public partial class MainForm : Form
    {
        private CancellationTokenSource _source;
        private bool _isStarted;
        public bool IsStarted
        {
            get => _isStarted;
            set
            {
                _isStarted = value;
                UIStateChange();
            }
        }

        public MainForm()
        {
            InitializeComponent();
            BindValuesToUI();
        }

        private void Start(int threadCount, CancellationToken token)
        {
            Thread.Sleep(2000);
            if (token.IsCancellationRequested)
            {
                return;
            }
                
            MessageBox.Show("test");
        }

        private void BindValuesToUI()
        {
            label_SliderNumber.Text = slider_ThreadCount.Value.ToString();
        }
        private void UIStateChange()
        {
            btn_Start.Enabled = !IsStarted;
            slider_ThreadCount.Enabled = !IsStarted;
            btn_Stop.Enabled = IsStarted;
        }

        #region events
        private void slider_ThreadCount_ValueChanged(object sender, EventArgs e)
        {
            BindValuesToUI();
        }

        private void btn_Start_Click(object sender, EventArgs e)
        {
            IsStarted = true;
            int threadCount = slider_ThreadCount.Value;
            _source = new CancellationTokenSource();
            Task thread = new Task(()=>Start(threadCount, _source.Token), _source.Token);
            thread.Start();
        }

        private void btn_Stop_Click(object sender, EventArgs e)
        {
            IsStarted = false;
            _source.Cancel();
        }
        #endregion
    }
}
