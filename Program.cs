// See https://aka.ms/new-console-template for more information
using Personnummer_kontroll.Models;


PersNr persnr = new PersNr();
while (true)
{
    persnr.RunProgram();
    Console.WriteLine("\nProgrammet startar om...\n");    
}