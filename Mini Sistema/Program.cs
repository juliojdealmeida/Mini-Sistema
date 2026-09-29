using System;
using System.Globalization;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("--- Portfólio de Investimentos ---");
            Console.WriteLine("1. Inserir dados do investimento");
            Console.WriteLine("2. Sair");
            Console.Write("Escolha uma opção: ");
            string opcao = Console.ReadLine();

            if (opcao == "1")
            {
                ExecutarInvestimento();
            }
            else if (opcao == "2")
            {
                break;
            }
            else
            {
                Console.WriteLine("Opção inválida. Pressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
        }
    }

    static void ExecutarInvestimento()
    {
        decimal valor = LerValor();
        DateTime dataInicial = LerData("Digite a data inicial (dd/MM/yyyy): ");
        DateTime dataFinal = LerData("Digite a data final (dd/MM/yyyy): ");

        // Exemplo de cálculo: rendimento fictício de 0,5% ao mês
        int meses = ((dataFinal.Year - dataInicial.Year) * 12) + dataFinal.Month - dataInicial.Month;
        decimal rendimento = valor * (decimal)Math.Pow(1.005, meses);

        Console.WriteLine($"\nValor investido: {valor:C}");
        Console.WriteLine($"Data inicial: {dataInicial:dd/MM/yyyy}");
        Console.WriteLine($"Data final: {dataFinal:dd/MM/yyyy}");
        Console.WriteLine($"Rendimento estimado: {rendimento:C}");

        Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
        Console.ReadKey();
    }

    static decimal LerValor()
    {
        while (true)
        {
            Console.Write("Digite o valor do investimento (ex: 1.000,00): ");
            string entrada = Console.ReadLine();

            if (decimal.TryParse(entrada, NumberStyles.Number, new CultureInfo("pt-BR"), out decimal valor))
            {
                return valor;
            }
            else
            {
                Console.WriteLine("Formato inválido. Tente novamente.");
            }
        }
    }

    static DateTime LerData(string mensagem)
    {
        while (true)
        {
            Console.Write(mensagem);
            string entrada = Console.ReadLine();

            if (DateTime.TryParseExact(entrada, "dd/MM/yyyy", new CultureInfo("pt-BR"), DateTimeStyles.None, out DateTime data))
            {
                return data;
            }
            else
            {
                Console.WriteLine("Formato inválido. Tente novamente.");
            }
        }
    }
}
