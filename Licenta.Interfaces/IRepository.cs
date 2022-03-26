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
        UserEntity GetUser(string username, string password);
        TrailsEntity GetTrail(int id);
        DescriptionEntity GetDescription(int id);
        List<DifficultyEntity> GetTrailDifficulty(int difficultyId);
        List<DescriptionEntity> GetTrailDescription(int descriptionId);
        List<ReviewEntity> GetTrailReview(int trailId);
        List<ReviewEntity> GetUserReview(int reviewId);
        MessageDto CreateUser(string firstname,string lastname,string username, string email, string role, string password);
        //MessageDto InsertReview(string review);
        // List<ReviewEntity> GetReviewUser(int userId);
        // UserEntity GetUserRev(int id);
    }
}

