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

//Creo la lista de string para poder guardar la info de cada archivo y despues escribir esto en el CSV
List<string> lineasParaCSV = new List<string>();
//Añado esta linea, como para poder tener una referencia de que es cada columna
lineasParaCSV.Add("Nombre del archivo; Tamanio en KB; Fecha ult. modificacion");

//Para poder acceder a la info de los archivos
string[] nombreArchivos = Directory.GetFiles(rutaDirectorio);
foreach (string archivos in nombreArchivos)
{
    FileInfo infoArchivos = new FileInfo(archivos);
    Console.WriteLine($"El nombre del archivo es: {infoArchivos.Name} y su tamanio en KB: {infoArchivos.Length / 1024}");
    //Añado las lineas a la lista dependiendo de cuantos archivos tenga el directorio en el que estoy parado
    lineasParaCSV.Add($"{infoArchivos.Name};{infoArchivos.Length / 1024};{infoArchivos.LastWriteTime}");
}
Console.ResetColor();
//Creo la ruta del archivo
string rutaCSV = @$"{rutaDirectorio}/reporte_archivos.csv";
//Escribo en el archivo las lineas, pasandole la lista
File.WriteAllLines(rutaCSV, lineasParaCSV);