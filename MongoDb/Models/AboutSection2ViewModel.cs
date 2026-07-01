using MongoDb.Dtos.AboutListDto;
using MongoDb.Dtos.AboutSection2Dto;

namespace MongoDb.Models
{
    public class AboutSection2ViewModel
    {
        public ResultAboutSection2Dto AboutSection2 { get; set; }
        public List<ResultAboutListDto> AboutList { get; set; }
    }
}
