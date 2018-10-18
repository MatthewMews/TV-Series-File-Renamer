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
		public static string directoryOfFiles;
		public static string[] currentFileNames; // Files are not being retrieved just yet in order to prevent the program from stalling if the folder doesn't exist.

		public static void Main(string[] args)
		{
			AskForDirectoryPath ();
		
			CheckDirectoryAndFilesExists (directoryOfFiles);

			RenameVideoFolder (ref currentFileNames, ref directoryOfFiles);

			RenameFiles.ScanAndRenameFiles ();

			Console.WriteLine ("File renaming complete.");

			Console.ReadKey ();
		}

		private static void AskForDirectoryPath()
		{
			Console.WriteLine ("Please enter the path of the directory");
			string userInputFilePath = Console.ReadLine ();

			if (userInputFilePath.ToLower() == "exit")
			{
				Environment.Exit (1);
			}
				
			directoryOfFiles = userInputFilePath;

			if (!Directory.Exists (userInputFilePath)) {
				CheckDirectoryAndFilesExists(directoryOfFiles);
			}
		}

		private static void RenameVideoFolder(ref string[] currentFileNames, ref string directoryOfFiles)
		{
			Console.WriteLine ($"Do you wish to rename the directory {Path.GetFileName(directoryOfFiles)}? y / n");
			string renameFolderUserInput = Console.ReadLine ();

			if (renameFolderUserInput.ToLower() == "y" || renameFolderUserInput == "yes")
			{
				string pathWithoutDirectoryName = Directory.GetParent(directoryOfFiles).FullName + "/";

				Console.WriteLine ("\nPlease enter the folders new name.\n");
				string userInputDirectoryNewName = Console.ReadLine ();

				Directory.Move (directoryOfFiles, pathWithoutDirectoryName + userInputDirectoryNewName);


				directoryOfFiles = pathWithoutDirectoryName + userInputDirectoryNewName;
				currentFileNames = Directory.GetFiles (directoryOfFiles);


				if (Directory.Exists(pathWithoutDirectoryName + userInputDirectoryNewName))
				{
					Console.WriteLine ("The directory has been successfully renamed!");
				} else {
					Console.WriteLine ("Error attemping to rename directory.");
				}
			}
		}

		private static void CheckDirectoryAndFilesExists(string directoryOfFiles)
		{
			if (Directory.Exists (directoryOfFiles)) {
				Console.WriteLine ("\nVideo Directory Found!");
				currentFileNames = Directory.GetFiles(directoryOfFiles); // We can now go get those files.

				Console.WriteLine ("\nFinding video(s)...\n");

				string[] vids = Directory.GetFiles (directoryOfFiles);

				if(vids.Length > 0)
				{
					Console.WriteLine ($"{vids.Length} Video(s) found!\n");
				} else {
					Console.WriteLine ("No video(s) were found.\n");
					Environment.Exit (2);
				}

			} else {
				Console.WriteLine ("\nVideo Directory not found. Please try again.\n");
				AskForDirectoryPath ();
			}
		}

		public static void RenameFile(string filename, string seriesId, string episodeId, string fileFormat)
		{
			int numOfRenamedFiles = 0;

			foreach(string file in currentFileNames) // Checks to see if any more files need renaming.
			{
				string tempFile = Path.GetFileName(file);

				// Checking to see if the file name has been updated with the new naming convention listed below.
				if(tempFile.StartsWith("S01") || tempFile.StartsWith("S02") || tempFile.StartsWith("S03") || tempFile.StartsWith("S04") || tempFile.StartsWith("S05") 
					|| tempFile.StartsWith("S06") || tempFile.StartsWith("S07") || tempFile.StartsWith("S08") || tempFile.StartsWith("S09") || tempFile.StartsWith("S10") 
					|| tempFile.StartsWith("S11") || tempFile.StartsWith("S12"))
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
			Console.WriteLine ($"\nWhat is the name of {seriesId} {episodeId}?");
			string episodeName = Console.ReadLine ();

			File.Move (filename, directoryOfFiles + "/" + seriesId + " " + episodeId + " - " + episodeName + fileFormat);

			if (File.Exists(directoryOfFiles + "/" + seriesId + " " + episodeId + " - " + episodeName + fileFormat))
			{
				Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine ("\nFile has been renamed succesfully!");
			} else {
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine ("\nError attempting to rename file.");
			}

			Console.ResetColor ();
		}
	}
}