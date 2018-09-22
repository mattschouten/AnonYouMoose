using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Word = Microsoft.Office.Interop.Word;
using System.IO;

namespace AnonYouMoose
{
    class WordAnonymizer
    {

        public void Anonymize(string[] paths)
        {
            string[] realPaths = GetRealPaths(paths);
            if (realPaths.Length == 0) { return; }

            Word.Application wordApp = new Word.Application();
            try
            {
                wordApp.Visible = true;

                foreach (string file in realPaths)
                {
                    // Open the file
                    Word.Document doc = wordApp.Documents.Open(file);

                    // Change all comment authors to "Reviewer"
                    foreach (Word.Comment comment in doc.Comments)
                    {
                        //Console.WriteLine(comment.Creator.ToString());
                        //Console.WriteLine(comment.Author.ToString());
                        comment.Author = "Reviewer";
                        comment.Initial = "REV";
                    }

                    // Change "Last Saved By" to "Reviewer"
                    var props = doc.BuiltInDocumentProperties;
                    Console.WriteLine(props.Item(Word.WdBuiltInProperty.wdPropertyLastAuthor).Value);
                    
                    
                    // Save and close the file with a different username.
                    SaveAsReviewer(wordApp, doc);

                    Console.WriteLine(props.Item(Word.WdBuiltInProperty.wdPropertyLastAuthor).Value);
                    
                    doc.Close();
                }
            }
            finally
            {
                wordApp.Quit();
            }
        }

        private static void SaveAsReviewer(Word.Application wordApp, Word.Document doc)
        {
            string username = wordApp.UserName;
            string userinitials = wordApp.UserInitials;
            try
            {
                wordApp.UserName = "Reviewer";
                wordApp.UserInitials = "REV";
                doc.Save();
            }
            finally
            {
                wordApp.UserName = username;
                wordApp.UserInitials = userinitials;
            }
        }

        private string[] GetRealPaths(string[] paths)
        {
            // Cases:
            // - Single File (leave as-is, maybe drop non docx)
            // - Multiple Files (leave as-is, maybe drop non docx)
            // - Directory (find all .docx)
            // - Multiple Directories (NOT HANDLED YET)
            if (paths.Length == 1)
            {
                // Single file or single directory
                if (paths[0].EndsWith(".docx"))  // Single file
                {
                    return paths;
                }
                else  // Single directory
                {
                    return FindWordFilesInDirectory(paths[0]);
                }
            }
            else  // Assuming multiple files for now, drop non .docx
            {
                string[] results = paths.Where(s => s.EndsWith(".docx")).ToArray();
                return results;
            }
        }

        private string[] FindWordFilesInDirectory(string path)
        {
            return Directory.EnumerateFiles(path, "*.docx").ToArray();
        }
    }
}
