using System;
using System.Threading;
using System.Windows.Input;

namespace binary_watch_victor
{
    class Program
    {

		static void Main(string[] args)
        {
			// Lavet af 'Victor | Vezit' i Console App (.NET Core). Hele koden ligger under static void Main(string[] args)
			// Hele koden ligger under static void Main(string[] args)
			// H2 H1 M2 M1 S2 S1

			//     h2 h1 m2 m1 s2 s1
			//
			// 8       *     *     *
			// 4       *  *  *  *  *
			// 2   *   *  *  *  *  *
			// 1   *   *  *  *  *  *

			// Når vi indhender timer, minutter og sekunder lageres de i tre variabler, men vi skal bruge en variable for hver
			// kolonne dvs. seks variabler.
			// Givet at klokken er 13:54:42 vil fremstå på det binære ur - følg programmets kommentare med denne tid angivet:

			//     h2 h1 m2 m1 s2 s1
			//
			// 8       0     0     0
			// 4       0  1  1  1  0
			// 2   0   1  0  0  0  1
			// 1   1   1  1  0  0  0

			// Skift baggrundsfarven på konsolen
			Console.BackgroundColor = ConsoleColor.Gray;
			Console.ForegroundColor = ConsoleColor.Red;
			Console.Clear(); 

			int windownWidth = Console.WindowWidth / 2;
			int windowHeight = Console.WindowHeight / 2;


			// Kører uendligt, og looper hver x antal sekundt med hjælp fra System.Threading.Thread.Sleep(800)
			//while ( true )
			do
			{
				while (!Console.KeyAvailable)
				{


					// luk programmet hvis du trykker på escape
					//System.Console.ReadKey.

					// Gør så at curseren ikke blinker - det ser fjollet ud.
					Console.CursorVisible = false;

					int origWidth = 0;
					// Lav en variable som indenholder bredden og højden af consolen
					origWidth	= Console.WindowWidth;
					int origHeight	= Console.WindowHeight;

					//Console.SetWindowSize(870, origHeight);

					// sover i et 0.8 sekundt bare for ikke at bruge unødvendigt meget strøm.
					System.Threading.Thread.Sleep(100); // sover i 0.1 sekundt

					// Indhenter nye tider
					// HH:MM:SS f.eks. 13:54:42 // 9:44:23
					string hours	= DateTime.Now.ToString("HH");    // 13 - Tykker timer ud af datetime 
					string minutes	= DateTime.Now.ToString("mm");    // 54
					string seconds	= DateTime.Now.ToString("ss");    // 42






					// Der er seks af disse kode snippets, en for kolonne hver af dem skaber den nødvendige variable 
					//
					// Denne snippet tykker sig frem til H(H):MM:SS f.eks. 1(3):54:42 og skaber en ny variable ved navn h1_int_decimal = 3
					//
					// skaber h1 værdi 1(3):54:42
					int h1_int_decimal = (int)Char.GetNumericValue(hours[1]); // 13 -> 3
					string h1_string_binary = Convert.ToString(h1_int_decimal, 2); // Konvertere decimal til binær 1 -> 101
					while (h1_string_binary.Length < 4) // så længe at h1_string_binary er mindre fire karaktere lang gør følgende: - sørger for at h1 altid er fire lang 
					{
						// Sørger for at string er lige så lang som kolonnen
						for (int i = 0; i < (4 - h1_string_binary.Length); i++)
						{
							h1_string_binary = '0' + h1_string_binary; // tilføjer et foranstående nul
						}
					} // h1_int_decimal = 0101

					// skaber h2 værdi (1)3:54:42
					int h2_int_decimal = (int)Char.GetNumericValue(hours[0]); // 13 -> 1
					string h2_string_binary = Convert.ToString(h2_int_decimal, 2); // 1 -> 1
					while (h2_string_binary.Length < 2) //Sørger for at h2 altid er fire lang
					{
						for (int i = 0; i < (2 - h2_string_binary.Length); i++)
						{
							h2_string_binary = '0' + h2_string_binary;
						}
					} // h2_int_decimal = 0001

					// skaber m1 værdi 
					int m1_int_decimal = (int)Char.GetNumericValue(minutes[1]);     // 54 -> 4
					string m1_string_binary = Convert.ToString(m1_int_decimal, 2);  // 4  -> 100
					while (m1_string_binary.Length < 4) //Sørger for at m1 altid er fire lang
					{
						for (int i = 0; i < (4 - m1_string_binary.Length); i++)
						{
							m1_string_binary = '0' + m1_string_binary;
						}
					} // m1_string_binary = 0100

					// skaber m2 værdi
					int m2_int_decimal = (int)Char.GetNumericValue(minutes[0]);     // 54 -> 5
					string m2_string_binary = Convert.ToString(m2_int_decimal, 2);  // 5  -> 101
					while (m2_string_binary.Length < 3) //Sørger for at m2 altid er fire lang
					{
						for (int i = 0; i < (3 - m2_string_binary.Length); i++)
						{
							m2_string_binary = '0' + m2_string_binary;
						}
					} // m2_string_binary = 0101

					// skaber s1 værdi
					int s1_int_decimal = (int)Char.GetNumericValue(seconds[1]); // 42 -> 2
					string s1_string_binary = Convert.ToString(s1_int_decimal, 2); // 2 -> 10
					while (s1_string_binary.Length < 4) //Sørger for at s1 altid er fire lang
					{
						for (int i = 0; i < (4 - s1_string_binary.Length); i++)
						{
							s1_string_binary = '0' + s1_string_binary;
						}
					} // s1_string_binary = 0010

					// skaber s2 værdi
					int s2_int_decimal = (int)Char.GetNumericValue(seconds[0]); // 42 -> 4
					string s2_string_binary = Convert.ToString(s2_int_decimal, 2); // 4 -> 100
					while (s2_string_binary.Length < 3) //Sørger for at s2 altid er fire lang
					{
						for (int i = 0; i < (3 - s2_string_binary.Length); i++)
						{
							s2_string_binary = '0' + s2_string_binary;
						}
					} // s2_string_binary = 0100
					


					//Console.WriteLine("█");


					// Nedenfor er der nogle værdier som du kan arbejde med til at skabe 
					//
					// indenholder alle de kolonner som er fire lang - dvs h1, m1, s1
					for (int i = 0; 4 > i; i++)
					{
						// H2 H1 M2 M1 S2 (S1)
						Console.SetCursorPosition(windownWidth + 5 + 2 + 32, i * 2 + windowHeight);
						if (s1_string_binary[i] == '1') 
						{
							Console.ForegroundColor = ConsoleColor.Red;
							Console.WriteLine("██");
							//Console.SetCursorPosition(5 + 2, i + 1);
						} else 
						{
							Console.ForegroundColor = ConsoleColor.DarkGray;
							Console.WriteLine("██");
							//Console.SetCursorPosition(5 + 2, i + 1);
						}
						// H2 H1 M2 (M1) S2 S1
						Console.SetCursorPosition(windownWidth + 3 + 1 + 28, i * 2 + windowHeight);
						if (m1_string_binary[i] == '1') //{ Console.WriteLine("1"); } else { Console.WriteLine("*"); }
						{
							Console.ForegroundColor = ConsoleColor.Red;
							Console.WriteLine("██");
							//Console.SetCursorPosition(5 + 2, i + 1);
						}
						else
						{
							Console.ForegroundColor = ConsoleColor.DarkGray;
							Console.WriteLine("██");
							//Console.SetCursorPosition(5 + 2, i + 1);
						}
						// H2 (H1) M2 M1 S2 S1
						Console.SetCursorPosition(windownWidth + 1 + 24, i * 2 + windowHeight);
						if (h1_string_binary[i] == '1') // { Console.WriteLine("1"); } else { Console.WriteLine("*"); }
						{
							Console.ForegroundColor = ConsoleColor.Red;
							Console.WriteLine("██");
							//Console.SetCursorPosition(5 + 2, i + 1);
						}
						else
						{
							Console.ForegroundColor = ConsoleColor.DarkGray;
							Console.WriteLine("██");
							//Console.SetCursorPosition(5 + 2, i + 1);
						}
					}


					
					// indenholder alle dem som er tre lang - dvs m2, s2
					for (int i = 0; 3 > i; i++)
					{
						// H2 H1 M2 M1 (S2) S1
						Console.SetCursorPosition(windownWidth + 4 + 2 + 30, 2 + i * 2 + windowHeight);
						if (s2_string_binary[i] == '1') // { Console.WriteLine("1"); } else { Console.WriteLine("*"); }
						{
							Console.ForegroundColor = ConsoleColor.Red;
							Console.WriteLine("██");
							//Console.SetCursorPosition(5 + 2, i + 1);
						}
						else
						{
							Console.ForegroundColor = ConsoleColor.DarkGray;
							Console.WriteLine("██");
							//Console.SetCursorPosition(5 + 2, i + 1);
						}
						// H2 H1 (M2) M1 S2 S1
						Console.SetCursorPosition(windownWidth + 2 + 1 + 26, 2 + i * 2 + windowHeight);
						if (m2_string_binary[i] == '1') // { Console.WriteLine("1"); } else { Console.WriteLine("*"); }
						{
							Console.ForegroundColor = ConsoleColor.Red;
							Console.WriteLine("██");
							//Console.SetCursorPosition(5 + 2, i + 1);
						}
						else
						{
							Console.ForegroundColor = ConsoleColor.DarkGray;
							Console.WriteLine("██");
							//Console.SetCursorPosition(5 + 2, i + 1);
						}
					}
					//
					// indenholder alle dem som er 2 lang - dvs h2
					for (int i = 0; 2 > i; i++)
					{
						// (H2) H1 M2 M1 S2 S1
						Console.SetCursorPosition(windownWidth + 0 + 22, 2 + i * 2 + (windowHeight + 2));
						if (h2_string_binary[i] == '1') // { Console.WriteLine("1"); } else { Console.WriteLine("*"); }
						{
							Console.ForegroundColor = ConsoleColor.Red;
							Console.WriteLine("██");
							//Console.SetCursorPosition(5 + 2, i + 1);
						}
						else
						{
							Console.ForegroundColor = ConsoleColor.DarkGray;
							Console.WriteLine("██");
							//Console.SetCursorPosition(5 + 2, i + 1);
						}
					}
					
				}
				//Console.Clear();
				//Console.ForegroundColor = ConsoleColor.White;
			} while (Console.KeyAvailable && Console.ReadKey(true).Key != ConsoleKey.Escape);
		}
    }
}
