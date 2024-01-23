using DesafioFundamentos.Models;
using System;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        decimal precoInicial = ObterValorDecimal("Digite o preço inicial:");
        decimal precoPorHora = ObterValorDecimal("Agora digite o preço por hora:");

        Estacionamento estacionamento = new Estacionamento(precoInicial, precoPorHora);

        string opcao = string.Empty;
        bool exibirMenu = true;

        while (exibirMenu)
        {
            Console.Clear();
            ExibirMenu();
            opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    string placa = ObterPlaca("Digite a placa do veículo para estacionar:");
                    estacionamento.AdicionarVeiculo(placa);
                    break;

                case "2":
                    string placaRemover = ObterPlaca("Digite a placa do veículo para remover:");
                    int horasEstacionado = ObterValorInteiro("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                    decimal valorTotal = estacionamento.RemoverVeiculo(placaRemover, horasEstacionado);
                    Console.WriteLine($"O veículo {placaRemover} foi removido e o preço total foi de: R$ {valorTotal}");
                    break;

                case "3":
                    estacionamento.ListarVeiculos();
                    break;

                case "4":
                    exibirMenu = false;
                    break;

                case "5":
                    decimal valorAcumulado = estacionamento.CalcularValorTotalAcumulado();
                    Console.WriteLine($"O valor total acumulado é: R$ {valorAcumulado}");
                    break;

                default:
                    Console.WriteLine("Opção inválida");
                    break;
            }

            Console.WriteLine("Pressione uma tecla para continuar");
            Console.ReadLine();
        }

        Console.WriteLine("O programa se encerrou");
    }

    static void ExibirMenu()
    {
        Console.WriteLine("Digite a sua opção:");
        Console.WriteLine("1 - Cadastrar veículo");
        Console.WriteLine("2 - Remover veículo");
        Console.WriteLine("3 - Listar veículos");
        Console.WriteLine("4 - Encerrar");
        Console.WriteLine("5 - Calcular valor total acumulado");
    }

    static decimal ObterValorDecimal(string mensagem)
    {
        Console.WriteLine(mensagem);
        decimal valor = Convert.ToDecimal(Console.ReadLine());
        return valor;
    }

    static int ObterValorInteiro(string mensagem)
    {
        Console.WriteLine(mensagem);
        int valor = Convert.ToInt32(Console.ReadLine());
        return valor;
    }

    static string ObterPlaca(string mensagem)
    {
        Console.WriteLine(mensagem);
        string placa = Console.ReadLine();
        return placa.ToUpper();
    }
}
