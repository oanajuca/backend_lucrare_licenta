  
using Licenta.Interfaces;
using Licenta.Models;
using Licenta.Infrastructure.Wrappers;
using Licenta.Models.Entities;
using Licenta.Models.Dto;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;

namespace Licenta.Services.Implementations
{
    public class DatabaseRepository : IRepository
    {
        private readonly IMapper _mapper;
        private ILogger _logger;

        public DatabaseRepository(IMapper mapper, ILogger logger)
        {
            _mapper = mapper;
            _logger = logger;
        }
        public IEnumerable<TrailsEntity> GetTrail()
        {
            using (var licentaDataEntities = new licenta())
            {
                var trailsDao = licentaDataEntities.Trails;

                var trails = _mapper.Convert(trailsDao);

                return trails;
            }
        }
        public IEnumerable<DescriptionEntity> GetDescription()
        {
            using (var licentaDataEntities = new licenta())
            {
                var descriptionDao = licentaDataEntities.Descriptions;

                var description = _mapper.Convert(descriptionDao);

                return description;
            }
        }
        public IEnumerable<DifficultyEntity> GetDifficulty()
        {
            using (var licentaDataEntities = new licenta())
            {
                var difficultyDao = licentaDataEntities.Difficulties;

                var difficulty = _mapper.Convert(difficultyDao);

                return difficulty;
            }
        }
        public IEnumerable<ReviewEntity> GetReview()
        {
            using (var licentaDataEntities = new licenta())
            {
                var reviewDao = licentaDataEntities.Reviews;

                var review = _mapper.Convert(reviewDao);

                return review;
            }
        }
        public IEnumerable<TouristGuideEntity> GetGuide()
        {
            using (var licentaDataEntities = new licenta())
            {
                var guideDao = licentaDataEntities.TouristGuides;

                var guide = _mapper.Convert(guideDao);

                return guide;
            }
        }
        public IEnumerable<UserEntity> GetUserRev()
        {
            using (var licentaDataEntities = new licenta())
            {
                var usrRevDao = licentaDataEntities.Users;

                var usrRev = _mapper.Convert(usrRevDao);

                return usrRev;
            }
        }
        public TrailsEntity GetTrail(int id)
        {
            using (var licentaDataEntities = new licenta())
            {
                var trailDao = licentaDataEntities.Trails.Where(a => a.Id == id).FirstOrDefault();

                if (trailDao != null)
                {
                    var trail = _mapper.Convert(trailDao);
                    return trail;
                }
                else
                {
                    _logger.Error("Trail ID specified does not exist. Id:  " + id);
                }
                return null;
            }
        }
        public UserEntity GetUserRev(int id)
        {
            using (var licentaDataEntities = new licenta())
            {
                var userRevDao = licentaDataEntities.Users.Where(a => a.Id == id).FirstOrDefault();

                if (userRevDao != null)
                {
                    var userRev = _mapper.Convert(userRevDao);
                    return userRev;
                }
                else
                {
                    _logger.Error("User ID specified does not exist. Id:  " + id);
                }
                return null;
            }
        }
        public DescriptionEntity GetDescription(int id)
        {
            using (var licentaDataEntities = new licenta())
            {
                var descriptionDao = licentaDataEntities.Descriptions.Where(a => a.Id == id).FirstOrDefault();

                if (descriptionDao != null)
                {
                    var description = _mapper.Convert(descriptionDao);
                    return description;
                }
                else
                {
                    _logger.Error("Description ID specified does not exist. Id:  " + id);
                }
                return null;
            }
        }
        public List<DescriptionEntity> GetTrailDescription(int descriptionId)
        {
            using (var licentaDataEntities = new licenta())
            {
                var desc = licentaDataEntities.Descriptions
                    .Join(licentaDataEntities.Trails, u => u.TrailId, t => t.Id, (u, t) => new { u, t })
                    .Where(a => a.u.TrailId == descriptionId)
                    .Select(a => new DescriptionEntity
                    {
                        Id = a.u.TrailId,
                        ShortDescription = a.u.ShortDescription,
                        Steps = a.u.Steps,
                        Indications = a.u.Indications,
                        Equipment = a.u.Equipment,
                        Observations = a.u.Observations,
                        TrailId = a.u.TrailId,

                    }).ToList();

                return desc;
            }
        }
        public List<ReviewEntity> GetUserReview(int reviewId)
        {
            using (var licentaDataEntities = new licenta())
            {
                var revi = licentaDataEntities.Reviews
                    .Join(licentaDataEntities.Users, p => p.UserId, pr => pr.Id, (p, pr) => new { p, pr })
                    .Where(a => a.p.UserId == reviewId)
                    .Select(a => new ReviewEntity
                    {
                        Id = a.p.UserId,
                        Comment = a.p.Comment,
                        Stars = a.p.Stars,
                        UserId = a.p.UserId,
                    }).ToList();

                return revi;
            }
        }

