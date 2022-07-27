using System;

using Unity;
using WebBanHangMcv.Models;
using WebBanHangMcv.Services.AboutService;
using WebBanHangMcv.Services.CategoryService;
using WebBanHangMcv.Services.ContactService;
using WebBanHangMcv.Services.ContentService;
using WebBanHangMcv.Services.ContentTagService;
using WebBanHangMcv.Services.FeedbackServices;
using WebBanHangMcv.Services.FooterServices;
using WebBanHangMcv.Services.LanguageServices;
using WebBanHangMcv.Services.MenuServices;
using WebBanHangMcv.Services.MenuTypeServices;
using WebBanHangMcv.Services.OrderDetailServices;
using WebBanHangMcv.Services.OrderSrevices;
using WebBanHangMcv.Services.ProductCategorySrevices;
using WebBanHangMcv.Services.ProductServices;
using WebBanHangMcv.Services.SlideServices;
using WebBanHangMcv.Services.TemporaryShoppingCartServices;
using WebBanHangMcv.Services.UserSrevices;
using WebQuanLayBanHangEntityFramework;

namespace WebBanHangMcv
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your type's mappings here.
            // container.RegisterType<IProductRepository, ProductRepository>();

            container.RegisterType<IRepository, Repository<OnlineShopEntities>>();
            container.RegisterType<IBaseService, BaseService>();
            container.RegisterType(typeof(IGenericService<>), typeof(GenericService<>));

            container.RegisterType<IAboutService, AboutServices>();
            container.RegisterType<ICategoryServices, CategoryService>();
            container.RegisterType<IContactService, ContactServices>();

            container.RegisterType<IContentService, ContentServices>();
            container.RegisterType<IContentTagServices, ContentTagServices>();
            container.RegisterType<IFeedbackServices, FeedbackService>();

            container.RegisterType<IFooterSrevices, FooterSrevice>();
            container.RegisterType<ILanguageServices, LanguageService>();
            container.RegisterType<IMenuServices, MenuService>();

            container.RegisterType<IMenuTypeServices, MenuTypeServices>();
            container.RegisterType<IOrderDetailServices, OrderDetailService>();
            container.RegisterType<IOrderSrevices, OrderSrevice>();

            container.RegisterType<IProductCategorySrevices, ProductCategorySrevice>();
            container.RegisterType<IProducSrevices, ProductSercie>();
            container.RegisterType<IUserSercies, UserSercie>();
            container.RegisterType<ISlideServices, SlideService>();

            container.RegisterType<ITemporaryShoppingCartServices, TemporaryShoppingCartServices>();
        }
    }
}