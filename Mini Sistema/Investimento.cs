using System;

namespace Mini_Sistema
{
    // Classe abstrata que serve de modelo para diferentes tipos de investimento
    public abstract class Investimento
    {
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataInicial { get; set; }
        public DateTime DataFinal { get; set; }

        // Construtor para inicializar nome, valor e datas
        public Investimento(string nome, decimal valor, DateTime dataInicial, DateTime dataFinal)
        {
            Nome = nome;
            Valor = valor;
            DataInicial = dataInicial;
            DataFinal = dataFinal;
        }

        // Método abstrato: cada tipo de investimento implementa sua própria lógica de rendimento
        public abstract decimal CalcularRendimento();

        // Método auxiliar para calcular prazo em dias
        public int PrazoEmDias()
        {
            return (DataFinal - DataInicial).Days;
        }

        public override string ToString()
        {
            return $"Investimento: {Nome}, Valor: {Valor:C}, Início: {DataInicial:dd/MM/yyyy}, Fim: {DataFinal:dd/MM/yyyy}";
        }
    }
}
