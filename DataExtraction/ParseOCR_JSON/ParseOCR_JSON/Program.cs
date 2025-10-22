using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseOCR_JSON
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Specify the folder path
            string folderPath = @"C:\Users\Hassan Ullah\Desktop\PaddleOCR\ExtractedData";

            if (Directory.Exists(folderPath))
            {
                // Get all .json files in the folder
                string[] jsonFiles = Directory.GetFiles(folderPath, "*.json");

                // Print all file names
                foreach (string file in jsonFiles)
                {
                    string input_path = "";
                    string rec_texts = "";
                    List<string> first30Lines = new List<string>();
                    // Console.WriteLine(file);
                    string jsonContent = File.ReadAllText(file);

                    // Parse JSON to a JObject
                    JObject jsonData = JObject.Parse(jsonContent);

                    if (jsonData["input_path"] != null)
                    {
                        input_path =Convert.ToString(jsonData["input_path"]);
                        //Console.WriteLine("input_path : " + jsonData["input_path"]);
                    }
                    if (jsonData["rec_texts"] != null)
                    {
                        input_path = Convert.ToString(jsonData["input_path"]);
                        //Console.WriteLine("input_path : " + jsonData["input_path"]);
                    }
                    if (jsonData["rec_texts"] != null)
                    {
                        rec_texts = Convert.ToString(jsonData["rec_texts"]);
                        //Console.WriteLine("input_path : " + jsonData["input_path"]);


                        // Remove the square brackets and split by comma
                        string[] items = rec_texts.Trim('[', ']').Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                        // Trim quotes and spaces from each item
                        for (int i = 0; i < items.Length; i++)
                        {
                            items[i] = items[i].Trim().Trim('"');

                        }

                        // Take first 30 items
                        
                        int count = Math.Min(30, items.Length);
                        for (int i = 0; i < count; i++)
                        {
                            first30Lines.Add(items[i]);
                        }

                        if (first30Lines.Any(line => line == "Cash Invoice" || line == "INVOICE"))
                        {
                            Console.WriteLine("INVOICE : "+ file);
                        }
                        if (first30Lines.Any(line => line == "DELIVERYNOTE" || line == "DELIVERY NOTE"))
                        {
                            Console.WriteLine("DELIVERY NOTE : " + file);
                        }


                        //Print the list
                        //foreach (var item in first30Lines)
                        //{
                        //    Console.WriteLine(item);
                        //}
                    }

                    //Console.WriteLine("input_path : " + jsonData["input_path"]);

                }

            }
            else
            {
                Console.WriteLine("Folder does not exist.");
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
