using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Encryptor_app
{
    class Encryptor
    {
        public string Path { get; set; } //file path
        public string Text { get; set; } //text in file
        public ulong Key { get; set; } //key for encryption

        public List<char> charrOriginText = new List<char>(); //origin text by chars
        public List<char> charrEncrypText = new List<char>(); //encryp text by chars

        public void Text_Encryption()
        {
            // Read text by symbols
            StreamReader sr = new StreamReader(Path, Encoding.UTF8);
                while (sr.Peek() >= 0)
                {
                    charrOriginText.Add((char)sr.Read());
                }
                sr.Close();

            //Make encryption
            for (int i = 0; i < charrOriginText.Count; i++)
            {
                charrEncrypText.Add((char)(charrOriginText[i] ^ Key));
            }

            //Write encrypted text to our file
            StreamWriter sw = new StreamWriter(Path);
                for (int i = 0; i < charrEncrypText.Count; i++)
                {
                    sw.Write(charrEncrypText[i]);
                }
                sw.Close();

            charrEncrypText.Clear();
            charrOriginText.Clear();
        }
    }
}
