namespace ASPNedjelja3Vjezbe.Domain
{
    public class Specification : Entity
    {
        public string Name { get; set; }
        public virtual ICollection<CategorySpecification> CategorySpecifications { get; set; } = new List<CategorySpecification>();
        public virtual ICollection<SpecificationValue> SpecificationValues { get; set; } = new List<SpecificationValue>();
    }
}