        public List<DifficultyEntity> GetTrailDifficulty(int trailId)
        {
            var difficulty = new List<DifficultyEntity>();

            using (var licentaDataEntities = new licenta())
            {
                var diff = licentaDataEntities.TrailDifficulties
                    .Join(licentaDataEntities.Difficulties, u => u.DifficultyId, t => t.Id, (u, t) => new { u, t })
                    .Join(licentaDataEntities.Trails, ct => ct.u.TrailId, c => c.Id, (ct, c) => new { ct, c })
                    .Where(a => a.ct.u.TrailId == trailId)
                    .Select(a => new DifficultyEntity
                    {
                        Id = a.ct.u.Difficulty.Id,
                        Description = a.ct.u.Difficulty.Description,

                    }).ToList();

                return diff;
            }
        }
        public List<TouristGuideEntity> GetTrailTouristGuide(int trailId)
        {
            var guides = new List<TouristGuideEntity>();

            using (var licentaDataEntities = new licenta())
            {
                var diff = licentaDataEntities.TouristGuideTrails
                    .Join(licentaDataEntities.TouristGuides, u => u.TouristGuideId, t => t.Id, (u, t) => new { u, t })
                    .Join(licentaDataEntities.Trails, ct => ct.u.TrailId, c => c.Id, (ct, c) => new { ct, c })
                    .Where(a => a.ct.u.TrailId == trailId)
                    .Select(a => new TouristGuideEntity
                    {
                        Id = a.ct.u.TouristGuideId,
                        Camping = a.ct.u.TouristGuide.Camping,
                        Deviation = a.ct.u.TouristGuide.Deviation,
                        Environment = a.ct.u.TouristGuide.Environment,
                        Discover = a.ct.u.TouristGuide.Discover,
                        Fire = a.ct.u.TouristGuide.Fire,
                        Garbage = a.ct.u.TouristGuide.Garbage,
                        Noise = a.ct.u.TouristGuide.Noise,
                        Promote = a.ct.u.TouristGuide.Promote,
                        Rules = a.ct.u.TouristGuide.Rules,
                    }).ToList();

                return diff;
            }
        }
        public List<ReviewEntity> GetTrailReview(int trailId)
        {
            var revie = new List<ReviewEntity>();

            using (var licentaDataEntities = new licenta())
            {
                var rev = licentaDataEntities.Reviews
                    .Join(licentaDataEntities.Trails, u => u.TrailId, t => t.Id, (u, t) => new { u, t })
                   // .Join(licentaDataEntities.Trails, ct => ct.u.TrailId, c => c.Id, (ct, c) => new { ct, c })
                    .Where(a => a.u.TrailId == trailId)
                    .Select(a => new ReviewEntity
                    {
                       Id= a.u.Id,
                       Comment=a.u.Comment,
                       Stars = a.u.Stars,
                       UserId = a.u.UserId,
                       TrailId = a.u.TrailId,

                    }).ToList();

                return rev;
            }
        }
        public List<ReviewEntity> GetReviewUser(int reviewId)
        {

            using (var licentaDataEntities = new licenta())
            {
                var urew = licentaDataEntities.Reviews
                    .Join(licentaDataEntities.Users, u => u.UserId, t => t.Id, (u, t) => new { u, t })
                    .Where(a => a.u.UserId == reviewId)
                    .Select(a => new ReviewEntity
                    {
                        Id = a.u.UserId,
                        Stars = a.u.Stars,
                        Comment = a.u.Comment,
                        UserId = a.u.UserId,
                    }).ToList();

                return urew;
            }
        }
        public UserEntity GetUser(string username, string password)
        {
            using (var licentaDataEntities = new licenta())
            {
                var userDto = licentaDataEntities.Users.Where(a => a.Username == username).FirstOrDefault();

                if (userDto != null)
                {
                    if (Licenta.Services.Implementations.Cryptography.Decrypt(userDto.Password) == password)
                    {
                        var user = _mapper.Convert(userDto);
                        return user;
                    }
                    else
                    {
                        _logger.Error("Invalid password for user " + userDto.Username);
                    }
                }

                return null;
            }
        }

