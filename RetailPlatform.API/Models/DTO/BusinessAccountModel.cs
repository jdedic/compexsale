
namespace RetailPlatform.API.Models.DTO
{
    public class BusinessAccountModel
    {
        public long Id { get; set; }
        public string CompanyName { get; set; }
        public string PIB { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public bool IsAssigned { get; set; }
    }
}
