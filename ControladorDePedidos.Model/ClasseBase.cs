using System.ComponentModel.DataAnnotations;

namespace ControladorDePedidos.Model
{
    public class ClasseBase
    {

        [Key]
        public int Codigo { get; set; }
    }
}
