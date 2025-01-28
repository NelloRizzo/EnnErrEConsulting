using nr.Utils;
using nr.Validation;

namespace nr.BusinessLayer.Dto
{
    public class BaseDto : IValidatable
    {
        public int Id { get; set; }
        public override bool Equals(object? obj) => obj is BaseDto dto && dto.GetHashCode() == GetHashCode();
        public override int GetHashCode() => Id;

        public override string ToString() => this.Describe();
    }
}
