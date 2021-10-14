// See https://aka.ms/new-console-template for more information
using Luchthaven.Model;

Console.WriteLine("Hello,ControleToren!");
ControleToren toren = new ControleToren();
bool doorgaan = true;

do {
    Console.WriteLine("\n1. Voeg baan toe \n2. Registreer Vliegtuig \n3. Controletoren overzicht \n4. Aanvraag voor opstijgen." +
        "\n5. Opstijgen \n6. Stop");
    var keuze = Console.ReadLine();
    switch (keuze)
    {
        case "1":
            Console.Write("Geef baancode in.");
            string code = Console.ReadLine();
            Baan nieuweBaan = new Baan(code);
            toren.GetBanen().Add(nieuweBaan);
            Console.WriteLine("Overzicht banen: \n" + toren.OverzichtBanen() + "\n");
            Console.WriteLine("Druk op een toets om verder te gaan");
            Console.ReadKey();
            break;
        case "2":
            Vliegtuig nieuwVliegtuig = new Vliegtuig();
            Console.WriteLine(toren.RegistreerVliegtuig(nieuwVliegtuig));
            Console.WriteLine("\nOverzicht vliegtuigen \n" + toren.OverzichtVliegtuigen() + "\n");
            Console.WriteLine("Druk op een toets om verder te gaan");
            Console.ReadKey();
            break;
        case "3":
            Console.WriteLine("Overzicht banen: \n" + toren.OverzichtBanen() + "\n");
            Console.WriteLine("\nOverzicht vliegtuigen \n" + toren.OverzichtVliegtuigen() + "\n");
            Console.WriteLine("Druk op een toets om verder te gaan");
            Console.ReadKey();
            break;
        case "4":
            Console.WriteLine("Geef het vluchtnummer in:");
            string vluchtnummer = Console.ReadLine();
            Console.WriteLine(toren.AanvraagTotOpstijgen(vluchtnummer));
            Console.WriteLine("Druk op een toets om verder te gaan");
            Console.ReadKey();
            break;
        case "5":
            Console.WriteLine("Geef het vluchtnummer in:");
            string vluchtnummerVoorOpstijgen = Console.ReadLine();
            Vliegtuig vliegtuig = toren.ZoekVliegtuig(vluchtnummerVoorOpstijgen);
            if(vliegtuig == null)
            {
                Console.WriteLine("Vliegtuig met vluchtnummer " + vluchtnummerVoorOpstijgen + " niet gevonden. Probeer opnieuw");
                break;
            }
            Console.WriteLine(vliegtuig.StijgOp());
            Console.WriteLine("Druk op een toets om verder te gaan");
            Console.ReadKey();
            break;
        case "6":
            doorgaan = false;
            break;
        default:
            Console.WriteLine("Ongeldige ingave, kies uit de nummer 1, 2, 3, 4, 5 of 6");
            break;
    }

}while(doorgaan);
Console.WriteLine("Programma beëindigd");

