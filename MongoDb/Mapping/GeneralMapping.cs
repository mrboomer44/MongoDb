using MongoDb.Dtos.AboutListDto;
using MongoDb.Dtos.AboutSection1Dto;
using MongoDb.Dtos.AboutSection2Dto;
using MongoDb.Dtos.FaqDto;
using MongoDb.Dtos.FeatureDto;
using MongoDb.Dtos.OrderDto;
using MongoDb.Dtos.ProductDto;
using MongoDb.Dtos.SocialMediaDto;
using MongoDb.Dtos.StoryVideoDto;
using MongoDb.Dtos.SubscribeDto;
using MongoDb.Dtos.TestimonialDto;
using MongoDb.Dtos.LoginDto;
using MongoDb.Entities;
using AutoMapper;

namespace MongoDb.Mapping   
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Product, ResultProductDto>().ReverseMap();
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
            CreateMap<Product, GetProductByIdDto>().ReverseMap();

            CreateMap<Testimonial, ResultTestimonialDto>().ReverseMap();
            CreateMap<Testimonial, CreateTestimonialDto>().ReverseMap();
            CreateMap<Testimonial, UpdateTestimonialDto>().ReverseMap();
            CreateMap<Testimonial, GetTestimonialByIdDto>().ReverseMap();

            CreateMap<Feature, ResultFeatureDto>().ReverseMap();
            CreateMap<Feature, CreateFeatureDto>().ReverseMap();
            CreateMap<Feature, UpdateFeatureDto>().ReverseMap();
            CreateMap<Feature, GetFeatureByIdDto>().ReverseMap();

            CreateMap<AboutList, ResultAboutListDto>().ReverseMap();
            CreateMap<AboutList, CreateAboutListDto>().ReverseMap();
            CreateMap<AboutList, UpdateAboutListDto>().ReverseMap();
            CreateMap<AboutList, GetAboutListByIdDto>().ReverseMap();

            CreateMap<AboutSection1, ResultAboutSection1Dto>().ReverseMap();
            CreateMap<AboutSection1, CreateAboutSection1Dto>().ReverseMap();
            CreateMap<AboutSection1, UpdateAboutSection1Dto>().ReverseMap();

            CreateMap<AboutSection2, ResultAboutSection2Dto>().ReverseMap();
            CreateMap<AboutSection2, CreateAboutSection2Dto>().ReverseMap();
            CreateMap<AboutSection2, UpdateAboutSection2Dto>().ReverseMap();

            CreateMap<Faq, ResultFaqDto>().ReverseMap();
            CreateMap<Faq, CreateFaqDto>().ReverseMap();
            CreateMap<Faq, UpdateFaqDto>().ReverseMap();
            CreateMap<Faq, GetFaqByIdDto>().ReverseMap();

            CreateMap<Order, ResultOrderDto>().ReverseMap();
            CreateMap<Order, CreateOrderDto>().ReverseMap();
            CreateMap<Order, GetOrderByIdDto>().ReverseMap();

            CreateMap<SocialMedia, ResultSocialMediaDto>().ReverseMap();
            CreateMap<SocialMedia, CreateSocialMediaDto>().ReverseMap();
            CreateMap<SocialMedia, UpdateSocialMediaDto>().ReverseMap();

            CreateMap<StoryVideo, ResultStoryVideoDto>().ReverseMap();
            CreateMap<StoryVideo, CreateStoryVideoDto>().ReverseMap();
            CreateMap<StoryVideo, UpdateStoryVideoDto>().ReverseMap();

            CreateMap<Subscribe, ResultSubscribeDto>().ReverseMap();
            CreateMap<Subscribe, CreateSubscribeDto>().ReverseMap();

            CreateMap<Login, ResultLoginDto>().ReverseMap();
            CreateMap<Login, CreateLoginDto>().ReverseMap();
            CreateMap<Login, UpdateLoginDto>().ReverseMap();
            CreateMap<Login, GetLoginByIdDto>().ReverseMap();
        }
    }
}
