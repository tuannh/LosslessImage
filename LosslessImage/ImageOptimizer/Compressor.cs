﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MadsKristensen.ImageOptimizer
{
    public class Compressor
    {
        private static string[] _supported = new[] { ".png", ".jpg", ".jpeg", ".gif" };

        public object CompressFile(string fileName, string targetFile, string toolpath)
        {
            var start = new ProcessStartInfo("cmd")
            {
                WindowStyle = ProcessWindowStyle.Hidden,
                WorkingDirectory = toolpath,
                Arguments = GetArguments(fileName, targetFile),
                UseShellExecute = false,
                CreateNoWindow = true,
            };

            var process = new Process();
            process.StartInfo = start;
            process.Start();
            process.WaitForExit();

            return new { FileName = fileName, Target = targetFile };
        }

        private static string GetArguments(string sourceFile, string targetFile)
        {
            if (!Uri.IsWellFormedUriString(sourceFile, UriKind.RelativeOrAbsolute) && !File.Exists(sourceFile))
                return null;

            string ext;

            try
            {
                ext = Path.GetExtension(sourceFile).ToLowerInvariant();
            }
            catch (ArgumentException)
            {
                return null;
            }

            switch (ext)
            {
                case ".png":
                    return string.Format(CultureInfo.CurrentCulture, "/c pngout \"{0}\" \"{1}\" /s0 /y /v /kpHYs /force", sourceFile, targetFile);

                case ".jpg":
                case ".jpeg":
                    return string.Format(CultureInfo.CurrentCulture, "/c jpegtran -copy none -optimize -progressive \"{0}\" \"{1}\"", sourceFile, targetFile);

                case ".gif":
                    return string.Format(CultureInfo.CurrentCulture, "/c gifsicle --crop-transparency --no-comments --no-extensions --no-names --optimize=3 --batch \"{0}\" --output=\"{1}\"", sourceFile, targetFile);
            }

            return null;
        }

        public static bool IsFileSupported(string fileName)
        {
            string ext = Path.GetExtension(fileName);

            return _supported.Any(s => s.Equals(ext, StringComparison.OrdinalIgnoreCase));
        }
    }
}
