using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Pigalev_API_beautiful_places.Models
{
    public class FavoritesModels
    {
        public int id_davorites { get; set; }
        public int id_user { get; set; }
        public int id_beautiful_place { get; set; }
        public FavoritesModels(Favorites favorites)
        {
            id_davorites = favorites.id_davorites;
            id_user = favorites.id_user;
            id_beautiful_place = favorites.id_beautiful_place;
        }
    }
}