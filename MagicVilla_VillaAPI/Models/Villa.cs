namespace MagicVilla_VillaAPI.Models;

public class Villa
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    //So we don't want this additional field to be displayed to client and that's why we use DTO, to restrict only above fields
    public DateTime createdAt { get; set; }
    
}