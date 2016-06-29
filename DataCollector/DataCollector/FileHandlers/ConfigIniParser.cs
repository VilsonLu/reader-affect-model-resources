using DataCollector.Models;
using IniParser;
using IniParser.Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCollector.FileHandlers {
    public static class ConfigIniParser {
        private static FileIniDataParser parser;
        private static IniData data;

        static ConfigIniParser() {
            parser = new FileIniDataParser();
            Console.WriteLine("HELLO");
            data = parser.ReadFile("../../Config.ini");
        }

        public static String GetResultsPath() {
            return data["RESOURCES"]["resultspath"];
        }

        public static String GetStoriesPath() {
            return data["RESOURCES"]["storiespath"];
        }

        public static String GetSelectedStoryPath(Stories story) {
            return data["STORIES"][story.ToString()];
        }
    }
}
