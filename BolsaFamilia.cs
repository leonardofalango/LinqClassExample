public class BolsaFamilia
{
    public int Ano { get; private set; }
    public int Mes { get; private set; }
    public string Regiao { get; private set; }
    public int Familias { get; private set; }
    public double Capital { get; private set; }
    public int PobresNaRegiao { get; private set; }
    public int PctPobrezaExtrema { get; private set; }

    public BolsaFamilia(string line)
    {

        try
        {
            string capital = new string(line
                .SkipWhile(e => e != '"')
                .Skip(1)
                .TakeWhile(e => e != '"')
                .ToArray())
                .Replace("$", "")
                .Replace(",", "");

            this.Capital = double.Parse(capital.Replace(",", ""));

            line = line.Replace(capital, "");
            line = line.Replace("\"", "").Replace("$", "");

            string[] attrs = line.Split(",", StringSplitOptions.RemoveEmptyEntries);
            this.Ano = int.Parse(attrs[0]);
            this.Mes = int.Parse(attrs[1]);
            this.Regiao = attrs[2];
            this.Familias = int.Parse(attrs[3]);
            this.PobresNaRegiao = int.Parse(attrs[4]);
            this.PctPobrezaExtrema = int.Parse(attrs[5]);
        }
        catch
        {
            return;
        }

    }
}