namespace WinfromsThreading
{
    partial class MainForm
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
            this.lv_Data = new System.Windows.Forms.ListView();
            this.ThreadID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Text = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btn_Start = new System.Windows.Forms.Button();
            this.btn_Stop = new System.Windows.Forms.Button();
            this.slider_ThreadCount = new System.Windows.Forms.TrackBar();
            this.label_SliderNumber = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.slider_ThreadCount)).BeginInit();
            this.SuspendLayout();
            // 
            // lv_Data
            // 
            this.lv_Data.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ThreadID,
            this.Text});
            this.lv_Data.FullRowSelect = true;
            this.lv_Data.HideSelection = false;
            this.lv_Data.Location = new System.Drawing.Point(12, 12);
            this.lv_Data.Name = "lv_Data";
            this.lv_Data.Size = new System.Drawing.Size(776, 397);
            this.lv_Data.TabIndex = 0;
            this.lv_Data.UseCompatibleStateImageBehavior = false;
            this.lv_Data.View = System.Windows.Forms.View.Details;
            // 
            // ThreadID
            // 
            this.ThreadID.Text = "ThreadID";
            // 
            // Text
            // 
            this.Text.Text = "Data";
            this.Text.Width = 712;
            // 
            // btn_Start
            // 
            this.btn_Start.Location = new System.Drawing.Point(608, 420);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(99, 23);
            this.btn_Start.TabIndex = 1;
            this.btn_Start.Text = "Start";
            this.btn_Start.UseVisualStyleBackColor = true;
            this.btn_Start.Click += new System.EventHandler(this.btn_Start_Click);
            // 
            // btn_Stop
            // 
            this.btn_Stop.Enabled = false;
            this.btn_Stop.Location = new System.Drawing.Point(713, 420);
            this.btn_Stop.Name = "btn_Stop";
            this.btn_Stop.Size = new System.Drawing.Size(75, 23);
            this.btn_Stop.TabIndex = 2;
            this.btn_Stop.Text = "Stop";
            this.btn_Stop.UseVisualStyleBackColor = true;
            this.btn_Stop.Click += new System.EventHandler(this.btn_Stop_Click);
            // 
            // slider_ThreadCount
            // 
            this.slider_ThreadCount.Location = new System.Drawing.Point(12, 420);
            this.slider_ThreadCount.Maximum = 15;
            this.slider_ThreadCount.Minimum = 2;
            this.slider_ThreadCount.Name = "slider_ThreadCount";
            this.slider_ThreadCount.Size = new System.Drawing.Size(433, 45);
            this.slider_ThreadCount.TabIndex = 3;
            this.slider_ThreadCount.Value = 2;
            this.slider_ThreadCount.ValueChanged += new System.EventHandler(this.slider_ThreadCount_ValueChanged);
            // 
            // label_SliderNumber
            // 
            this.label_SliderNumber.AutoSize = true;
            this.label_SliderNumber.Location = new System.Drawing.Point(451, 425);
            this.label_SliderNumber.Name = "label_SliderNumber";
            this.label_SliderNumber.Size = new System.Drawing.Size(13, 13);
            this.label_SliderNumber.TabIndex = 4;
            this.label_SliderNumber.Text = "0";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label_SliderNumber);
            this.Controls.Add(this.slider_ThreadCount);
            this.Controls.Add(this.btn_Stop);
            this.Controls.Add(this.btn_Start);
            this.Controls.Add(this.lv_Data);
            this.Name = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.slider_ThreadCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lv_Data;
        private System.Windows.Forms.Button btn_Start;
        private System.Windows.Forms.Button btn_Stop;
        private System.Windows.Forms.TrackBar slider_ThreadCount;
        private System.Windows.Forms.Label label_SliderNumber;
        private System.Windows.Forms.ColumnHeader ThreadID;
        private System.Windows.Forms.ColumnHeader Text;
    }
}

