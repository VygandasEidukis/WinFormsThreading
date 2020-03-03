using System;
using System.Collections.Generic;
using System.Text;

namespace WinformsThreading_Common.Models
{
    public class ThreadDto
    {
        public int ID { get; set; }
        public int ThreadID { get; set; }
        public string Text { get; set; }

        public ThreadDto(int threadID, string text)
        {
            ThreadID = threadID;
            Text = text;
        }

        public ThreadDto()
        {

        }
    }
}
