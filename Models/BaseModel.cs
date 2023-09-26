using System.ComponentModel.DataAnnotations;

namespace auth.studies.Models;
public class BaseModel
{
    [Key]
    public int Id { get; set; }
}