        public IEnumerable<UserEntity> GetUsers()
        {
            using (var licentaDataEntities = new licenta())
            {
                var usersDao = licentaDataEntities.Users;

                var users = _mapper.Convert(usersDao);

                return users;
            }

        }
        public MessageDto CreateUser(string firstname, string lastname, string username, string email, string role, string password)
        {
            try
            {
                var existingUsers = GetUsers();
                if (!existingUsers.Any(a => a.Username == username))
                {
                    using (var licentaDataEntities = new licenta())
                    {
                        var userDao = new User
                        {
                            FirstName = firstname,
                            LastName = lastname,
                            Username = username,
                            Email = email,
                            Role = role,
                            Password = Cryptography.Encrypt(password)
                        };

                        licentaDataEntities.Users.Add(userDao);
                        licentaDataEntities.SaveChanges();
                    }

                    return new MessageDto { Category = Infrastructure.Wrappers.Constants.Info, Description = "User created successfully." };
                }
                else
                {
                    return new MessageDto { Category = Infrastructure.Wrappers.Constants.Warn, Description = "User with username: " + username + " already exists in DB." };
                }
            }
            catch (DbEntityValidationException ex)
            {
                HandleDbEntityValiddationException("CreateUser", ex);
                return new MessageDto { Category = Infrastructure.Wrappers.Constants.Error, Description = ex.ToString() };
            }
            catch (Exception ex)
            {
                _logger.Error("CreateUser failed in DatabaseRepository.cs. Error: ", ex);
                return new MessageDto { Category = Infrastructure.Wrappers.Constants.Error, Description = ex.ToString() };
            }
        }
        public UserDto GetUserObject(string username, string password)
        {
            using (var licentaDataEntities = new licenta())
            {
                var userDto = licentaDataEntities.Users.Where(a => a.Username == username).FirstOrDefault();

                if (userDto != null)
                {
                    var user = _mapper.ConvertToDto(userDto);
                    user.Password = Cryptography.Decrypt(userDto.Password);

                    return user;
                }

                return null;
            }
        }
        public void UpdateUserPassword(UserDto user)
        {
            using (var licentaDataEntities = new licenta())
            {
                var userDao = licentaDataEntities.Users.FirstOrDefault(a => a.Username == user.Username);

                userDao.Password = Cryptography.Encrypt(user.Password);

                licentaDataEntities.SaveChanges();
            }
        }
        /* public MessageDto InsertReview(string id, string stars, string comment)
         {
             try
             {
                 using (var licentaDataEntities = new licenta())
                 {
                         var rev = new Review
                         {
                           Id = 
                         };
                         licentaDataEntities.Reviews.Add(rev);
                         licentaDataEntities.SaveChanges();
                         return new MessageDto { Category = Infrastructure.Wrappers.Constants.Info, Description = "Review inserted successfully." };
                 }
             }
             catch (DbEntityValidationException ex)
             {
                 HandleDbEntityValiddationException("InsertReview", ex);
                 return new MessageDto { Category = Infrastructure.Wrappers.Constants.Error, Description = ex.ToString() };
             }
             catch (Exception ex)
             {
                 _logger.Error("InsertReview failed in DatabaseRepository.cs. Error: ", ex);
                 return new MessageDto { Category = Infrastructure.Wrappers.Constants.Error, Description = ex.ToString() };
             }
         } */

        private void HandleDbEntityValiddationException(string methodOfOcuring, DbEntityValidationException ex)
        {
            StringBuilder sb = new StringBuilder($"{methodOfOcuring} failed in DbEntityValidationException");

            foreach (var eve in ex.EntityValidationErrors)
            {
                sb.Append($"\nEntity of type [{eve.Entry.Entity.GetType().Name}] in state [{eve.Entry.State}] has the following validation errors:");
                foreach (var ve in eve.ValidationErrors)
                {
                    sb.Append($"\n- Property: [{ve.PropertyName}], Error: [{ve.ErrorMessage}]");
                }
            }

            //_logger.Error(sb.ToString(), ex);
        }

