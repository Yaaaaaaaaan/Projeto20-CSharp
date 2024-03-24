using System;
using System.Globalization;
using System.Collections.Generic;
using Projeto20_CSharp;
using System.Reflection.Metadata.Ecma335;
using System.Security.Principal;
using System.Reflection.Metadata;
using System.Net;

namespace Projeto20
{
    internal class Program
    {
        static List<Colaborador> lista = new List<Colaborador>();
        static int pesquisaId;
        static void Main(string[] args)
        {
                Console.WriteLine("Selecione a operação; ");
                Console.WriteLine("1 - Inserir colaboradores");
                Console.WriteLine("s - Sair");

                string op = Console.ReadLine();
                if(op == "1"){
                    goto inserirLista;
                }else if (op == "s" || op== "S"){
                    goto sair;
                }

            inicio:
                Console.WriteLine("----------------------------------------------------------------------------------------");
                Console.WriteLine();
                Console.WriteLine("Selecione a operação; ");
                Console.WriteLine("1 - Visualizar colaboradores");
                Console.WriteLine("2 - Inserir colaboradores");
                Console.WriteLine("3 - Remover colaborador");
                Console.WriteLine("4 - Atualizar colaborador");
                Console.WriteLine("5 - Aumentar salário em porcentagem");
                Console.WriteLine("6 - Atualizar salário");
                Console.WriteLine("0 - Sair");
                op = Console.ReadLine();
                if (op == "1"){
                    goto verLista;
                }else if (op == "2"){
                    goto inserirLista;
                }else if (op == "3"){
                    goto removerLista;
                }else if (op == "5"){
                    goto atualizarListaPorcentagem;
                }else if (op == "6"){
                    goto atualizarLista;
                }
                else if (op == "4"){
                    goto atualizarListaColaborador;
                }
                else if (op == "s" || op == "S" || op== "0"){
                    goto fim;
                }
            inserirLista:
                Console.WriteLine();
                Console.WriteLine("Colaboradores a serem empregados; ");
                int p = int.Parse(Console.ReadLine());
               

                for (int m = 1; m<= p; m++ ){
               
                    Console.WriteLine();
                    Console.WriteLine("Colaborador #; " +m+":");
                    Console.WriteLine("Id: ");
                    int id = int.Parse(Console.ReadLine());
                    Console.WriteLine("Nome; ");
                    string nome = Console.ReadLine();
                    Console.WriteLine("Salário; ");
                    double salario = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    lista.Add(new Colaborador(id, nome, salario));

                }
                Console.WriteLine("Deseja atualizar algum salário?");
                op = Console.ReadLine();
                if(op == "S"|| op == "s")
                {
                    goto atualizarLista;
                }else if(op == "n"|| op == "N")
                {
                    goto verLista;
                }
           atualizarLista:
                Console.WriteLine();
                Console.WriteLine("----------------------------------------------------------------------------------------");
                Console.WriteLine();
                Console.WriteLine("Insira o Id do colaborador a se alterar o salário: ");
                pesquisaId = int.Parse(Console.ReadLine());

                Colaborador aL = lista.Find(a => a.Id == pesquisaId);
                if (aL != null)
                {
                    Console.WriteLine("Colaborador :" + aL.ToString() + "Confirma? (S/N)");
                    op = Console.ReadLine();
                        if (op == "S" || op == "s")
                        {
                            Console.WriteLine("Insira a operação desejada: (- para subtração, + para soma, / para divisão e * para multiplicação)");
                            op = Console.ReadLine();
                            double valor = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                            aL.AtualizaSalario(valor, op);
                        }else{
                            goto atualizarLista; 
                        }
                }
                else
                {
                    Console.WriteLine("Id Inexistente.");
                }
                goto verLista;
            atualizarListaPorcentagem:
                Console.WriteLine();
                Console.WriteLine("----------------------------------------------------------------------------------------");
                Console.WriteLine();
                Console.WriteLine("Insira o Id do colaborador a se alterar o salário: ");
                pesquisaId = int.Parse(Console.ReadLine());
                Colaborador aLP = lista.Find(a => a.Id == pesquisaId);
                if(aLP != null)
                {
                    Console.WriteLine("Colaborador :" + aLP.ToString() + "Confirma? (S/N)");
                    op = Console.ReadLine();
                    if(op == "S"||op == "s")
                    {
                        Console.WriteLine("Insira a porcentagem de aumento: ");
                        double porcentagem = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                        aLP.AumentoDeSalario(porcentagem);
                    }
                    else
                    {
                        goto atualizarListaPorcentagem;
                    }
                    
                }
                else
                {
                    Console.WriteLine("Id Inexistente.");
                }
                goto verLista;
            removerLista:
                Console.WriteLine();
                Console.WriteLine("----------------------------------------------------------------------------------------");
                Console.WriteLine();
                Console.WriteLine("Insira o Id do colaborador a ser excluído: ");
                pesquisaId = int.Parse(Console.ReadLine());
                Colaborador rem = lista.Find(a => a.Id == pesquisaId);
            if (rem != null)
            {
                Console.WriteLine("Colaborador :" + rem.ToString() + "Confirma? (S/N)");
                op = Console.ReadLine();
                if (op == "S" || op == "s")
                {
                    lista.Remove(rem);
                }else { goto removerLista; }
            }
            else
            {
                Console.WriteLine("Id Inexistente.");
            }
                goto verLista;
            atualizarListaColaborador:
                Console.WriteLine();
                Console.WriteLine("----------------------------------------------------------------------------------------");
                Console.WriteLine();
                Console.WriteLine("Insira o Id do colaborador a ser atualizado: ");
                pesquisaId = int.Parse(Console.ReadLine());
                Colaborador atu = lista.Find(a => a.Id == pesquisaId);
            if (atu != null)
            {
                Console.WriteLine("Colaborador :" + atu.ToString() + "Confirma? (S/N)");
                op = Console.ReadLine();
                if (op == "S" || op == "s")
                {
                    Console.WriteLine("Novo nome; ");
                    string nome = Console.ReadLine();
                    int id = atu.Id;
                    double salario = atu.Salario;
                    lista.Add(new Colaborador(id, nome, salario));
                    lista.Remove(atu);
                }else { goto atualizarListaColaborador; }
            }
            
            else
            {
                Console.WriteLine("Id Inexistente.");
            }
            goto verLista;
            verLista:
                Console.WriteLine();
                Console.WriteLine("----------------------------------------------------------------------------------------");
                Console.WriteLine();
                Console.WriteLine("Lista atualizada de colaboradores: ");
                foreach( Colaborador obj in lista)
                {
                    Console.WriteLine(obj);
                }
                goto fim;
            fim:
                Console.WriteLine("----------------------------------------------------------------------------------------");
                Console.WriteLine();
                Console.WriteLine("Deseja retornar ao menu? s/n ");
                op = Console.ReadLine();
                if (op == "s" || op=="S")
                {
                    goto inicio;
                }
            else {  }
            sair:;

        }
    }
}
