using SpaceID3v1;
using System.IO;
using System.Runtime;
using System.Text;

string rutaArchivo = @"audio.mp3"; //Path archivo
FileStream FStreamHelp;

//Si el archivo existe, entonces lo abrimos con FileStream
if (File.Exists(rutaArchivo))
{
    using (FStreamHelp = new FileStream(rutaArchivo, FileMode.Open))  //Abrir el archivo -- Utilizo "using" para que se cierre automaticamente al salir del bloque y no tener que preocuparme por eso dsp
    {
        FStreamHelp.Seek(FStreamHelp.Length - 128, SeekOrigin.Begin); //Me paro en los ultimos 128 bits para analizar
        byte[] buffer = new byte[128];
        int bytesLeidos = FStreamHelp.Read(buffer, 0, 128);
        string header = Encoding.Latin1.GetString(buffer, 0, 3);
        string titulo = Encoding.Latin1.GetString(buffer, 3, 30).Trim(); //Utilizo Trim para poder eliminar los espacios al final si es que tienen
        string artista = Encoding.Latin1.GetString(buffer, 33, 30).Trim();
        string album = Encoding.Latin1.GetString(buffer, 63, 30).Trim();
        string anio = Encoding.Latin1.GetString(buffer, 93, 4).Trim();
        string comentario = Encoding.Latin1.GetString(buffer, 97, 30).Trim();
        byte genero = buffer[127];

        //Creo la instancia
        ID3v1Tag informacion = new ID3v1Tag(header, titulo, artista, album, anio, comentario, genero);
        informacion.MostrarDatos();
    }
}
else
{
    Console.WriteLine($"El archivo no se encontro {rutaArchivo}");
}

//Encoding.Latin1.GetString(buffer, 0, 3); Esto sirve para convertir los bytes a texto 
//Latin1, sirve para poder identificar los acentos, simbolos y demas
//Tomo desde el byte 0 hasta el 3 y esos 3 bytes son los que voy a interpretar y devolver como texto