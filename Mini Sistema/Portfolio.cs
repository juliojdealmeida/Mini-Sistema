using System;
using System.Collections.Generic;

namespace Mini_Sistema
{
    public class Portfolio
    {
        // Lista de investimentos
        private List<Investimento> investimentos = new List<Investimento>();

        // Adicionar um investimento ao portfólio
        public void AdicionarInvestimento(Investimento investimento)
        {
            investimentos.Add(investimento);
        }

        // Listar todos os investimentos com prazo
        public void ListarInvestimentos()
        {
            Console.WriteLine("---- Investimentos no Portfólio ----");
            foreach (var inv in investimentos)
            {
                int prazoEmDias = (inv.DataFinal - inv.DataInicial).Days;
                decimal rendimento = inv.CalcularRendimento();

                Console.WriteLine($"{inv.Nome} - Valor: {inv.Valor:C} - Prazo: {prazoEmDias} dias - Rentabilidade esperada: {rendimento:F2}%");
            }
        }

        // Calcular o valor total projetado do portfólio
        public decimal CalcularTotal()
        {
            decimal total = 0;
            foreach (var inv in investimentos)
            {
                decimal rendimentoPercentual = inv.CalcularRendimento();
                decimal valorProjetado = inv.Valor * (1 + rendimentoPercentual / 100);

                total += valorProjetado;
            }
            return total;
        }
    }
}
