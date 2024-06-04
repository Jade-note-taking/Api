namespace JadeApi.Data;

public static class JadeDbData
{
    // #region Users
    //
    // private static readonly User manager = new()
    // {
    //     Id = Guid.NewGuid(),
    //     Name = "Manager",
    //     Email = "manager@netjesavans.nl",
    //     Password = "testing123",
    //     Role = Role.MANAGER
    // };
    //
    // private static readonly User cashier = new()
    // {
    //     Id = Guid.NewGuid(),
    //     Name = "Cashier",
    //     Email = "cashier@netjesavans.nl",
    //     Password = "testing123",
    //     Role = Role.CASHIER
    // };
    // private static readonly User backoffice = new()
    // {
    //     Id = Guid.NewGuid(),
    //     Name = "Backoffice",
    //     Email = "backoffice@netjesavans.nl",
    //     Password = "testing123",
    //     Role = Role.BACKOFFICE
    // };
    //
    // #endregion
    // public static readonly List<User> Users = [manager, cashier, backoffice];
    //
    // #region Showings
    //
    // private static readonly Showing showing1 = new()
    // {
    //     Id = Guid.NewGuid(),
    //     Name = "Top Gun: Maverick",
    //     Description = "Thirty years of service leads Maverick to train a group of elite TOPGUN graduates to prepare for a high-profile mission while Maverick battles his past demons.",
    //     ImagePath = "https://m.media-amazon.com/images/I/71BokibfVUL._AC_SL1500_.jpg",
    //     Start = new DateTime(2025, 2, 25, 16, 0, 0),
    //     Type = Type.Movie,
    //     Genre = "Action"
    // };
    //
    // private static readonly Showing showing2 = new()
    // {
    //     Id = Guid.NewGuid(),
    //     Name = "Inception",
    //     Description = "A skilled thief enters the dreams of others to steal their deepest secrets, but he is tasked with planting an idea into the mind of a CEO.",
    //     ImagePath = "https://m.media-amazon.com/images/I/714b1KQmskL.jpg",
    //     Start = new DateTime(2024, 7, 16, 19, 30, 0),
    //     Type = Type.Movie,
    //     Genre = "Sci-fi"
    // };
    //
    // private static readonly Showing showing3 = new()
    // {
    //     Id = Guid.NewGuid(),
    //     Name = "The Dark Knight",
    //     Description = "Batman faces the chaotic Joker, who seeks to create anarchy in Gotham City, pushing the caped crusader to his limits.",
    //     ImagePath = "https://img.posterstore.com/zoom/wb0037-8batman-thedarkknightrises50x70.jpg",
    //     Start = new DateTime(2024, 7, 18, 18, 15, 0),
    //     Type = Type.Movie,
    //     Genre = "Romance"
    // };
    //
    // private static readonly Showing showing4 = new()
    // {
    //     Id = Guid.NewGuid(),
    //     Name = "Jurassic Park",
    //     Description = "A theme park with genetically engineered dinosaurs goes awry, putting the lives of visitors and staff in grave danger.",
    //     ImagePath = "https://m.media-amazon.com/images/I/71+csl5-uEL._AC_UF894,1000_QL80_.jpg",
    //     Start = new DateTime(2024, 6, 11, 20, 0, 0),
    //     Type = Type.Movie,
    //     Genre = "Adventure"
    // };
    //
    // private static readonly Showing showing5 = new()
    // {
    //     Id = Guid.NewGuid(),
    //     Name = "The Shawshank Redemption",
    //     Description = "A man is wrongly convicted of murder and befriends a fellow inmate as he plans his escape from Shawshank State Penitentiary.",
    //     ImagePath = "https://m.media-amazon.com/images/I/71JxA6I+sgL._AC_UF1000,1000_QL80_.jpg",
    //     Start = new DateTime(2024, 9, 23, 21, 45, 0),
    //     Type = Type.Movie,
    //     Genre = "Action"
    // };
    //
    // private static readonly Showing showing6 = new()
    // {
    //     Id = Guid.NewGuid(),
    //     Name = "Interstellar",
    //     Description = "A group of astronauts embarks on a journey through a wormhole to find a new habitable planet for humanity as Earth faces an environmental crisis.",
    //     ImagePath = "https://m.media-amazon.com/images/I/71thymE6lwL._AC_UF1000,1000_QL80_.jpg",
    //     Start = new DateTime(2024, 11, 7, 17, 30, 0),
    //     Type = Type.Movie,
    //     Genre = "Action"
    // };
    //
    // private static readonly Showing showing7 = new()
    // {
    //     Id = Guid.NewGuid(),
    //     Name = "Avatar",
    //     Description = "In a distant future, a paraplegic marine is dispatched to the moon Pandora, where he becomes torn between following orders and protecting the alien civilization.",
    //     ImagePath = "https://static.posters.cz/image/750/posters/avatar-limited-ed-one-sheet-sun-i7182.jpg",
    //     Start = new DateTime(2025, 12, 18, 22, 0, 0),
    //     Type = Type.Movie,
    //     Genre = "Sci-fi"
    // };
    //
    // private static readonly Showing showing8 = new()
    // {
    //     Id = Guid.NewGuid(),
    //     Name = "The Matrix",
    //     Description = "A computer hacker discovers the shocking truth about his reality and joins a group of rebels in a battle against powerful machines controlling humanity.",
    //     ImagePath = "https://m.media-amazon.com/images/I/91SZzvt+w4L._AC_UF894,1000_QL80_.jpg",
    //     Start = new DateTime(2025, 3, 31, 20, 45, 0),
    //     Type = Type.Movie,
    //     Genre = "Action"
    // };
    //
    // private static readonly Showing showing9 = new()
    // {
    //     Id = Guid.NewGuid(),
    //     Name = "Forrest Gump",
    //     Description = "The life story of a man with a low IQ but good intentions, who unwittingly influences several defining moments in American history.",
    //     ImagePath = "https://m.media-amazon.com/images/I/41Al9falobL._AC_UF894,1000_QL80_.jpg",
    //     Start = new DateTime(2025, 7, 6, 15, 15, 0),
    //     Type = Type.Movie,
    //     Genre = "Adventure"
    // };
    //
    // private static readonly Showing showing10 = new()
    // {
    //     Id = Guid.NewGuid(),
    //     Name = "Eternal Sunshine of the Spotless Mind",
    //     Description = "A couple undergoes a procedure to erase the memories of each other after a painful breakup, only to rediscover their love for one another.",
    //     ImagePath = "https://m.media-amazon.com/images/M/MV5BMTY4NzcwODg3Nl5BMl5BanBnXkFtZTcwNTEwOTMyMw@@._V1_.jpg",
    //     Start = new DateTime(2025, 3, 19, 18, 30, 0),
    //     Type = Type.Movie,
    //     Genre = "Romance"
    // };
    //
    // #endregion
    // public static readonly List<Showing> Showings = [showing1, showing2, showing3, showing4, showing5, showing6, showing7, showing8, showing9, showing10];
    //
    // #region Rooms
    //
    // private static readonly Room room1 = new()
    // {
    //     Id = Guid.NewGuid(),
    //     Name = "Room 1",
    //     SeatingArrangement = GenerateSeatingArrangement(8, 15)
    // };
    //
    // private static readonly Room room2 = new()
    // {
    //     Id = Guid.NewGuid(),
    //     Name = "Room 2",
    //     SeatingArrangement = GenerateSeatingArrangement(8, 15)
    // };
    //
    // private static readonly Room room3 = new()
    // {
    //     Id = Guid.NewGuid(),
    //     Name = "Room 3",
    //     SeatingArrangement = GenerateSeatingArrangement(8, 15)
    // };
    //
    // private static readonly Room room4 = new()
    // {
    //     Id = Guid.NewGuid(),
    //     Name = "Room 4",
    //     SeatingArrangement = GenerateSeatingArrangement(6, 10)
    // };
    //
    // private static readonly Room room5 = new()
    // {
    //     Id = Guid.NewGuid(),
    //     Name = "Room 5",
    //     SeatingArrangement = GenerateCombinedSeatingArrangement(2, 10, 2, 15)
    // };
    //
    // private static readonly Room room6 = new()
    // {
    //     Id = Guid.NewGuid(),
    //     Name = "Room 6",
    //     SeatingArrangement = GenerateCombinedSeatingArrangement(2, 10, 2, 15)
    // };
    //
    // // Function to generate seating arrangement as a 2-dimensional array
    // private static string GenerateSeatingArrangement(int rows, int seatsPerRow)
    // {
    //     int[][] seatingArrangement = new int[rows][];
    //     int seatCount = 0;
    //     for (int i = 0; i < rows; i++)
    //     {
    //         seatingArrangement[i] = new int[seatsPerRow];
    //         for (int j = 0; j < seatsPerRow; j++)
    //         {
    //             seatingArrangement[i][j] = seatCount++ % 10;
    //         }
    //     }
    //     return JsonConvert.SerializeObject(seatingArrangement);;
    // }
    //
    // private static string GenerateCombinedSeatingArrangement(int rows1, int seatsPerRow1, int rows2, int seatsPerRow2)
    // {
    //     // Calculate the total number of rows and seats per row in the combined arrangement. This function does have a bug!
    //     int totalRows = rows1 + rows2;
    //     int maxSeatsPerRow = Math.Max(seatsPerRow1, seatsPerRow2);
    //
    //     // Initialize the combined seating arrangement
    //     int[][] combinedSeatingArrangement = new int[totalRows][];
    //     int seatCount = 0;
    //
    //     // Generate the first seating arrangement
    //     for (int i = 0; i < rows1; i++)
    //     {
    //         combinedSeatingArrangement[i] = new int[seatsPerRow1];
    //         for (int j = 0; j < seatsPerRow1; j++)
    //         {
    //             combinedSeatingArrangement[i][j] = seatCount++ % 10;
    //         }
    //     }
    //
    //     // Generate the second seating arrangement and append it to the combined arrangement
    //     for (int i = rows1; i < totalRows; i++)
    //     {
    //         combinedSeatingArrangement[i] = new int[maxSeatsPerRow];
    //         for (int j = 0; j < seatsPerRow2; j++)
    //         {
    //             combinedSeatingArrangement[i][j] = seatCount++ % 10;
    //         }
    //     }
    //
    //     return JsonConvert.SerializeObject(combinedSeatingArrangement);;
    // }
    //
    // #endregion
    // public static readonly List<Room> Rooms = [room1, room2, room3, room4, room5, room6];
    //
    // #region Shows
    //
    // private static readonly UpcomingShow show1 = new()
    // {
    //     Id = Guid.NewGuid(),
    //     RoomId = room1.Id,
    //     ShowingId = showing1.Id,
    //     StartTime = DateTime.UtcNow.Subtract(TimeSpan.FromDays(158)),
    //     EndTime = DateTime.UtcNow.Add(TimeSpan.FromDays(250)),
    // };
    //
    // private static readonly UpcomingShow show2 = new()
    // {
    //     Id = Guid.NewGuid(),
    //     RoomId = room5.Id,
    //     ShowingId = showing3.Id,
    //     StartTime = DateTime.UtcNow.Subtract(TimeSpan.FromDays(50)),
    //     EndTime = DateTime.UtcNow.Add(TimeSpan.FromDays(120)),
    // };
    //
    // private static readonly UpcomingShow show3 = new()
    // {
    //     Id = Guid.NewGuid(),
    //     RoomId = room6.Id,
    //     ShowingId = showing6.Id,
    //     StartTime = DateTime.UtcNow.Subtract(TimeSpan.FromDays(5)),
    //     EndTime = DateTime.UtcNow.Add(TimeSpan.FromDays(300)),
    // };
    //
    // #endregion
    // public static readonly List<UpcomingShow> Shows = [show1, show2, show3];
    //
    // #region Arrangements
    //
    // private static readonly Arrangement arrangement1 = new()
    // {
    //     Id = Guid.NewGuid(),
    //     Name = "SmallPopcorn",
    //     Description = "Small popcorn",
    //     Price = 4.0
    // };
    //
    // private static readonly Arrangement arrangement2 = new()
    // {
    //     Id = Guid.NewGuid(),
    //     Name = "BigPopcorn",
    //     Description = "Big popcorn",
    //     Price = 6.0
    // };
    //
    // private static readonly Arrangement arrangement3 = new()
    // {
    //     Id = Guid.NewGuid(),
    //     Name = "PopcornArrangement",
    //     Description = "Popcorn arrangement",
    //     Price = 10.0
    // };
    //
    // private static readonly Arrangement arrangement4 = new()
    // {
    //     Id = Guid.NewGuid(),
    //     Name = "Vip",
    //     Description = "Vip arrangement",
    //     Price = 400.0
    // };
    //
    // private static readonly Arrangement arrangement5 = new()
    // {
    //     Id = Guid.NewGuid(),
    //     Name = "ChildrenParty",
    //     Description = "Children party",
    //     Price = 40.0
    // };
    //
    // #endregion
    // public static readonly List<Arrangement> Arrangements = [arrangement1, arrangement2, arrangement3, arrangement4, arrangement5];
    //
    // #region FoundItems
    //
    // private static readonly FoundItem FoundItem1 = new()
    // {
    //     Id = Guid.NewGuid(),
    //     Name = "Green bag",
    //     Location = "Room 2; Second row",
    //     CreatedAt = new DateTime(2023, 7, 18, 18, 45, 0)
    // };
    //
    // private static readonly FoundItem FoundItem2 = new()
    // {
    //     Id = Guid.NewGuid(),
    //     Name = "JBL black headphone",
    //     Location = "Left side of room 2 cashier",
    //     CreatedAt = new DateTime(2024, 1, 25, 15, 30, 0)
    // };
    //
    // private static readonly FoundItem FoundItem3 = new()
    // {
    //     Id = Guid.NewGuid(),
    //     Name = "Airpods",
    //     Location = "Room 1; Last row; Between seat 3 and 4",
    //     CreatedAt = new DateTime(2024, 1, 20, 0, 30, 0)
    // };
    //
    // #endregion
    // public static readonly List<FoundItem> FoundItems = [FoundItem1, FoundItem2, FoundItem3];
}
