namespace back.models
{
    public class Cadastro
    {
        public int id { get; set; }

        public string? name { get; set; }
        public string? email { get; set; }
        public string? senha { get; set; }
        public string? cep { get; set; }
        public string? estado { get; set; }
        public string? cidade { get; set; }
        public string? bairro { get; set; }
        public string? rua { get; set; }
        public int numero { get; set; }
    }
}