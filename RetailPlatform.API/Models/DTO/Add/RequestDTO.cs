
namespace RetailPlatform.API.Models.DTO.Add
{
    public class RequestDTO
    {
        public long Id { get; set; }
        public string UniqueId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string DateOfCreation { get; set; }
        public string Description { get; set; }
        public string Place { get; set; }
        public string CreatedBy { get; set; }
    }
}
