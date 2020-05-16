using AutoMapper;
using IMDB.BLL.Services.Abstract;
using IMDB.BLL.ValueInjecter;
using IMDB.DAL.Repository.Abstract;
using IMDB.Entites.Entity;
using IMDB.Infrastructure.DTO;
using IMDB.Infrastructure.VM;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Omu.ValueInjecter;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace IMDB.BLL.Services.Concrete
{
    public class MovieService : IMovieService
    {
        private ICategoryService _categoryService;
        private IMovieImageService _movieImageService;
        private IMovieUserRepository _movieUserRepository;
        private IWebHostEnvironment Environment;
        private IMovieRepository movieRepository;
        private IMapper _map;
        private IAppUserRepository _appUserService;
        public MovieService(IMovieRepository _movieRepository, IWebHostEnvironment _Environment, IMapper map, IMovieUserRepository movieUserService, IAppUserRepository appUserService, IMovieImageService movieImageService, ICategoryService categoryService)
        {
            _categoryService = categoryService;
            _appUserService = appUserService;
            _movieUserRepository = movieUserService;
            Environment = _Environment;
            _map = map;
            movieRepository = _movieRepository;
            _movieImageService = movieImageService;
        }
        public void Add(MovieDTO model, string name, string descreption, string categoryName)
        {
            var category = _categoryService.GetByName(categoryName);
            model.CategoryId = category.Id;
            model.Name = name;
            model.Descreption = descreption;
            Movie movie = _map.Map<Movie>(model);
            movieRepository.Add(movie);
        }

        public void AddImage(List<IFormFile> files, int Id)
        {
            var movies = movieRepository.Get(x => x.Id == Id);
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
                    MovieImages movieImages = new MovieImages();
                    postedFile.CopyTo(stream);
                    _movieImageService.Add(movieImages, movies.Id, fileName);

                }
            }
        }
        public void Delete(int Id)
        {
            Movie movie = movieRepository.Get(x => x.Id == Id);
            movieRepository.Delete(movie);
        }
        public MovieDTO Details(int Id)
        {
            var movie = movieRepository.Get(x => x.Id == Id);
            movie.Images = _movieImageService.GetByMovies(Id);
            var member = _appUserService.GetByMovie(Id);
            MovieDTO model = _map.Map<MovieDTO>(movie);
            model.Member = member;
            return model;
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
            var movie = movieRepository.GetList().OrderByDescending(x=>x.AddedDate);
            foreach (var item in movie)
            {
                item.Images = _movieImageService.GetByMovies(item.Id);
            }
            List<MovieDTO> model = _map.Map<List<MovieDTO>>(movie);
            return model;
        }
        public MovieCategoryVM Update(int Id)
        {
            var movie = movieRepository.Get(x => x.Id == Id);
            var members = new List<AppUser>();
            var nonmembers = new List<AppUser>();
            var appuser = _appUserService.GetList();
            foreach (var item in appuser)
            {
                var list = _movieUserRepository.Any(x => x.AppUserId == item.Id && x.MovieId == movie.Id) ? members : nonmembers;
                list.Add(item);
            }
            var model = new MovieCategoryVM();
            model.Categories = _categoryService.GetList();
            model.Movie = _map.Map<MovieDTO>(movie);
            model.Movie.Member = members;
            model.Movie.NonMember = nonmembers;
            return model;

        }
        public void Update(MovieDTO model, int Id, string name, string descreption, string categoryName, string[] IdToAdd)
        {
            model.Id = Id;
            model.Name = name;
            model.Descreption = descreption;

            var kategori = _categoryService.GetByName(categoryName);
            model.CategoryId = kategori.Id;

            model.IdToAdd = IdToAdd;
            var movies = movieRepository.Get(x => x.Id == Id);
            foreach (var userId in model.IdToAdd ?? new string[] { })
            {
                AppUser appUser = _appUserService.Get(x => x.Id == userId);
                if (appUser != null)
                {
                    UserMovie movie = new UserMovie();
                    movie.AppUserId = appUser.Id;
                    movie.MovieId = model.Id;
                    _movieUserRepository.Add(movie);
                }
            }
            movies.InjectFrom<FilterId>(model);
            movieRepository.Update(movies);
        }
    }
}
