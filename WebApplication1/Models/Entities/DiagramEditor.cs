namespace WebApplication1.Models.Entities
{
    public class DiagramEditor  
    {
        public int Id { get; set; }     
        public string IdentityId { get; set; }   
        public AppUser Identity { get; set; }  // navigation property
    }
}
