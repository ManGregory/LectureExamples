using System;
using System.Collections.Generic;

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
            string music = "80;4C4;4D4;4E4;4F4;4G4;4A4;4H4;4C5;4D5;4E5;4F5;4G5;4A5;4H5;";

            var musicParts = music.Split(";", StringSplitOptions.RemoveEmptyEntries);
            int bpm = int.Parse(musicParts[0]);
            for (int index = 1; index < musicParts.Length; index++)
            {                
                string musicPart = musicParts[index];
                bool oneDigitDuration = musicPart.Length == 3;
                int duration = int.Parse(oneDigitDuration ? musicPart[0].ToString() : musicPart.Substring(0, 2));
                string notes = musicPart[oneDigitDuration ? 1 : 2].ToString();
                int octave = int.Parse(oneDigitDuration ? musicPart[2].ToString() : musicPart[3].ToString());
                int noteHertz = hertzTable[notes];

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
                Console.Beep(noteHertz, (int) (quarterMilliseconds / (duration / 4.0)));
            }
        }
    }
}
