using System;

namespace Mini_Sistema
{
    public class Acao : Investimento
    {
        public int Quantidade { get; set; }
        public decimal PrecoMedioCompra { get; set; }
        public decimal PrecoMercado { get; set; }
        public decimal DividendosRecebidos { get; set; }
        public decimal DividendoPorAcao { get; set; }
        public string Periodicidade { get; set; }
        public decimal VariacaoDiaria { get; set; }

        // Construtor atualizado
        public Acao(string nome, int quantidade, decimal precoMedioCompra, decimal precoMercado,
                    decimal dividendosRecebidos, decimal dividendoPorAcao, string periodicidade, decimal variacaoDiaria,
                    DateTime dataInicial, DateTime dataFinal)
            : base(nome, quantidade * precoMedioCompra, dataInicial, dataFinal) // agora passa datas também
        {
            Quantidade = quantidade;
            PrecoMedioCompra = precoMedioCompra;
            PrecoMercado = precoMercado;
            DividendosRecebidos = dividendosRecebidos;
            DividendoPorAcao = dividendoPorAcao;
            Periodicidade = periodicidade;
            VariacaoDiaria = variacaoDiaria;
        }

        public decimal ValorInvestido => Quantidade * PrecoMedioCompra;
        public decimal ValorAtual => Quantidade * PrecoMercado;

        // Agora usa as datas herdadas para calcular prazo
        public override decimal CalcularRendimento()
        {
            int prazoEmDias = (DataFinal - DataInicial).Days;

            decimal valorProjetado = ValorAtual * (decimal)Math.Pow((double)(1 + VariacaoDiaria), prazoEmDias);
            decimal totalComDividendos = valorProjetado + DividendosRecebidos;

            return ((totalComDividendos - ValorInvestido) / ValorInvestido) * 100;
        }

        public decimal RendaPeriodica()
        {
            return Quantidade * DividendoPorAcao;
        }
    }
}
