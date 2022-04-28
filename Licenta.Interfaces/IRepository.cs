using Licenta.Models.Dto;
using Licenta.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Licenta.Interfaces
{
    public interface IRepository
    {
        IEnumerable<TrailsEntity> GetTrail();
        IEnumerable<DescriptionEntity> GetDescription();
        IEnumerable<DifficultyEntity> GetDifficulty();
        IEnumerable<ReviewEntity> GetReview();
        IEnumerable<UserEntity> GetUserRev();
        IEnumerable<TouristGuideEntity> GetGuide();
        UserEntity GetUser(string username, string password);
        UserDto GetUserObject(string username, string password);
        void UpdateUserPassword(UserDto user);
        TrailsEntity GetTrail(int id);
        DescriptionEntity GetDescription(int id);
        List<DifficultyEntity> GetTrailDifficulty(int difficultyId);
        List<DescriptionEntity> GetTrailDescription(int descriptionId);
        List<ReviewEntity> GetTrailReview(int trailId);
        List<ReviewEntity> GetUserReview(int reviewId);
        List<TouristGuideEntity> GetTrailTouristGuide(int trailId);
        MessageDto CreateUser(string firstname,string lastname,string username, string email, string role, string password);
      
         List<ReviewEntity> GetReviewUser(int userId);
        UserEntity GetUserRev(int id);
        MessageDto SaveOverview(int trailId, TrailOverviewModel trailOverviewEntity);
        MessageDto SaveTouristGuide(int trailId, TrailTouristGuideModel trailTouristGuideEntity);
        MessageDto CreateReview(string comment, int stars, int userid, int trailid);
        MessageDto DeleteReview(int id);
    }
}

