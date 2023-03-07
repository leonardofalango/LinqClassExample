using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;


StreamReader sr = new StreamReader("data/bolsafamilia.csv");
sr.ReadLine();

List<BolsaFamilia> bolsas = new List<BolsaFamilia>();
while (!sr.EndOfStream)
{
    // Processamento das linhas
    string line = sr.ReadLine();
    BolsaFamilia bf = new BolsaFamilia(line);
    bolsas.Add(bf);
}
Console.WriteLine("Quant pobres totais beneficiados: " + bolsas.Sum(e => e.PobresNaRegiao));

