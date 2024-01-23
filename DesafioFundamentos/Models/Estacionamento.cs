using System;
using System.Collections.Generic;
using System.Linq;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal PrecoInicial { get; set; }
        private decimal PrecoPorHora { get; set; }
        private List<string> Veiculos { get; set; }

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            PrecoInicial = precoInicial;
            PrecoPorHora = precoPorHora;
            Veiculos = new List<string>();
        }

        public void AdicionarVeiculo(string placa)
        {
            try
            {
                if (!string.IsNullOrEmpty(placa))
                {
                    Veiculos.Add(placa.ToUpper());
                    Console.WriteLine($"Veículo com placa {placa} estacionado com sucesso!");
                }
                else
                {
                    throw new ArgumentException("Placa inválida. Tente novamente.");
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public decimal RemoverVeiculo(string placa, int horas)
        {
            if (Veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Veiculos.Remove(placa.ToUpper());
                return PrecoInicial + (PrecoPorHora * horas);
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
                return 0;
            }
        }

        public void ListarVeiculos()
        {
            if (Veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach (var veiculo in Veiculos)
                {
                    Console.WriteLine(veiculo);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }

        public decimal CalcularValorTotalAcumulado()
        {
            return Veiculos.Count > 0 ? Veiculos.Count * PrecoInicial : 0;
        }
    }
}
