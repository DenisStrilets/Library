using AutoMapper;
using BookingAppStore4.DALNew.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Enums;
using ViewModel.Models;

namespace BookingAppStore4.DALNew
{
    public static class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Author, AuthorViewModel>();
                cfg.CreateMap<AuthorViewModel, Author>();

                cfg.CreateMap<Book, BookViewModel>();
                cfg.CreateMap<BookViewModel, Book>();

                cfg.CreateMap<Author, RedactionViewModel>();
                cfg.CreateMap<RedactionViewModel, Author>();

                cfg.CreateMap<Brochure, BrochureViewModel>();
                cfg.CreateMap<BrochureViewModel, Brochure>();

                cfg.CreateMap<Gournal, GournalViewModel>();
                cfg.CreateMap<GournalViewModel, Gournal>();

                cfg.CreateMap<Publication, PublicationViewModel>();
                cfg.CreateMap<PublicationViewModel, Publication>();

                cfg.CreateMap<Book, LibraryViewModel>()
             .ForMember(dest => dest.Name, opt => opt.ResolveUsing(src => src.Name))
             .ForMember(dest => dest.Price, opt => opt.ResolveUsing(src => src.Price))
             .ForMember(dest => dest.Image64, opt => opt.ResolveUsing(src => src.Image64))
             .ForMember(dest => dest.Type, opt => opt.ResolveUsing(src => (LibraryType)src.Type));

                cfg.CreateMap<Brochure, LibraryViewModel>()
               .ForMember(dest => dest.Name, opt => opt.ResolveUsing(src => src.Name))
               .ForMember(dest => dest.Price, opt => opt.ResolveUsing(src => src.Price))
               .ForMember(dest => dest.Image64, opt => opt.ResolveUsing(src => src.Image64))
               .ForMember(dest => dest.Type, opt => opt.ResolveUsing(src => (LibraryType)src.Type));

                cfg.CreateMap<Publication, LibraryViewModel>()
            .ForMember(dest => dest.Name, opt => opt.ResolveUsing(src => src.Name))
            .ForMember(dest => dest.Price, opt => opt.ResolveUsing(src => src.Price))
            .ForMember(dest => dest.Image64, opt => opt.ResolveUsing(src => src.Image64))
            .ForMember(dest => dest.Type, opt => opt.ResolveUsing(src => (LibraryType)src.Type));

                cfg.CreateMap<Gournal, LibraryViewModel>()
                            .ForMember(dest => dest.Name, opt => opt.ResolveUsing(src => src.Name))
                            .ForMember(dest => dest.Price, opt => opt.ResolveUsing(src => src.Price))
                            .ForMember(dest => dest.Image64, opt => opt.ResolveUsing(src => src.Image64))
                            .ForMember(dest => dest.Type, opt => opt.ResolveUsing(src => (LibraryType)src.Type));

            });

        }

    }
}

