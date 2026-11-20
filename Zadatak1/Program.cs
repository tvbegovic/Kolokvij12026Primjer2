(int brojParnih, int brojNeparnih) PrebrojiBrojeve(int[] brojevi)
{
    if (brojevi == null || brojevi.Length == 0)
        throw new ArgumentException("Polje mora imati bar jedan element");
    (int brojParnih, int brojNeparnih) rezultat = (0, 0);
    foreach (var broj in brojevi)
    {
        if (broj % 2 == 0)
            rezultat.brojParnih++;
        else
            rezultat.brojNeparnih++;
    }
    return rezultat;
}

bool nastavi = true;
do
{
    Console.Write("Unesite broj elemenata polja (>=1): ");
    string unos = Console.ReadLine();
    if (string.IsNullOrEmpty(unos))
        nastavi = false;
    else
    {
        try
        {
            bool ok = int.TryParse(unos, out int brojElemenata);
            if(!ok)
            {
                Console.WriteLine("Pogrešan format");
                continue;
            }
            int[] brojevi = new int[brojElemenata];
            int i = 0;
            while (i < brojElemenata)
            {
                Console.Write($"Element {i+1}: ");
                unos = Console.ReadLine();
                ok = int.TryParse(unos, out brojevi[i]);
                if(!ok)
                {
                    Console.WriteLine("Pogrešan format");
                    continue;
                }
                i++;
            }
            var rezultat = PrebrojiBrojeve(brojevi);
            Console.WriteLine($"U polju ima {rezultat.brojParnih} parnih brojeva i {rezultat.brojNeparnih} neparnih brojeva");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Dogodila se pogreška. Tekst: {ex.Message}");
        }
    }
}
while (nastavi);

