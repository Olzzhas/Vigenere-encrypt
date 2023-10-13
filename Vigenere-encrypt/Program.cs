using System;

namespace Vigenere_encrypt
{
    class Program
    {
        static void Main(string[] args)
        {
            string plaintext = "asdIJASDij -d ! sdla,d .";
            string key = "cat";

            
            string decryptedText = VigenereEncrypt(plaintext, key);

            Console.WriteLine(decryptedText);

        }

        static string VigenereEncrypts(string plaintext, string key)
        {
            char[] decryptedText = plaintext.ToCharArray();
            int index = 0;
            int k = 0;

            foreach (char c in plaintext)
            {
                int difference;
                if (c > 64 && c < 91)
                {
                    difference = c + (key[k] - 65);
                }
                else
                {
                    difference = key[k] - c;
                    if (difference < 0)
                    {
                        difference *= -1;
                    }
                }


                if ((char.IsLower(c) && (difference - 97 > 26)) || (!char.IsLower(c) && (difference - 65 > 26)))
                {
                    difference -= 26;
                }

                decryptedText[index] = (char)(c + difference);

                index++;
                k++;
                if (k == key.Length)
                {
                    k = 0;
                }
            }
            string result = new string(decryptedText);
            return result;
        }

        static string VigenereEncrypt(string plaintext, string key)
        {
            char[] decryptedText = plaintext.ToCharArray();
            int index = 0;
            int k = 0;

            foreach(char c in plaintext)
            {
                char newValue;

                if ((char.IsLower(c) && (c + (key[k] - 97) > 122)))
                {
                    newValue = (char)(c + key[k] - 97 - 26);
                }
                else if ((!char.IsLower(c) && (c + (key[k] - 97) > 90)))
                {
                    newValue = (char)(c + key[k] - 65 - 26);
                }
                else if((c >= 32 && c<= 47) || (c >=58 && c<= 64))
                {
                    newValue = c;
                    k -= 1;
                }
                else
                {
                    newValue = (char)(c + key[k] - 97);
                }

                

                decryptedText[index] = newValue;

                index++;
                k++;
                if(k > key.Length-1)
                {
                    k = 0;
                }
                
            }

            string result = new string(decryptedText);

            
            return result;
        }
    }
}
