﻿using System;
using System.Collections.Generic;

public class Funcionario
{
    public string Nome { get; set; }
    public string Cargo { get; set; }
    public List<Funcionario> Subordinados { get; set; }

    public Funcionario(string nome, string cargo)
    {
        Nome = nome;
        Cargo = cargo;
        Subordinados = new List<Funcionario>();
    }
}

public class Organograma
{
    public Funcionario CEO { get; set; }

    public Organograma(Funcionario ceo)
    {
        CEO = ceo;
    }

    public void ImprimirOrganograma()
    {
        Console.WriteLine("Organograma:");

        ImprimirSubordinados(CEO, 0);
    }

    private void ImprimirSubordinados(Funcionario funcionario, int profundidade)
    {
        string espacamento = new string(' ', profundidade * 2);
        Console.WriteLine($"{espacamento}{funcionario.Cargo}: {funcionario.Nome}");

        foreach (var subordinado in funcionario.Subordinados)
        {
            ImprimirSubordinados(subordinado, profundidade + 1);
        }
    }
}

class Programa
{
    static void Main()
    {
        // Criar uma estrutura de dados em árvore para representar o organograma
        Funcionario ceo = new Funcionario("Julio", "CEO");
        Funcionario cto = new Funcionario("Jhonatan", "CTO");
        Funcionario gerenteRH = new Funcionario("Sayonara", "Gerente de RH");

        ceo.Subordinados.Add(new Funcionario("Caroline", "Assistente"));
        ceo.Subordinados.Add(cto);
        ceo.Subordinados.Add(gerenteRH);

        cto.Subordinados.Add(new Funcionario("Alberto", "Engenheiro de Software"));
        cto.Subordinados.Add(new Funcionario("Joelma", "Arquiteto de Sistemas"));

        gerenteRH.Subordinados.Add(new Funcionario("Lilian", "Especialista em RH"));

        // Criar o organograma
        Organograma org = new Organograma(ceo);

        // Imprimir o organograma
        org.ImprimirOrganograma();
    }
}