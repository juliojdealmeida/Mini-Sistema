using System;

namespace Mini_Sistema
{
    public class RendaFixa : Investimento
    {
        public decimal TaxaAnual { get; set; }   // Ex: 10 significa 10%

        // Construtor atualizado
        public RendaFixa(string nome, decimal valorInvestido, decimal taxaAnual,
                         DateTime dataInicial, DateTime dataFinal)
            : base(nome, valorInvestido, dataInicial, dataFinal)
        {
            TaxaAnual = taxaAnual;
        }

        // Dias decorridos desde a aplicação
        public int DiasDecorridos()
        {
            return (DateTime.Now - DataInicial).Days;
        }

        // Dias restantes até o vencimento
        public int DiasParaVencimento()
        {
            return (DataFinal - DateTime.Now).Days;
        }

        // Rentabilidade percentual considerando prazo em dias
        public override decimal CalcularRendimento()
        {
            int prazoEmDias = (DataFinal - DataInicial).Days;
            decimal prazoEmAnos = prazoEmDias / 365m;

            // Juros simples: taxa anual proporcional ao prazo
            decimal rendimentoPercentual = TaxaAnual * prazoEmAnos;

            return rendimentoPercentual;
        }

        // Valor atual da posição considerando prazo
        public decimal ValorAtual()
        {
            return Valor * (1 + CalcularRendimento() / 100);
        }
    }
}
