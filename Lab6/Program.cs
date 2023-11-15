using System;

public delegate string CipherDelegate(string input);

public class CipherSystem
{
    public static string CaesarCipher(string input)
    {
        char[] charArray = input.ToCharArray();
        for (int i = 0; i < charArray.Length; i++)
        {
            if (char.IsLetter(charArray[i]))
            {
                char shift = char.IsUpper(charArray[i]) ? 'A' : 'a';
                charArray[i] = (char)(shift + (charArray[i] - shift + 1) % 26);
            }
        }

        return new string(charArray);
    }


    public static string ReverseCipher(string input)
    {
        char[] charArray = input.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }
}


public class Program
{
    public static void Main()
    {
        CipherDelegate caesarCipher = CipherSystem.CaesarCipher;
        CipherDelegate reverseCipher = CipherSystem.ReverseCipher;

        string plaintext = "Hello, World";
        string caesarCipherText = caesarCipher(plaintext);
        string reverseCipherText = reverseCipher(plaintext);

        Console.WriteLine("Plaintext: " + plaintext);
        Console.WriteLine("Caesar Cipher: " + caesarCipherText);
        Console.WriteLine("Reverse Cipher: " + reverseCipherText);
    }
}