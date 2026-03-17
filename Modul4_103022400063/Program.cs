// See https://aka.ms/new-console-template for more information

public class KodePaket
{
    public enum NamaPaket { Basic, Standard, Premium, Unlimited, Gaming, Streaming, Family, Business, Student, Traveler }

    public static string getKodePaket(NamaPaket NamaPaket)
    {
        string[] kodePaket = { "P201", "P202", "P203", "P204", "P205", "P206", "P207", "P208", "P209", "P210" };
        return kodePaket[(int)NamaPaket];
    }
}

public class main
{
    static void Main()
    {

        string[] NamaPaketNames = Enum.GetNames(typeof(KodePaket.NamaPaket));
        Console.WriteLine("Daftar Paket Beserta Kode Paket");
        for (int i = 0; i < NamaPaketNames.Length; i++)
        {
            KodePaket.NamaPaket kel = (KodePaket.NamaPaket)Enum.Parse(typeof(KodePaket.NamaPaket), NamaPaketNames[i]);

            string kodepaket = KodePaket.getKodePaket(kel);

            Console.WriteLine("Paket: {0} | Kode Paket: {1}", kel, kodepaket);
        }
    }
}

