using System;
using System.IO;
using System.Linq;

namespace TVSeriesFileRenamer
{
	public class FileRenamer
	{
		public static string directoryOfFiles;
		public static string[] currentFileNames; // Files are not being retrieved just yet in order to prevent the program from stalling if the folder doesn't exist.

		public static void Main(string[] args)
		{
			Console.Title = "TV Series File Renamer";

			AskForDirectoryPath ();

			CheckDirectoryAndFilesExists (directoryOfFiles);

			RenameVideoFolder (ref currentFileNames, ref directoryOfFiles);

            RenameFiles.ScanAndRenameFiles (currentFileNames);

			Console.WriteLine ("\nFile renaming complete.");
		}

		private static void AskForDirectoryPath()
		{
			Console.WriteLine ("Please enter the folder path the videos are located in.\n");
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

		private static void CheckDirectoryAndFilesExists(string directoryOfFiles)
		{
			if (Directory.Exists (directoryOfFiles)) {
				Console.WriteLine ("\nVideo Directory Found!\n");

				currentFileNames = Directory.GetFiles (directoryOfFiles) // We can now go get those files. OrderBy organises the videos by name.
					.Select(v => Path.GetFileName(v))
					.Where (v => v.EndsWith (".mp4") || v.EndsWith (".avi") ||
						v.EndsWith (".mkv") || v.EndsWith (".wmv")).ToArray();

				if(currentFileNames.Count() > 0)
				{
					Console.WriteLine ($"{currentFileNames.Count()} Video(s) found!\n");

				} else {
					Console.WriteLine ("Error: No video(s) were found.\n");
					Environment.Exit (2);
				}

			} else {
				Console.WriteLine ("\nError: Video Directory not found. Please try again.\n");
				AskForDirectoryPath ();
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

				if (!Directory.Exists (pathWithoutDirectoryName + userInputDirectoryNewName)) {

					Directory.Move (directoryOfFiles, pathWithoutDirectoryName + userInputDirectoryNewName);
				} else {
					Console.WriteLine("\nError: Unable to rename directory as there is already a directory with the same name.\n");
					RenameVideoFolder (ref currentFileNames, ref directoryOfFiles);
                    return;
				}

				directoryOfFiles = pathWithoutDirectoryName + userInputDirectoryNewName;

				if (Directory.Exists(pathWithoutDirectoryName + userInputDirectoryNewName))
				{
					Console.WriteLine ($"\nThe directory has been successfully renamed to {userInputDirectoryNewName}!");
				} else {
                    Console.WriteLine("Error: Unable to rename directory.");
				}
			}
		}

		public static void RenameFile(string filename, string seriesId, string episodeId, string fileFormat)
		{
			Console.WriteLine ($"\nWhat is the name of {seriesId} {episodeId}?\n");
			string episodeName = Console.ReadLine ();

			File.Move (directoryOfFiles + "/" + filename, directoryOfFiles + "/" + seriesId + " " + episodeId + " - " + episodeName + fileFormat);

			if (File.Exists(directoryOfFiles + "/" + seriesId + " " + episodeId + " - " + episodeName + fileFormat))
			{
				Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine ("\nFile has been renamed succesfully!");
			} else {
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine ("\nError: Unable to rename file.");
			}

			Console.ResetColor ();
		}
	}
}