using System.ComponentModel.Design;
 
char menu;
do
{
    Console.WriteLine("Scegli il tipo di figura da calcolare:");
    Console.WriteLine("1: Poligono");
    Console.WriteLine("2: Cerchio / Ovale");
    Console.WriteLine("3: Esci");   
    Console.WriteLine();

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

    switch (menu)
    {
        case '1':
            string sceltaPoligono;
            int N;
            bool controllo;
            do
            {
                Console.WriteLine("Il poligono è regolare o irregolare? (Regolare/Irregolare)");
                sceltaPoligono = Console.ReadLine();
                controllo = int.TryParse(sceltaPoligono, out N);
            } while (controllo == true);

            if (sceltaPoligono == "Regolare" || sceltaPoligono == "regolare")
            {
                char menuregolare;
                Console.WriteLine("1: Poligono regolare");
                Console.WriteLine("2: Rombo");
                Console.WriteLine("3: Triangolo");

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
                    case '1':
                        int numeroLati;
                        double lunghezzaLato;
                        double Rls1;
                        bool controllo2;
                        bool controllo3;

                        do
                        {
                            Console.WriteLine("Inserisci il numero di lati del poligono:");
                            controllo2 = int.TryParse(Console.ReadLine(), out numeroLati);
                        } while (controllo2 == false);
                        do
                        {
                            Console.WriteLine("Inserisci la lunghezza del lato del poligono:");
                            controllo3 = double.TryParse(Console.ReadLine(), out lunghezzaLato);
                        } while (controllo3 == false);

                        Rls1 = AreaPoligonoRegolare(numeroLati, lunghezzaLato);
                        Console.WriteLine($"L'area del poligono regolare è: {Rls1}");
                        break;
                    case '2':
                        double diagonaleMaggiore;
                        double diagonaleMinore;
                        double Rls2;
                        bool controllo4;
                        bool controllo5;

                        do
                        {
                            Console.WriteLine("Inserisci la lunghezza della diagonale maggiore:");
                            controllo4 = double.TryParse(Console.ReadLine(), out diagonaleMaggiore);
                        } while (controllo4 == false);
                        do
                        {
                            Console.WriteLine("Inserisci la lunghezza della diagonale minore:");
                            controllo5 = double.TryParse(Console.ReadLine(), out diagonaleMinore);
                        } while (controllo5 == false);

                        Rls2 = AreaRombo(diagonaleMaggiore, diagonaleMinore);
                        Console.WriteLine($"L'area del rombo è: {Rls2}");
                        break;
                    case '3':
                        double baseTriangolo;
                        double altezzaTriangolo;
                        double Rls3;
                        bool controllo6;
                        bool controllo7;

                        do
                        {
                            Console.WriteLine("Inserisci la lunghezza della base del triangolo:");
                            controllo6 = double.TryParse(Console.ReadLine(), out baseTriangolo);
                        } while (controllo6 == false);
                        do
                        {
                            Console.WriteLine("Inserisci la lunghezza dell'altezza del triangolo:");
                            controllo7 = double.TryParse(Console.ReadLine(), out altezzaTriangolo);
                        } while (controllo7 == false);

                        Rls3 = AreaTriangolo(baseTriangolo, altezzaTriangolo);
                        Console.WriteLine($"L'area del triangolo è: {Rls3}");
                        break;
                    default:
                        Console.WriteLine("Inserisci un numero che esiste nella lista!!!");
                        break;
                }
            }
            else if (sceltaPoligono == "Irregolare" || sceltaPoligono == "irregolare")
            {
                char menuirregolare;
                Console.WriteLine("Che tipo di poligono irregolare vuoi calcolare??");
                Console.WriteLine("1: Rettangolo");
                Console.WriteLine("2: Triangolo");
                Console.WriteLine("3: Trapezio");
                Console.WriteLine("4: Parallelogramma");

                Console.WriteLine();

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
                        double Rls4;
                        bool controllo8;
                        bool controllo9;

                        do
                        {
                            Console.WriteLine("Inserisci la lunghezza della base del rettangolo:");
                            controllo8 = double.TryParse(Console.ReadLine(), out baseRettangolo);
                        } while (controllo8 == false);
                        do
                        {
                            Console.WriteLine("Inserisci la lunghezza dell'altezza del rettangolo:");
                            controllo9 = double.TryParse(Console.ReadLine(), out altezzaRettangolo);
                        } while (controllo9 == false);

                        Rls4 = AreaRettangolo(baseRettangolo, altezzaRettangolo);
                        Console.WriteLine($"L'area del rettangolo è: {Rls4}");
                        break;
                    case '2':
                        double proiezioneCateti1;
                        double proiezioneCateti2;
                        double CH;
                        double Area;
                        double Rls5;
                        bool controllo10;
                        bool controllo11;

                        do
                        {
                            Console.WriteLine("Inserisci la lunghezza della proiezione del primo cateto:");
                            controllo10 = double.TryParse(Console.ReadLine(), out proiezioneCateti1);
                        } while (controllo10 == false);
                        do
                        {
                            Console.WriteLine("Inserisci la lunghezza della proiezione del secondo cateto:");
                            controllo11 = double.TryParse(Console.ReadLine(), out proiezioneCateti2);
                        } while (controllo11 == false);

                        Rls5 = AreaTriangoloIrregolare(proiezioneCateti1, proiezioneCateti2);
                        Console.WriteLine($"L'area del triangolo irregolare è: {Rls5}");
                        break;
                    case '3':
                        double baseMaggiore;
                        double baseMinore;
                        double altezzaTrapezio;
                        double Rls6;
                        bool controllo12;
                        bool controllo13;
                        bool controllo14;

                        do
                        {
                            Console.WriteLine("Inserisci la lunghezza della base maggiore del trapezio:");
                            controllo12 = double.TryParse(Console.ReadLine(), out baseMaggiore);
                        } while (controllo12 == false);
                        do
                        {
                            Console.WriteLine("Inserisci la lunghezza della base minore del trapezio:");
                            controllo13 = double.TryParse(Console.ReadLine(), out baseMinore);
                        } while (controllo13 == false);
                        do
                        {
                            Console.WriteLine("Inserisci la lunghezza dell'altezza del trapezio:");
                            controllo14 = double.TryParse(Console.ReadLine(), out altezzaTrapezio);
                        } while (controllo14 == false);

                        Rls6 = AreaTrapezio(baseMaggiore, baseMinore, altezzaTrapezio);
                        Console.WriteLine($"L'area del trapezio è: {Rls6}");
                        break;
                    case '4':
                        double baseParallelogramma;
                        double altezzaParallelogramma;
                        double Rls7;
                        bool controllo15;
                        bool controllo16;

                        do
                        {
                            Console.WriteLine("Inserisci la lunghezza della base del parallelogramma:");
                            controllo15 = double.TryParse(Console.ReadLine(), out baseParallelogramma);
                        } while (controllo15 == false);
                        do
                        {
                            Console.WriteLine("Inserisci la lunghezza dell'altezza del parallelogramma:");
                            controllo16 = double.TryParse(Console.ReadLine(), out altezzaParallelogramma);
                        } while (controllo16 == false);

                        Rls7 = AreaParallelogramma(baseParallelogramma, altezzaParallelogramma);
                        Console.WriteLine($"L'area del parallelogramma è: {Rls7}");
                        break;
                    default:
                        Console.WriteLine("Inserisci un numero che esiste nella lista!!!");
                        break;
                }
            }

            break;
        case '2':
            break;
        case '3':
            break;
        default:
            Console.WriteLine("Inserisci un numero che esiste nella lista!!!");
            break;
    }
} while (menu != '3');

