using System.ComponentModel.DataAnnotations;

namespace GreatDesafio.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Cpf { get; set; }
        [Required]
        public string Rg { get; set; }
        [Required]
        public string NomeDaMae { get; set; }
        [Required]
        public string NomeDoPai { get; set; }
        [Required]
        public string DataDeNascimento { get; set; }
        [Required]
        public string DataDeCadastro { get; set; }
        
    }
}