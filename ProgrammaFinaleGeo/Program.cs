// Programma geometrico per calcolare Aree e Perimetri per quasi tutti i poligoni.
// Versione: 1.0.0
// data: 08/01/2025
// Collaboratori: Cristian Di Risio, Luca Belometti, Ye Yuhao.

using System.ComponentModel.Design;
using System.Diagnostics;
using System.IO;
using System.Xml;

internal class Program
{
    private static void Main(string[] args)
    {
        char menu;
        do
        {
            double area;
            double perimetro;
            String Invio = System.Environment.NewLine;

            Console.ForegroundColor = ConsoleColor.Blue;

            Console.WriteLine("Benvenuto nel Geometr(Eas)y");
            Console.WriteLine("Questo programma ti permette di calcolare l'area e il perimetro di diverse figure geometriche");

            // 1° Menù della figura di cui calcolare informazioni

            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("Scegli il tipo di figura da calcolare:");

            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("1: Poligono");
            Console.WriteLine("2: Cerchio / Ovale");
            Console.WriteLine("3: Cronologia");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("4: Esci");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            // Controllo scelta della figura di cui calcolare informazioni

            string scelta;
            do
            {
                scelta = Console.ReadLine();
                if (scelta.Length != 1)
                {
                    Console.WriteLine("Inserisci un solo carattere");
                }
            } while (scelta.Length != 1);

            menu = Convert.ToChar(scelta);

            // Menù per la scelta se è regolare e irregolare

            switch (menu)
            {
                case '1':
                    string sceltaPoligono;
                    int N;
                    bool controllo;
                    do
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Il poligono è regolare o irregolare? (Regolare/Irregolare)");
                        Console.ForegroundColor = ConsoleColor.White;
                        sceltaPoligono = Console.ReadLine();
                        controllo = int.TryParse(sceltaPoligono, out N);
                    } while (controllo == true);

                    // Condizione per calcolare le infomrazioni dei poligoni regolari

                    if (sceltaPoligono == "Regolare" || sceltaPoligono == "regolare" || sceltaPoligono == "REGOLARE")
                    {
                        char menuregolare;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("il Poligono in questione é un: ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("1: Poligono regolare dei quadrilateri");
                        Console.WriteLine("2: Rombo");
                        Console.WriteLine("3: Triangolo");

                        // Controllo scelta del poligono

                        string sceltaregolare;
                        do
                        {
                            sceltaregolare = Console.ReadLine();
                            if (sceltaregolare.Length != 1)
                            {
                                Console.WriteLine("Inserisci un solo carattere");
                            }
                        } while (sceltaregolare.Length != 1);

                        menuregolare = Convert.ToChar(sceltaregolare);

                        switch (menuregolare)
                        {
                            // Calcolo area e perimetro di un poligono appartenente alla famiglia dei quadrilateri

                            case '1':
                                int numeroLati;
                                double lunghezzaLato;
                                double AreaRls1;
                                double PerimetroRls1;
                                bool controllo2;
                                bool controllo3;

                                // Richiesta dei dati e controllo variabili

                                do
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("Inserisci il numero di lati del poligono:");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    controllo2 = int.TryParse(Console.ReadLine(), out numeroLati);
                                } while (controllo2 == false);
                                do
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("Inserisci la lunghezza del lato del poligono in mm:");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    controllo3 = double.TryParse(Console.ReadLine(), out lunghezzaLato);
                                } while (controllo3 == false);

                                // Dichiarazione funzione per calcolare l'area

                                AreaRls1 = AreaPoligonoRegolare(numeroLati, lunghezzaLato);
                                area = AreaRls1;

                                // Dichiarazione funzione per calcolare il perimetro

                                PerimetroRls1 = PerimetroPoligonoRegolare(numeroLati, lunghezzaLato);
                                perimetro = PerimetroRls1;

                                //restituzione area e perimetro

                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine($"L'area del poligono regolare di {numeroLati} di lunghezza {lunghezzaLato} mm è: {AreaRls1} mm^2");
                                Console.WriteLine("");
                                Console.WriteLine($"Il perimetro del poligono regolare di {numeroLati} di lunghezza {lunghezzaLato} mm è: {PerimetroRls1} mm");
                                string AreaPoligonoRegolareDoc = "l'area corrisponde a: " + AreaRls1 +", il perimetro corrisponde a: " + PerimetroRls1 + Invio + Invio;

                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.WriteLine("Vuoi il risultato in altre unità di misura? (S/N)");
                                Console.ForegroundColor = ConsoleColor.White;
                                char risposta = Convert.ToChar(Console.ReadLine());
                                if (risposta == 'S' || risposta == 's')
                                {
                                    string sceltadimensione;
                                    do
                                    {
                                        int NN;
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Vuoi convertirlo in quale unità (da terametri a picometri)?");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        sceltadimensione = Console.ReadLine();
                                        controllo = int.TryParse(sceltadimensione, out NN);
                                    } while (controllo == true);


                                    if (risposta == 's')
                                    {
                                        Console.WriteLine("Inserisci la misura (pm, nm, um, cm, dm, m, dam, hm, km, Mm, Gm, Tm):");
                                        string misura = Console.ReadLine();
                                        var convertitore = ConvertiAreaEPerimetro(area, perimetro, misura);
                                        Console.WriteLine($"Area convertita: {convertitore.area} {misura}^2");
                                        Console.WriteLine($"Perimetro convertito: {convertitore.perimetro} {misura}");
                                    }
                                }
                                    //trascrizione sul documento
                                    DateTime now = DateTime.Now;
                                File.AppendAllText("Database_cronologia", "Hai avviato il codice il: " + now.ToString("dd/MM/yyyy HH:mm:ss") + Invio);
                                File.AppendAllText("Database_Cronologia", AreaPoligonoRegolareDoc);
                                break;
                            case '2':
                                double diagonaleMaggiore;
                                double diagonaleMinore;
                                double AreaRls2;
                                double PerimetroRls2;
                                bool controllo4;
                                bool controllo5;

                                // Richiesta dei dati e controllo variabili

                                do
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("Inserisci la lunghezza della diagonale maggiore in mm:");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    controllo4 = double.TryParse(Console.ReadLine(), out diagonaleMaggiore);
                                } while (controllo4 == false);
                                do
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("Inserisci la lunghezza della diagonale minore in mm:");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    controllo5 = double.TryParse(Console.ReadLine(), out diagonaleMinore);
                                } while (controllo5 == false);

                                // Dichiarazione funzione per calcolare l'area

                                AreaRls2 = AreaRombo(diagonaleMaggiore, diagonaleMinore);
                                area = AreaRls2;

                                // Dichiarazione funzione per calcolare il perimetro

                                PerimetroRls2 = PerimetroRombo(diagonaleMaggiore, diagonaleMinore);
                                perimetro = PerimetroRls2;

                                //restituzione area e perimetro

                                Console.WriteLine($"L'area del rombo di diagonale {diagonaleMaggiore} mm e {diagonaleMinore} mm è: {AreaRls2} mm^2");
                                Console.WriteLine("");
                                Console.WriteLine($"Il perimetro del rombo di diagonale {diagonaleMaggiore} mm e {diagonaleMinore} mm è: {PerimetroRls2} mm");

                                Console.WriteLine("Vuoi il risultato in altre unità di misura? (S/N)");
                                char risposta1 = Convert.ToChar(Console.ReadLine());
                                if (risposta1 == 'S' || risposta1 == 's')
                                {
                                    string sceltadimensione;
                                    do
                                    {
                                        int NN;
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Vuoi convertirlo in quale unità (da terametri a picometri)?");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        sceltadimensione = Console.ReadLine();
                                        controllo = int.TryParse(sceltadimensione, out NN);
                                    } while (controllo == true);

                                    if (risposta1 == 's')
                                    {
                                        Console.WriteLine("Inserisci la misura (pm, nm, um, cm, dm, m, dam, hm, km, Mm, Gm, Tm):");
                                        string misura = Console.ReadLine();
                                        var convertitore = ConvertiAreaEPerimetro(area, perimetro, misura);
                                        Console.WriteLine($"Area convertita: {convertitore.area} {misura}^2");
                                        Console.WriteLine($"Perimetro convertito: {convertitore.perimetro} {misura}");
                                    }
                                }
                                    //trascrizione sul documento
                                    string AreaRomboDoc = "l'area corrisponde a: " + AreaRls2 + ", il perimetro corrisponde a: " + PerimetroRls2 + Invio + Invio;
                                    DateTime now1 = DateTime.Now;
                                File.AppendAllText("Database_cronologia", "Hai avviato il codice il: " + now1.ToString("dd/MM/yyyy HH:mm:ss") + Invio);
                                File.AppendAllText("Database_Cronologia", AreaRomboDoc);
                                break;
                            case '3':
                                double baseTriangolo;
                                double altezzaTriangolo;
                                double AreaRls3;
                                double PerimetroRls3;
                                bool controllo6;
                                bool controllo7;

                                // Richiesta dei dati e controllo variabili

                                do
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("Inserisci la lunghezza della base del triangolo in mm:");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    controllo6 = double.TryParse(Console.ReadLine(), out baseTriangolo);
                                } while (controllo6 == false);
                                do
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("Inserisci la lunghezza dell'altezza del triangolo in mm:");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    controllo7 = double.TryParse(Console.ReadLine(), out altezzaTriangolo);
                                } while (controllo7 == false);

                                // Dichiarazione funzione per calcolare l'area

                                AreaRls3 = AreaTriangolo(baseTriangolo, altezzaTriangolo);
                                area = AreaRls3;

                                // Dichiarazione funzione per calcolare il perimetro

                                PerimetroRls3 = PerimetroTriangolo(baseTriangolo, baseTriangolo, baseTriangolo);
                                perimetro = PerimetroRls3;

                                //restituzione area e perimetro

                                Console.WriteLine($"L'area del triangolo di base {baseTriangolo} mm e altezza {altezzaTriangolo} mm è : {AreaRls3} mm^2");
                                Console.WriteLine("");
                                Console.WriteLine($"Il perimetro del triangolo di base {baseTriangolo} cm e altezza {altezzaTriangolo} mm è: {PerimetroRls3} mm");

                                Console.WriteLine("Vuoi il risultato in altre unità di misura? (S/N)");
                                char risposta2 = Convert.ToChar(Console.ReadLine());
                                if (risposta2 == 'S' || risposta2 == 's')
                                {
                                    string sceltadimensione;
                                    do
                                    {
                                        int NN;
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Vuoi convertirlo in quale unità (da terametri a picometri)?");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        sceltadimensione = Console.ReadLine();
                                        controllo = int.TryParse(sceltadimensione, out NN);
                                    } while (controllo == true);
                                }

                                    //trascrizione sul documento
                                    string AreaTriangoloRegolareDoc = "l'area corrisponde a: " + AreaRls3 + ", il perimetro corrisponde a: " + PerimetroRls3 + Invio + Invio;
                                DateTime now7 = DateTime.Now;
                                File.AppendAllText("Database_cronologia", "Hai avviato il codice il: " + now7.ToString("dd/MM/yyyy HH:mm:ss") + Invio);
                                File.AppendAllText("Database_Cronologia", AreaTriangoloRegolareDoc);

                                break;
                            default:
                                Console.WriteLine("Inserisci un numero che esiste nella lista!!!");

                                break;
                        }
                    }

                    // Condizione per calcolare le infomrazioni dei poligoni irregolari

                    else if (sceltaPoligono == "Irregolare" || sceltaPoligono == "irregolare" || sceltaPoligono == "IRREGOLARE")
                    {
                        char menuirregolare;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Che tipo di poligono irregolare vuoi calcolare??");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("1: Rettangolo");
                        Console.WriteLine("2: Triangolo");
                        Console.WriteLine("3: Trapezio");
                        Console.WriteLine("4: Parallelogramma");
                        Console.WriteLine("5: Perimetro poligono Irregolare");

                        Console.WriteLine();

                        Console.ForegroundColor = ConsoleColor.White;

                        string sceltairregolare;
                        do
                        {
                            sceltairregolare = Console.ReadLine();
                            if (sceltairregolare.Length != 1)
                            {
                                Console.WriteLine("Inserisci un solo carattere");
                            }
                        } while (sceltairregolare.Length != 1);

                        menuirregolare = Convert.ToChar(sceltairregolare);

                        switch (menuirregolare)
                        {
                            case '1':
                                double baseRettangolo;
                                double altezzaRettangolo;
                                double AreaRls4;
                                double PerimetroRls4;
                                bool controllo8;
                                bool controllo9;

                                // Richiesta dei dati e controllo variabili

                                do
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("Inserisci la lunghezza della base del rettangolo in mm:");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    controllo8 = double.TryParse(Console.ReadLine(), out baseRettangolo);
                                } while (controllo8 == false);
                                do
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("Inserisci la lunghezza dell'altezza del rettangolo in mm:");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    controllo9 = double.TryParse(Console.ReadLine(), out altezzaRettangolo);
                                } while (controllo9 == false);

                                // Dichiarazione funzione per calcolare l'area

                                AreaRls4 = AreaRettangolo(baseRettangolo, altezzaRettangolo);
                                area = AreaRls4;

                                // Dichiarazione funzione per calcolare il perimetro

                                PerimetroRls4 = PerimetroRettangolo(baseRettangolo, altezzaRettangolo);
                                perimetro = PerimetroRls4;

                                //restituzione area e perimetro

                                Console.WriteLine($"L'area del rettangolo di base {baseRettangolo} mm e altezza {altezzaRettangolo} mm è: {AreaRls4} mm^2");
                                Console.WriteLine("");
                                Console.WriteLine($"Il perimetro del rettangolo di base {baseRettangolo} mm e altezza {altezzaRettangolo} mm è: {PerimetroRls4}");

                                Console.WriteLine("Vuoi il risultato in altre unità di misura? (S/N)");
                                char risposta2 = Convert.ToChar(Console.ReadLine());
                                if (risposta2 == 'S' || risposta2 == 's')
                                {
                                    string sceltadimensione;
                                    do
                                    {
                                        int NN;
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Vuoi convertirlo in quale unità (da terametri a picometri)?");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        sceltadimensione = Console.ReadLine();
                                        controllo = int.TryParse(sceltadimensione, out NN);
                                    } while (controllo == true);


                                    Console.WriteLine("Vuoi il risultato in altre unità di misura? (S/N)");
                                    char risposta = Convert.ToChar(Console.ReadLine());
                                    if (risposta == 'S' || risposta == 's')
                                    {
                                        do
                                        {
                                            int NN;
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("Vuoi convertirlo in quale unità (da terametri a picometri)?");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            sceltadimensione = Console.ReadLine();
                                            controllo = int.TryParse(sceltadimensione, out NN);
                                        } while (controllo == true);
                                    }
                                }
                        
                                    //trascrizione sul documento
                                    string AreaRettangoloDoc = "l'area corrisponde a: " + AreaRls4 + ", il perimetro corrisponde a: " + PerimetroRls4 + Invio + Invio;
                                DateTime now7 = DateTime.Now;
                                File.AppendAllText("Database_cronologia", "Hai avviato il codice il: " + now7.ToString("dd/MM/yyyy HH:mm:ss") + Invio);
                                File.AppendAllText("Database_Cronologia", AreaRettangoloDoc);

                                break;
                            case '2':
                                double proiezioneCateti1;
                                double proiezioneCateti2;
                                double AreaRls5;
                                double PerimetroRls5;
                                bool controllo10;
                                bool controllo11;

                                // Richiesta dei dati e controllo variabili

                                do
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("Inserisci la lunghezza della proiezione del primo cateto (quello minore) in mm:");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    controllo10 = double.TryParse(Console.ReadLine(), out proiezioneCateti1);
                                } while (controllo10 == false);
                                do
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("Inserisci la lunghezza della proiezione del secondo cateto (quello maggiore) in mm:");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    controllo11 = double.TryParse(Console.ReadLine(), out proiezioneCateti2);
                                } while (controllo11 == false);

                                // Dichiarazione funzione per calcolare l'area

                                AreaRls5 = AreaTriangoloIrregolare(proiezioneCateti1, proiezioneCateti2);
                                area = AreaRls5;

                                // Dichiarazione funzione per calcolare il perimetro

                                PerimetroRls5 = PerimetroTriangolo(proiezioneCateti1, proiezioneCateti2, proiezioneCateti1 + proiezioneCateti2);
                                perimetro = PerimetroRls5;

                                //restituzione area e perimetro

                                Console.WriteLine($"L'area del triangolo irregolare è: {AreaRls5} mm^2");
                                Console.WriteLine("");
                                Console.WriteLine($"Il perimetro del triangolo irregolare è: {PerimetroRls5} mm");

                                Console.WriteLine("Vuoi il risultato in altre unità di misura? (S/N)");
                                char risposta3 = Convert.ToChar(Console.ReadLine());
                                if (risposta3 == 'S' || risposta3 == 's')
                                {
                                    string sceltadimensione;
                                    do
                                    {
                                        int NN;
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Vuoi convertirlo in quale unità (da terametri a picometri)?");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        sceltadimensione = Console.ReadLine();
                                        controllo = int.TryParse(sceltadimensione, out NN);
                                    } while (controllo == true);


                                    Console.WriteLine("Vuoi il risultato in altre unità di misura? (S/N)");
                                    char risposta1 = Convert.ToChar(Console.ReadLine());
                                    if (risposta1 == 'S' || risposta1 == 's')
                                    {
                                        do
                                        {
                                            int NN;
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("Vuoi convertirlo in quale unità (da terametri a picometri)?");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            sceltadimensione = Console.ReadLine();
                                            controllo = int.TryParse(sceltadimensione, out NN);
                                        } while (controllo == true);
                                    }
                                }

                                    //trascrizione sul documento
                                    string AreaTriangoloIrregolareDoc = "l'area corrisponde a: " + AreaRls5 + ", il perimetro corrisponde a: " + PerimetroRls5 + Invio + Invio;
                                DateTime now8 = DateTime.Now;
                                File.AppendAllText("Database_cronologia", "Hai avviato il codice il: " + now8.ToString("dd/MM/yyyy HH:mm:ss") + Invio);
                                File.AppendAllText("Database_Cronologia", AreaTriangoloIrregolareDoc);

                                break;
                            case '3':
                                double baseMaggiore;
                                double baseMinore;
                                double altezzaTrapezio;
                                double AreaRls6;
                                double PerimetroRls6;
                                bool controllo12;
                                bool controllo13;
                                bool controllo14;

                                // Richiesta dei dati e controllo variabili

                                do
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("Inserisci la lunghezza della base maggiore del trapezio in cm:");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    controllo12 = double.TryParse(Console.ReadLine(), out baseMaggiore);
                                } while (controllo12 == false);
                                do
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("Inserisci la lunghezza della base minore del trapezio in cm:");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    controllo13 = double.TryParse(Console.ReadLine(), out baseMinore);
                                } while (controllo13 == false);
                                do
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("Inserisci la lunghezza dell'altezza del trapezio in cm:");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    controllo14 = double.TryParse(Console.ReadLine(), out altezzaTrapezio);
                                } while (controllo14 == false);

                                // Dichiarazione funzione per calcolare l'area

                                AreaRls6 = AreaTrapezio(baseMaggiore, baseMinore, altezzaTrapezio);
                                area = AreaRls6;

                                // Dichiarazione funzione per calcolare il perimetro

                                PerimetroRls6 = PerimetroTrapezio(baseMaggiore, baseMinore, baseMaggiore, baseMinore);
                                perimetro = PerimetroRls6;

                                //restituzione area e perimetro

                                Console.WriteLine($"L'area del trapezio di base maggiore {baseMaggiore} mm, base minore {baseMinore} mm e altezza {altezzaTrapezio} mm è: {AreaRls6} mm^2");
                                Console.WriteLine("");
                                Console.WriteLine($"Il perimetro del trapezio di base maggiore {baseMaggiore} mm, base minore {baseMinore} mm e altezza {altezzaTrapezio} mm è: {PerimetroRls6} mm");

                                Console.WriteLine("Vuoi il risultato in altre unità di misura? (S/N)");
                                char risposta4 = Convert.ToChar(Console.ReadLine());
                                if (risposta4 == 'S' || risposta4 == 's')
                                {
                                    string sceltadimensione;
                                    do
                                    {
                                        int NN;
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Vuoi convertirlo in quale unità (da terametri a picometri)?");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        sceltadimensione = Console.ReadLine();
                                        controllo = int.TryParse(sceltadimensione, out NN);
                                    } while (controllo == true);


                                    Console.WriteLine("Vuoi il risultato in altre unità di misura? (S/N)");
                                    char risposta12 = Convert.ToChar(Console.ReadLine());
                                    if (risposta12 == 'S' || risposta12 == 's')
                                    {
                                        do
                                        {
                                            int NN;
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("Vuoi convertirlo in quale unità (da terametri a picometri)?");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            sceltadimensione = Console.ReadLine();
                                            controllo = int.TryParse(sceltadimensione, out NN);
                                        } while (controllo == true);
                                    }
                                }

                                    //trascrizione sul documento
                                    string AreaTrapezioDoc = "l'area corrisponde a: " + AreaRls6 + ", il perimetro corrisponde a: " + PerimetroRls6 + Invio + Invio;
                                DateTime now9 = DateTime.Now;
                                File.AppendAllText("Database_cronologia", "Hai avviato il codice il: " + now9.ToString("dd/MM/yyyy HH:mm:ss") + Invio);
                                File.AppendAllText("Database_Cronologia", AreaTrapezioDoc);

                                break;
                            case '4':
                                double baseParallelogramma;
                                double altezzaParallelogramma;
                                double AreaRls7;
                                double PerimetroRls7;
                                bool controllo15;
                                bool controllo16;

                                // Richiesta dei dati e controllo variabili

                                do
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("Inserisci la lunghezza della base del parallelogramma in mm:");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    controllo15 = double.TryParse(Console.ReadLine(), out baseParallelogramma);
                                } while (controllo15 == false);
                                do
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("Inserisci la lunghezza dell'altezza del parallelogramma in mm:");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    controllo16 = double.TryParse(Console.ReadLine(), out altezzaParallelogramma);
                                } while (controllo16 == false);

                                // Dichiarazione funzione per calcolare l'area

                                AreaRls7 = AreaParallelogramma(baseParallelogramma, altezzaParallelogramma);
                                area = AreaRls7;

                                // Dichiarazione funzione per calcolare il perimetro

                                PerimetroRls7 = PerimetroParallelogramma(baseParallelogramma, altezzaParallelogramma);
                                perimetro = PerimetroRls7;

                                //restituzione area e perimetro

                                Console.WriteLine($"L'area del parallelogramma di base {baseParallelogramma} mm e altezza {altezzaParallelogramma} mm è: {AreaRls7} cm^2");
                                Console.WriteLine("");
                                Console.WriteLine($"Il perimetro del parallelogramma di base {baseParallelogramma} mm e altezza {altezzaParallelogramma} mm è: {PerimetroRls7} cm");

                                Console.WriteLine("Vuoi il risultato in altre unità di misura? (S/N)");
                                char risposta6 = Convert.ToChar(Console.ReadLine());
                                if (risposta6 == 'S' || risposta6 == 's')
                                {
                                    string sceltadimensione;
                                    do
                                    {
                                        int NN;
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Vuoi convertirlo in quale unità (da terametri a picometri)?");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        sceltadimensione = Console.ReadLine();
                                        controllo = int.TryParse(sceltadimensione, out NN);
                                    } while (controllo == true);


                                    Console.WriteLine("Vuoi il risultato in altre unità di misura? (S/N)");
                                    char risposta13 = Convert.ToChar(Console.ReadLine());
                                    if (risposta13 == 'S' || risposta13 == 's')
                                    {
                                        do
                                        {
                                            int NN;
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("Vuoi convertirlo in quale unità (da terametri a picometri)?");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            sceltadimensione = Console.ReadLine();
                                            controllo = int.TryParse(sceltadimensione, out NN);
                                        } while (controllo == true);
                                    }
                                }
                                
                                    //trascrizione sul documento
                                    string AreaParallelogrammaDoc = "l'area corrisponde a: " + AreaRls7 + ", il perimetro corrisponde a: " + PerimetroRls7 + Invio + Invio;
                                DateTime now10 = DateTime.Now;
                                File.AppendAllText("Database_cronologia", "Hai avviato il codice il: " + now10.ToString("dd/MM/yyyy HH:mm:ss") + Invio);
                                File.AppendAllText("Database_Cronologia", AreaParallelogrammaDoc);

                                break;
                            case '5':
                                Console.WriteLine("Inserisci il numero di lati del poligono irregolare:");
                                int numeroLati;
                                bool controllo19;
                                do
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    controllo19 = int.TryParse(Console.ReadLine(), out numeroLati);
                                    Console.ForegroundColor = ConsoleColor.White;
                                } while (controllo19 == false);
                                Console.WriteLine("Inserisci la lunghezza del lato del poligono irregolare:");
                                double lunghezzaLato; bool controllo18;

                                do
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    controllo18 = double.TryParse(Console.ReadLine(), out lunghezzaLato);
                                    Console.ForegroundColor = ConsoleColor.White;
                                } while (controllo18 == false);
                                double perimetro9 = PerimetroPoligonoIrregolare(numeroLati, lunghezzaLato);
                                Console.WriteLine($"L'area del poligono irregolare di {numeroLati} lati e lato di {lunghezzaLato} cm è: {perimetro9} cm");
                                break;
                        }
                    }
                    break;
                case '2':
                    string sceltaFormaIrregolare;
                    int N1;
                    bool controllo17;
                    do
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("La forma è un cerchio o elisse? (Cerchio/elisse)");
                        Console.ForegroundColor = ConsoleColor.White;
                        sceltaFormaIrregolare = Console.ReadLine();
                        controllo17 = int.TryParse(sceltaFormaIrregolare, out N1);
                    } while (controllo17 == true);

                    // Condizione per calcolare le infomrazioni del cerchio

                    if (sceltaFormaIrregolare == "Cerchio" || sceltaFormaIrregolare == "cerchio" || sceltaFormaIrregolare == "CERCHIO")
                    {
                        double raggio;
                        double AreaRls8;
                        double CirconferenzaRls8;
                        bool controllo18;

                        do
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Inserisci il raggio del cerchio in mm:");
                            Console.ForegroundColor = ConsoleColor.White;
                            controllo18 = double.TryParse(Console.ReadLine(), out raggio);
                        } while (controllo18 == false);

                        // Dichiarazione funzione per calcolare l'area

                        AreaRls8 = AreaCerchio(raggio);
                        area = AreaRls8;

                        // Dichiarazione funzione per calcolare la circonferenza

                        CirconferenzaRls8 = CirconferenzaCerchio(raggio);
                        perimetro = CirconferenzaRls8;

                        //restituzione area e circonferenza

                        Console.WriteLine($"L'area del cerchio di {raggio} mm è: {AreaRls8} mm^2");
                        Console.WriteLine("");
                        Console.WriteLine($"La circonferenza del cerchio di {raggio} è: {CirconferenzaRls8} mm");

                        Console.WriteLine("Vuoi il risultato in altre unità di misura? (S/N)");
                        char risposta2 = Convert.ToChar(Console.ReadLine());
                        if (risposta2 == 'S' || risposta2 == 's')
                        {
                            string sceltadimensione;
                            do
                            {
                                int NN;
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Vuoi convertirlo in quale unità (da terametri a picometri)?");
                                Console.ForegroundColor = ConsoleColor.White;
                                sceltadimensione = Console.ReadLine();
                                controllo = int.TryParse(sceltadimensione, out NN);
                            } while (controllo == true);


                            Console.WriteLine("Vuoi il risultato in altre unità di misura? (S/N)");
                            char risposta14 = Convert.ToChar(Console.ReadLine());
                            if (risposta14 == 'S' || risposta14 == 's')
                            {
                                do
                                {
                                    int NN;
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Vuoi convertirlo in quale unità (da terametri a picometri)?");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    sceltadimensione = Console.ReadLine();
                                    controllo = int.TryParse(sceltadimensione, out NN);
                                } while (controllo == true);
                            }
                        }

                            //trascrizione sul documento
                            string AreaTriangoloRegolareDoc = "l'area corrisponde a: " + AreaRls8 + ", il perimetro corrisponde a: " + CirconferenzaRls8 + Invio + Invio;
                        DateTime now7 = DateTime.Now;
                        File.AppendAllText("Database_cronologia", "Hai avviato il codice il: " + now7.ToString("dd/MM/yyyy HH:mm:ss") + Invio);
                        File.AppendAllText("Database_Cronologia", AreaTriangoloRegolareDoc);

                    }

                    // Condizione per calcolare le infomrazioni degli ovali

                    else if (sceltaFormaIrregolare == "Elisse" || sceltaFormaIrregolare == "elisse" || sceltaFormaIrregolare == "ELISSE")
                    {
                        double raggioMaggiore;
                        double raggioMinore;
                        double AreaRls9;
                        double CirconferenzaRls9;
                        bool controllo19;
                        bool controllo20;

                        // Richiesta dei dati e controllo variabili

                        do
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Inserisci il raggio maggiore dell'elisse in mm:");
                            Console.ForegroundColor = ConsoleColor.White;
                            controllo19 = double.TryParse(Console.ReadLine(), out raggioMaggiore);
                        } while (controllo19 == false);
                        do
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Inserisci il raggio minore dell'elisse in mm:");
                            Console.ForegroundColor = ConsoleColor.White;
                            controllo20 = double.TryParse(Console.ReadLine(), out raggioMinore);
                        } while (controllo20 == false);

                        // Dichiarazione funzione per calcolare l'area

                        AreaRls9 = AreaOvale(raggioMaggiore, raggioMinore);
                        area = AreaRls9;

                        // Dichiarazione funzione per calcolare la circonferenza

                        CirconferenzaRls9 = CirconferenzaOvale(raggioMaggiore, raggioMinore);
                        perimetro = CirconferenzaRls9;

                        //restituzione area e circonferenza

                        Console.WriteLine($"L'area dell'elisse è: {AreaRls9}");
                        Console.WriteLine("");
                        Console.WriteLine($"La circonferenza dell'elisse è: {CirconferenzaRls9}");

                        Console.WriteLine("Vuoi il risultato in altre unità di misura? (S/N)");
                        char risposta2 = Convert.ToChar(Console.ReadLine());
                        if (risposta2 == 'S' || risposta2 == 's')
                        {
                            string sceltadimensione;
                            do
                            {
                                int NN;
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Vuoi convertirlo in quale unità (da terametri a picometri)?");
                                Console.ForegroundColor = ConsoleColor.White;
                                sceltadimensione = Console.ReadLine();
                                controllo = int.TryParse(sceltadimensione, out NN);
                            } while (controllo == true);


                            Console.WriteLine("Vuoi il risultato in altre unità di misura? (S/N)");
                            char risposta16 = Convert.ToChar(Console.ReadLine());
                            if (risposta16 == 'S' || risposta16 == 's')
                            {
                                do
                                {
                                    int NN;
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Vuoi convertirlo in quale unità (da terametri a picometri)?");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    sceltadimensione = Console.ReadLine();
                                    controllo = int.TryParse(sceltadimensione, out NN);
                                } while (controllo == true);
                            }
                        }

                            //trascrizione sul documento
                            string AreaEllisseDoc = "l'area corrisponde a: " + AreaRls9 + ", il perimetro corrisponde a: " + CirconferenzaRls9 + Invio + Invio;
                        DateTime now7 = DateTime.Now;
                        File.AppendAllText("Database_cronologia", "Hai avviato il codice il: " + now7.ToString("dd/MM/yyyy HH:mm:ss") + Invio);
                        File.AppendAllText("Database_Cronologia", AreaEllisseDoc);

                    }

                    break;
                case '3':
                    char rispostadoc;
                    Console.WriteLine("1: Elenco cronologia");
                    Console.WriteLine("2: Cancella cronologia");
                    Console.ForegroundColor = ConsoleColor.White;
                    rispostadoc = Convert.ToChar(Console.ReadLine());
                    if (rispostadoc == '2')
                    {
                        Console.WriteLine("Sei sicuro di voler cancellare la cronologia? (S/N)");
                        char rispostacanc = Convert.ToChar(Console.ReadLine());
                        if (rispostacanc == 'S' || rispostacanc == 's')
                        {
                            File.Delete("Database_Cronologia");
                            Console.WriteLine("Cronologia cancellata");
                        }
                        else if (rispostacanc == 'N' || rispostacanc == 'n')
                        {
                            Console.WriteLine("Cronologia non cancellata");
                        }
                    }
                    else if (rispostadoc == '1')
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Cronologia:");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine(File.ReadAllText("Database_Cronologia"));
                    }
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Inserisci un numero che esiste nella lista!!!");
                    break;
            }
        } while (menu != '4');



        //funzione area poligono

        static double AreaPoligonoRegolare(int numeroLati, double lunghezzaLato)
        {
            double angolo = Math.PI / numeroLati;
            double cotangente = 1 / Math.Tan(angolo);
            double area = numeroLati * Math.Pow(lunghezzaLato, 2) * cotangente / 4;
            return area;
        }

        //funzione area rombo

        static double AreaRombo(double diagonaleMaggiore, double diagonaleMinore)
        {
            double area = diagonaleMaggiore * diagonaleMinore / 2;
            return area;
        }

        //funzione area triangolo

        static double AreaTriangolo(double baseTriangolo, double altezzaTriangolo)
        {
            double area = baseTriangolo * altezzaTriangolo / 2;
            return area;
        }

        //funzione area rettangolo

        static double AreaRettangolo(double baseRettangolo, double altezzaRettangolo)
        {
            double area = baseRettangolo * altezzaRettangolo;
            return area;
        }

        //funzione area trapezio

        static double AreaTrapezio(double baseMaggiore, double baseMinore, double altezzaTrapezio)
        {
            double area = (baseMaggiore + baseMinore) * altezzaTrapezio / 2;
            return area;
        }

        //funzione area parallelogramma

        static double AreaParallelogramma(double baseParallelogramma, double altezzaParallelogramma)
        {
            double area = baseParallelogramma * altezzaParallelogramma;
            return area;
        }

        //funzione area triangolo irregolare

        static double AreaTriangoloIrregolare(double ProiezioneCateti1, double ProiezioneCateti2)
        {
            double CH;
            double Area;
            CH = Math.Sqrt(ProiezioneCateti1 * ProiezioneCateti2);
            return Area = (ProiezioneCateti1 + ProiezioneCateti2) * CH / 2;

        }

        //funzione area cerchio

        static double AreaCerchio(double raggio)
        {
            return Math.PI * Math.Pow(raggio, 2);
        }

        //funzione area elisse

        static double AreaOvale(double raggioMaggiore, double raggioMinore)
        {
            return Math.PI * raggioMaggiore * raggioMinore;
        }

        //funzione perimetro regolare

        static double PerimetroPoligonoRegolare(int numeroLati, double lunghezzaLato)
        {
            double perimetro = numeroLati * lunghezzaLato;
            return perimetro;
        }

        //funzione perimetro rombo

        static double PerimetroRombo(double diagonaleMaggiore, double diagonaleMinore)
        {
            return 2 * Math.Sqrt(Math.Pow(diagonaleMaggiore, 2) + Math.Pow(diagonaleMinore, 2));
        }

        //funzione perimetro triangolo

        static double PerimetroTriangolo(double lato1, double lato2, double lato3)
        {
            return lato1 + lato2 + lato3;
        }

        //funzione perimetro rettangolo

        static double PerimetroRettangolo(double baseRettangolo, double altezzaRettangolo)
        {
            return 2 * (baseRettangolo + altezzaRettangolo);
        }

        //funzione perimetro trapezio

        static double PerimetroTrapezio(double baseMaggiore, double baseMinore, double lato1, double lato2)
        {
            return baseMaggiore + baseMinore + lato1 + lato2;
        }

        //funzione perimetro parallelogramma

        static double PerimetroParallelogramma(double baseParallelogramma, double altezzaParallelogramma)
        {
            double perimetro = 2 * (baseParallelogramma + altezzaParallelogramma);
            return perimetro;
        }

        //funzione circonferenza cerchio

        static double CirconferenzaCerchio(double raggio)
        {
            double perimetro = 2 * Math.PI * raggio;
            return perimetro;
        }

        //funzione circonferenza elisse 

        static double CirconferenzaOvale(double raggioMaggiore, double raggioMinore)
        {
            double perimetro = 2 * Math.PI * Math.Sqrt((Math.Pow(raggioMaggiore, 2) + Math.Pow(raggioMinore, 2)) / 2);
            return perimetro;
        }
        static (double area, double perimetro) ConvertiAreaEPerimetro(double area, double perimetro, string misura)
        {
            if (misura == "pm" || misura == "nm" || misura == "um" || misura == "cm" || misura == "dm" || misura == "m" || misura == "dam" || misura == "hm" || misura == "km" || misura == "Mm" || misura == "Gm" || misura == "Tm")
            {
                switch (misura)
                {
                    case "pm":
                        area *= Math.Pow(10, 18);
                        perimetro *= 1000000000;
                        break;
                    case "nm":
                        area *= Math.Pow(10, 12);
                        perimetro *= 1000000;
                        break;
                    case "um":
                        area *= Math.Pow(10, 6);
                        perimetro *= 1000;
                        break;
                    case "cm":
                        area /= 100;
                        perimetro /= 10;
                        break;
                    case "dm":
                        area /= Math.Pow(10, 2);
                        perimetro /= 10;
                        break;
                    case "m":
                        area /= Math.Pow(10, 6);
                        perimetro /= 1000;
                        break;
                    case "dam":
                        area /= Math.Pow(10, 8);
                        perimetro /= 10000;
                        break;
                    case "hm":
                        area /= Math.Pow(10, 10);
                        perimetro /= 100000;
                        break;
                    case "km":
                        area /= Math.Pow(10, 12);
                        perimetro /= 1000000;
                        break;
                    case "Mm":
                        area /= Math.Pow(10, 18);
                        perimetro /= 1000000000;
                        break;
                    case "Gm":
                        area /= Math.Pow(10, 24);
                        perimetro /= 1000000000000;
                        break;
                    case "Tm":
                        area /= Math.Pow(10, 30);
                        perimetro /= 1000000000000000;
                        break;
                }

                return (area, perimetro);
            }
            else
            {
                Console.WriteLine("Misura non valida");
                return (area, perimetro);
            }
        }

        static double PerimetroPoligonoIrregolare(int Nlati, double lunghezzeLati)
        {
            double[] lunghezzaLati = new double[Nlati];
            for (int i = 0; i < Nlati; i++)
            {
                bool controllo;
                Console.ForegroundColor = ConsoleColor.White;
                do
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Inserisci la lunghezza del lato " + (i + 1) + " del poligono");
                    Console.ForegroundColor = ConsoleColor.White;
                    controllo = double.TryParse(Console.ReadLine(), out lunghezzaLati[i]);
                } while (controllo == false);
            }

            double perimetro = 0;

            for (int i = 0; i < Nlati; i++)
            {
                perimetro += lunghezzaLati[i];
            }

            return perimetro;
        }
    }
}