using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace px2vwAndvh
{
    class Config
    {
        private static string ConfigFilePath()
        {
            var workDir = Environment.CurrentDirectory;
            return workDir + "\\px2vwAndvh.txt";
        }

        public static void SavePsdWidthAndHeight(PsdWidthAndHeight wh)
        {

            using (var fs = new FileStream(ConfigFilePath(), FileMode.Create))
            {
                using (var sw = new StreamWriter(fs))
                {
                    sw.WriteLine(wh.Format());
                    sw.Flush();
                }
            }
        }


        public static PsdWidthAndHeight GetPsdWidthAndHeight()
        {
            if( !File.Exists(ConfigFilePath()) )
            {
                return new PsdWidthAndHeight();
            }
            using (var fs = new FileStream(ConfigFilePath(), FileMode.Open))
            {
                using (var sr = new StreamReader(fs))
                {
                    var result = sr.ReadToEnd();
                    var regex = new Regex(@"(?<a>\d*.?\d*),(?<b>\d*.?\d*)");
                    if( !regex.IsMatch(result))
                    {
                        return new PsdWidthAndHeight();
                    } else
                    {
                        var ms = regex.Match(result);
                        var first = ms.Groups["a"].Value;
                        var second = ms.Groups["b"].Value;
                        return new PsdWidthAndHeight(float.Parse(first), float.Parse(second));
                    }
                }
            }
        }
    }
}
