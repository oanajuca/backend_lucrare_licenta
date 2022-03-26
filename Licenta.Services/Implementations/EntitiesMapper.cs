using Licenta.Interfaces;
using Licenta.Models;
using Licenta.Models.Dto;
using Licenta.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Licenta.Services.Implementations
{
    public class EntitiesMapper : IMapper
    {
        public UserEntity Convert(User usersDao)
        {
            var user = new UserEntity
            {
                Id = usersDao.Id,
                FirstName = usersDao.FirstName,
                LastName = usersDao.LastName,
                Email = usersDao.Email,
                Username = usersDao.Username,
                Role = usersDao.Role
            };

            return user;
        }
        public IEnumerable<UserEntity> Convert(IEnumerable<User> usersDao)
        {
            var users = new List<UserEntity>();

            foreach (var item in usersDao)
            {
                users.Add(Convert(item));
            }
            return users;
        }
        
        public IEnumerable<TrailsEntity> Convert(IEnumerable<Trail> trailDao)
        {
            {
                var trails = new List<TrailsEntity>();

                foreach (var item in trailDao)
                {
                    trails.Add(Convert(item));
                }

                return trails;
            }

        }
        public TrailsEntity Convert(Trail trailDao)
        {
            var trail = new TrailsEntity
            {
                Id = trailDao.Id,
                Name = trailDao.Name,
                ShortDescription = trailDao.ShortDescription,
                Location = trailDao.Location,
               Distance = trailDao.Distance,
                Time = trailDao.Time,
                Mark = trailDao.Mark
            };

            return trail;
        }

        public IEnumerable<DifficultyEntity> Convert(IEnumerable<Difficulty> difficultyDao)
        {
            {
                var difficulties = new List<DifficultyEntity>();

                foreach (var item in difficultyDao)
                {
                    difficulties.Add(Convert(item));
                }

                return difficulties;
            }
        }

        public DifficultyEntity Convert(Difficulty difficultyDao)
        {
            var difficulty = new DifficultyEntity
            {
                Id = difficultyDao.Id,
                Description = difficultyDao.Description,
              
            };

            return difficulty;
        }

        public IEnumerable<DescriptionEntity> Convert(IEnumerable<Description> descriptionDao)
        {
            {
                var descriptions = new List<DescriptionEntity>();

                foreach (var item in descriptionDao)
                {
                    descriptions.Add(Convert(item));
                }

                return descriptions;
            }
        }

        public DescriptionEntity Convert(Description descriptionDao)
        {
            var description = new DescriptionEntity
            {
                Id = descriptionDao.Id,
                ShortDescription = descriptionDao.ShortDescription,
                Steps = descriptionDao.Steps,
                Indications = descriptionDao.Indications,
                Equipment = descriptionDao.Equipment,   
                Observations = descriptionDao.Observations,
                TrailId = descriptionDao.TrailId,
            };

            return description;
        }

        public IEnumerable<ReviewEntity> Convert(IEnumerable<Review> reviewDao)
        {
            {
                var reviews = new List<ReviewEntity>();

                foreach (var item in reviewDao)
                {
                    reviews.Add(Convert(item));
                }

                return reviews;
            }
        }

        public ReviewEntity Convert(Review reviewDao)
        {
            var review = new ReviewEntity
            {
                Id = reviewDao.Id,
                Stars = reviewDao.Stars,
                Comment = reviewDao.Comment,
                UserId = reviewDao.UserId,
                
            };

            return review;
        }
    }
}