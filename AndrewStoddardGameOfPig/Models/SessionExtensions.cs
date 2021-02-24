// ***********************************************************************
// Author           : Andrew Stoddard
// Created          : 02-24-2021
//
// Last Modified By : Andrew Stoddard
// Last Modified On : 02-24-2021
// ***********************************************************************
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AndrewStoddardGameOfPig.Models
{
    /// <summary>
    /// Class SessionExtensions.
    /// </summary>
    public static class SessionExtensions
    {
        /// <summary>
        /// Sets the boolean.
        /// </summary>
        /// <param name="session">The session.</param>
        /// <param name="key">The key.</param>
        /// <param name="value">if set to <c>true</c> [value].</param>
        public static void SetBoolean(this ISession session, string key, bool value)
        {
            session.SetString(key, value.ToString());
        }
        /// <summary>
        /// Gets the boolean.
        /// </summary>
        /// <param name="session">The session.</param>
        /// <param name="key">The key.</param>
        /// <returns>Boolean.</returns>
        public static Boolean GetBoolean(this ISession session, string key)
        {
            string value = session.GetString(key);
            return Boolean.Parse(value ?? "false");
        }

    }
}
