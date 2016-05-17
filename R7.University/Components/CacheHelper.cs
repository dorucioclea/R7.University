﻿//
// CacheHelper.cs
//
// Author:
//       Roman M. Yagodin <roman.yagodin@gmail.com>
//
// Copyright (c) 2014 Roman M. Yagodin
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using System.Collections.ObjectModel;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Services.Cache;

namespace R7.University.Components
{
    public static class CacheHelper
    {
        public static bool Exists (string key)
        {
            return DataCache.GetCache (key) != null;
        }

        public static void Set<T> (T toSet, string key, int seconds)
        {
            DataCache.SetCache (key, toSet, TimeSpan.FromSeconds (seconds)); 
        }

        public static T Get<T> (string key)
        {
            return (T) DataCache.GetCache (key);
        }

        public static T TryGet<T> (string key, T defValue)
        {
            var obj = DataCache.GetCache (key);
            if (obj != null)
                return (T) obj;

            return defValue;
        }

        /// <summary>
        /// Remove all cache keys with specified prefix
        /// </summary>
        /// <param name="cacheKeyPrefix">Cache key prefix.</param>
        public static void RemoveCacheByPrefix (string cacheKeyPrefix)
        {
            // get all cache keys with s
            var cacheKeys = new Collection<string> ();
            var cacheEnumerator = CachingProvider.Instance ().GetEnumerator ();

            while (cacheEnumerator.MoveNext ()) {
                var cacheKey = cacheEnumerator.Key.ToString ();
                if (cacheKey.StartsWith ("DNN_" + cacheKeyPrefix, StringComparison.InvariantCultureIgnoreCase)) {
                    cacheKeys.Add (cacheKey);
                }
            }

            foreach (var cacheKey in cacheKeys) {
                // Substring (4) removes DNN_ prefix 
                DataCache.RemoveCache (cacheKey.Substring (4));
            }
        }
    }
}
