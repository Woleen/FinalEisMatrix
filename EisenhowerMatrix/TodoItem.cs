using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EisenhowerMain
{
    public class TodoItem
    {
        private readonly string Title;

        private readonly DateTime Deadline;

        public bool IsDone;

        public TodoItem(string title, DateTime deadline)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentNullException(nameof(title), "Title cannot be null or empty.");
            }

            Title = title;
            Deadline = deadline < DateTime.Now ? DateTime.Now : deadline;
            IsDone = false;
        }

        public string GetTitle() { return Title; }
        public DateTime GetDeadLine() { return Deadline; }
        public void Mark() { IsDone = true; }
        public void Unmark() { IsDone = false; }
        public string CurrentTitle { get { return GetTitle(); } }
        public override string ToString()
        {
            string title = GetTitle();
            string deadline = GetDeadLine().ToString("dd-MM");
            string mark = IsDone ? "[X]" : "[ ]";
            return $"{mark} {deadline} {title}";
        }


    }
}