using nr.Utils;

namespace nr.BusinessLayer.Tests
{
    class First
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
            var t = new First();
            Assert.DoesNotThrow(() => Console.WriteLine(t.Describe()));
        }
    }
}
