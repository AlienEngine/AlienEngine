using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlienEngine.Core.Utils
{
    public class IniParser
    {
        private Dictionary<string, Dictionary<string, string>> _sectionedResult;
        private Dictionary<string, string> _rawResult;

        /// <summary>
        /// The parsed result with sections.
        /// </summary>
        public Dictionary<string, Dictionary<string, string>> SectionedResult
        {
            get { return _sectionedResult; }
        }

        /// <summary>
        /// The parsed result.
        /// </summary>
        public Dictionary<string, string> RawResult
        {
            get { return _rawResult; }
        }

        /// <summary>
        /// Parse an .ini file.
        /// </summary>
        /// <param name="filename">The path to the file to parse.</param>
        public IniParser(string filename)
        {
            if (!File.Exists(filename))
                throw new FileNotFoundException("Can't parse the .ini file", filename);

            using (var sr = new StreamReader(filename))
            {
                // Initializing
                _rawResult = new Dictionary<string, string>();
                _sectionedResult = new Dictionary<string, Dictionary<string, string>>();

                // Stores the current line
                string line = string.Empty;

                // Stores the current section title
                string section = string.Empty;

                while ((line = sr.ReadLine()) != null)
                {
                    // Skip comments
                    if (line.StartsWith("#"))
                        continue;
                    // Detect sections title
                    else if (line.StartsWith("[") && line.EndsWith("]"))
                    {
                        section = line.Trim('[', ']');
                        if (!_sectionedResult.ContainsKey(section))
                            _sectionedResult.Add(section, new Dictionary<string, string>());
                        continue;
                    }
                    // Parse values
                    else if (!string.IsNullOrEmpty(line.Trim()))
                    {
                        string[] parts = line.Split(new char[] { ' ', '=' }, StringSplitOptions.RemoveEmptyEntries);
                        _rawResult.Add(parts[0], parts[1]);
                        if (!string.IsNullOrEmpty(section) && _sectionedResult.ContainsKey(section))
                            _sectionedResult[section].Add(parts[0], parts[1]);
                    }
                }
            }
        }
    }
}
