using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculadoraFinanceira
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Calculadora Financeira";
            double valorAplicado = 0, rendimentoMensal = 0, total = 0, rendaFixa = 0, auxiliar = 0, totalRendaFixa = 0, totalRendaFixaSemImposto = 0, impostoRenda = 0, totalReal = 0;
            int mes = 0;
            string msg = "";
            Console.WriteLine("Digite o valor a ser aplicado na poupança: ");
            valorAplicado = Convert.ToDouble(Console.ReadLine());
            while (valorAplicado <= 0)
            {
                Console.Clear();
                Console.WriteLine("Valor não pode ser nulo ou negativo!");
                Console.WriteLine("Digite o valor a ser aplicado na poupança: ");
                valorAplicado = Convert.ToDouble(Console.ReadLine());
            }
            total = totalRendaFixaSemImposto = valorAplicado;
            total = totalRendaFixa = valorAplicado;
            Console.Clear();
            Console.WriteLine("Digite o rendimento mensal na poupança: ");
            rendimentoMensal = Convert.ToDouble(Console.ReadLine());
            while (rendimentoMensal <= 0)
            {
                Console.Clear();
                Console.WriteLine("O rendimento não pode ser negativo ou igual a 0!");
                Console.WriteLine("Digite o rendimento mensal na poupança: ");
                rendimentoMensal = Convert.ToDouble(Console.ReadLine());
            }
            //rendimentoMensal /= 100;
            Console.Clear();
            Console.WriteLine("Digite a quantidade de meses que o dinheiro ficará aplicado: ");
            mes = Convert.ToInt32(Console.ReadLine());
            while (mes <= 0)
            {
                Console.Clear();
                Console.WriteLine("O mês não pode ser nulo ou negativo!");
                Console.WriteLine("Digite a quantidade de meses que o dinheiro ficará aplicado: ");
                mes = Convert.ToInt32(Console.ReadLine());
            }
            if (mes <= 12)
                impostoRenda = 0.25;
            else if (mes > 12 && mes <= 24)
                impostoRenda = 0.15;
            else if (mes > 24 && mes <= 36)
                impostoRenda = 0.05;
            else
                impostoRenda = 0.01;
            Console.Clear();
            Console.WriteLine("Digite o percentual de rendimento mensal em renda fixa: ");
            rendaFixa = Convert.ToDouble(Console.ReadLine());
            while (rendaFixa <= 0)
            {
                Console.Clear();
                Console.WriteLine("A renda fixa não pode ser negativa ou igual a 0!");
                Console.WriteLine("Digite o percentual de rendimento mensal em renda fixa: ");
                rendaFixa = Convert.ToDouble(Console.ReadLine());
            }
            //rendaFixa /= 100;
            for (int i = 1; i <= mes; i++) 
            {
                auxiliar = total * rendimentoMensal;
                total += auxiliar;
            }
            for (int i = 1; i <= mes; i++)
            {
                auxiliar = totalRendaFixaSemImposto * rendaFixa;
                totalRendaFixaSemImposto += auxiliar;
                auxiliar = totalRendaFixa * rendaFixa;
                totalRendaFixa += auxiliar;
            }
            auxiliar = totalRendaFixa - valorAplicado;
            totalReal = totalRendaFixa - valorAplicado;
            totalReal *= impostoRenda;
            totalReal = auxiliar - totalReal;
            totalRendaFixa = totalReal + valorAplicado;
            if (total > totalRendaFixa)
                msg = "Poupança.";
            else if (totalRendaFixa > total)
                msg = "Renda fixa.";
            else
                msg = "Você receberá um lucro idêntico em ambos os investimentos!";
            Console.Clear();
            Console.WriteLine("No final do " + mes + "º mês você terá: " + total.ToString("C") + " caso opte pela poupança.");
            Console.WriteLine("No final do " + mes + "º mês você terá: " + totalRendaFixaSemImposto.ToString("C") + " caso opte pela renda fixa, isto sem o imposto de renda subtraído.");
            Console.WriteLine("Com a escolha da Renda fixa e da quantidade de: " + mes + " meses, você será cobrado um imposto no valor de: " + impostoRenda + " ao mês até o final do rendimento !");
            Console.WriteLine("No final do " + mes + "º mês você terá: " + totalRendaFixa.ToString("C"));
            Console.WriteLine("Recomenda-se investir na: " + msg);
            Console.ReadKey();
        }
    }
}
