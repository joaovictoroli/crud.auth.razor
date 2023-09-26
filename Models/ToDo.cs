using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace auth.studies.Models
{
    public class ToDo : BaseModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres")]
        [DisplayName("Titulo")]
        public required string Title { get; set; }

        [MinLength(1), MaxLength(50)]
        [DisplayName("Descrição")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres")]
        [DataType(DataType.MultilineText)]
        public required string Description { get; set; }
        [DisplayName("Iniciado Em:")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public required DateTime CreatedAt { get; set; }

        [DisplayName("Modificado Em:")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy:hh:mm:ss}")]       
        public required DateTime LastUpdatedAt { get; set; }
        public bool IsDone { get; set; }
    }
}

