using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinformsThreading_Common.Models;
using WinformsThreading_DataAccess;

namespace WinfromsThreading
{
    public partial class MainForm : Form
    {
        private CancellationTokenSource _dataGeneratingSource;
        private const int _maxDataCount = 20;
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

        private List<ThreadDto> _bufferedData { get; set; } = new List<ThreadDto>();

        public MainForm()
        {
            InitializeComponent();
            BindValuesToUI();
        }

        private async void BufferedSaveData()
        {
            //save data every second
            Thread.Sleep(1000);

            List<ThreadDto> threadDtos = new List<ThreadDto>();
            threadDtos.AddRange(_bufferedData);

            AccessContext accessContext = new AccessContext();
            await accessContext.InsertMultiple(threadDtos);

            for (int i = 0; i < threadDtos.Count; i++)
            {
                _bufferedData.Remove(threadDtos[i]);
            }

            if(IsStarted)
                BufferedSaveData();
        }

        private void Start(int threadCount, CancellationToken token)
        {
            DataGenerator dataGenerator = new DataGenerator(threadCount, token);
            dataGenerator.populateData += PopulateData;
            Thread dataSavingThread = new Thread(BufferedSaveData);

            dataSavingThread.Start();
            dataGenerator.ExecuteThreads();
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
            _dataGeneratingSource = new CancellationTokenSource();

            Task thread = new Task(()=>Start(threadCount, _dataGeneratingSource.Token), _dataGeneratingSource.Token);
            thread.Start();
        }

        private void btn_Stop_Click(object sender, EventArgs e)
        {
            IsStarted = false;
            _dataGeneratingSource.Cancel();
        }

        public void PopulateData(ThreadDto dto)
        {
            _bufferedData.Add(dto);

            ListViewItem item = new ListViewItem(dto.ThreadID.ToString());
            item.SubItems.Add(dto.Text);

            try
            {
                this.Invoke((MethodInvoker)(
                () =>
                {
                    lv_Data.Items.Add(item);
                    if (lv_Data.Items.Count > _maxDataCount)
                        lv_Data.Items.Remove(lv_Data.Items[0]);
                }));
            }
            catch 
            {
                _dataGeneratingSource.Cancel();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _isStarted = false;
            if(_dataGeneratingSource != null)
                _dataGeneratingSource.Cancel();
        }
        #endregion
    }
}
