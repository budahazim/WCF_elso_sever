using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using WCF_elso_sever.Models;

public class ZeneszamController
{
    public List<Zeneszam> ZeneszamokLista()
    {
        string[] sorok = File.ReadAllLines("C:\\Users\\elect\\OneDrive\\Desktop\\WCF_elso_sever\\WCF_elso_sever\\WCF_elso_sever");
        List<Zeneszam> list = new List<Zeneszam>();
        for (int i = 1; i < sorok.Length; i++)
        {
            string[] bontas = sorok[i].Split(';');
            list.Add(new Eloado()
            {
                ZeneszamAz = int.Parse(bontas[0]),
                ZeneszamCim = bontas[1]
                ZeneszamHossz = int.Parse(bontas[2])

            });

        }
        return list;
        //  C:\Users\elect\OneDrive\Desktop\WCF_elso_sever\WCF_elso_sever\WCF_elso_sever
    }
