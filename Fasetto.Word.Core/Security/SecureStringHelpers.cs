﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Fasetto.Word.Core
{
    /// <summary>
    /// Helpers for the <see cref="SecureString"/> class
    /// </summary>
    public static class SecureStringHelpers
    {
        /// <summary>
        /// Unsecures a <see cref="SecureString"/> to a plain text
        /// </summary>
        /// <param name="secureString"></param>
        /// <returns></returns>
        public static string Unsecure(this SecureString secureString)
        {
            // make sure we have a secure string
            if (secureString == null)
                return string.Empty;

            // get a pointer for an unsecure string in memory
            // set the password toa location in memeory
            IntPtr unmanagedString = IntPtr.Zero;


            try
            {
                // unsecures the password
                // convert that location in memeory to string
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(secureString);
                return Marshal.PtrToStringUni(unmanagedString);
            }
            finally
            {
                // clean up any memeory allocation
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }


        }
    }
}
