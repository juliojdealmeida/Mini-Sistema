using System;

namespace Mini_Sistema
{
    public class FundoInvestimento : Investimento
    {
        public int QuantidadeCotas { get; set; }
        public decimal ValorCotaCompra { get; set; }
        public decimal ValorCotaAtual { get; set; }
        public decimal TaxaAdministracao { get; set; } // apenas informativa
        public decimal RendimentoPorCota { get; set; }
        public string Periodicidade { get; set; }
        public decimal VariacaoDiaria { get; set; }

        // Construtor atualizado com datas
        public FundoInvestimento(string nome, int quantidadeCotas, decimal valorCotaCompra,
                                 decimal valorCotaAtual, decimal taxaAdministracao,
                                 decimal rendimentoPorCota, string periodicidade, decimal variacaoDiaria,
                                 DateTime dataInicial, DateTime dataFinal)
            : base(nome, quantidadeCotas * valorCotaCompra, dataInicial, dataFinal)
        {
            QuantidadeCotas = quantidadeCotas;
            ValorCotaCompra = valorCotaCompra;
            ValorCotaAtual = valorCotaAtual;
            TaxaAdministracao = taxaAdministracao;
            RendimentoPorCota = rendimentoPorCota;
            Periodicidade = periodicidade;
            VariacaoDiaria = variacaoDiaria;
        }

        public decimal ValorInvestido => QuantidadeCotas * ValorCotaCompra;
        public decimal ValorAtual => QuantidadeCotas * ValorCotaAtual;

        // Agora usa as datas herdadas
        public override decimal CalcularRendimento()
        {
            int prazoEmDias = (DataFinal - DataInicial).Days;

            decimal valorProjetado = ValorAtual * (decimal)Math.Pow((double)(1 + VariacaoDiaria), prazoEmDias);
            decimal totalComRendimentos = valorProjetado + (QuantidadeCotas * RendimentoPorCota);

            return ((totalComRendimentos - ValorInvestido) / ValorInvestido) * 100;
        }

        public decimal RendaPeriodica()
        {
            return QuantidadeCotas * RendimentoPorCota;
        }
    }
}
