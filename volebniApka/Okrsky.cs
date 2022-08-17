﻿namespace volebniApka;
using volebniApka;

public class Okrsky

{
   public  IDictionary<int, Okrsek> stuff = new Dictionary<int, Okrsek>();
    public Okrsky(string fileLocation, int ObceZahra, HashSet<string> _specialOkrsky)
    {
        FileStream stream = File.Open(fileLocation, FileMode.Open);
        StreamReader reader = new StreamReader(stream);


        //Načtení dat z CSV soubor
        string line = reader.ReadLine(); //Vynechá hlavičku
        while ((line = reader.ReadLine()) != null)
        {
            string[] data = line.Split(',');
            int id = int.Parse(data[(int) DataNames.ID_OKRSKY]);
            int party = int.Parse(data[(int) DataNames.KSTRANA]);
            int votes = int.Parse(data[(int) DataNames.POC_HLASU]);
            int obec = int.Parse(data[(int) DataNames.OBEC]);
            int okrsek = int.Parse(data[(int) DataNames.OKRSEK]);

            if (!stuff.ContainsKey(id))
            {
                stuff.Add(id, new Okrsek(id, obec, okrsek, ObceZahra, _specialOkrsky));
            }

            stuff[id].votes.Add(party, votes);
        }
        stream.Close();
    }
}