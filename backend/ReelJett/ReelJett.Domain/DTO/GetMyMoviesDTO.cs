using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReelJett.Domain.DTO
{
    public class GetMyMoviesDTO
    {
        public string Id { get; set; }
        public string PublishDate { get; set; }
        public string Poster { get; set; }
        public string Description { get; set; }
        public string PublishState { get; set; }
        public string Link { get; set; }
        public string Title { get; set; }
        public int ViewCount { get; set; }
        public int LikeCount { get; set; }
        public int DislikeCount { get; set; }
        public int CommentCount { get; set; }
    }
}
