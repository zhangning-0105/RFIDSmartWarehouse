/*----------------------------------------------------------------
// Copyright (C) 江苏秀园果科技有限公司
// 版权所有。
//
// 文件名：HttpHelper.cs
// 功能描述：
// 
// 创建标识：zhangning   2020/5/12 10:12:47  
// 
// 修改标识：
// 修改描述：
//
// 修改标识：
// 修改描述：
//
//----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RFIDSmartWarehouse
{
    public class HttpHelper
    {
        #region properties

        private readonly Encoding ENCODING = Encoding.UTF8;
        #endregion

        #region constructor
        public HttpHelper()
        {

        }
        #endregion

        #region public methods

        /// <summary>
        /// Post
        /// </summary>
        /// <param name="url"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public string HTTPJsonPost(string url, string msg)
        {
            string result = string.Empty;
            try
            {
                result = CommonHttpRequest(msg, url, "POST");
                //if (!result.Contains("\"Code\":200"))
                //{
                //    throw new Exception(result);
                //}
            }
            catch (WebException ex)
            {
                if (ex.Response != null)
                {
                    HttpWebResponse response = (HttpWebResponse)ex.Response;
                    LogHelper.WriteLog("接口返回数据异常", ex);
                    switch (response.StatusCode)
                    {
                        case HttpStatusCode.BadRequest:
                        case HttpStatusCode.Forbidden:
                        case HttpStatusCode.InternalServerError:
                            {
                                using (Stream data = response.GetResponseStream())
                                {
                                    using (StreamReader reader = new StreamReader(data))
                                    {
                                        string text = reader.ReadToEnd();
                                        throw new Exception(text);
                                    }
                                }
                            }
                    }

                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("接口获取数据异常", ex);

            }
            return result;
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public string HTTPJsonGet(string url)
        {
            string result = string.Empty;
            try
            {
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                request.ContentType = "application/json";
                request.Method = "GET";
                HttpWebResponse resp = request.GetResponse() as HttpWebResponse;
                System.IO.StreamReader reader = new System.IO.StreamReader(resp.GetResponseStream(), this.ENCODING);
                result = reader.ReadToEnd();
            }
            catch (Exception ex)
            {
            }
            return result;
        }

        /// <summary>
        /// Put
        /// </summary>
        /// <param name="data"></param>
        /// <param name="uri"></param>
        /// <returns></returns>
        public string HTTPJsonDelete(string url, string data)
        {
            return CommonHttpRequest(data, url, "DELETE");
        }

        /// <summary>
        /// Put
        /// </summary>
        /// <param name="data"></param>
        /// <param name="uri"></param>
        /// <returns></returns>
        public string HTTPJsonPut(string url, string data)
        {
            return CommonHttpRequest(data, url, "PUT");
        }


        #endregion



        #region private

        public string CommonHttpRequest(string data, string uri, string type)
        {

            //Web访问对象，构造请求的url地址
            string serviceUrl = uri;

            //构造http请求的对象
            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(serviceUrl);
            myRequest.Timeout = 600000;
            //转成网络流
            byte[] buf = this.ENCODING.GetBytes(data);
            //设置
            myRequest.Method = type;
            myRequest.ContentLength = buf.LongLength;
            myRequest.ContentType = "text/plain";



            using (Stream reqstream = myRequest.GetRequestStream())
            {
                reqstream.Write(buf, 0, (int)buf.Length);
            }
            HttpWebResponse resp = myRequest.GetResponse() as HttpWebResponse;
            System.IO.StreamReader reader = new System.IO.StreamReader(resp.GetResponseStream(), this.ENCODING);
            string ReturnXml = reader.ReadToEnd();
            reader.Close();
            resp.Close();
            return ReturnXml;
        }
        #endregion




        /// <summary>
        /// 检查IP地址格式
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static bool IsIP(string ip)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(ip, @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$");
        }

        public static long ConvertDataTimeLong(DateTime dt)
        {
            DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            TimeSpan toNow = dt.Subtract(dtStart);
            long timeStamp = toNow.Ticks;
            timeStamp = long.Parse(timeStamp.ToString().Substring(0, timeStamp.ToString().Length - 4));
            return timeStamp;
        }

        public static DateTime ConvertLongDateTime(long d)
        {
            DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            long lTime = long.Parse(d + "0000");
            TimeSpan toNow = new TimeSpan(lTime);
            DateTime dtResult = dtStart.Add(toNow);
            return dtResult;
        }


    }

    /// <summary>
    /// Http请求操作类之WebClient
    /// </summary>

    public static class WebClientHelper
    {
        public static string Post(string url, string jsonData)
        {
            var client = new WebClient();
            client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
            client.Encoding = System.Text.Encoding.UTF8;
            byte[] data = Encoding.UTF8.GetBytes(jsonData);
            byte[] responseData = client.UploadData(new Uri(url), "POST", data);
            string response = Encoding.UTF8.GetString(responseData);
            return response;
        }

        public static void PostAsync(string url, string jsonData, Action<string> onComplete, Action<Exception> onError)
        {
            var client = new WebClient();
            client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
            client.Encoding = System.Text.Encoding.UTF8;
            byte[] data = Encoding.UTF8.GetBytes(jsonData);

            client.UploadDataCompleted += (s, e) =>
            {
                if (e.Error == null && e.Result != null)
                {
                    string response = Encoding.UTF8.GetString(e.Result);
                    onComplete(response);
                }
                else
                {
                    onError(e.Error);
                }
            };

            client.UploadDataAsync(new Uri(url), "POST", data);
        }
    }



}
