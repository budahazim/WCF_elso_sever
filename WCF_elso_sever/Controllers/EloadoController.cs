using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using WCF_elso_sever.Models;

namespace WCF_elso_sever.Controllers
{
    public class EloadoController
    {
        public class ZeneszamInsertResult
        {
            public string Uzenet { get; set; }
            public Zeneszam Zeneszam { get; set; }
        }
        public List<Eloado> EloadokLista()
        {
            string[] sorok = File.ReadAllLines("C:\\Users\\elect\\source\\repos\\WCF_elso_sever\\WCF_elso_sever\\eloadoadatok.txt");
            List<Eloado> list = new List<Eloado>();
            for (int i = 1; i < sorok.Length; i++)
            {
                string[] bontas = sorok[i].Split(';');
                list.Add(new Eloado()
                {
                    eloadoAz = int.Parse(bontas[0]),
                    eloadoName = bontas[1]

                });

            }
            return list;
        }
        public string InsertEloado(Eloado ujeloado)
        {
            ujeloado.eloadoAz = GenerateId();
            StreamWriter kimenet = new StreamWriter("C:\\Users\\elect\\source\\repos\\WCF_elso_sever\\WCF_elso_sever\\eloadoadatok.txt", true);

            kimenet.WriteLine(ujeloado.ToString());
            kimenet.Close();
            return "Sikeresen mentettük az előadót.";
        }
        int GenerateId()
        {
            return EloadokLista().Select(eloado => eloado.eloadoAz).ToList().Max() + 1;
        }
        public string UpdateEloado(Eloado updateEloado)
        {
            List<Eloado> quack = EloadokLista(); //beolvasok egy állományból egy listába
                                                 //a listában megkeresem a megfelelő ID-t, ha megtalálom, módosítom az adatokat
                                                 //a módosított listával újragenerálom az állományt
                                                 // ha nem találom, akkor nem változtatok az állományon, csak üzenem hogy nincs ilyen
            int index = 0;
            while (index < quack.Count && quack[index].eloadoAz != updateEloado.eloadoAz)
            {
                index++;
            }
            if (index < quack.Count)
            {
                quack[index].eloadoName = updateEloado.eloadoName;
                StreamWriter ujallomany = new StreamWriter("C:\\Users\\Tanulo\\Desktop\\WCF_elso_sever\\WCF_elso_sever\\WCF_elso_sever\\eloadoadatok.txt");
                ujallomany.WriteLine("azon;EloadoName;");
                foreach (Eloado a in quack)
                {
                    ujallomany.WriteLine(a.ToString());
                }
                ujallomany.Close();
                return "A módosítás sikeres!";
            }
            else
            {
                return "Nincs ilyen azonosítójú előadó!";
            }

        }
        public string TorolEloado(int id)
        {
            List<Eloado> quack = EloadokLista(); //beolvasok egy állományból egy listába
                                                 //a listában megkeresem a megfelelő ID-t, ha megtalálom, módosítom az adatokat
                                                 //a módosított listával újragenerálom az állományt
                                                 // ha nem találom, akkor nem változtatok az állományon, csak üzenem hogy nincs ilyen
            int index = 0;
            while (index < quack.Count && quack[index].eloadoAz != id)
            {
                index++;
            }
            if (index < quack.Count)
            {
                quack.RemoveAt(index);
                StreamWriter ujallomany = new StreamWriter("C:\\Users\\Tanulo\\Desktop\\WCF_elso_sever\\WCF_elso_sever\\WCF_elso_sever\\eloadoadatok.txt");
                ujallomany.WriteLine("azon;EloadoName;");
                foreach (Eloado a in quack)
                {
                    ujallomany.WriteLine(a.ToString());
                }
                ujallomany.Close();
                return "A módosítás sikeres!";
            }
            else
            {
                return "Nincs ilyen azonosítójú előadó!";
            }

        }
        public class ZeneszamController
        {
            public List<Zeneszam> ZeneszamokLista()
            {
                string[] sorok = File.ReadAllLines("C:\\Users\\elect\\source\\repos\\WCF_elso_sever\\WCF_elso_sever\\zeneszamadatok.txt");
                List<Zeneszam> list1 = new List<Zeneszam>();
                for (int i = 1; i < sorok.Length; i++)
                {
                    string[] bontas = sorok[i].Split(';');
                    list1.Add(new Zeneszam()
                    {
                        ZeneszamAz = int.Parse(bontas[0]),
                        ZeneszamCim = bontas[1],
                        ZeneszamHossz = int.Parse(bontas[2])

                    });

                }
                return list1;
            }

                public string InsertZeneszam(Zeneszam ujzeneszam)
                {
                    ujzeneszam.ZeneszamAz = GenerateId();
                    StreamWriter kimenet = new StreamWriter("C:\\Users\\elect\\source\\repos\\WCF_elso_sever\\WCF_elso_sever\\zeneszamadatok.txt", true);

                    kimenet.WriteLine(ujzeneszam.ToString());
                    kimenet.Close();
                    return "Sikeresen mentettük a zeneszámot.";
                }
                int GenerateId()
                {
                    return ZeneszamokLista().Select(zeneszam => zeneszam.ZeneszamAz).ToList().Max() + 1;
                }
                public string UpdateZeneszam(Zeneszam updateZeneszam)
                {
                    List<Zeneszam> zenek = ZeneszamokLista();

                    int index = 0;
                    while (index < zenek.Count && zenek[index].ZeneszamAz != updateZeneszam.ZeneszamAz)
                    {
                        index++;
                    }
                    if (index < zenek.Count)
                    {
                        zenek[index].ZeneszamCim = updateZeneszam.ZeneszamCim;
                        StreamWriter ujallomany = new StreamWriter("C:\\Users\\elect\\source\\repos\\WCF_elso_sever\\WCF_elso_sever\\zeneszamadatok.txt");
                        ujallomany.WriteLine("azon;ZeneszamCim;ZeneszamHossz;");
                        foreach (Zeneszam a in zenek)
                        {
                            ujallomany.WriteLine(a.ToString());
                        }
                        ujallomany.Close();
                        return "A módosítás sikeres!";
                    }
                    else
                    {
                        return "Nincs ilyen azonosítójú zeneszám!";
                    }

                }
              public  string TorolZeneszam(int id2)
                {
                    List<Zeneszam> zenek = ZeneszamokLista(); //beolvasok egy állományból egy listába
                                                              //a listában megkeresem a megfelelő ID-t, ha megtalálom, módosítom az adatokat
                                                              //a módosított listával újragenerálom az állományt
                                                              // ha nem találom, akkor nem változtatok az állományon, csak üzenem hogy nincs ilyen
                    int index = 0;
                    while (index < zenek.Count && zenek[index].ZeneszamAz != id2)
                    {
                        index++;
                    }
                    if (index < zenek.Count)
                    {
                        zenek.RemoveAt(index);
                        StreamWriter ujallomany = new StreamWriter("C:\\Users\\elect\\source\\repos\\WCF_elso_sever\\WCF_elso_sever\\zeneszamadatok.txt");
                        ujallomany.WriteLine("azon;ZeneszamCim;ZeneszamHossz;");
                        foreach (Zeneszam a in zenek)
                        {
                            ujallomany.WriteLine(a.ToString());
                        }
                        ujallomany.Close();
                        return "A módosítás sikeres!";
                    }
                    else
                    {
                        return "Nincs ilyen azonosítójú zeneszám!";
                    }
                }

            }

        } } 