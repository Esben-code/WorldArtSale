using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Net;

namespace IO
{
    public class ClassCallWebApi
    {

        public ClassCallWebApi()
        {

        }

        public async Task<byte[]> GetURLContentsAsync(string inURL)
        {
            var content = new MemoryStream();
            var webReq = (HttpWebRequest)WebRequest.Create(inURL);
            try
            {
                using (WebResponse response = await webReq.GetResponseAsync())
                {

                    using (Stream responceStream = response.GetResponseStream())
                    {
                        await responceStream.CopyToAsync(content);
                    }

                }
            }
            catch (IOException ex)
            {

                throw ex;
            }


            return content.ToArray();  //Encoding.UTF8.GetString(content.ToArray());

        }

    }
}
