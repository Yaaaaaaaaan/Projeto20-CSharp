﻿using System.Globalization;


namespace Projeto20_CSharp
{
    internal class Colaborador{
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Salario { get; private set; }

        public Colaborador(int id, string nome, double salario)
        {
            Id = id;
            Nome = nome;
            Salario = salario;
        }

        public void AumentoDeSalario(double porcentagem)
        {
            Salario += Salario * porcentagem / 100.0;
        }

        public void AtualizaSalario(double valor, string op)
        {
            if(op== "+")
            {
                Salario = Salario + valor;
            }
            else if (op == "-")
            {
                Salario = Salario - valor;
            }
            else if (op == "*")
            {
                Salario = Salario * valor;
            }
            if (op == "/")
            {
                Salario = Salario / valor;
            }

        }

        public override string ToString()
        {
            return Id
                + ", "
                + Nome
                + ", "
                + Salario.ToString("F2", CultureInfo.InvariantCulture);
        }
    }
}
