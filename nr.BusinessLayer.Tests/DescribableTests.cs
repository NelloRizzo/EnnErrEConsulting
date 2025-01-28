namespace nr.BusinessLayer.Tests
{
    class Test
    {
        public string Name { get; set; } = "Name";
        public string Description { get; set; } = "Description";
        public int Value { get; set; } = 10;
        public DateTime Date { get; set; } = DateTime.Now;
    }

    public class DescribableTests
    {
        [Test]
        public void Describable() {
            var t = new Test();
            Assert.DoesNotThrow(() => Console.WriteLine(t));
        }

    }
}
