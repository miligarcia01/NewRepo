using System.ComponentModel.DataAnnotations;

namespace ParcialProgramacion.Models
{
	public class Inscriptos
	{ 
			[Key] public int Id { get; set; } 
			[Required(ErrorMessage = "El nombre es obligatorio")] 
			public string Nombre { get; set; } 
			[Required(ErrorMessage = "La disciplina es obligatoria")] 
			public string Disciplina { get; set; } 
			[Range(0, int.MaxValue, ErrorMessage = "La edad debe ser al menos 0")] 
			public int Edad { get; set; } [Required(ErrorMessage = "La ciudad de residencia es obligatoria")] 
			public string CiudadResidencia { get; set; } 
		
	}
}

