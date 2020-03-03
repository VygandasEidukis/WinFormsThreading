using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinformsThreading_Common.Models;
using WinformsThreading_DataAccess;

namespace WinfromsThreading
{
    public partial class MainForm : Form
    {
        private const int _maxDataCount = 20;
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

        private void InsertThreadData(ThreadDto threadDto)
        {
            AccessContext accessContext = new AccessContext();
            accessContext.Insert(threadDto);
        }

        private void Start(int threadCount, CancellationToken token)
        {
            DataGenerator dataGenerator = new DataGenerator(threadCount, token);
            dataGenerator.populateData += PopulateData;
            dataGenerator.StartThreads();
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

        public void PopulateData(ThreadDto dto)
        {
            Task insertTask = new Task(() => InsertThreadData(dto));
            insertTask.Start();


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
                _source.Cancel();
            }
        }
        #endregion
    }
}
