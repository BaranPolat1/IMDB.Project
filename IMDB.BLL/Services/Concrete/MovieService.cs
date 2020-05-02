using AutoMapper;
using IMDB.BLL.Services.Abstract;
using IMDB.BLL.ValueInjecter;
using IMDB.DAL.Repository.Abstract;
using IMDB.Entites.Entity;
using IMDB.Infrastructure.DTO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Omu.ValueInjecter;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace IMDB.BLL.Services.Concrete
{
    public class MovieService : IMovieService
    {
        private IWebHostEnvironment Environment;
        private IMovieRepository movieRepository;
        private IMapper _map;
        public MovieService(IMovieRepository _movieRepository,  IMovieUserService _movieUserService, IWebHostEnvironment _Environment, IMapper map)
        {
            Environment = _Environment;
            _map = map;
            movieRepository = _movieRepository;
        }
        public void Add(MovieDTO model,int categoryId, List<IFormFile> files,string name,string descreption)
        {
            model.Name = name;
            model.CategoryId = categoryId;
            model.Descreption = descreption;
            string uploadDir = Path.Combine(Environment.WebRootPath, "media/movie");
            if (!Directory.Exists(uploadDir))
            {
                Directory.CreateDirectory(uploadDir);
            }
            foreach (IFormFile postedFile in files)
            {
                string fileName = Path.GetFileName(postedFile.FileName);
                using (FileStream stream = new FileStream(Path.Combine(uploadDir, fileName), FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                    model.ImagePaths.Add(fileName);
                }
            }
            Movie movie = new Movie();
            movie.InjectFrom(model);
            movieRepository.Add(movie);
          
        }

        public void Delete(int Id)
        {
            Movie movie =movieRepository.Get(x => x.Id == Id);
            movieRepository.Delete(movie);
        }

        public ICollection<MovieDTO> GetByCategory(int categoryId)
        {
            var movie = movieRepository.GetList(x => x.CategoryId == categoryId);
            List<MovieDTO> model = _map.Map<List<MovieDTO>>(movie);
            return model;
        }

        public MovieDTO GetById(int id)
        {
            var movie = movieRepository.Get(x => x.Id == id);
            MovieDTO model = new MovieDTO();
            model.InjectFrom(movie);
            return model;
        }

        public MovieDTO GetByName(string name)
        {
            var movie = movieRepository.Get(x => x.Name == name);
            MovieDTO model = new MovieDTO();
            model.InjectFrom(movie);
            return model;
        }

        public ICollection<MovieDTO> GetByStarOrDirector(string userId)
        {
            var movie = movieRepository.GetByStarOrDirector(userId);
            List<MovieDTO> model = _map.Map<List<MovieDTO>>(movie);
            return model;
        }

        public ICollection<MovieDTO> GetList()
        {
            var movie = movieRepository.GetList();
            List<MovieDTO> model = _map.Map<List<MovieDTO>>(movie);
            return model;
        }

        public void Update(MovieDTO model,int categoryId, List<IFormFile> files, string name, string descreption)
        {
            if (files != null)
            {
                string uploadDir = Path.Combine(Environment.WebRootPath, "media/movie");
                if (!Directory.Exists(uploadDir))
                {
                    Directory.CreateDirectory(uploadDir);
                }
                foreach (IFormFile postedFile in files)
                {
                    string fileName = Path.GetFileName(postedFile.FileName);
                    using (FileStream stream = new FileStream(Path.Combine(uploadDir, fileName), FileMode.Create))
                    {
                        postedFile.CopyTo(stream);
                        model.ImagePaths.Add(fileName);
                    }
                }
            }
            Movie movie = movieRepository.Get(x => x.Id == model.Id);
            movie.InjectFrom<FilterId>(model);
            movieRepository.Update(movie);
        }
    }
}
