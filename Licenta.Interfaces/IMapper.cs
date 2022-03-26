using System.Collections.Generic;
using Licenta.Models;
using Licenta.Models.Entities;
using System.Collections;

namespace Licenta.Interfaces
{
    public interface IMapper
    {

        IEnumerable<TrailsEntity> Convert(IEnumerable<Trail> trailsDao);
        TrailsEntity Convert(Trail trail);
        IEnumerable<DifficultyEntity> Convert(IEnumerable<Difficulty> difficultyDao);
        DifficultyEntity Convert(Difficulty difficulty);
        IEnumerable<DescriptionEntity> Convert(IEnumerable<Description> descriptionDao);
        DescriptionEntity Convert(Description description);
        IEnumerable<ReviewEntity> Convert(IEnumerable<Review> reviewDao);
        ReviewEntity Convert(Review review);
        IEnumerable<UserEntity> Convert(IEnumerable<User> usersDao);
        UserEntity Convert(Licenta.Models.User userDao);

    }
}