static double AreaPoligonoRegolare(int numeroLati, double lunghezzaLato)
{
    double angolo = Math.PI / numeroLati;
    double cotangente = 1 / Math.Tan(angolo);
    double area = (numeroLati * Math.Pow(lunghezzaLato, 2) * cotangente) / 4;
    return area;
}

static double AreaRombo(double diagonaleMaggiore, double diagonaleMinore)
{
    double area = (diagonaleMaggiore * diagonaleMinore) / 2;
    return area;
}   

static double AreaTriangolo(double baseTriangolo, double altezzaTriangolo)
{
    double area = (baseTriangolo * altezzaTriangolo) / 2;
    return area;
}

static double AreaRettangolo(double baseRettangolo, double altezzaRettangolo)
{
    double area = baseRettangolo * altezzaRettangolo;
    return area;
}   

static double AreaTrapezio(double baseMaggiore, double baseMinore, double altezzaTrapezio)
{
    double area = ((baseMaggiore + baseMinore) * altezzaTrapezio) / 2;
    return area;
}
static double AreaParallelogramma(double baseParallelogramma, double altezzaParallelogramma)
{
    double area = baseParallelogramma * altezzaParallelogramma;
    return area;
}
static double AreaTriangoloIrregolare(double ProiezioneCateti1, double ProiezioneCateti2)
{
    double CH;
    double Area;
    CH = Math.Sqrt(ProiezioneCateti1 * ProiezioneCateti2);
    return Area = ((ProiezioneCateti1 + ProiezioneCateti2) * CH)/2;

}

