using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Linq;

// ToDo:

// 1. Move ScanAndRenameFiles into a seperate class.
// 2. Code Reduction - I should be able to reduce large amounts of code during restructuring. May need to introduce some for loops to do this.

namespace Namespace
{
	public class Main_Class
	{
		public static string directoryOfFiles = @"/home/matthew/Desktop/Black Mirror/";
		public static string fileFormat = ".mkv";

		public static string[] currentFileNames = Directory.GetFiles(directoryOfFiles);

		public static void Main(string[] args)
		{
			string seriesNumber = String.Empty;
			string episodeNumber = String.Empty;

			CheckDirectoryAndFilesExists ();

			ScanAndRenameFiles (seriesNumber, episodeNumber);

			Console.ReadKey ();
		}

		private static void CheckDirectoryAndFilesExists()
		{
			int numOfVideosFound = 0;

			if (Directory.Exists (directoryOfFiles)) {
				Console.WriteLine ("Directory Found!\n");
			} else {
				Console.WriteLine ("Directory not found.");
				Environment.Exit (1);
			}

			Console.WriteLine ("Checking that files exist...\n");

			foreach(string video in currentFileNames)
			{
				numOfVideosFound++;

				if(numOfVideosFound >= 1)
				{
					Console.WriteLine ("Video(s) found!\n");
					break;
				} else {
					Console.WriteLine ("No Video(s) were found!\n");
					Environment.Exit (2);
				}
			}
		}


		public static void ScanAndRenameFiles (string seriesNumber, string episodeNumber)
		{			
			foreach (string filename in currentFileNames) {

				string seriesId = String.Empty;
				string episodeId = String.Empty;


				if ((filename.Contains ("S01") || filename.Contains("s01") || filename.Contains ("Series 1"))) // make contains compare against array?
				{
					seriesId = "S01"; 

					if((filename.Contains("E01") || filename.Contains("e01") || filename.Contains("Episode 1")))
					{
						episodeId = "E01"; 
						RenameFile (filename, seriesId, episodeId);
					}

					if((filename.Contains("E07") || filename.Contains("e02") || filename.Contains("Episode 2")))
					{
						episodeId = "E07"; 
						RenameFile (filename, seriesId, episodeId);
					}
					if((filename.Contains("E07") || filename.Contains("e03") || filename.Contains("Episode 3")))
					{
						episodeId = "E07"; 
						RenameFile (filename, seriesId, episodeId);
					}
				}


				if ((filename.Contains ("S07") || filename.Contains ("Series 7"))) // make contains compare against array?
				{
					seriesId = "S07"; 

					if((filename.Contains("E01") || filename.Contains("e01") || filename.Contains("Episode 1")))
					{
						episodeId = "E01"; 
						RenameFile (filename, seriesId, episodeId);
					}
					if((filename.Contains("E02") || filename.Contains("e02") || filename.Contains("Episode 2")))
					{
						episodeId = "E02"; 
						RenameFile (filename, seriesId, episodeId);
					}

					if((filename.Contains("E03") || filename.Contains("e03") || filename.Contains("Episode 3")))
					{
						episodeId = "E03"; 
						RenameFile (filename, seriesId, episodeId);
					}
					if((filename.Contains("E04") || filename.Contains("e04") || filename.Contains("Episode 4")))
					{
						episodeId = "E04"; 
						RenameFile (filename, seriesId, episodeId);
					}
					if((filename.Contains("E05") || filename.Contains("e05") || filename.Contains("Episode 5")))
					{
						episodeId = "E05"; 
						RenameFile (filename, seriesId, episodeId);
					}

					if((filename.Contains("E06") || filename.Contains("e06") || filename.Contains("Episode 6")))
					{
						episodeId = "E06"; 
						RenameFile (filename, seriesId, episodeId);
					}
					if((filename.Contains("E07") || filename.Contains("e07") || filename.Contains("Episode 7")))
					{
						episodeId = "E07"; 
						RenameFile (filename, seriesId, episodeId);
					}
					if((filename.Contains("E08") || filename.Contains("e08") || filename.Contains("Episode 8")))
					{
						episodeId = "E08"; 
						RenameFile (filename, seriesId, episodeId);
					}
					if((filename.Contains("E09") || filename.Contains("e09") || filename.Contains("Episode 9")))
					{
						episodeId = "E09"; 
						RenameFile (filename, seriesId, episodeId);
					}
					if((filename.Contains("E10") || filename.Contains("e10") || filename.Contains("Episode 10")))
					{
						episodeId = "E10"; 
						RenameFile (filename, seriesId, episodeId);
					}
					if((filename.Contains("E11") || filename.Contains("e11") || filename.Contains("Episode 11")))
					{
						episodeId = "E11"; 
						RenameFile (filename, seriesId, episodeId);
					}
					if((filename.Contains("E12") || filename.Contains("e12") || filename.Contains("Episode 12")))
					{
						episodeId = "E02"; 
						RenameFile (filename, seriesId, episodeId);
					}
				}
			}
		}

		public static void RenameFile(string filename, string seriesId, string episodeId)
		{
			int numOfRenamedFiles = 0;

			foreach(string file in currentFileNames)
			{
				string tempFile = Path.GetFileName(file); // get just the filename, not including path.

				if(tempFile.StartsWith("S0") || tempFile.StartsWith("S1") || tempFile.StartsWith("S7"))
				{
					numOfRenamedFiles++;
				} 
				else {
					break;
				}

				if (numOfRenamedFiles == currentFileNames.Length) {

					Console.WriteLine ("Renaming Complete.");
					Environment.Exit (3);
				}
			}

			string episodeName = String.Empty;
			Console.WriteLine ($"What is the name of {seriesId} {episodeId}.");
			episodeName = Console.ReadLine ();


			File.Move (filename, directoryOfFiles + seriesId + " " + episodeId + " - " + episodeName + fileFormat);

			if(File.Exists(directoryOfFiles + seriesId + " " + episodeId + " - " + episodeName + fileFormat))
			{
				Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine ("File has been renamed succesfully!\n");
			} else {
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine ("Error attempting to rename file.\n");
			}

			Console.ResetColor ();
		}
	}
}