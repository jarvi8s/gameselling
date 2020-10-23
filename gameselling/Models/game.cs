using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Web;

namespace gameselling.Models
{
    public class game
    {   public int GameId { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }

      public string Category { get; set; }
        public game(int gameId,string title,int price,string category)
        {
            GameId = gameId;
            Title = title;
            Price = price;
          Category = category;
        }

    }
   
}