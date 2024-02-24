namespace Tests
{
    public class TodoIntegrationTests
    {
        private TodoQuarter quarter;

        [SetUp]
        public void Setup()
        {
            quarter = new TodoQuarter();
        }

        [Test]
        public void AddingTaskUpdatesQuarterList()
        {
            var initialCount = quarter.TodoItems.Count;
            var title = "Test Task";
            var deadline = DateTime.Now.AddDays(1);

            quarter.AddItem(title, deadline);

            Assert.That(quarter.TodoItems, Has.Count.EqualTo(initialCount + 1));
        }

        [Test]
        public void AddingTaskUpdatesQuarterList_TitleMatches()
        {
            var initialCount = quarter.TodoItems.Count;
            var title = "Test Task";
            var deadline = DateTime.Now.AddDays(1);

            quarter.AddItem(title, deadline);

            Assert.That(quarter.TodoItems[initialCount].CurrentTitle, Is.EqualTo(title));
        }

        [Test]
        public void AddingTaskUpdatesQuarterList_DeadlineMatches()
        {
            var initialCount = quarter.TodoItems.Count;
            var title = "Test Task";
            var deadline = DateTime.Now.AddDays(1);

            quarter.AddItem(title, deadline);

            Assert.That(quarter.TodoItems[initialCount].GetDeadLine(), Is.EqualTo(deadline));
        }

        [Test]
        public void AddingTaskUpdatesQuarterList_IsDoneIsFalse()
        {
            var initialCount = quarter.TodoItems.Count;
            var title = "Test Task";
            var deadline = DateTime.Now.AddDays(1);

            quarter.AddItem(title, deadline);

            Assert.That(quarter.TodoItems[initialCount].IsDone, Is.False);
        }

        [Test]
        public void RemovingTaskUpdatesQuarterList_RemovesItem()
        {
            var title = "Test Task";
            var deadline = DateTime.Now.AddDays(1);
            quarter.AddItem(title, deadline);
            var initialCount = quarter.TodoItems.Count;

            quarter.RemoveItem(0);

            Assert.That(quarter.TodoItems, Has.Count.EqualTo(initialCount - 1));
        }

        [Test]
        public void RemovingTaskUpdatesQuarterList_ThrowsArgumentOutOfRangeException()
        {
            var title = "Test Task";
            var deadline = DateTime.Now.AddDays(1);
            quarter.AddItem(title, deadline);
            var initialCount = quarter.TodoItems.Count;

            Assert.Throws<ArgumentOutOfRangeException>(() => quarter.GetItem(initialCount));
        }
    }
}