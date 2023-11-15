using System;

namespace NewDelegates;

public delegate string EncryptDelegate(string plaintext);

public static class CipherSystem
{
    public static string CaesarCipher(string plaintext)
    {
        char[] characters = plaintext.ToCharArray();
        for (int i = 0; i < characters.Length; i++)
        {
            if (char.IsLetter(characters[i]))
            {
                char baseChar = char.IsLower(characters[i]) ? 'a' : 'A';
                characters[i] = (char)(baseChar + (characters[i] - baseChar + 1) % 26);
            }
        }
        return new string(characters);
    }

    public static string ReverseCipher(string plaintext)
    {
        char[] characters = plaintext.ToCharArray();
        Array.Reverse(characters);
        return new string(characters);
    }

    public static void Main(string[] args)
    {
        EncryptDelegate caesarCipher = new EncryptDelegate(CaesarCipher);
        EncryptDelegate reverseCipher = new EncryptDelegate(ReverseCipher);

        string plaintext = "Hello, World!";

        string caesarCipherText = caesarCipher(plaintext);
        string reverseCipherText = reverseCipher(plaintext);

        Console.WriteLine("Original Text: " + plaintext);
        Console.WriteLine("Caesar Cipher Text: " + caesarCipherText);
        Console.WriteLine("Reverse Cipher Text: " + reverseCipherText);
    }
}
