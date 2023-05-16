namespace ASPNedjelja3Vjezbe.Api.DTO
{
    public class SpecificationDTO : BaseDTO
    {
        public string Name { get; set; }
        public IEnumerable<SpecificationValueDTO> SpecificationValues { get; set; }
    }
}
