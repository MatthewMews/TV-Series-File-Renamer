using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Linq;

namespace TVSeriesFileRenamer
{
	public class FileRenamer
	{
		public static string directoryOfFiles = @"/home/matthew/Desktop/Black Mirror/";
		public static string[] currentFileNames = Directory.GetFiles(directoryOfFiles);

		public static void Main(string[] args)
		{

			CheckDirectoryAndFilesExists ();

			RenameFiles.ScanAndRenameFiles ();

			Console.WriteLine ("File renaming complete.");

			Console.ReadKey ();
		}

		private static void CheckDirectoryAndFilesExists()
		{

			if (Directory.Exists (directoryOfFiles)) {
				Console.WriteLine ("Video Directory Found!\n");
			} else {
				Console.WriteLine ("Video Directory not found.\n");
				Environment.Exit (1);
			}

			Console.WriteLine ("Finding video(s)...\n");

			string[] vids = Directory.GetFiles (directoryOfFiles);

			if(vids.Length > 0)
			{
				Console.WriteLine ("Video(s) found!\n");
			} else {
				Console.WriteLine ("No video(s) found.\n");
				Environment.Exit (2);
			}
		}

		public static void RenameFile(string filename, string seriesId, string episodeId, string fileFormat)
		{
			int numOfRenamedFiles = 0;

			foreach(string file in currentFileNames) // Checks to see if any more files need renaming.
			{
				string tempFile = Path.GetFileName(file);

				if(tempFile.StartsWith("S0") || tempFile.StartsWith("S1") || tempFile.StartsWith("S7"))
				{
					numOfRenamedFiles++;
				} 

				if (numOfRenamedFiles == currentFileNames.Length) {

					return; // return to main function, job is done!
				}
			}

			GetEpisodeName (filename, seriesId, episodeId, fileFormat); // if there's a file left to rename, calls GetEpisodeName();
		}

		private static void GetEpisodeName(string filename, string seriesId, string episodeId, string fileFormat)
		{
			Console.WriteLine ($"What is the name of {seriesId} {episodeId}?");
			string episodeName = Console.ReadLine ();

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