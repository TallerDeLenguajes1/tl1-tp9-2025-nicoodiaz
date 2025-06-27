namespace SpaceID3v1;

class ID3v1Tag
{
    private string header;
    private string tituloCancion;
    private string nombreArtista;
    private string tituloAlbum;
    private string anioPublicacion;
    private string comentario;
    private byte numGenero;

    public ID3v1Tag(string header, string tituloCancion, string nombreArtista, string tituloAlbum, string anioPublicacion, string comentario, byte numGenero)
    {
        this.header = header;
        this.tituloCancion = tituloCancion;
        this.nombreArtista = nombreArtista;
        this.tituloAlbum = tituloAlbum;
        this.anioPublicacion = anioPublicacion;
        this.comentario = comentario;
        this.numGenero = numGenero;
    }

    public string Header { get => header; set => header = value; }
    public string TituloCancion { get => tituloCancion; set => tituloCancion = value; }
    public string NombreArtista { get => nombreArtista; set => nombreArtista = value; }
    public string TituloAlbum { get => tituloAlbum; set => tituloAlbum = value; }
    public string AnioPublicacion { get => anioPublicacion; set => anioPublicacion = value; }
    public string Comentario { get => comentario; set => comentario = value; }
    public byte NumGenero { get => numGenero; set => numGenero = value; }

    public void MostrarDatos()
    {
        Console.WriteLine($"Cancion: {TituloCancion} - ({AnioPublicacion})");
        Console.WriteLine($"Artista: {NombreArtista}");
        Console.WriteLine($"Album: {TituloAlbum}");
        Console.WriteLine($"Comentario: {Comentario}");
    }
}