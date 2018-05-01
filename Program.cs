using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace AnalyzingSocialCues
{
    class Program
    {
        static String pathToFiles = "..\\ReadGestures"; //put the files in the C:\\ drive directly.

        static void Main(string[] args)
        {
            String[] completePathOfFiles;
            try
            {

                Console.WriteLine("Welcome to the Social Cues Database Program.");

                Console.WriteLine("\n\nHere are the files that are currently in your directory: ");


                completePathOfFiles = Directory.GetFiles(pathToFiles); //getting all the files in the directory
                String[] titleOfFiles = new String[completePathOfFiles.Length]; //only the names of the files here
                for (int i = 0; i < completePathOfFiles.Length; i++)
                {
                    //Console.WriteLine(completePathOfFiles[i]); //print all choices.

                    //however, I want only the name of the files to allow selection.
                    String[] split = completePathOfFiles[i].Split('\\');
                    titleOfFiles[i] = split[split.Length - 1].Split('.')[0];
                    Console.WriteLine(titleOfFiles[i]); //prints all the possible selections
                }

                while (true)
                {
                    Console.WriteLine("\n\nIf you wish to add a new file, press 1.");
                    Console.WriteLine("If you wish to add to an existent file, press 2.");
                    Console.WriteLine("If you wish to delete a file, press 3.");
                    Console.WriteLine("If you wish to exit, press 4.");

                    int input = Convert.ToInt32(Console.ReadLine());

                    if (input == 1)
                    {
                        Console.WriteLine("Warning: If you write down the same file name as another existent file, it will delete it, and create a new one.");

                        Console.Write("\nWrite the name of your new file: ");
                        String fileName = Console.ReadLine();

                        String fullPath = pathToFiles + "\\" + fileName + ".txt";

                        if (File.Exists(fullPath))
                        {
                            File.Delete(fullPath);
                        }
                        File.Create(fullPath);

                        Console.WriteLine("\n\n Your file will be appearing in your choices when the program will reboot.");
                    }
                    else if (input == 2)
                    {
                        Console.WriteLine("\n\nWrite down the number of your choice from the options below: ");
                        for (int i = 0; i < completePathOfFiles.Length; i++)
                        {
                            Console.WriteLine(i + " => " + titleOfFiles[i]); //prints all the possible selections
                        }
                        //take input 
                        int fileChoice = Convert.ToInt32(Console.ReadLine());

                        Process.Start(completePathOfFiles[fileChoice]); // launch notepad to see content and modify it
                    }
                    else if (input == 3)
                    {
                        Console.WriteLine("\n\nWrite down the number of your choice from the options below: ");
                        for (int i = 0; i < completePathOfFiles.Length; i++)
                        {
                            Console.WriteLine(i + " => " + titleOfFiles[i]); //prints all the possible selections
                        }

                        int fileChoice = Convert.ToInt32(Console.ReadLine());


                        if (File.Exists(completePathOfFiles[fileChoice]))
                        {
                            File.Delete(completePathOfFiles[fileChoice]);
                        }

                        Console.WriteLine("\n\nIt is suggested that you shut down the application. However, it is not necessary.");
                    }
                    else if (input == 4)
                    {
                        System.Environment.Exit(0);
                    }
                    else
                    {
                        Console.WriteLine("Please enter valid input.");
                    }
                }
                

            }

            catch(IOException ex)
            {
                Console.WriteLine("Files not found");
                Console.WriteLine(ex.Message);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Shut down inexpectedly");
                Console.WriteLine(ex.Message);
            }


            Console.ReadLine();
            //need to loop back until the user wants to quit
            
        }
    }

    class AddNewFileToList
    {

    }


}
