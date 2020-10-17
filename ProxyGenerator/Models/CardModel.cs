using System;
using System.Collections.Generic;
using System.Text;

namespace ProxyGenerator.Models
{
    public class CardModel
    {
        public CardImagesModel image_uris { get; set; }
        public List<CardFaceModel> card_faces { get; set; }
    }
}
