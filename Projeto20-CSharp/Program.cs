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
            inicio:
                Console.WriteLine("Selecione a operação; ");
                Console.WriteLine("1 - Visualizar lista");
                Console.WriteLine("2 - Inserir colaboradores na lista");
                Console.WriteLine("3 - Remover colaborador da lista");
                Console.WriteLine("4 - Atualizar salário do colaborador");
                Console.WriteLine("s - Sair");

                string op = Console.ReadLine();

                if(op == "1"){
                    goto verLista;
                }
                else if(op == "2"){
                    goto inserirLista;
                }
                else if (op == "3"){
                    goto removerLista;
                }
                else if (op == "4"){
                    goto atualizarLista;
                }else if (op == "s" || op== "S"){
                    goto fim;
                }
            inserirLista:
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
                    goto inicio;
                }
           
            atualizarLista:
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
                Console.WriteLine("Insira o Id do colaborador a se alterar o salário: ");
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
                goto fim;
            verLista:
                Console.WriteLine();
                Console.WriteLine("Lista atualizada de colaboradores: ");
                foreach( Colaborador obj in lista)
                {
                    Console.WriteLine(obj);
                }
                goto fim;
            fim:
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
