using Autofac;
using FluentValidation;
using IMDB.BLL.Services.Abstract;
using IMDB.BLL.Services.Concrete;
using IMDB.BLL.Validation.EntitiesValidaton;
using IMDB.DAL.Repository.Abstract;
using IMDB.DAL.Repository.Concrete;
using IMDB.Entites.Entity;
using IMDB.Infrastructure.DTO;
using IMDB.Infrastructure.VM;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMDB.BLL.DependencyResolvers
{
   public class AutofacBusinessModel: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AppUserService>().As<IAppUserService>().InstancePerLifetimeScope();
            builder.RegisterType<CategoryService>().As<ICategoryService>().InstancePerLifetimeScope();
            builder.RegisterType<MovieUserService>().As<IMovieUserService>().InstancePerLifetimeScope();
            builder.RegisterType<MovieImageService>().As<IMovieImageService>().InstancePerLifetimeScope();
            builder.RegisterType<MovieService>().As<IMovieService>().InstancePerLifetimeScope();

            builder.RegisterType<MovieImageRepositoryEF>().As<IMovieImageRepository>().InstancePerLifetimeScope();
            builder.RegisterType<AppUserRepositoryEF>().As<IAppUserRepository>().InstancePerLifetimeScope();
            builder.RegisterType<MovieRepositoryEF>().As<IMovieRepository>().InstancePerLifetimeScope();
            builder.RegisterType<CategoryRepositoryEF>().As<ICategoryRepository>().InstancePerLifetimeScope();
            builder.RegisterType<UserMovieRepositoryEF>().As<IMovieUserRepository>().InstancePerLifetimeScope();
            builder.RegisterType<CategoryValidator>().As<IValidator<CategoryDTO>>().InstancePerLifetimeScope();
            builder.RegisterType<AppUserValidation>().As<IValidator<UserDTO>>().InstancePerLifetimeScope();
            builder.RegisterType<MoviesValidation>().As<IValidator<MovieDTO>>().InstancePerLifetimeScope();
            builder.RegisterType<RegisterValidation>().As<IValidator<RegisterVM>>().InstancePerLifetimeScope();
            builder.RegisterType<LoginValidation>().As<IValidator<LoginVM>>().InstancePerLifetimeScope();
            

        }
    }
}
