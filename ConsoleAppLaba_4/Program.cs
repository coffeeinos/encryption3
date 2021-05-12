using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppLaba_4
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] arrFirst =
                {
                { 'х','я','м','р','г','ш'},
                { 'ц','д','у','ъ','й','т'},
                { 'а','ь','с','э','н','з'},
                { ' ','о','к','ф','ч','.'},
                { 'л','ё','ю','ы',',','п'},
                { 'в','щ','е','б','ж','и'}
            };
            char[,] arrSecond =
                {
                { 'ь','л','ф','с','з','д'},
                { 'я','г','а','б','в','к'},
                { 'ч','э','и','ж','у','ё'},
                { 'е',' ','о','н','ю','ъ'},
                { 'т','х',',','й','ц','щ'},
                { '.','ы','р','п','ш','м'}
            };
            for (int i = 0; i < arrFirst.GetLength(0); i++)
            {
                for (int j = 0; j < arrFirst.GetLength(1); j++)
                {
                    Console.Write($"{arrFirst[i,j]} ");
                }
                Console.WriteLine("");
            }
            Console.WriteLine("");
            Console.WriteLine("");
            for (int i = 0; i < arrSecond.GetLength(0); i++)
            {
                for (int j = 0; j < arrSecond.GetLength(1); j++)
                {
                    Console.Write($"{arrSecond[i, j]} ");
                }
                Console.WriteLine("");
            }

            Console.WriteLine("");
            Console.WriteLine("");

            Console.WriteLine("Введите предложение для шифрования");
            string messageToEncrypt = Console.ReadLine().ToLower();

            if (messageToEncrypt.Length % 2 != 0)
            {
                messageToEncrypt += " ";
            }

            string encryptedMessage = "";
            int[] indexLetter = new int[4];

            for (int i = 0, j = 0; i < messageToEncrypt.Length; i++)
            {
                if ((i + 1) % 2 == 0)
                {
                    for (; j <= i; j++)
                    {
                        if ((j + 1) % 2 == 0)
                        {
                            for (int a = 0; a < arrSecond.GetLength(0); a++)
                            {
                                for (int b = 0; b < arrSecond.GetLength(1); b++)
                                {
                                    if (messageToEncrypt[j] == arrSecond[a,b])
                                    {
                                        indexLetter[2] = a;
                                        indexLetter[3] = b;
                                    }
                                }
                            }
                        }
                        else if ((j + 1) % 2 != 0)
                        {
                            for (int a = 0; a < arrFirst.GetLength(0); a++)
                            {
                                for (int b = 0; b < arrFirst.GetLength(1); b++)
                                {
                                    if (messageToEncrypt[j] == arrFirst[a, b])
                                    {
                                        indexLetter[0] = a;
                                        indexLetter[1] = b;
                                    }
                                }
                            }
                        }
                    }
                    if (indexLetter[3] == indexLetter[1])
                    {
                        encryptedMessage += arrSecond[indexLetter[0], indexLetter[3]];
                        encryptedMessage += arrFirst[indexLetter[2], indexLetter[1]];
                    }
                    else
                    {
                        encryptedMessage += arrSecond[indexLetter[2], indexLetter[1]];
                        encryptedMessage += arrFirst[indexLetter[0], indexLetter[3]];
                    }
                }
            }
            Console.WriteLine("Сообщение для шифрования");
            for (int i = 0; i < messageToEncrypt.Length; i++)
            {
                Console.Write(messageToEncrypt[i]);
                if ((i+1)%2==0)
                {
                    Console.Write('|');
                }
            }
            Console.WriteLine("");
            Console.WriteLine("Зашифрованное сообщение");
            for (int i = 0; i < encryptedMessage.Length; i++)
            {
                Console.Write(encryptedMessage[i]);
                if ((i + 1) % 2 == 0)
                {
                    Console.Write('|');
                }
            }

            string decryptedMessage = "";

            for (int i = 0, j = 0; i < encryptedMessage.Length; i++)
            {
                if ((i + 1) % 2 == 0)
                {
                    for (; j <= i; j++)
                    {
                        if ((j + 1) % 2 != 0)
                        {
                            for (int a = 0; a < arrSecond.GetLength(0); a++)
                            {
                                for (int b = 0; b < arrSecond.GetLength(1); b++)
                                {
                                    if (encryptedMessage[j] == arrSecond[a, b])
                                    {
                                        indexLetter[2] = a;
                                        indexLetter[3] = b;
                                    }
                                }
                            }
                        }
                        else if ((j + 1) % 2 == 0)
                        {
                            for (int a = 0; a < arrFirst.GetLength(0); a++)
                            {
                                for (int b = 0; b < arrFirst.GetLength(1); b++)
                                {
                                    if (encryptedMessage[j] == arrFirst[a, b])
                                    {
                                        indexLetter[0] = a;
                                        indexLetter[1] = b;
                                    }
                                }
                            }
                        }
                    }
                    if (indexLetter[3] == indexLetter[1])
                    {
                        decryptedMessage += arrFirst[indexLetter[2], indexLetter[1]];
                        decryptedMessage += arrSecond[indexLetter[0], indexLetter[3]];
                    }
                    else
                    {
                        decryptedMessage += arrFirst[indexLetter[0], indexLetter[3]];
                        decryptedMessage += arrSecond[indexLetter[2], indexLetter[1]];
                    }
                }
            }
            Console.WriteLine("");
            Console.WriteLine("Расшифрованное сообщение");
            for (int i = 0; i < decryptedMessage.Length; i++)
            {
                Console.Write(decryptedMessage[i]);
            }
            Console.WriteLine("");
        }
    }
}