        public MessageDto SaveOverview(int trailId, TrailOverviewModel trailOverviewEntity)
        {
            try
            {
                using (var licentaDataEntities = new licenta())
                {
                    var trailDao = licentaDataEntities.Trails.Where(a => a.Id == trailId).FirstOrDefault();

                    if (trailDao != null)
                    {
                        foreach (var descrip in trailOverviewEntity.Descriptions)
                        {
                            var existingOverview = licentaDataEntities.Descriptions.Where(a => a.Id == descrip.Id).FirstOrDefault();


                            if (existingOverview == null)
                            {
                                var newOverview = new Description
                                {
                                    ShortDescription = descrip.ShortDescription,
                                    Steps = descrip.Steps,
                                    Equipment = descrip.Equipment,
                                    Indications = descrip.Indications,
                                    Observations = descrip.Observations,
                                    TrailId = descrip.TrailId,

                                };

                                licentaDataEntities.Descriptions.Add(newOverview);
                                licentaDataEntities.SaveChanges();
                            }
                            else if (existingOverview != null)
                            {
                                existingOverview.ShortDescription = descrip.ShortDescription;
                                existingOverview.Steps = descrip.Steps;
                                existingOverview.Equipment = descrip.Equipment;
                                existingOverview.Indications = descrip.Indications;
                                existingOverview.Observations = descrip.Observations;
                                existingOverview.TrailId = descrip.TrailId;


                                licentaDataEntities.SaveChanges();
                            }
                        }

                        return new MessageDto { Category = Constants.Info, Description = "Details for trail: " + trailId + " were updated." };
                    }
                    else
                    {
                        return new MessageDto { Category = Constants.Warn, Description = "Trail ID specified does not exist. Id: " + trailId };
                    }
                }
            }
            catch (DbEntityValidationException ex)
            {
                HandleDbEntityValiddationException("SaveOverview", ex);
                return new MessageDto { Category = Constants.Error, Description = ex.ToString() };
            }
            catch (Exception ex)
            {
                _logger.Error("SaveOverview failed in DatabaseRepository.cs. Error: ", ex);
                return new MessageDto { Category = Constants.Error, Description = ex.ToString() };
            }
        }
        public MessageDto SaveTouristGuide(int trailId, TrailTouristGuideModel trailTouristGuideEntity)
        {
            try
            {
                using (var licentaDataEntities = new licenta())
                {
                    var trailDao = licentaDataEntities.Trails.Where(a => a.Id == trailId).FirstOrDefault();

                    if (trailDao != null)
                    {
                        foreach (var guide in trailTouristGuideEntity.TouristGuides)
                        {
                            var existingGuide = licentaDataEntities.TouristGuides.Where(a => a.Id == guide.Id).FirstOrDefault();


                            if (existingGuide == null)
                            {
                                var newGuide = new TouristGuide
                                {
                                    Deviation = guide.Deviation,
                                    Camping = guide.Camping,
                                    Discover = guide.Discover,
                                    Environment = guide.Environment,
                                    Fire = guide.Fire,
                                    Garbage = guide.Garbage,
                                    Noise = guide.Noise,
                                    Promote = guide.Promote,
                                    Rules = guide.Rules,


                                };

                                licentaDataEntities.TouristGuides.Add(newGuide);
                                licentaDataEntities.SaveChanges();
                            }
                            else if (existingGuide != null)
                            {
                                existingGuide.Deviation = guide.Deviation;
                                existingGuide.Camping = guide.Camping;
                                existingGuide.Discover = guide.Discover;
                                existingGuide.Environment = guide.Environment;
                                existingGuide.Fire = guide.Fire;
                                existingGuide.Garbage = guide.Garbage;
                                existingGuide.Noise = guide.Noise;
                                existingGuide.Promote = guide.Promote;
                                existingGuide.Rules = guide.Rules;


                                licentaDataEntities.SaveChanges();
                            }
                        }

                        return new MessageDto { Category = Constants.Info, Description = "Guides for trail: " + trailId + " were updated." };
                    }
                    else
                    {
                        return new MessageDto { Category = Constants.Warn, Description = "Trail ID specified does not exist. Id: " + trailId };
                    }
                }
            }
            catch (DbEntityValidationException ex)
            {
                HandleDbEntityValiddationException("SaveTouristGuide", ex);
                return new MessageDto { Category = Constants.Error, Description = ex.ToString() };
            }
            catch (Exception ex)
            {
                _logger.Error("SaveTouristGuide failed in DatabaseRepository.cs. Error: ", ex);
                return new MessageDto { Category = Constants.Error, Description = ex.ToString() };
            }
        }
        public MessageDto CreateReview(string comment, int stars, int userid,int trailid)
        {
            try
            {
                var existingReviews = GetReview();
                if (!existingReviews.Any(a => a.Comment == comment))
                {
                    using (var licentaDataEntities = new licenta())
                    {
                        var reviewDao = new Review
                        {
                           Comment = comment,
                           Stars = stars,
                           UserId = userid,
                           TrailId = trailid
                        };

                        licentaDataEntities.Reviews.Add(reviewDao);
                        licentaDataEntities.SaveChanges();
                    }

                    return new MessageDto { Category = Infrastructure.Wrappers.Constants.Info, Description = "Review added successfully." };
                }
                else
                {
                    return new MessageDto { Category = Infrastructure.Wrappers.Constants.Warn, Description = "Review with comment: " + comment + " already exists in DB." };
                }
            }
            catch (DbEntityValidationException ex)
            {
                HandleDbEntityValiddationException("CreateReview", ex);
                return new MessageDto { Category = Infrastructure.Wrappers.Constants.Error, Description = ex.ToString() };
            }
            catch (Exception ex)
            {
                _logger.Error("CreateReview failed in DatabaseRepository.cs. Error: ", ex);
                return new MessageDto { Category = Infrastructure.Wrappers.Constants.Error, Description = ex.ToString() };
            }
        }

    }

}

