﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace TestNinja.Mocking
{
    public class VideoService
    {
        private IFileReader _fileReader;
        private IVideoRepo _repo;

        // null allow param to be optional 
        public VideoService(IFileReader fileReader, IVideoRepo repo = null)
        {
            _fileReader = fileReader ?? new FileReader();
            _repo = repo ?? new VideoRepo();
        }

        public string ReadVideoTitle()
        {
            // Mock IFileReader needs to be passed as a string
            var str = _fileReader.Read("video.txt");
            var video = JsonConvert.DeserializeObject<Video>(str);
            if (video == null)
                return "Error parsing the video.";
            return video.Title;
        }

        public string GetUnprocessedVideosAsCsv()
        {
            var videoIds = new List<int>();

            var videos = _repo.GetUnprocessedVids();
                foreach (var v in videos)
                    videoIds.Add(v.Id);

                return String.Join(",", videoIds);
           
        }
    }

    public class Video
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsProcessed { get; set; }
    }

    public class VideoContext : DbContext
    {
        public DbSet<Video> Videos { get; set; }
    }
}