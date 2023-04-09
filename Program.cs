//declareren
using System;

string Woord;
string WoordAangepast = "";
string[] WoordA;

int AantalCijfers, Cijfer = 0;
int LengteWoord;
//invoer
Console.WriteLine("Vul uw woord hier in:");
Woord = Console.ReadLine();

//verwerking
LengteWoord = Woord.Length;

for (int i = 0; i < Woord.Length; i++) ;
{
    WoordAangepast = WoordAangepast + "," + Woord.Substring(0 + Cijfer, 1);
    Cijfer = Cijfer + 1;

}

WoordA = new string[Woord.Length];
WoordA = WoordAangepast.Split(',');

foreach (string item in WoordA)
{
    Console.WriteLine(item);
}