using GamingStore.BL.InerFaces;
using AutoMapper;
using GamingStore.BL.Services;
using GamingStore.DL.InerFaces;
using Moq;
using Gaming_Store_Data.Data;
using GamingStore2.AutoMap;
using Gaming_Store_Data.Request;

namespace Test
{
    public class GameServiceTest
    {
        private readonly Mock <IGameRepository> _gameRepository;
        private readonly IMapper _mapper;
        private readonly IGameService _gamingService;

        private IList<Game> Games = new List<Game>()
        {
            new Game()
            {
                Id = new Guid("439246d4-44c9-4353-8960-92ede9e6b3f2"),
                Developer = "deev 1",
                Title = "deev 1 "
            },
            new Game()
            {
                Id = new Guid("223f9029-5e80-4d89-af49-0a8cdb450728"),
                Developer = "deev 2",
                Title = "deev 2 Bio"
            }
        };

        public GameServiceTest()
        {
            var mockMapper =
                new MapperConfiguration(cfg =>
                {
                    cfg.AddProfiles(new[] { new AutoMapperConfigs() });
                });

            _mapper = mockMapper.CreateMapper();

            _gameRepository = new Mock<IGameRepository>();

            _gamingService =
                new GameService(
                    _gameRepository.Object, _mapper);
        }

        [Fact]
        public async Task GetAll_Test_Ok()
        {
            //setup
            var expectedCount = 2;

            _gameRepository.Setup(x =>
                x.GetAll())
                .Returns(async () =>
                    Games.AsEnumerable());

            //inject
            //Act
            var result =
                await _gamingService.GetAll();

            var enumerable = result.ToList();

            //Assert
            Assert.NotNull(result);
            Assert.Equal(expectedCount, enumerable.Count());
            Assert.Equal(Games, enumerable);
        }

        [Fact]
        public async Task GetById_Test_Ok()
        {
            //setup
            var gameId = Guid.NewGuid();

            _gameRepository.Setup(x =>
                x.GetById(gameId))
            .Returns(async () =>
                Games.FirstOrDefault(a => a.Id == gameId));

            //inject
            //Act
            var result = await _gamingService.GetById(gameId);

            //Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task GetById_Test_NotFound()
        {
            //setup
            var expectedId = Games[0].Id;
            var expectedName = $"@{Games[0].Title}";

            _gameRepository.Setup(x =>
                    x.GetById(expectedId))
                .Returns(async () =>
                    Games.FirstOrDefault(a => a.Id == expectedId));

            //inject
            //Act
            var result = await _gamingService.GetById(expectedId);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(expectedName, result.Title);
        }

        [Fact]
        public async Task AddGame_Test_Ok()
        {
            //setup
            var expectedCount = 3;
            var gameRequest = new AddGameRequest()
            {
                Description = "tit 3",
               Spacification = "op"
            };

            _gameRepository.Setup(x =>
                    x.Add(It.IsAny<Game>()))
                .Callback(() =>
                {
                    Games.Add(new Game()
                    {
                        Title = "tit",
                        Developer = "op"
                    });
                });


            //inject
            //Act
            var result =
                await _gamingService.AddGame(gameRequest);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(expectedCount, Games.Count);
        }
    }
}
