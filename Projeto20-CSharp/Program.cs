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
        static void Main(string[] args)
        {
                Console.WriteLine("Selecione a operação; ");
                Console.WriteLine("1 - Inserir colaboradores");
                Console.WriteLine("s - Sair");

                string op = Console.ReadLine();
                if(op == "1"){
                    goto inserirLista;
                }else if (op == "s" || op== "S"){
                    goto fim;
                }

            inicio:
                Console.WriteLine("----------------------------------------------------------------------------------------");
                Console.WriteLine();
                Console.WriteLine("Selecione a operação; ");
                Console.WriteLine("1 - Visualizar colaboradores");
                Console.WriteLine("2 - Inserir colaboradores");
                Console.WriteLine("3 - Remover colaborador");
                Console.WriteLine("4 - Aumentar salário em porcentagem");
                Console.WriteLine("5 - Atualizar salário");
                Console.WriteLine("s - Sair");
                op = Console.ReadLine();
                if (op == "1"){
                    goto verLista;
                }else if (op == "2"){
                    goto inserirLista;
                }else if (op == "3"){
                    goto removerLista;
                }else if (op == "4"){
                    goto atualizarLista;
                }else if (op == "s" || op == "S"){
                    goto fim;
                }
            inserirLista:
                Console.WriteLine();
                Console.WriteLine("Colaboradores a serem empregados; ");
                int p = int.Parse(Console.ReadLine());
               

                for (int m = 1; m<= p; m++ ){
               
                    Console.WriteLine();
                    Console.WriteLine("Colaborador #; " +1+":");
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
                int pesquisaId = int.Parse(Console.ReadLine());

                Colaborador col = lista.Find(a => a.Id == pesquisaId);
                if(col != null)
                {
                    Console.WriteLine("Insira a porcentagem de aumento: ");
                    double porcentagem = double.Parse(Console.ReadLine() , CultureInfo.InvariantCulture);
                    col.AumentoDeSalario(porcentagem);
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
                    lista.Remove(rem);
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
                
        }
    }
}
