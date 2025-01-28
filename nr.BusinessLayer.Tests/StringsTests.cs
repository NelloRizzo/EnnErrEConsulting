using nr.Utils;

namespace nr.BusinessLayer.Tests;

public class StringsTests
{
    [SetUp]
    public void Setup() {
    }

    [Test]
    public void Slice() {
        Assert.Multiple(() => {
            Assert.That("12345".Slice(end: -2), Is.EqualTo("123"));
            Assert.That("12345".Slice(-3), Is.EqualTo("345"));
        });
    }
    [Test]
    public void FiscalCode() {
        Assert.Multiple(() => {
            Assert.That("RZZNLL68H06L628E".IsFiscalCode(), Is.True);
            Assert.That("RZZNLL68H06L628F".IsFiscalCode(), Is.False);
        });
    }
}
