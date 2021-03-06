﻿#region License
/*
Copyright (c) 2019 Konrad Mattheis und Martin Berthold
Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/
#endregion

namespace Ser.Api
{
    #region Usings
    using NLog;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;
    using System.Text;
    #endregion

    /// <summary>
    /// Class with general methods for SER
    /// </summary>
    public class SerUtilities
    {
        #region Logger
        private static Logger logger = LogManager.GetCurrentClassLogger();
        #endregion

        /// <summary>
        /// Convert a Path to a full path.
        /// </summary>
        /// <param name="path">path</param>
        /// <returns>full path</returns>
        public static string GetFullPathFromApp(string path)
        {
            try
            {
                if (String.IsNullOrEmpty(path))
                    return null;
                if (path.StartsWith("/"))
                    return path;
                if (!path.StartsWith("\\\\") && !path.Contains(":") && !path.StartsWith("%"))
                    path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location).TrimEnd('\\'), path.TrimStart('\\'));
                path = Environment.ExpandEnvironmentVariables(path);
                return Path.GetFullPath(path);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return null;
            }
        }
    }
}
