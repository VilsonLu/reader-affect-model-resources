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
            data = parser.ReadFile("../../Resources/App/Config.ini");
        }

        /// <summary>
        /// Returns the directory to the Results folder.
        /// </summary>
        /// <returns>tThe directory to the Results folder.</returns>
        public static String GetResultsPath() {
            return data["RESOURCES"]["resultspath"];
        }

        /// <summary>
        /// Returns the directory of the given 'story'.
        /// </summary>
        /// <param name="story"></param>
        /// <returns></returns>
        public static String GetSelectedStoryPath(Stories story) {
            return data["STORIES"][story.ToString()];
        }
    }
}
