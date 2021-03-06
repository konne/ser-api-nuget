﻿#region License
/*
Copyright (c) 2019 Konrad Mattheis und Martin Berthold
Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
 */
#endregion;

namespace Ser.Api
{
    #region Usings
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;
    #endregion

    /// <summary>
    /// Class for work with the qlik userid und userdirectory logic.
    /// </summary>
#if NET45
    [Reinforced.Typings.Attributes.TsInterface]
#endif
    public class DomainUser
    {
        #region Properties
        /// <summary>
        /// Qlik user id
        /// </summary>
        public string UserId { get; private set; }

        /// <summary>
        /// Qlik user directory
        /// </summary>
        public string UserDirectory { get; private set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Creating a object for DomainUser.
        /// </summary>
        /// <param name="domainUserValue">UserId and UserDirectory as Path.
        /// Sample: 'USERDIRECTORY\\USERID' or 'UserDirectory=USERDIRECTORY; UserId=USERID'
        /// </param>
        public DomainUser(string domainUserValue)
        {
            var split = domainUserValue.Split('\\');
            if (split.Length == 2)
            {
                UserId = split.ElementAtOrDefault(1) ?? null;
                UserDirectory = split.ElementAtOrDefault(0) ?? null;
            }
            else
            {
                split = domainUserValue.Split(';');
                if (split.Length == 2)
                {
                    UserId = split.ElementAtOrDefault(1)?.Split('=').ElementAtOrDefault(1) ?? null;
                    UserDirectory = split.ElementAtOrDefault(0)?.Split('=').ElementAtOrDefault(1) ?? null;
                }
            }
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Format UserId and UserDirectory to string
        /// </summary>
        /// <returns></returns>
#if NET45
        [Reinforced.Typings.Attributes.TsIgnore]
#endif
        public override string ToString()
        {
            return $"{UserDirectory.ToLowerInvariant()}\\{UserId.ToLowerInvariant()}";
        }
        #endregion
    }
}