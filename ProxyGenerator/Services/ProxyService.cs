using ProxyGenerator.Models;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Text;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ProxyGenerator.Services
{
    public static class ProxyService
    {
        private static readonly HttpClient client = new HttpClient();
        public static void RunAsync(IEnumerable<CardRecord> cards, string savePath)
        {
            var imgList = new List<Image>();
            foreach (var card in cards)
            {
                var imgs = GetCardAsync(card.Name);
                for (int i = 0; i < card.Number; i++)
                {
                    imgList.AddRange(imgs);
                }
            }
            for (int i = 0; i < Math.Ceiling(imgList.Count / (decimal)9); i++)
            {
                CombineImages(imgList.Skip(9 * i).Take(9).ToList(), i, savePath);
            }
        }

        public static List<CardRecord> ParseImport(string text)
        {
            var cards = new List<CardRecord>();
            foreach (var line in Regex.Split(text, "\r\n|\r|\n"))
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    var card = new CardRecord();
                    card.Number = int.Parse(line.Substring(0, line.IndexOf(' ')));
                    card.Name = line.Substring(line.IndexOf(' ') + 1);
                    cards.Add(card);
                }
            }
            return cards;
        }

        private static IList<Image> GetCardAsync(string name)
        {
            var response = client.GetStringAsync($"https://api.scryfall.com/cards/named?exact={name}").Result;
            var card = JsonConvert.DeserializeObject<CardModel>(response);
            var res = new List<Image>();
            if (!string.IsNullOrEmpty(card.image_uris?.large))
                res.Add(DownloadImageFromUrl(card.image_uris.large));
            if (card.card_faces != null)
                foreach (var face in card.card_faces)
                    if (!string.IsNullOrEmpty(face.image_uris?.large))
                        res.Add(DownloadImageFromUrl(face.image_uris.large));
            return res;
        }

        private static void CombineImages(IList<Image> images, int fileNumber, string path)
        {
            //change the location to store the final image.
            string finalImage = $@"{path}/img{fileNumber}.jpeg";
            int localWidth = 0, localHeight = 0, width = 0, height = 0;
            for (int i = 0; i < images.Count(); i++)
            {
                localWidth += images[i].Width;
                if (images[i].Height > localHeight)
                    localHeight = images[i].Height;
                if (i % 3 == 2 || i == images.Count - 1)
                {
                    if (localWidth > width)
                        width = localWidth;
                    height += localHeight;
                    localHeight = 0;
                    localWidth = 0;
                }
            }
            Bitmap img3 = new Bitmap(width + 20, height + 20);
            Graphics g = Graphics.FromImage(img3);
            g.Clear(Color.White);
            localWidth = 0;
            localHeight = 0;
            height = 0;
            for (int i = 0; i < images.Count(); i++)
            {
                g.DrawImage(images[i], new Rectangle(new Point(localWidth, height), new Size(images[i].Width, images[i].Height)));
                localWidth += images[i].Width + 10;
                if (images[i].Height > localHeight)
                    localHeight = images[i].Height;
                if (i % 3 == 2)
                {
                    height += localHeight + 10;
                    localHeight = 0;
                    localWidth = 0;
                }
            }
            g.Dispose();
            img3.Save(finalImage, System.Drawing.Imaging.ImageFormat.Jpeg);
            img3.Dispose();
        }

        public static Image DownloadImageFromUrl(string imageUrl)
        {
            Image image = null;

            try
            {
                System.Net.HttpWebRequest webRequest = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(imageUrl);
                webRequest.AllowWriteStreamBuffering = true;
                webRequest.Timeout = 30000;

                System.Net.WebResponse webResponse = webRequest.GetResponse();

                Stream stream = webResponse.GetResponseStream();

                image = Image.FromStream(stream);

                webResponse.Close();
            }
            catch (Exception ex)
            {
                return null;
            }

            return image;
        }
    }
}
