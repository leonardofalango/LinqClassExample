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
            var firstString = line.Substring(0, line.IndexOf("\""));
            var lastAtts = line.Substring(line.IndexOf("\""), line.Length - firstString.Length);

            string[] firstAtts = firstString.Split(",");

            Ano = int.Parse(firstAtts[0]);
            Mes = int.Parse(firstAtts[1]);
            Regiao = firstAtts[2];
            Familias = int.Parse(firstAtts[3]);

            var capital = lastAtts.Skip(2).TakeWhile(z => z != '\"').ToArray();
            double cap = double.Parse(new string(capital).Replace(",", ""));
            Capital = cap;
            string[] lastmesmo = (new string(lastAtts.Skip(1).SkipWhile(e => e != '"').ToArray()).Split(","));
            this.PobresNaRegiao = int.Parse(lastmesmo[1]);
            this.PctPobrezaExtrema = int.Parse(lastmesmo[2]);

        }
        catch
        {
            return;
        }

    }
}