using System.Linq.Expressions;

namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {

            if (Suite == null)
            {
                throw new InvalidOperationException("Nenhuma suíte foi cadastrada antes de adicionar hóspedes.");
            }

            if (Suite.Capacidade >= hospedes.Count)
            {
                Hospedes = hospedes;
            }
            else
            {
                throw new InvalidOperationException($"A suíte não comporta {hospedes.Count} hóspedes. Capacidade máxima: {Suite.Capacidade}.");
            }

        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            return Hospedes.Count;
        }

        public decimal CalcularValorDiaria()
        {
            decimal valor = DiasReservados * Suite.ValorDiaria;
            if (DiasReservados >= 10)
            {
                valor = valor - (valor * 0.10m);
                //valor *= 0.90m;
            }

            return valor;
        }
    }
}