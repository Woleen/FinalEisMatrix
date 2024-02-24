namespace Tests
{
    public class TodoQuarterExceptionHandlingTests
    {
        private TodoQuarter quarter;

        [SetUp]
        public void Setup()
        {
            quarter = new TodoQuarter();
        }

        [Test]
        public void RemoveItem_IndexInRange_DoesNotThrowException()
        {
            quarter.AddItem("Test Task", DateTime.Now.AddDays(1));

            Assert.DoesNotThrow(() => quarter.RemoveItem(0));
        }
        [Test]
        public void RemoveItem_IndexOutOfRange_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => quarter.RemoveItem(0));
        }

        [Test]
        public void GetItem_IndexOutOfRange_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => quarter.GetItem(0));
        }
        [Test]
        public void RemoveItem_IndexOutOfRangeBelow_ThrowsArgumentOutOfRangeException()
        {
            quarter.AddItem("Test Task", DateTime.Now.AddDays(1));

            Assert.Throws<ArgumentOutOfRangeException>(() => quarter.RemoveItem(-1));
        }

        [Test]
        public void RemoveItem_IndexOutOfRangeAbove_ThrowsArgumentOutOfRangeException()
        {
            quarter.AddItem("Test Task", DateTime.Now.AddDays(1));

            Assert.Throws<ArgumentOutOfRangeException>(() => quarter.RemoveItem(1));
        }

        [Test]
        public void GetItem_IndexOutOfRangeBelow_ThrowsArgumentOutOfRangeException()
        {
            quarter.AddItem("Test Task", DateTime.Now.AddDays(1));

            Assert.Throws<ArgumentOutOfRangeException>(() => quarter.GetItem(-1));
        }

        [Test]
        public void GetItem_IndexOutOfRangeAbove_ThrowsArgumentOutOfRangeException()
        {
            quarter.AddItem("Test Task", DateTime.Now.AddDays(1));

            Assert.Throws<ArgumentOutOfRangeException>(() => quarter.GetItem(1));
        }

        [Test]
        public void RemoveItem_ValidIndex_NonEmptyList_RemovesItem()
        {
            // Arrange
            quarter.AddItem("Test Task 1", DateTime.Now.AddDays(1));
            quarter.AddItem("Test Task 2", DateTime.Now.AddDays(2));
            int initialCount = quarter.TodoItems.Count;

            // Act
            quarter.RemoveItem(1);

            // Assert
            Assert.That(quarter.TodoItems.Count, Is.EqualTo(initialCount - 1));
            Assert.That(quarter.TodoItems.Any(item => item.CurrentTitle == "Test Task 2"), Is.False);
        }

        [Test]
        public void RemoveItem_InvalidIndex_NonEmptyList_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            quarter.AddItem("Test Task 1", DateTime.Now.AddDays(1));
            quarter.AddItem("Test Task 2", DateTime.Now.AddDays(2));

            // Act and Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => quarter.RemoveItem(2));
        }

        [Test]
        public void RemoveItem_ValidIndex_EmptyList_ThrowsArgumentOutOfRangeException()
        {
            // Act and Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => quarter.RemoveItem(0));
        }

        [Test]
        public void RemoveItem_InvalidIndex_EmptyList_ThrowsArgumentOutOfRangeException()
        {
            // Act and Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => quarter.RemoveItem(1));
        }
    }
}