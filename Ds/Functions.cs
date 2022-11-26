partial class Program
{
    // Losowania jednorazowe
    static string losujowner()
    {
        string ow = "";
        Random generator = new Random();
        for (int i = 0; i < 36; i++)
        {
            ow = ow + $"{Convert.ToString((generator.Next(1, 9)))}";
        }
        return ow;
    }
    static string losujtag()
    {
        Random generator = new Random();
        string tag = $"#{Convert.ToString((generator.Next(10000, 99999)))}";
        return tag;

    }
}
