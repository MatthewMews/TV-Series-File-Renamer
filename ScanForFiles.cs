using System;
using System.IO;

namespace TVSeriesFileRenamer
{
	public class RenameFiles
	{
		public static void ScanAndRenameFiles()
		{			
			foreach (string filename in FileRenamer.currentFileNames) 
			{
				string seriesId = String.Empty;
				string episodeId = String.Empty;

				string fileFormat = Path.GetExtension (filename);

				// Series Checking


				if ((filename.Contains("S01") || filename.Contains ("s01") || filename.Contains ("Series 1"))) { // make contains compare against array?
					seriesId = "S01";
				} 
				else if ((filename.Contains ("S02") || filename.Contains ("s02") || filename.Contains ("Series 2"))) {
					seriesId = "S02";
				}
				else if ((filename.Contains ("S03") || filename.Contains ("s03") || filename.Contains ("Series 3"))) {
					seriesId = "S03";
				}
				else if ((filename.Contains ("S04") || filename.Contains ("s04") || filename.Contains ("Series 4"))) {
					seriesId = "S04";
				}
				else if ((filename.Contains ("S05") || filename.Contains ("s05") || filename.Contains ("Series 5"))) {
					seriesId = "S05";
				}
				else if ((filename.Contains ("S06") || filename.Contains ("s06") || filename.Contains ("Series 6"))) {
					seriesId = "S06";
				}
				else if ((filename.Contains ("S07") || filename.Contains ("s07") || filename.Contains ("Series 7"))) {
					seriesId = "S07";
				}
				else if ((filename.Contains ("S08") || filename.Contains ("s08") || filename.Contains ("Series 8"))) {
					seriesId = "S08";
				}
				else if ((filename.Contains ("S09") || filename.Contains ("s09") || filename.Contains ("Series 9"))) {
					seriesId = "S09";
				}
				else if ((filename.Contains ("S10") || filename.Contains ("s10") || filename.Contains ("Series 10"))) {
					seriesId = "S10";
				}
				else if ((filename.Contains ("S11") || filename.Contains ("s11") || filename.Contains ("Series 11"))) {
					seriesId = "S11";
				}
				else if ((filename.Contains ("S12") || filename.Contains ("s12") || filename.Contains ("Series 12"))) {
					seriesId = "S12";
				} else {
					Console.ForegroundColor = ConsoleColor.Magenta;
					Console.WriteLine ("Warning - The program could not detect the show's season number.\nPlease enter the season number below:");
					Console.ResetColor ();
					seriesId = "S" + Console.ReadLine ();
				}
					
				// Episode Checking

				if((filename.Contains("E01") || filename.Contains("e01") || filename.Contains("Episode 1")))
				{
					episodeId = "E01"; 
					FileRenamer.RenameFile (filename, seriesId, episodeId, fileFormat);
				}
				else if((filename.Contains("E02") || filename.Contains("e02") || filename.Contains("Episode 2")))
				{
					episodeId = "E02"; 
					FileRenamer.RenameFile (filename, seriesId, episodeId, fileFormat);
				}

				else if((filename.Contains("E03") || filename.Contains("e03") || filename.Contains("Episode 3")))
				{
					episodeId = "E03"; 
					FileRenamer.RenameFile (filename, seriesId, episodeId, fileFormat);
				}
				else if((filename.Contains("E04") || filename.Contains("e04") || filename.Contains("Episode 4")))
				{
					episodeId = "E04"; 
					FileRenamer.RenameFile (filename, seriesId, episodeId, fileFormat);
				}
				else if((filename.Contains("E05") || filename.Contains("e05") || filename.Contains("Episode 5")))
				{
					episodeId = "E05"; 
					FileRenamer.RenameFile (filename, seriesId, episodeId, fileFormat);
				}
				else if((filename.Contains("E06") || filename.Contains("e06") || filename.Contains("Episode 6")))
				{
					episodeId = "E06"; 
					FileRenamer.RenameFile (filename, seriesId, episodeId, fileFormat);
				}
				else if((filename.Contains("E07") || filename.Contains("e07") || filename.Contains("Episode 7")))
				{
					episodeId = "E07"; 
					FileRenamer.RenameFile (filename, seriesId, episodeId, fileFormat);
				}
				else if((filename.Contains("E08") || filename.Contains("e08") || filename.Contains("Episode 8")))
				{
					episodeId = "E08"; 
					FileRenamer.RenameFile (filename, seriesId, episodeId, fileFormat);
				}
				else if((filename.Contains("E09") || filename.Contains("e09") || filename.Contains("Episode 9")))
				{
					episodeId = "E09"; 
					FileRenamer.RenameFile (filename, seriesId, episodeId, fileFormat);
				}
				else if((filename.Contains("E10") || filename.Contains("e10") || filename.Contains("Episode 10")))
				{
					episodeId = "E10"; 
					FileRenamer.RenameFile (filename, seriesId, episodeId, fileFormat);
				}
				else if((filename.Contains("E11") || filename.Contains("e11") || filename.Contains("Episode 11")))
				{
					episodeId = "E11"; 
					FileRenamer.RenameFile (filename, seriesId, episodeId, fileFormat);
				}
				else if((filename.Contains("E12") || filename.Contains("e12") || filename.Contains("Episode 12")))
				{
					episodeId = "E12"; 
					FileRenamer.RenameFile (filename, seriesId, episodeId, fileFormat);
				}
				else if((filename.Contains("E13") || filename.Contains("e13") || filename.Contains("Episode 13")))
				{
					episodeId = "E13"; 
					FileRenamer.RenameFile (filename, seriesId, episodeId, fileFormat);
				}
				else if((filename.Contains("E14") || filename.Contains("e14") || filename.Contains("Episode 14")))
				{
					episodeId = "E14"; 
					FileRenamer.RenameFile (filename, seriesId, episodeId, fileFormat);
				}
				else if((filename.Contains("E15") || filename.Contains("e15") || filename.Contains("Episode 15")))
				{
					episodeId = "E15"; 
					FileRenamer.RenameFile (filename, seriesId, episodeId, fileFormat);
				}
				else if((filename.Contains("E16") || filename.Contains("e16") || filename.Contains("Episode 16")))
				{
					episodeId = "E16"; 
					FileRenamer.RenameFile (filename, seriesId, episodeId, fileFormat);
				}
				else if((filename.Contains("E17") || filename.Contains("e17") || filename.Contains("Episode 17")))
				{
					episodeId = "E17"; 
					FileRenamer.RenameFile (filename, seriesId, episodeId, fileFormat);
				}
				else if((filename.Contains("E18") || filename.Contains("e18") || filename.Contains("Episode 18")))
				{
					episodeId = "E18"; 
					FileRenamer.RenameFile (filename, seriesId, episodeId, fileFormat);
				}
				else if((filename.Contains("E19") || filename.Contains("e19") || filename.Contains("Episode 19")))
				{
					episodeId = "E19"; 
					FileRenamer.RenameFile (filename, seriesId, episodeId, fileFormat);
				}
				else if((filename.Contains("E20") || filename.Contains("e20") || filename.Contains("Episode 20")))
				{
					episodeId = "E20"; 
					FileRenamer.RenameFile (filename, seriesId, episodeId, fileFormat);
				}
				else {
					Console.ForegroundColor = ConsoleColor.Magenta;
					Console.WriteLine ("Warning - The program could not detect the show's season number.\nPlease enter the season number below:");
					Console.ResetColor ();
					episodeId = "S" + Console.ReadLine ();
					FileRenamer.RenameFile (filename, seriesId, episodeId, fileFormat);
				}
			}
		}
	}
}

