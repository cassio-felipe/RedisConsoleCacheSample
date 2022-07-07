using System;

namespace RedisConsoleCacheSample
{
    public class Pessoa
    {
        public string Id { get; private set; }
        public string Nome { get; set; }
        public string Documento { get; set; }
        
        public Pessoa()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}