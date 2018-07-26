using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNinja.Mocking
{
    public interface IVideoRepo
    {
        IEnumerable<Video> GetUnprocessedVids();
    }

    class VideoRepo : IVideoRepo
    {
        public IEnumerable<Video> GetUnprocessedVids()
        {
            using (var context = new VideoContext())
            {
                var videos =
                    (from video in context.Videos
                        where !video.IsProcessed
                        select video).ToList();
                return videos;
            }           
        }
    }
}
