using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MultiThreading
{
    public class TaskObject
    {

        public int taskId { get; set; }
        public Action task { get; set; }

    }
}
