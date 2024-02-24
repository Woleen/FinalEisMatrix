using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace EisenhowerMain
{
    public class TodoQuarter
    {
        public readonly List<TodoItem> TodoItems;
        public int ActiveTaskIndex = 0;

        public TodoQuarter()
        {
            TodoItems = new List<TodoItem>();
        }

        public void AddItem(string title, DateTime deadline)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentNullException(nameof(title), "Title cannot be null or empty.");
            }

            if (deadline < DateTime.Now)
            {
                throw new ArgumentException("Deadline cannot be in the past.", nameof(deadline));
            }

            if (TodoItems.Any(item => item.GetDeadLine() == deadline))
            {
                throw new ArgumentException("A task with the same deadline already exists.", nameof(deadline));
            }

            TodoItems.Add(new TodoItem(title, deadline));
        }
        public void RemoveItem(int index)
        {
            if (index < 0 || index >= TodoItems.Count)
            {
                // throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");
            }

            TodoItems.RemoveAt(index);
        }
        public void ArchiveItems()
        {
            for (int i = TodoItems.Count - 1; i >= 0; i--)
            {
                if (GetItem(i).IsDone)
                {
                    RemoveItem(i);
                }
            }
        }

        public TodoItem GetItem(int index)
        {
            if (index < 0 || index >= TodoItems.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");
            }

            return TodoItems[index];
        }

        private List<TodoItem> GetItems()
        {
            return TodoItems;
        }

        public void GoUpTaskList()
        {
            ActiveTaskIndex = ActiveTaskIndex > 0 ? ActiveTaskIndex-1 : TodoItems.Count - 1;
        }

        public void GoDownTaskList()
        {
            if (ActiveTaskIndex < TodoItems.Count - 1)
            {
                ActiveTaskIndex++;
            }
            else ActiveTaskIndex = 0;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            List<TodoItem> items = GetItems();
            foreach (TodoItem item in items)
            {
                stringBuilder.Append(item.ToString() + "\n");
            }
            return stringBuilder.ToString();
        }
    }
}
