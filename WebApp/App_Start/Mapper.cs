using AutoMapper;
using ToolsApp.EntityFramework;
using ToolsApp.Models;


namespace ToolsApp.App_Start
{
    public static class Mapper
    {
        private static IMapper _mapper;
        public static void RegisterMappings()
        {
            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                #region User
                cfg.CreateMap<User, QL_UserViewModel>()
                                .ForMember(dto => dto.Id, opt => opt.MapFrom(src => src.Id))
                                .ForMember(dto => dto.Username, opt => opt.MapFrom(src => src.UserName))
                                .ForMember(dto => dto.HoNV, opt => opt.MapFrom(src => src.HoNV))
                                .ForMember(dto => dto.TenNV, opt => opt.MapFrom(src => src.TenNV))
                                .ForMember(dto => dto.Email, opt => opt.MapFrom(src => src.Email));

                cfg.CreateMap<QL_UserViewModel, User>()
                                .ForMember(dto => dto.Id, opt => opt.MapFrom(src => src.Id))
                          .ForMember(dto => dto.HoNV, opt => opt.MapFrom(src => src.HoNV))
                                .ForMember(dto => dto.TenNV, opt => opt.MapFrom(src => src.TenNV))
                                .ForMember(dto => dto.TenNV, opt => opt.MapFrom(src => src.HoNV))
                                .ForMember(dto => dto.Email, opt => opt.MapFrom(src => src.Email));
                #endregion

                #region Page
                cfg.CreateMap<Page, QLKTPPageViewModel>()
                                .ForMember(dto => dto.Id, opt => opt.MapFrom(src => src.Id))
                                .ForMember(dto => dto.Controler, opt => opt.MapFrom(src => src.Controler))
                                .ForMember(dto => dto.Action, opt => opt.MapFrom(src => src.Action))
                                .ForMember(dto => dto.Code, opt => opt.MapFrom(src => src.Code))
                                .ForMember(dto => dto.Info, opt => opt.MapFrom(src => src.Info))
                                .ForMember(dto => dto.UserCreate, opt => opt.MapFrom(src => src.UserCreate))
                                .ForMember(dto => dto.DatetimeCreate, opt => opt.MapFrom(src => src.DatetimeCreate))
                                .ForMember(dto => dto.UserUpdate, opt => opt.MapFrom(src => src.UserUpdate))
                                .ForMember(dto => dto.DatetimeUpdate, opt => opt.MapFrom(src => src.DatetimeUpdate))
                                .ForMember(dto => dto.isDelete, opt => opt.MapFrom(src => src.isDelete))
                                .ForMember(dto => dto.UserDelete, opt => opt.MapFrom(src => src.UserDelete))
                                .ForMember(dto => dto.DatetimeDelete, opt => opt.MapFrom(src => src.DatetimeDelete));

                cfg.CreateMap<QLKTPPageViewModel, Page>()
                                .ForMember(dto => dto.Id, opt => opt.MapFrom(src => src.Id))
                                .ForMember(dto => dto.Controler, opt => opt.MapFrom(src => src.Controler))
                                .ForMember(dto => dto.Action, opt => opt.MapFrom(src => src.Action))
                                .ForMember(dto => dto.Code, opt => opt.MapFrom(src => src.Code))
                                .ForMember(dto => dto.Info, opt => opt.MapFrom(src => src.Info))
                                .ForMember(dto => dto.UserCreate, opt => opt.MapFrom(src => src.UserCreate))
                                .ForMember(dto => dto.DatetimeCreate, opt => opt.MapFrom(src => src.DatetimeCreate))
                                .ForMember(dto => dto.UserUpdate, opt => opt.MapFrom(src => src.UserUpdate))
                                .ForMember(dto => dto.DatetimeUpdate, opt => opt.MapFrom(src => src.DatetimeUpdate))
                                .ForMember(dto => dto.isDelete, opt => opt.MapFrom(src => src.isDelete))
                                .ForMember(dto => dto.UserDelete, opt => opt.MapFrom(src => src.UserDelete))
                                .ForMember(dto => dto.DatetimeDelete, opt => opt.MapFrom(src => src.DatetimeDelete));
                #endregion

                #region Menu
                cfg.CreateMap<Menu, QLKTPMenuViewModel>()
                                .ForMember(dto => dto.Id, opt => opt.MapFrom(src => src.Id))
                                .ForMember(dto => dto.MenuName, opt => opt.MapFrom(src => src.MenuName))
                                .ForMember(dto => dto.ParentId, opt => opt.MapFrom(src => src.ParentId))
                                .ForMember(dto => dto.PageId, opt => opt.MapFrom(src => src.PageId))
                                .ForMember(dto => dto.Icon, opt => opt.MapFrom(src => src.Icon))
                                .ForMember(dto => dto.OrderNo, opt => opt.MapFrom(src => src.OrderNo))
                                .ForMember(dto => dto.UserCreate, opt => opt.MapFrom(src => src.UserCreate))
                                .ForMember(dto => dto.DatetimeCreate, opt => opt.MapFrom(src => src.DatetimeCreate))
                                .ForMember(dto => dto.UserUpdate, opt => opt.MapFrom(src => src.UserUpdate))
                                .ForMember(dto => dto.DatetimeUpdate, opt => opt.MapFrom(src => src.DatetimeUpdate))
                                .ForMember(dto => dto.isDelete, opt => opt.MapFrom(src => src.isDelete))
                                .ForMember(dto => dto.UserDelete, opt => opt.MapFrom(src => src.UserDelete))
                                .ForMember(dto => dto.DatetimeDelete, opt => opt.MapFrom(src => src.DatetimeDelete));

                cfg.CreateMap<QLKTPMenuViewModel, Menu>()
                                .ForMember(dto => dto.Id, opt => opt.MapFrom(src => src.Id))
                                .ForMember(dto => dto.MenuName, opt => opt.MapFrom(src => src.MenuName))
                                .ForMember(dto => dto.ParentId, opt => opt.MapFrom(src => src.ParentId))
                                .ForMember(dto => dto.PageId, opt => opt.MapFrom(src => src.PageId))
                                .ForMember(dto => dto.Icon, opt => opt.MapFrom(src => src.Icon))
                                .ForMember(dto => dto.OrderNo, opt => opt.MapFrom(src => src.OrderNo))
                                .ForMember(dto => dto.UserCreate, opt => opt.MapFrom(src => src.UserCreate))
                                .ForMember(dto => dto.DatetimeCreate, opt => opt.MapFrom(src => src.DatetimeCreate))
                                .ForMember(dto => dto.UserUpdate, opt => opt.MapFrom(src => src.UserUpdate))
                                .ForMember(dto => dto.DatetimeUpdate, opt => opt.MapFrom(src => src.DatetimeUpdate))
                                .ForMember(dto => dto.isDelete, opt => opt.MapFrom(src => src.isDelete))
                                .ForMember(dto => dto.UserDelete, opt => opt.MapFrom(src => src.UserDelete))
                                .ForMember(dto => dto.DatetimeDelete, opt => opt.MapFrom(src => src.DatetimeDelete));
                #endregion






            })
            {

            };
            _mapper = mapperConfiguration.CreateMapper();
        }

        //internal static object MapFrom(Qr_Event model)
        //{
        //    throw new NotImplementedException();
        //}

        #region User
        public static QL_UserViewModel MapFrom(User data)
        {
            return _mapper.Map<User, QL_UserViewModel>(data);
        }
        public static User MapFrom(QL_UserViewModel data)
        {
            return _mapper.Map<QL_UserViewModel, User>(data);
        }
        public static User MapFrom(QL_UserViewModel data_view, User data_entity)
        {
            return _mapper.Map(data_view, data_entity);
        }
        #endregion

        #region Page
        public static QLKTPPageViewModel MapFrom(Page data)
        {
            return _mapper.Map<Page, QLKTPPageViewModel>(data);
        }
        public static Page MapFrom(QLKTPPageViewModel data)
        {
            return _mapper.Map<QLKTPPageViewModel, Page>(data);
        }
        public static Page MapFrom(QLKTPPageViewModel data_view, Page data_entity)
        {
            return _mapper.Map(data_view, data_entity);
        }
        #endregion


        #region Menu
        public static QLKTPMenuViewModel MapFrom(Menu data)
        {
            return _mapper.Map<Menu, QLKTPMenuViewModel>(data);
        }
        public static Menu MapFrom(QLKTPMenuViewModel data)
        {
            return _mapper.Map<QLKTPMenuViewModel, Menu>(data);
        }
        public static Menu MapFrom(QLKTPMenuViewModel data_view, Menu data_entity)
        {
            return _mapper.Map(data_view, data_entity);
        }
        #endregion


    }
}