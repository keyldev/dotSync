using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace sharpSync.Core.Classes
{
    class FTPClient
    {
        private string _uri;
        private int bufferSize = 1024;

        public bool passive = true;
        public bool binary = true;
        public bool enableSSL = false;
        public bool hash = false;
        public FTPClient(string uri)
        {
            _uri = uri;
        }
        string _username = null;
        string _password = null;
        public FTPClient(string uri, string username, string password)
        {
            _uri = uri;
            _username = username;
            _password = password;
        }
        public string[] ListDirectoryDetails()
        {
            var list = new List<string>();

            var request = _createRequest(WebRequestMethods.Ftp.ListDirectoryDetails);

            using (var response = (FtpWebResponse)request.GetResponse())
            {
                using (var stream = response.GetResponseStream())
                {
                    using (var reader = new StreamReader(stream, true))
                    {
                        while (!reader.EndOfStream)
                        {
                            list.Add(reader.ReadLine());
                        }
                    }
                }
            }

            return list.ToArray();
        }
        private FtpWebRequest _createRequest(string method)
        {
            return _createRequest(_uri, method);
        }
        private FtpWebRequest _createRequest(string uri, string method)
        {
            var request = (FtpWebRequest)WebRequest.Create(uri);
            if (_username == null && _password == null)
                request.Credentials = new NetworkCredential("", "");
            else request.Credentials = new NetworkCredential(_username, _password);
            request.Method = method;

            request.UseBinary = binary;
            request.EnableSsl = enableSSL;
            request.UsePassive = passive;

            return request;
        }
        private FtpWebRequest _createRequestWithCredentials(string uri, string method, string login, string password)
        {
            var request = (FtpWebRequest)WebRequest.Create(uri);

            request.Credentials = new NetworkCredential(login, password);
            request.Method = method;

            request.UseBinary = binary;
            request.EnableSsl = enableSSL;
            request.UsePassive = passive;

            return request;
        }
        private string getStatus(FtpWebRequest request)
        {
            using (var response = (FtpWebResponse)request.GetResponse())
            {
                return response.StatusDescription;
            }
        }
        private string combine(string path1, string path2)
        {
            return Path.Combine(path1, path2).Replace("\\", "/");
        }
        public string DownloadFile(string source, string dest)
        {
            var request = _createRequest(combine(_uri, source), WebRequestMethods.Ftp.DownloadFile);

            byte[] buffer = new byte[bufferSize];

            using (var response = (FtpWebResponse)request.GetResponse())
            {
                using (var stream = response.GetResponseStream())
                {
                    using (var fs = new FileStream(dest, FileMode.OpenOrCreate))
                    {
                        int readCount = stream.Read(buffer, 0, bufferSize);

                        while (readCount > 0)
                        {
                            if (hash)
                                Console.Write("#");

                            fs.Write(buffer, 0, readCount);
                            readCount = stream.Read(buffer, 0, bufferSize);
                        }
                    }
                }
                return response.StatusDescription;
            }
        }
        public void FTPUploadFile(string filename, string destination)
        {
            FileInfo fileInf = new FileInfo(filename);
            
            string uri = _uri;
            FtpWebRequest reqFTP;

            reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(uri + destination + "/" + fileInf.Name));

            reqFTP.Credentials = new NetworkCredential("", "");
            reqFTP.KeepAlive = false;
            reqFTP.Method = WebRequestMethods.Ftp.UploadFile;
            reqFTP.UseBinary = true;
            reqFTP.ContentLength = fileInf.Length;

            int buffLength = 2048;
            byte[] buff = new byte[buffLength];
            int contentLen;
            FileStream fs = fileInf.OpenRead();
            try
            {
                Stream strm = reqFTP.GetRequestStream();
                // Читаем из потока по 2 кбайт
                contentLen = fs.Read(buff, 0, buffLength);
                // Пока файл не кончится
                while (contentLen != 0)
                {
                    strm.Write(buff, 0, contentLen);
                    contentLen = fs.Read(buff, 0, buffLength);
                }
                // Закрываем потоки
                strm.Close();
                fs.Close();
            }
            catch (Exception)
            {
                
            }
            
        }
    }
}
