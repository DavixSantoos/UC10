namespace Estudo
{

    #region classes
    public class Endereco
    {
        public int Id { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
    }

    public class Cliente
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public Endereco? Endereco { get; set; }
    }

    public class Conta 
    { 
        public int Id { get; set; }
        public string? Numero { get; set; }
        public decimal Saldo { get; set; }
        public Cliente? Cliente { get; set; }
    }
#endregion
    class Program
    {

        static void Main(string[] args)
        {
            var contas = new List<Conta>
          {
            new Conta { Id = 1, Numero = "1001", Saldo = 1500.50m, Cliente = new Cliente { Id = 1, Nome = "Ana", Endereco = new Endereco { Id = 1, Cidade = "São Paulo", Estado = "SP" } } },
            new Conta { Id = 2, Numero = "1002", Saldo = 250.00m, Cliente = new Cliente { Id = 2, Nome = "Bruno", Endereco = new Endereco { Id = 2, Cidade = "Campinas", Estado = "SP" } } },
            new Conta { Id = 3, Numero = "1003", Saldo = 8900.00m, Cliente = new Cliente { Id = 3, Nome = "Carlos", Endereco = new Endereco { Id = 3, Cidade = "Curitiba", Estado = "PR" } } }

           };
            // # A. Encontrando um objeto específico:
            //# B. Filtrando  e Mapeando


            //usando um foreach, busque apenas os 'nomes' dos clientes que moram em 'São Paulo' e exiba-os no console.
            #region
            var Nomes = new List<string>();

            foreach (var c in contas)
            {
                
                if (c.Cliente.Endereco.Estado == "SP")
                {
                    Nomes.Add(c.Cliente.Nome);
                    Console.WriteLine(c.Cliente.Nome);
                }
            }
            var nomeSp = contas.Where(c => c.Cliente.Endereco.Estado == "SP") .Select(c => c.Cliente.Nome).ToList();
#endregion


            decimal saldoTotal = 0;
            foreach (var c in contas) 
            { 
                saldoTotal += c.Saldo;
            }
            Console.WriteLine(saldoTotal);

            //usando linq
            saldoTotal = contas.Sum(c => c.Saldo);
            Console.WriteLine(saldoTotal);
            #region Encontrando um objeto específico
            Conta? contaEncontrada = null;

            foreach (var c in contas)
            {
                //Console.WriteLine($"ID: {c.Id}, Numero: {c.Numero}, Nome {c.Cliente.Nome}, Cidade: {c.Cliente.Endereco.Cidade}");

                if (c.Numero == "1002")
                {
                    contaEncontrada = c;
                    break; // Encerra o loop 
                }
            }
                contaEncontrada = contas.FirstOrDefault(c => c.Numero == "1002");
            #endregion
        }
    }
   }
