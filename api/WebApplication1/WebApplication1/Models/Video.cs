using System;

namespace WebApplication1.Models
{
    public class Video
    {
        public int VideoId { get; set; }
        public string VideoURL { get; set; }
        public DateTime FechaHora { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string ImagenAlbum { get; set; }
        public DateTime FechaVideo { get; set; }
        public DateTime Duracion { get; set; }
        public string Estado { get; set; }
    }
}
