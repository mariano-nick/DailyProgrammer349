using System;
using System.Collections.Generic;
using System.IO;

namespace DailyProgrammer349
{
    public class FileInputGetter : IInputGetter
    {
        // TODO if the file has more than one input, fire an event, do something with that event in main?
        
        // fields
        private FileInfo _file;
        private string _input;
        private List<string> _listOfInputs = new List<string>();

        // prop
        public FileInfo File
        {
            get { return _file; }
            private set
            {
                if (value.Exists)
                {
                    _file = value;
                }
                else
                {
                    throw new FileNotFoundException("File not found.", value.FullName);
                }
            }
        }

        // ctors
        public FileInputGetter(string filePath)
        {
            if (!String.IsNullOrEmpty(filePath))
            {
                var file = new FileInfo(filePath);
                File = file;
                ReadFile();              
            }
            else
            {
                throw new ArgumentNullException("filePath");
            }
        }
        public FileInputGetter(FileInfo file)
        {
            File = file;
            ReadFile();
        }
        
        // interface methods
        public string GetInput()
        {
            return _input;
        }

        // private methods
        private void ReadFile()
        {
            var fileReader = new StreamReader(_file.FullName);
            _input = fileReader.ReadLine();

            if (fileReader.EndOfStream)
            {
                fileReader.Dispose();
            }
            else
            {
                
            }
        }
    }

}
