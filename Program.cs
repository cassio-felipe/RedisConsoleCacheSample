using System;
using ServiceStack.Redis;

namespace RedisConsoleCacheSample
{
    class Program
    {
        private static readonly string redisHost = "localhost:6379";
        static void Main(string[] args)
        {
            var pessoa1 = new Pessoa() { Documento = "1234567890", Nome = "Luke Skywalker" };
            var pessoa2 = new Pessoa() { Documento = "9988221999", Nome = "Leia Organa" };
            var pessoa3 = new Pessoa() { Documento = "0000000000", Nome = "Obiwan Kenoby" };

            using (var redisClient = new RedisClient(redisHost))
            {
                redisClient.Set(pessoa1.Id, pessoa1, new TimeSpan(0, 1, 0));
                redisClient.Set(pessoa2.Id, pessoa2, new TimeSpan(0, 1, 0));
                redisClient.Set(pessoa3.Id, pessoa3, new TimeSpan(0, 1, 0));
                
                Console.WriteLine(redisClient.Get<Pessoa>(pessoa2.Id).Nome);
            }
        }
    }
}