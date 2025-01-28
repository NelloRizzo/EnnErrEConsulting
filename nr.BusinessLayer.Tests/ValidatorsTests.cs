using nr.BusinessLayer.Dto;
using nr.BusinessLayer.Dto.Customers;
using nr.BusinessLayer.Dto.Customers.Addresses;
using nr.Validation;

namespace nr.BusinessLayer.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup() {
        }

        [Test]
        public void CustomDtoValidatorsTest() {
            var c1 = new CompanyDto {
                CompanyName = "Test",
                BusinessAddress = new PostalAddressDto { Street = "", City = "", CivicNumber = "", PostalCode = "", Region = "" }
            };
            Assert.That(c1.IsValid, Is.False);
            c1.FiscalCode = "RZZNLL68H06L628E";
            Assert.That(c1.IsValid, Is.True);
            c1.FiscalCode = null;
            c1.VatCode = "12345";
            Assert.That(c1.IsValid, Is.False);
            c1.VatCode = "02342520158";
            Assert.That(c1.IsValid, Is.True);
        }

        [LessThan<DateOnly>(compareField: nameof(FirstDate), targetField: nameof(LastDate))]
        private class TestComparerDto : BaseDto
        {
            public DateOnly FirstDate { get; set; }
            public DateOnly LastDate { get; set; }
        }

        [Test]
        public void ComparerAttributeTest() {
            var now = DateTime.Now;
            var t = new TestComparerDto { FirstDate = DateOnly.FromDateTime(now), LastDate = DateOnly.FromDateTime(now.AddDays(1)) };
            Assert.That(t.IsValid, Is.True);
        }
    }
}
