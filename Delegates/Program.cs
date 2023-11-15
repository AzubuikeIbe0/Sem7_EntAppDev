using System;

delegate string EncryptMethod(string plaintext);

class Program
{
    static void Main()
    {
        // Define the delegate instances for different encryption methods
        EncryptMethod caesarCipher = CaesarCipher;
        EncryptMethod reverseCipher = ReverseCipher;

        // Test the encryption methods
        string plaintext = "Hello, world!";
        string caesarEncrypted = Encrypt(plaintext, caesarCipher);
        string reverseEncrypted = Encrypt(plaintext, reverseCipher);

        Console.WriteLine("Plaintext: " + plaintext);
        Console.WriteLine("Caesar Encrypted: " + caesarEncrypted);
        Console.WriteLine("Reverse Encrypted: " + reverseEncrypted);
    }

    // Encrypt method that takes a plaintext and an encryption method delegate
    static string Encrypt(string plaintext, EncryptMethod encryptionMethod)
    {
        return encryptionMethod(plaintext);
    }

    // Caesar Cipher encryption method
    static string CaesarCipher(string plaintext)
    {
        char[] chars = plaintext.ToCharArray();
        for (int i = 0; i < chars.Length; i++)
        {
            if (char.IsLetter(chars[i]))
            {
                if (char.IsUpper(chars[i]))
                {
                    chars[i] = (char)(((chars[i] - 'A') + 1) % 26 + 'A');
                }
                else
                {
                    chars[i] = (char)(((chars[i] - 'a') + 1) % 26 + 'a');
                }
            }
        }
        return new string(chars);
    }

    // Reverse Cipher encryption method
    static string ReverseCipher(string plaintext)
    {
        char[] chars = plaintext.ToCharArray();
        Array.Reverse(chars);
        return new string(chars);
    }
}
