namespace Web.Models
{
    public class PeliculasModel : ErrorModel
    {
        public int IdPelicula { get; set; }
        public int IdCategoriaPeliculas { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public string? ActorPrincipal { get; set; }
        public string? ActorPrincipal2 { get; set; }
        public string? ActorSecundario { get; set; }
        public string? ActorSecundario2 { get; set; }
        public string? IdImdb { get; set; }
        public string? Portada { get; set; }
        public IMDBDataMovie IMDBData { get; set; }
    }

    public class IMDBDataMovie
    {        
        public string id { get; set; }
        public string title { get; set; }
        public float rating { get; set; }
        public string image { get; set; }

    }
}
