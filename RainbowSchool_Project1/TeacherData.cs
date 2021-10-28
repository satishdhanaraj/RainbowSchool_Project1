using System;
using System.IO;

namespace RainbowSchool_Project1
{
    class StoreTeacherData
    {
        public static void SaveTeacherData(int Id, string Name, string Class, string Section)
        {
            string folderpath = @"C:\RainbowSchool";
            string filepath = @"C:\RainbowSchool\TeacherData.txt";

            try
            {                
                if(!Directory.Exists(folderpath)) // To check if the Directory Exists or not, if not create a new dir
                {
                    Directory.CreateDirectory(folderpath);
                    Console.WriteLine("Directory didnt exists, now the directory has been created in the path: " + folderpath);
                }
                else
                {
                    Console.WriteLine("Directory exists in path: "+folderpath);
                }

                //Below code will help us to create a file if doesnt exists, and write into it,
                //If the file exists, below code will write data into it
                using (StreamWriter writer = File.CreateText(filepath))
                {
                    writer.WriteLine("ID: "+Id);
                    writer.WriteLine("Name: " + Name);
                    writer.WriteLine("Class: " + Class);
                    writer.WriteLine("Section: " + Section);

                    Console.WriteLine("Teacher Data Inserted successully.........");
                }
            }

            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            finally
            {
              
            }
            
        }
    }

    class RetriveTeacherData
    {
        public static void GetTeacherData()
        {
            string folderpath = @"C:\RainbowSchool";
            string filepath = @"C:\RainbowSchool\TeacherData.txt";

            // Read file using StreamReader. Reads file line by line    
            using (StreamReader file = new StreamReader(filepath))
            {
                int counter = 0;
                string ln;

                while ((ln = file.ReadLine()) != null)
                {
                    Console.WriteLine(ln);
                    counter++;
                }
                file.Close();
                Console.WriteLine($"File has {counter} lines.");

            }
        }
    }

    class UpdateTeacherData
    {
        public static void ModifyTeacherData()
        {
            string folderpath = @"C:\RainbowSchool";
            string filepath = @"C:\RainbowSchool\TeacherData.txt";
            try
            {
                string text = File.ReadAllText(filepath);
                text = text.Replace("Satish", "D1, Satish");
                File.WriteAllText(filepath, text);
                Console.WriteLine("Teacher Record updated successfully.......");
            }

            catch(Exception ex)
            {

            }

            finally
            {

            }
        }
    }
    class TeacherData
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Lets Store the Teachers Data in the File........");
                StoreTeacherData.SaveTeacherData(102, "Satish", "10", "A");
                Console.WriteLine("****************************");
                Console.WriteLine("Lets Retrive the Teachers Data from the File........");
                RetriveTeacherData.GetTeacherData();
                Console.WriteLine("****************************");
                Console.WriteLine("Lets Update the Teachers Data in the File........");
                UpdateTeacherData.ModifyTeacherData();
                Console.WriteLine("****************************");
                Console.WriteLine("Lets Again retrive the Teachers Data from the File to see the Updated Value........");
                RetriveTeacherData.GetTeacherData();
                Console.WriteLine("****************************");
            }

            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
