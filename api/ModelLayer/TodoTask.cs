using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class TodoTask
    {
        public int taskId {get; set;}
        public string ?taskName {get; set;}
        public string ?taskDesc {get; set;}
        public bool taskStatus {get; set;}

        public TodoTask(int taskId, string taskName, string taskDesc, bool taskStatus) {
            this.taskId = taskId;
            this.taskName = taskName;
            this.taskDesc = taskDesc;
            this.taskStatus = taskStatus;
        }
        public TodoTask() {}
    }
}