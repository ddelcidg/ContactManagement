using Konscious.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace AuthenticationService.Domain.Services
{
    public class PasswordHasher
    {
        public string HashPassword(string password)
        {
            // Genera un salt aleatorio de 16 bytes
            byte[] salt = new byte[16];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }

            var argon2 = new Argon2id(Encoding.UTF8.GetBytes(password))
            {
                Salt = salt,
                DegreeOfParallelism = 8,  // Número de threads
                Iterations = 4,
                MemorySize = 1024 * 1024  // 1 MB de memoria
            };

            byte[] hash = argon2.GetBytes(32);

            // Combina el salt y el hash en un solo array de bytes
            byte[] hashBytes = new byte[salt.Length + hash.Length];
            Array.Copy(salt, 0, hashBytes, 0, salt.Length);
            Array.Copy(hash, 0, hashBytes, salt.Length, hash.Length);

            // Convierte a Base64 para almacenar en la base de datos
            return Convert.ToBase64String(hashBytes);
        }

        public bool VerifyPassword(string storedHash, string plainPassword)
        {

            /*string hash1 = HashPassword("test1");
            string hash2 = HashPassword("test2");

            // Imprimir los hashes generados
            Console.WriteLine($"Hash for 'test1': {hash1}");
            Console.WriteLine($"Hash for 'test2': {hash2}");*/
            byte[] hashBytes = Convert.FromBase64String(storedHash);

            // Extrae el salt
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, salt.Length);

            var argon2 = new Argon2id(Encoding.UTF8.GetBytes(plainPassword))
            {
                Salt = salt,
                DegreeOfParallelism = 8,
                Iterations = 4,
                MemorySize = 1024 * 1024
            };

            byte[] hash = argon2.GetBytes(32);

            // Compara byte por byte el hash derivado con el hash almacenado
            for (int i = 0; i < 32; i++)
            {
                if (hashBytes[i + salt.Length] != hash[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
