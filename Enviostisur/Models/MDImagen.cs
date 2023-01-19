using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace Enviostisur.Models
{
    public class MDImagen
    {
        public int id_img { get; set; }
        public string? img_ruta { get; set; }
        public string? img_nombre { get; set; }
        public string? img_almacen { get; set; }
        
    }
}
