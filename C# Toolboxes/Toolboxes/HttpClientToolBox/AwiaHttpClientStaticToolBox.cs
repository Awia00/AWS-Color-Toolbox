using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace HttpClientToolBox
{
    public static class AwiaHttpClientStaticToolBox
    {
        static public HttpClient HttpClient { get; set; }

        /// <summary>
        /// Resets the httpclient and then sets the base address.
        /// </summary>
        /// <param name="baseAddress"></param>
        public static void Setup(Uri baseAddress)
        {
            HttpClient = new HttpClient { BaseAddress = baseAddress };
            HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        /// <summary>
        /// Resets the httpclient and then sets the base address.
        /// </summary>
        /// <param name="baseAddress"></param>
        public static void Setup(string baseAddress)
        {
            HttpClient = new HttpClient { BaseAddress = new Uri(baseAddress) };
            HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        /// <summary>
        /// Adds the mediatype header to the default httprequests.
        /// Deprecated.
        /// </summary>
        /// <param name="mediaHeaderType">For Json use: new MediaTypeWithQualityHeaderValue("application/json")</param>
        [Obsolete("SetMediaHeaders is deprecated, since only JSON is supported atm.", true)]
        public static void SetMediaHeaders(MediaTypeWithQualityHeaderValue mediaHeaderType)
        {
            HttpClient.DefaultRequestHeaders.Accept.Add(mediaHeaderType);
        }

        /// <summary>
        /// Sets the authetication header to the given value. Used for API's which needs authentication.
        /// </summary>
        /// <param name="authenticationHeader"></param>
        public static void SetAuthenticationHeader(AuthenticationHeaderValue authenticationHeader)
        {
            HttpClient.DefaultRequestHeaders.Authorization = authenticationHeader;
        }

        /// <summary>
        /// Creates a Post httprequest with the generic T to the webAPI at the url BaseAddress + uri. 
        /// T and the uri string must match.
        /// </summary>
        /// <typeparam name="T"> An object matching the expected object in the API at url (BaseAddress+Uri)</typeparam>
        /// <param name="uri">The uri of the api where T objects are stored</param>
        /// <param name="objectToCreate"> the object to create at the APi</param>
        /// <returns>The object which was created at the API</returns>
        public async static Task<T> Create<T>(string uri, T objectToCreate)
        {
            try
            {
                var response = await HttpClient.PostAsJsonAsync(uri, objectToCreate);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsAsync<T>();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Reads all the objects of type T at the webAPI on the string BaseAddress + uri. 
        /// T and the uri string must match.
        /// </summary>
        /// <typeparam name="T"> An object matching the expected object in the API at url (BaseAddress+Uri)</typeparam>
        /// <param name="uri">The uri of the api where T objects are stored</param>
        /// <returns>All T objects in the API using the URI</returns>
        public async static Task<IList<T>> ReadList<T>(string uri)
        {
            T[] objects;
            try
            {
                var response = await HttpClient.GetAsync(uri);
                response.EnsureSuccessStatusCode();
                objects = await response.Content.ReadAsAsync<T[]>();
            }
            catch (Exception)
            {
                throw;
            }
            return objects.ToList();
        }
        /// <summary>
        /// Reads the object of type T at the webAPI on the string BaseAddress + uri. 
        /// T and the uri string must match.
        /// </summary>
        /// <typeparam name="T"> An object matching the expected object in the API at url (BaseAddress+Uri)</typeparam>
        /// <param name="uri">The uri of the api where a single T object is stored</param>
        /// <returns>An T object in the API using the URI</returns>
        public async static Task<T> Read<T>(string uri)
        {
            try
            {
                HttpResponseMessage response = await HttpClient.GetAsync(uri);
                response.EnsureSuccessStatusCode();
                T objectToRead = await response.Content.ReadAsAsync<T>();
                return objectToRead;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Creates a Put httprequest with the generic T to the webAPI at the url BaseAddress + uri. 
        /// T and the uri string must match.
        /// </summary>
        /// <typeparam name="T"> An object matching the expected object in the API at url (BaseAddress+Uri)</typeparam>
        /// <param name="uri">The uri of the api where T objects are stored</param>
        /// <param name="objectToUpdate"> the object to update at the APi with an ID</param>
        /// <returns>A Task to await</returns>
        public async static Task Update<T>(string uri, T objectToUpdate)
        {
            try
            {
                var response = await HttpClient.PutAsJsonAsync(uri, objectToUpdate);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Creates a Delete httprequest to the webAPI at the url BaseAddress + uri. 
        /// </summary>
        /// <param name="uri">The uri of the API indicating a single object</param>
        /// <returns>A Task to await</returns>
        public async static Task Delete<T>(string uri)
        {
            try
            {
                var response = await HttpClient.DeleteAsync(uri);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
