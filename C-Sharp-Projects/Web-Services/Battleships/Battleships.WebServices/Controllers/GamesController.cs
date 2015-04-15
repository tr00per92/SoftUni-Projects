namespace Battleships.WebServices.Controllers
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Web.Http;

    using Battleships.Data;
    using Battleships.Models;
    using Battleships.WebServices.Infrastructure;
    using Battleships.WebServices.Models;

    [Authorize]
    public class GamesController : BaseApiController
    {
        private readonly IUserIdProvider userIdProvider;
        
        public GamesController(IBattleshipsData data, IUserIdProvider userIdProvider) 
            : base(data)
        {
            this.userIdProvider = userIdProvider;
        }

        [HttpGet]
        [ActionName("Count")]
        public IHttpActionResult GetGamesCount()
        {
            var gamesCount = this.Data.Games.All().Count();

            return this.Ok(gamesCount);
        }

        [HttpPost]
        public IHttpActionResult Create()
        {
            var userId = this.userIdProvider.GetUserId();
            var game = new Game
            {
                PlayerOneId = userId,
                Field = InitializeField(11)
            };

            this.Data.Games.Add(game);
            this.Data.SaveChanges();

            return this.Ok(game.Id);
        }

        [HttpGet]
        [ActionName("Available")]
        public IHttpActionResult GetAllAvailableGames()
        {
            var games = this.Data.Games
                .All()
                .Where(x => x.State == GameState.WaitingForPlayer)
                .Select(x => new
                {
                    x.Id,
                    PlayerOne = x.PlayerOne.UserName,
                    State = x.State.ToString(),
                })
                .ToList();

            return this.Ok(games);
        }

        [HttpGet]
        [ActionName("Mine")]
        public IHttpActionResult GetUserGames()
        {
            var userId = this.userIdProvider.GetUserId();
            var games = this.Data.Games
                .All()
                .Where(x => (x.PlayerOneId == userId || x.PlayerTwoId == userId) &&
                    (x.State == GameState.TurnOne || x.State == GameState.TurnTwo))
                .Select(x => new
                {
                    x.Id,
                    PlayerOne = x.PlayerOne.UserName,
                    PlayerTwo = x.PlayerTwo.UserName,
                    State = x.State.ToString()
                })
                .ToList();

            return this.Ok(games);
        }

        [HttpGet]
        public IHttpActionResult GetField(string id)
        {
            var userId = this.userIdProvider.GetUserId();
            var game = this.Data.Games.FirstOrDefault(g => g.PlayerOneId == userId || g.PlayerTwoId == userId);
            if (game == null)
            {
                return this.BadRequest("You are not a part of such a game");
            }

            // replacing the ships with the empty field symbols
            return this.Ok(game.Field.Replace("S", "O"));
        }

        [HttpPost]
        public IHttpActionResult Join(JoinGameBindingModel model)
        {
            var guidGameId = new Guid(model.GameId);
            var game = this.Data.Games.FirstOrDefault(x => x.Id == guidGameId);
            if (game == null)
            {
                return this.NotFound();
            }

            var userId = this.userIdProvider.GetUserId();
            if (game.PlayerOneId == userId)
            {
                return this.BadRequest("You cannot join your own game.");
            }

            game.PlayerTwoId = userId;
            game.State = GameState.TurnOne;
            this.Data.SaveChanges();

            return this.Ok(game.Id);
        }

        [HttpPost]
        public IHttpActionResult Play(PlayTurnBindingModel model)
        {
            if (model == null)
            {
                this.ModelState.AddModelError("model", "The model is empty");
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var guidGameId = new Guid(model.GameId);
            var game = this.Data.Games.FirstOrDefault(x => x.Id == guidGameId);
            if (game == null)
            {
                return this.NotFound();
            }

            var userId = this.userIdProvider.GetUserId();
            if (game.PlayerOneId != userId && game.PlayerTwoId != userId)
            {
                return this.BadRequest("You do not play in this game.");
            }

            if ((game.PlayerOneId == userId && game.State == GameState.WonByOne) ||
                game.PlayerTwoId == userId && game.State == GameState.WonByTwo)
            {
                return this.BadRequest("You already won this game.");
            }

            if ((game.PlayerOneId == userId && game.State == GameState.WonByTwo) ||
                game.PlayerTwoId == userId && game.State == GameState.WonByOne)
            {
                return this.BadRequest("You lost this game.");
            }

            if ((game.PlayerOneId == userId && game.State == GameState.TurnTwo) || 
                (game.PlayerTwoId == userId && game.State == GameState.TurnOne))
            {
                return this.BadRequest("It's not your turn.");
            }

            var fieldSideLength = (int)Math.Sqrt(game.Field.Length);
            if (model.PositionX >= fieldSideLength || model.PositionY >= fieldSideLength)
            {
                return this.BadRequest("Invalid position.");
            }

            var fieldPosition = model.PositionX + (model.PositionY * fieldSideLength);
            if (game.Field[fieldPosition] == 'X')
            {
                return this.BadRequest("Position already bombed.");
            }

            var response = "You didn't hit anything.";
            if (game.Field[fieldPosition] == 'S')
            {
                if (game.PlayerOneId == userId)
                {
                    game.PlayerOnePoints++;
                }
                else
                {
                    game.PlayerTwoPoints++;
                }

                response = "You hit a ship. You get one point.";
            }

            var field = new StringBuilder(game.Field);
            field[fieldPosition] = 'X';
            game.Field = field.ToString();
            game.State = game.State == GameState.TurnOne ? GameState.TurnTwo : GameState.TurnOne;

            if (!game.Field.Contains('S'))
            {
                game.State = game.PlayerOnePoints > game.PlayerTwoPoints ? GameState.WonByOne : GameState.WonByTwo;
                response = "You Won.";
            }

            this.Data.SaveChanges();

            return this.Ok(response);
        }

        private static string InitializeField(int shipsCount)
        {
            var field = new StringBuilder(new string('O', 64));
            var random = new Random();
            while (shipsCount > 0)
            {
                var position = random.Next(64);
                if (field[position] != 'S')
                {
                    field[position] = 'S';
                    shipsCount--;
                }
            }

            return field.ToString();
        }
    }
}