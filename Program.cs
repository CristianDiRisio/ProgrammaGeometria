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

            if (sceltaPoligono == "Regolare" || sceltaPoligono == "regolare" || sceltaPoligono == "REGOLARE")
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
                        double AreaRls1; 
                        double PerimetroRls1;
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

                        AreaRls1 = AreaPoligonoRegolare(numeroLati, lunghezzaLato);

                        PerimetroRls1 = PerimetroPoligonoRegolare(numeroLati, lunghezzaLato);

                        Console.WriteLine($"L'area del poligono regolare è: {AreaRls1}");

                        Console.WriteLine($"Il perimetro del poligono regolare è: {PerimetroRls1}");
                        break;
                    case '2':
                        double diagonaleMaggiore;
                        double diagonaleMinore;
                        double AreaRls2;
                        double PerimetroRls2;
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

                        AreaRls2 = AreaRombo(diagonaleMaggiore, diagonaleMinore);

                        PerimetroRls2 = PerimetroRombo(diagonaleMaggiore, diagonaleMinore);

                        Console.WriteLine($"L'area del rombo è: {AreaRls2}");

                        Console.WriteLine($"Il perimetro del rombo è: {PerimetroRls2}");
                        break;
                    case '3':
                        double baseTriangolo;
                        double altezzaTriangolo;
                        double AreaRls3;
                        double PerimetroRls3;
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

                        AreaRls3 = AreaTriangolo(baseTriangolo, altezzaTriangolo);

                        PerimetroRls3 = PerimetroTriangolo(baseTriangolo, baseTriangolo, baseTriangolo);

                        Console.WriteLine($"L'area del triangolo è: {AreaRls3}");

                        Console.WriteLine($"Il perimetro del triangolo è: {PerimetroRls3}");
                        break;
                    default:
                        Console.WriteLine("Inserisci un numero che esiste nella lista!!!");
                        break;
                }
            }
            else if (sceltaPoligono == "Irregolare" || sceltaPoligono == "irregolare" || sceltaPoligono == "IRREGOLARE")
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
                        double AreaRls4;
                        double PerimetroRls4;
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

                        AreaRls4 = AreaRettangolo(baseRettangolo, altezzaRettangolo);

                        PerimetroRls4 = PerimetroRettangolo(baseRettangolo, altezzaRettangolo);

                        Console.WriteLine($"L'area del rettangolo è: {AreaRls4}");

                        Console.WriteLine($"Il perimetro del rettangolo è: {PerimetroRls4}");
                        break;
                    case '2':
                        double proiezioneCateti1;
                        double proiezioneCateti2;
                        double AreaRls5;
                        double PerimetroRls5;
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

                        AreaRls5 = AreaTriangoloIrregolare(proiezioneCateti1, proiezioneCateti2);

                        PerimetroRls5 = PerimetroTriangolo(proiezioneCateti1, proiezioneCateti2, proiezioneCateti1 + proiezioneCateti2);

                        Console.WriteLine($"L'area del triangolo irregolare è: {AreaRls5}");

                        Console.WriteLine($"Il perimetro del triangolo irregolare è: {PerimetroRls5}");
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

                        AreaRls6 = AreaTrapezio(baseMaggiore, baseMinore, altezzaTrapezio);

                        PerimetroRls6 = PerimetroTrapezio(baseMaggiore, baseMinore, baseMaggiore, baseMinore);

                        Console.WriteLine($"L'area del trapezio è: {AreaRls6}");

                        Console.WriteLine($"Il perimetro del trapezio è: {PerimetroRls6}");
                        break;
                    case '4':
                        double baseParallelogramma;
                        double altezzaParallelogramma;
                        double AreaRls7;
                        double PerimetroRls7;
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

                        AreaRls7 = AreaParallelogramma(baseParallelogramma, altezzaParallelogramma);

                        PerimetroRls7 = PerimetroParallelogramma(baseParallelogramma, altezzaParallelogramma);

                        Console.WriteLine($"L'area del parallelogramma è: {AreaRls7}");

                        Console.WriteLine($"Il perimetro del parallelogramma è: {PerimetroRls7}");
                        break;
                    default:
                        Console.WriteLine("Inserisci un numero che esiste nella lista!!!");
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
                Console.WriteLine("La forma è un cerchio o ovale? (Cerchio/Ovale)");
                sceltaFormaIrregolare = Console.ReadLine();
                controllo17 = int.TryParse(sceltaFormaIrregolare, out N1);
            } while (controllo17 == true);

            if (sceltaFormaIrregolare == "Cerchio" || sceltaFormaIrregolare == "cerchio" || sceltaFormaIrregolare == "CERCHIO")
            {
                double raggio;
                double AreaRls8;
                double CirconferenzaRls8;
                bool controllo18;

                do
                {
                    Console.WriteLine("Inserisci il raggio del cerchio:");
                    controllo18 = double.TryParse(Console.ReadLine(), out raggio);
                } while (controllo18 == false);

                AreaRls8 = AreaCerchio(raggio);

                CirconferenzaRls8 = CirconferenzaCerchio(raggio);

                Console.WriteLine($"L'area del cerchio è: {AreaRls8}");

                Console.WriteLine($"La circonferenza del cerchio è: {CirconferenzaRls8}");
            }
            else if (sceltaFormaIrregolare == "Ovale" || sceltaFormaIrregolare == "ovale" || sceltaFormaIrregolare == "OVALE")
            {
                double raggioMaggiore;
                double raggioMinore;
                double AreaRls9;
                double CirconferenzaRls9;
                bool controllo19;
                bool controllo20;

                do
                {
                    Console.WriteLine("Inserisci il raggio maggiore dell'ovale:");
                    controllo19 = double.TryParse(Console.ReadLine(), out raggioMaggiore);
                } while (controllo19 == false);
                do
                {
                    Console.WriteLine("Inserisci il raggio minore dell'ovale:");
                    controllo20 = double.TryParse(Console.ReadLine(), out raggioMinore);
                } while (controllo20 == false);

                AreaRls9 = AreaOvale(raggioMaggiore, raggioMinore);

                CirconferenzaRls9 = CirconferenzaOvale(raggioMaggiore, raggioMinore);

                Console.WriteLine($"L'area dell'ovale è: {AreaRls9}");

                Console.WriteLine($"La circonferenza dell'ovale è: {CirconferenzaRls9}");
            }
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
    return Area = ((ProiezioneCateti1 + ProiezioneCateti2) * CH) / 2;

}
static double AreaCerchio(double raggio)
{
    return Math.PI * Math.Pow(raggio, 2);
}
static double AreaOvale(double raggioMaggiore, double raggioMinore)
{
    return Math.PI * raggioMaggiore * raggioMinore;
}
static double PerimetroPoligonoRegolare(int numeroLati, double lunghezzaLato)
{
    return numeroLati * lunghezzaLato;
}
static double PerimetroRombo(double diagonaleMaggiore, double diagonaleMinore)
{
    return 2 * Math.Sqrt(Math.Pow(diagonaleMaggiore, 2) + Math.Pow(diagonaleMinore, 2));
}
static double PerimetroTriangolo(double lato1, double lato2, double lato3)
{
    return lato1 + lato2 + lato3;
}
static double PerimetroRettangolo(double baseRettangolo, double altezzaRettangolo)
{
    return 2 * (baseRettangolo + altezzaRettangolo);
}

static double PerimetroTrapezio(double baseMaggiore, double baseMinore, double lato1, double lato2)
{
    return baseMaggiore + baseMinore + lato1 + lato2;
}

static double PerimetroParallelogramma(double baseParallelogramma, double altezzaParallelogramma)
{
    return 2 * (baseParallelogramma + altezzaParallelogramma);
}

static double CirconferenzaCerchio(double raggio)
{
    return 2 * Math.PI * raggio;
}

static double CirconferenzaOvale(double raggioMaggiore, double raggioMinore)
{
    return 2 * Math.PI * Math.Sqrt((Math.Pow(raggioMaggiore, 2) + Math.Pow(raggioMinore, 2)) / 2);
}
