//declaratie
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

int Difficulty = 6;
int AmountOfTries = 0;
bool Spelen = true;
var path = "C:\\Users\\kobev\\OneDrive\\Desktop\\code\\c#\\Hangman\\Hangman\\WoordenLijst.txt";
string[] lines = File.ReadAllLines(path, Encoding.UTF8);
int AantalWoordenInLijst = File.ReadAllLines(@path).Length;
int IndexWoord;
int Teller = 0;
Random random = new Random();
string OrigineelWoord = "";
string ReeksAangepastWoord;
char LetterGok = Convert.ToChar("a");
bool FouteCharIngave;
bool JuistOfFout;
string ReeksAlGekozenLetter = "";

//spel spelen

//menu
Console.Clear();
Console.WriteLine("---HANGMAN---\n1. makkelijk\n2. original\n3. moeilijk\n4. Custom difficulty\n0. spel afsluiten");
try { Difficulty = Convert.ToInt32(Console.ReadLine()); }
catch { }
//kansen zetten
switch (Difficulty)
{
    case 0:
        Environment.Exit(0);
        break;
    case 1:
        AmountOfTries = 12; break;
    case 2:
        AmountOfTries = 7; break;
    case 3:
        AmountOfTries = 4; break;
    case 4:
        Console.Clear();
        try
        {
            Console.WriteLine("aantal Kansen: ");
            AmountOfTries = Convert.ToInt16(Console.ReadLine());
        }
        catch (Exception ex)
        {
            Console.Clear();
            Console.WriteLine(ex.ToString());
            Thread.Sleep(300);
        }
        break;
    default:
        Console.WriteLine("Foute ingave !");
        Console.ReadLine();
        break;
}
Teller = 0;
IndexWoord = random.Next(1, AantalWoordenInLijst + 1);
foreach (string line in lines)
{

    Teller++;
    OrigineelWoord = line;
    if (Teller == IndexWoord)
    {
        break;
    }
}
string[] AangepastWoord = new string[OrigineelWoord.Length];
char[] OrigineelWoordArray = new char[OrigineelWoord.Length];
OrigineelWoordArray = OrigineelWoord.ToCharArray();
for (int i = 0; i < OrigineelWoord.Length; i++)
{
    AangepastWoord[i] = "_";
}
for (int k = 0; k <= AmountOfTries; k++)
{

    Console.Clear();
    ReeksAangepastWoord = "";
    foreach (string letter in AangepastWoord)
    {
        ReeksAangepastWoord += letter;
    }
    if (ReeksAangepastWoord == OrigineelWoord)
    {
        break;
    }
    do
    {
        FouteCharIngave = false;
        Console.WriteLine("Welke letter gok je ? (kans:{0}/{1})", k, AmountOfTries);
        Console.WriteLine(ReeksAangepastWoord);
        try
        {

            LetterGok = Convert.ToChar(Console.ReadLine());
        }
        catch
        {
            FouteCharIngave = true;
            Console.WriteLine("Foute ingave");
            Thread.Sleep(1000);
        }
        if (ReeksAlGekozenLetter.Contains(LetterGok))
        {
            Console.WriteLine("dat is al eens ingevoerd");
            Console.ReadLine();
            k--;
        }
        else
        {
            ReeksAlGekozenLetter += LetterGok;
        }

    } while (FouteCharIngave == true && ReeksAlGekozenLetter.Contains(LetterGok));

    JuistOfFout = false;
    for (int j = 0; j < OrigineelWoord.Length; j++)
    {
        if (LetterGok == OrigineelWoordArray[j])
        {
            AangepastWoord[j] = LetterGok.ToString();
            JuistOfFout = true;
        }
    }
    switch (JuistOfFout)
    {
        case true:
            Console.WriteLine("juist !!");
            Console.ReadLine();
            break;
        case false:
            Console.WriteLine("fout !!");
            break;
    }



}
Console.Clear();
ReeksAangepastWoord = "";
foreach (string letter in AangepastWoord)
{
    ReeksAangepastWoord += letter;
}
if (ReeksAangepastWoord != OrigineelWoord)
{
    Console.WriteLine("U heeft al uw kansen gebruikt\nu had " + ReeksAangepastWoord + " gevonden\nhet woord was " + OrigineelWoord);
    Console.ReadLine();
}
else
{
    Console.WriteLine("U heeft het woord {0} gevonden, proficiat !!", OrigineelWoord);
}




