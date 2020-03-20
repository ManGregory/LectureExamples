using System;
using System.Collections.Generic;
using System.Threading;

namespace MusicConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            var hertzTable = new Dictionary<string, int>()
            {
                { "C", 262 },
                { "C#", 277 },
                { "D", 294 },
                { "D#", 311 },
                { "E", 330 },
                { "F", 349 },
                { "F#", 367 },
                { "G", 392 },
                { "G#", 415 },
                { "A", 440 },
                { "A#", 466 },
                { "H", 494 }
            };
            string music = "80;4C4;4C#4;4D4;4D#4;4E4;4F4;4F#4;4G4;4G#4;4A4;4A#4;4H4;4C5;4C#5;4D5;4D#5;4E5;4F5;4F#5;4G5;4G#5;4A5;4A#5;4H5;";
            // happy birthday
            //music = "80;8G4;8G4;4A4;4G4;4C5;2H4;8G4;8G4;4A4;4G4;4D5;2C5;8G4;8G4;4G5;4E5;4C5;4H4;4A4;8F5;8F5;4E5;4C5;4D5;4C5;";
            // fur elise
            music = "80;8E5;8D#5;8E5;8D#5;8E5;8H4;8D5;8C5;4A4;8P;8C4;8E4;8A4;4H4;8P;8E4;8G#4;8H4;4C5;";

            var musicParts = music.Split(";", StringSplitOptions.RemoveEmptyEntries);
            int bpm = int.Parse(musicParts[0]);
            for (int index = 1; index < musicParts.Length; index++)
            {                
                string musicPart = musicParts[index];
                bool regularNote = musicPart.Length == 3;
                bool isPause = musicPart.Length == 2;

                int duration = int.Parse(musicPart[0].ToString());
                string notes = "";
                int octave = -1;
                if (!isPause)
                {
                    notes = regularNote ? musicPart[1].ToString() : musicPart.Substring(1, 2);
                    octave = int.Parse(regularNote ? musicPart[2].ToString() : musicPart[3].ToString());
                }

                int noteHertz = isPause ? 0 : hertzTable[notes];

                for (int counter = 0; counter < Math.Abs(4 - octave); counter++)
                {
                    if (octave > 4)
                    {
                        noteHertz *= 2;
                    }
                    else
                    {
                        noteHertz /= 2;
                    }
                }

                int quarterMilliseconds = (int)(60.0 / bpm * 1000);
                int durationMilliseconds = (int)(quarterMilliseconds / (duration / 4.0));
                if (isPause)
                {
                    Thread.Sleep(durationMilliseconds);
                }
                else
                {
                    Console.Beep(noteHertz, durationMilliseconds);
                }
            }
        }
    }
}
