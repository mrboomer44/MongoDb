using MongoDb.Dtos.FeatureDto;
using MongoDb.Dtos.LoginDto;
using MongoDb.Entities;
using MongoDb.Settings;
using AutoMapper;
using MongoDB.Driver;

namespace MongoDb.Services.LoginServices
{
    public class LoginServices : ILoginServices
    {
        private readonly IMongoCollection<Login> loginCollection;
        private readonly IMapper mapper;


        public LoginServices(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            loginCollection = database.GetCollection<Login>(databaseSettings.LoginCollectionName);
            this.mapper = mapper;
        }

        public async Task CreateLoginAsync(CreateLoginDto createLoginDto)
        {
            var value = mapper.Map<Login>(createLoginDto);
            await loginCollection.InsertOneAsync(value);
        }

        public async Task<List<ResultLoginDto>> GetAllLoginsAsync()
        {
            var values = await loginCollection.Find(x => true).ToListAsync();
            return mapper.Map<List<ResultLoginDto>>(values);
        }

        public Task UpdateLoginAsync(UpdateLoginDto updateLoginDto)
        {
            var value = mapper.Map<Login>(updateLoginDto);
            return loginCollection.ReplaceOneAsync(x => x.LoginId == updateLoginDto.LoginId, value);
        }

        public async Task<GetLoginByIdDto> GetLoginByIdDto(string id)
        {
            var value = await loginCollection.Find(x => x.LoginId == id).FirstOrDefaultAsync();
            return mapper.Map<GetLoginByIdDto>(value);
        }
    }
}
