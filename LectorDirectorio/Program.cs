using System.IO;
Console.ForegroundColor = ConsoleColor.DarkMagenta;
Console.WriteLine("--------Analizador de directorios-------");
Console.ResetColor();
Console.WriteLine("Ingrese la ruta de un directorio: "); //Pedimos la ruta

string? rutaDirectorio = Console.ReadLine();
rutaDirectorio = @"/mnt/c/FACULTAD"; //Esta es una ruta para poder acceder a los archivos de Windows desde WSL-Ubuntu

//Ciclo while, por si la ruta no es correcta, poder pedirla hasta que si lo sea
while (!Directory.Exists(rutaDirectorio))
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"El Path {rutaDirectorio} del directorio no es valido. Intente de nuevo.");
    Console.ResetColor();
    rutaDirectorio = Console.ReadLine();
}

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine($"El Path {rutaDirectorio}, funciona");
Console.ResetColor();
//Para poder acceder a la info de los directorios
string[] nombreDirectorios = Directory.GetDirectories(rutaDirectorio);
//Para recorrer los array creados
foreach (string directorios in nombreDirectorios)
{
    //Una instancia para poder acceder a metodos 
    FileInfo infoDirectorios = new FileInfo(directorios);
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine($"El nombre del directorio es: {infoDirectorios.Name}");
}

//Para poder acceder a la info de los archivos
string[] nombreArchivos = Directory.GetFiles(rutaDirectorio);
foreach (string archivos in nombreArchivos)
{
    FileInfo infoArchivos = new FileInfo(archivos);
    Console.WriteLine($"El nombre del archivo es: {infoArchivos.Name} y su tamanio en KB: {infoArchivos.Length / 1024}");
}
Console.ResetColor();