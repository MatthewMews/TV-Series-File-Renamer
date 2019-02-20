using System;
using System.IO;
using TVSeriesFileRenamer;

namespace TVSeriesFileRenamer
{
	public class RenameFiles
	{
		public static void ScanAndRenameFiles(string[] currentFileNames)
		{
		    for (int i = 0; i <= currentFileNames.Length - 1; i++)
		    {
			string seriesId = String.Empty;
			string episodeId = String.Empty;
			string fileFormat = Path.GetExtension(currentFileNames[i]);

			bool seriesFound = false;
			bool episodeFound = false;

			for (int j = 1; j <= 25; j++) // Detects up to 25 series.
			{
			    if ((j < 10) && (currentFileNames[i].ToLower().Contains("s0" + j) || currentFileNames[i].ToLower().Contains("series 0" + j) || (currentFileNames[i].ToLower().Contains("season 0" + j))))
			    {
				seriesId = "S0" + j;
				seriesFound = true;
				break;
			    } else if ((j >= 10) && (currentFileNames[i].ToLower().Contains("s" + j) || currentFileNames[i].ToLower().Contains("series " + j) || (currentFileNames[i].ToLower().Contains("season " + j)))) 
			    {
				seriesId = "S" + j;
				seriesFound = true;
				break;
			    }
			}

			if(seriesFound == false) // in the event we cannot get the series number, ask the user to enter it manually.
			{
			    Console.ForegroundColor = ConsoleColor.Magenta;
			    Console.WriteLine($"\nWarning - The program could not detect the show's season number for {currentFileNames[i]}.\nPlease enter the season number below:");
			    Console.ResetColor();

			    seriesId = Console.ReadLine();

			    if (seriesId.ToUpper().ToCharArray()[0] != 'S')
			    {
				seriesId = seriesId.Insert(0, "S");
			    }
			}

			for (int k = 0; k <= 100; k++) // Detects up to 100 episodes.
			{
			    if ((k < 10) && (currentFileNames[i].ToLower().Contains("e0" + k) || currentFileNames[i].ToLower().Contains("episode 0" + k)))
			    {
				episodeId = "E0" + k;
				episodeFound = true;

				FileRenamer.RenameFile(currentFileNames[i], seriesId, episodeId, fileFormat);

				break;
			    }
			    else if ((k >= 10) && (currentFileNames[i].ToLower().Contains("e" + k) || currentFileNames[i].ToLower().Contains("episode " + k)))
			    {
				episodeId = "E" + k;
				episodeFound = true;

				FileRenamer.RenameFile(currentFileNames[i], seriesId, episodeId, fileFormat);

				break;
			    }
			}

			if (episodeFound == false) // in the event we cannot get the episode number, ask the user to enter it manually.
			{
			    Console.ForegroundColor = ConsoleColor.Magenta;
			    Console.WriteLine($"\nWarning - The program could not detect the show's episode number for {FileRenamer.currentFileNames[i]}.\nPlease enter the season number below:");
			    Console.ResetColor();

			    episodeId = Console.ReadLine();

			    if (episodeId.ToUpper().ToCharArray()[0] != 'E')
			    {
				episodeId = episodeId.Insert(0, "E");
			    }

			    FileRenamer.RenameFile(currentFileNames[i], seriesId, episodeId, fileFormat);
			}
		    }
		}
	}
}

