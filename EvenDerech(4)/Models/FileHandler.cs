﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Web;
using System.Diagnostics;

namespace EvenDerech_4_.Models
{
    public class FileHandler
    {
        // Singleton
        private static FileHandler fileHandlerInstance = null;
        private string[] detailsRead;
        private int arrayIndex;
        private bool firstWrite;
        private string filePath;
        private string detailsLine;

        private FileHandler()
        { }


        public static FileHandler GetFileHandlerInstance
        {
            get {
                if (fileHandlerInstance == null) {
                    fileHandlerInstance = new FileHandler();
                }
                return fileHandlerInstance;
            }
        }
        //Property
        public string[] DetailsRead {
            get {
                return detailsRead;
            } set {
                this.detailsRead = value;
            }
        }
        //Property
        public bool FirstWrite {
            get {
                return firstWrite;
            }
            set {
                firstWrite = value;
            }
        }
        
        public int ArrayIndex {
            get {
                return arrayIndex;
            }
            set {
                arrayIndex = value;
            }
        }
        public string FilePath
        {
            get => filePath;
            set => filePath = value;
        }
        public string DetailsLine
        {
            get => detailsLine;
            set => detailsLine = value;
        }

        public string[] ReadData() {
            string[] dataRead = File.ReadAllLines(FilePath);
            return dataRead;
        }

        public void SaveDataToFile()
        {
            //todo - Not really 10 seconds.
            if (File.Exists(FilePath) && firstWrite) {
                File.Delete(FilePath);
            }

            if (firstWrite)
            {
                firstWrite = false;
            }

            using (StreamWriter streamWriter = File.AppendText(FilePath))
            {
                streamWriter.WriteLine(this.detailsLine);
            }
        }

    }
}