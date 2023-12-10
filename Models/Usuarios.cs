using System.ComponentModel.DataAnnotations;

public class Usuarios
{
    [Key]
    [Required(ErrorMessage ="El usuario es requerido")]
    public String NombreUsuario { get; set; }
    [Required(ErrorMessage ="La contaseña es requerida")]
    public String? Contraseña { get; set; }
}