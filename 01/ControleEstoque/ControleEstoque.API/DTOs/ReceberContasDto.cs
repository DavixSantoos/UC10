namespace ControleEstoque.API.DTOs
{
    public class ReceberContasDto
    {
        public class ReceberContas
        {
            public int  Id { get; set; }
            public string Status { get; set; } 

            public decimal Valor { get; set; }
            public DateTime DataPagamento { get; set; }
        }
        public class AtualizarContas
        {
            public int Id { get; set; }
            public string Status { get; set; }

            public decimal Valor { get; set; }
            public DateTime DataPagamento { get; set; }


        }
       
    }
}
