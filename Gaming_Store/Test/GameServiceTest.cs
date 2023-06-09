using Moq;
using GamingStore.BL.Interfaces;
using GamingStore.BL.Services;
using GamingStore.DL.Interfaces;
using Gaming_Store_Data.Data;
using Gaming_Store_Data.Request;
using AutoMapper;
using Gaming_Store.AutoMap;

namespace GameStore.Test
{
    public class GameServiceTest
    {
        private readonly Mock<IGameRepository> _gameRepository;
        private readonly IMapper _mapper;
        private readonly IGameService _gameService;

        private IList<Game> Games = new List<Game>()
        {
            new Game()
            {
                Id = new Guid("439246d4-44c9-4353-8960-92ede9e6b3f2"),
                Name = "game 1",
                Developer = "Brand"
            },
            new Game()
            {
                Id = new Guid("223f9029-5e80-4d89-af49-0a8cdb450728"),
                Name = "game 2",
                Developer = "Brand"
            }
        };

        public GameServiceTest()
        {
            var mockMapper =
                new MapperConfiguration(cfg =>
                {
                    cfg.AddProfiles(new[] { new AutoMapperConfig() });
                });

            _mapper = mockMapper.CreateMapper();

            _gameRepository = new Mock<IGameRepository>();

            _gameService =
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
                await _gameService.GetAll();

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
            var result = await _gameService.GetById(gameId);

            //Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task GetById_Test_NotFound()
        {
            //setup
            var expectedId = Games[0].Id;
            var expectedName = $"@{Games[0].Name}";

            _gameRepository.Setup(x =>
                    x.GetById(expectedId))
                .Returns(async () =>
                    Games.FirstOrDefault(a => a.Id == expectedId));

            //inject
            //Act
            var result = await _gameService.GetById(expectedId);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(expectedName, result.Name);
        }

        [Fact]
        public async Task AddGame_Test_Ok()
        {
            //setup
            var expectedCount = 3;
            var gameRequest = new AddGameRequest()
            {
                Name = "Game 3",
                Developer = "Brand "
            };

            _gameRepository.Setup(x =>
                    x.AddGame(It.IsAny<Game>()))
                .Callback(() =>
                {
                    Games.Add(new Game()
                    {
                        Name = "Game 3",
                        Developer = "Brand"
                    });
                });


            //inject
            //Act
            var result =
                await _gameService.AddGame(gameRequest);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(expectedCount, Games.Count);
        }
    }
}
