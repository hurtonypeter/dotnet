/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:DesktopApplication"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using DesktopApplication.BookService;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using AutoMapper;
using System;

namespace DesktopApplication.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
            ////}
            ////else
            ////{
            ////    // Create run time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DataService>();
            ////}

            SimpleIoc.Default.Register<IBookService, BookServiceClient>();
            SimpleIoc.Default.Register<IDummyClass, DummyClass>();

            SimpleIoc.Default.Register<MainWindowViewModel>();
            SimpleIoc.Default.Register<BookViewModel>();
            SimpleIoc.Default.Register<LendBookViewModel>();
            SimpleIoc.Default.Register<MembersViewModel>();

            Mapper.CreateMap<MembersViewModel, Member>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(s => s.MId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(s => s.MName))
                .ForMember(dest => dest.Barcode, opt => opt.MapFrom(s => s.MBarcode))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(s => s.MAddress))
                .ForMember(dest => dest.Telephone, opt => opt.MapFrom(s => s.MTelephone))
                .ForMember(dest => dest.Registration, opt => opt.MapFrom(s => DateTime.Now))
                .ForMember(dest => dest.RowVersion, opt => opt.MapFrom(s => s.MRowVersion))
                .IgnoreAllNonExisting();
        }

        public MainWindowViewModel Main
        {
            get { return ServiceLocator.Current.GetInstance<MainWindowViewModel>(); }
        }

        public BookViewModel BookView
        {
            get { return ServiceLocator.Current.GetInstance<BookViewModel>(); }
        }

        public LendBookViewModel LendBook
        {
            get { return ServiceLocator.Current.GetInstance<LendBookViewModel>(); }
        }

        public MembersViewModel Members
        {
            get { return ServiceLocator.Current.GetInstance<MembersViewModel>(); }
        }

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}