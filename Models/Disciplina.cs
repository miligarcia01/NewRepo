using System.ComponentModel.DataAnnotations;

namespace ParcialProgramacion.Models
{
	public class Disciplina
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public string Nombre { get; set; }
	}
}
